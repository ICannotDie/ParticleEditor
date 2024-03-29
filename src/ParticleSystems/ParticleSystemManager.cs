using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.Common.Extensions;
using ICannotDie.Plugins.UI.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ICannotDie.Plugins.ParticleSystems
{
    public class ParticleSystemManager : MonoBehaviour
    {
        JSONStorableString CurrentAtomUid;

        public bool HasCurrentAtom => CurrentAtom != null;
        public Atom CurrentAtom { get; private set; }
        public ParticleSystem CurrentParticleSystem => CurrentAtom != null ? CurrentAtom.GetComponentInChildren<ParticleSystem>() : null;
        public ParticleSystemRenderer CurrentParticleSystemRenderer => CurrentParticleSystem != null ? CurrentParticleSystem.GetComponent<ParticleSystemRenderer>() : null;
        public List<Atom> ParticleSystemAtoms { get; private set; } = new List<Atom>();
        public List<string> ParticleSystemUids => ParticleSystemAtoms.Any() ? ParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).Select(atom => atom.uid).ToList() : new List<string>();

        private ParticleEditor _particleEditor;

        public ParticleSystemManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public void Initialise()
        {
            FindParticleSystems();

            var atomToSetAsCurrent = GetAtomToSetAsCurrent();

            // Register storables
            CurrentAtomUid = new JSONStorableString("CurrentAtomUid", null);
            _particleEditor.RegisterString(CurrentAtomUid);

            SetCurrentAtom(atomToSetAsCurrent);

            // If we have a current atom set, but it has no particle systems, add one to it.
            // Only dot this if our current atom is also our containing atom
            if (CurrentAtom && !CurrentParticleSystem && CurrentAtom.uid == _particleEditor.containingAtom.uid)
            {
                AddParticleSystemToAtom(CurrentAtom);
            }

            RegisterEventHandlers();
        }

        public Atom GetAtomToSetAsCurrent()
        {
            var containingAtom = (Atom)null;

            if (_particleEditor && _particleEditor.containingAtom)
            {
                containingAtom = _particleEditor.containingAtom;
            }

            if (ParticleSystemAtoms.Any())
            {
                // Try to set to our stored current atom
                if (CurrentAtomUid != null && CurrentAtomUid.val != null)
                {
                    // We had a current atom set, try and find it
                    var storedCurrentAtom = _particleEditor.GetAtomById(CurrentAtomUid.val);
                    if (storedCurrentAtom != null)
                    {
                        // Is it in the list of ParticleSystem atoms?
                        if (ParticleSystemAtoms.Any(x => x.uid == storedCurrentAtom.uid))
                        {
                            return storedCurrentAtom;
                        }
                    }
                }

                // Try to set to our containing atom if it has a particle system
                if (_particleEditor?.containingAtom?.GetComponentInChildren<ParticleSystem>())
                {
                    // If our containing atom has a particle system component, set that as our current atom
                    return ParticleSystemAtoms.DefaultIfEmpty<Atom>(null).FirstOrDefault(atom => atom.uid == _particleEditor.containingAtom.uid);
                }
            }

            // If all else fails, set our own atom as our current atom
            return containingAtom;
        }

        public void RegisterEventHandlers()
        {
            SuperController.singleton.onAtomRemovedHandlers += OnAtomRemoved;
        }

        public void DeregisterEventHandlers()
        {
            SuperController.singleton.onAtomRemovedHandlers -= OnAtomRemoved;
        }

        public void OnDestroy()
        {
            DeregisterEventHandlers();

            foreach (var atom in ParticleSystemAtoms)
            {
                _particleEditor.StartCoroutine(RemoveAtomCoroutine(atom.uid));
            }
        }

        private void OnAtomRemoved(Atom atom)
        {
            Utility.LogMessage(nameof(OnAtomRemoved), "UID:", atom.uid);
            if (ParticleSystemAtoms.Any() && ParticleSystemAtoms.Contains(atom))
            {
                Utility.LogMessage(nameof(OnAtomRemoved), "UID:", atom.uid, "is in", nameof(ParticleSystemAtoms), ". Removing.");
                RemoveAndRebuild(atom);
            }
        }

        public void SetCurrentAtom(string uid) => SetCurrentAtom(SuperController.singleton.GetAtomByUid(uid));

        public void SetCurrentAtom(Atom atom)
        {
            if (atom != null)
            {
                CurrentAtom = atom;
                CurrentAtomUid.SetVal(atom.uid);
            }
            else
            {
                CurrentAtom = null;
                CurrentAtomUid.SetVal(null);
            }
        }

        public IEnumerator CreateAtomCoroutine()
        {
            // Get a new UID for the atom
            var nextUID = Utility.GetNextAtomUID(Constants.RootObjectName, ParticleSystemAtoms.Select(x => x.uid).ToList());

            // Add an atom by type (always an Empty)
            var atomEnumerator = SuperController.singleton.AddAtomByType(Constants.EmptyAtomTypeName, nextUID, true);

            // Yield the enumerator
            while (atomEnumerator.MoveNext())
            {
                yield return atomEnumerator.Current;
            }

            // Find the atom by uid to check it was added
            var atom = SuperController.singleton.GetAtomByUid(nextUID);

            if (atom == null)
            {
                throw new NullReferenceException("Atom did not spawn");
            }

            // If CreatePluginOnAdd is enabled, load a ParticleEditor plugin on the atom we create
            IEditor value;
            var editor = _particleEditor.UIManager.Editors.TryGetValue(typeof(ParticleSystemAtomEditor), out value);
            if (value != null && value as ParticleSystemAtomEditor != null)
            {
                ParticleSystemAtomEditor particleSystemAtomEditor = value as ParticleSystemAtomEditor;
                var createPluginOnAdd = particleSystemAtomEditor.CreatePluginOnAdd;
                if (createPluginOnAdd.val)
                {
                    CreateAndLoadPlugin(atom);
                }
            }

            // Add the particle system to the atom
            AddParticleSystemToAtom(atom);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(atom);
            SetParticleSystemRendererDefaults(CurrentParticleSystemRenderer);

            _particleEditor.UIManager.BuildUI();

            Utility.LogMessage("Created Atom");
        }

        private void SetParticleSystemRendererDefaults(ParticleSystemRenderer currentParticleSystemRenderer)
        {
            CurrentParticleSystemRenderer.material = ParticleSystemRendererEditorDefaults.Material(_particleEditor);
        }

        private void CreateAndLoadPlugin(Atom atom)
        {
            var pluginManager = atom.GetStorableByID(Constants.PluginManagerName) as MVRPluginManager;
            var plugin = pluginManager.CreatePlugin();
            var pluginPath = Utility.GetPluginPath(_particleEditor);

            plugin.pluginURLJSON.val = $"{pluginPath}//{Constants.PluginCSListFilename}";
        }

        private void AddParticleSystemToAtom(Atom atom)
        {
            //if (atom.type != Constants.EmptyAtomTypeName)
            //{
            //    throw new ArgumentException(nameof(atom));
            //}

            // Gets the Empty atom's rescaleObject
            var rescaleObject = atom.transform.GetChildByName(Constants.RescaleObjectName);

            if (rescaleObject != null)
            {
                // Add a ParticleSystem to the rescaleObject
                ParticleSystemAtoms.Add(atom);

                ParticleSystem particleSystem = rescaleObject.transform.gameObject.AddComponent<ParticleSystem>() as ParticleSystem;

                Defer.UntilNextFrame(() =>
                {
                    if (particleSystem)
                    {
                        Utility.LogMessage(nameof(ParticleSystemManager), nameof(AddParticleSystemToAtom), "particleSystem found");

                        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>() as ParticleSystemRenderer;

                        if (renderer)
                        {
                            Utility.LogMessage(nameof(ParticleSystemManager), nameof(AddParticleSystemToAtom), "renderer found");

                            // Set the default material of the renderer
                            renderer.material = ParticleSystemRendererEditorDefaults.Material(_particleEditor);

                            Utility.LogMessage(nameof(ParticleSystemManager), nameof(AddParticleSystemToAtom), "renderer default material set");
                        }
                    }
                });
            }
        }

        public IEnumerator RemoveAtomCoroutine(string uid)
        {
            // Get atom to remove by uid
            var _atomToRemove = SuperController.singleton.GetAtomByUid(uid);

            // Remove the atom
            SuperController.singleton.RemoveAtom(_atomToRemove);

            // Yield now so the atom gets removed before we continue 
            yield return new WaitForEndOfFrame();

            // Get the atom by uid again, to confirm it was removed
            var atom = SuperController.singleton.GetAtomByUid(uid);

            if (atom != null)
            {
                throw new NullReferenceException("Atom was not removed");
            }

            RemoveAndRebuild(_atomToRemove);
        }

        private void RemoveAndRebuild(Atom atom)
        {
            if (atom == null)
            {
                return;
            }

            if (!_particleEditor && !_particleEditor.ParticleSystemManager)
            {
                return;
            }

            Utility.LogMessage(nameof(RemoveAndRebuild), "UID:", atom.uid);

            // Choose a new atom to be set as current, or set null
            // Do this before we change the list to ensure we select correctly
            Atom currentAtom = _particleEditor.ParticleSystemManager.CurrentAtom;
            Atom nextAtom = null;

            // The atom we're removing is our current atom, we need to find a new current atom
            if (atom == currentAtom)
            {
                Utility.LogMessage(nameof(RemoveAndRebuild), "attempting to remove self UID:", atom.uid, "particle system atoms count:", ParticleSystemAtoms.Count);

                //// If there is another atom in the list, check for which we should pick
                //if (ParticleSystemAtoms.Count > 1 && ParticleSystemAtoms.Contains(atom))
                //{
                //    Utility.LogMessage(nameof(RemoveAndRebuild), "getting next atom in list before UID:", atom.uid);
                //    nextAtom = ParticleSystemAtoms.GetAtomBefore(atom);
                //}

                Utility.LogMessage(nameof(RemoveAndRebuild), "checking if nextAtom is ourselves UID:", atom.uid, "nextAtom: UID", nextAtom.uid);

                // If we now have a nextAtom, check if it's ourselves
                // If it is, set nextAtom to null, we're being removed so we don't want to set to ourselves
                if (nextAtom != null && atom == nextAtom)
                {
                    Utility.LogMessage(nameof(RemoveAndRebuild), "resetting nextAtom to null");
                    // Our current atom is the only one left in the list, set null instead
                    nextAtom = null;
                }
            }
            else
            {
                Utility.LogMessage(nameof(RemoveAndRebuild), "setting nextAtom to currentAtom");
                nextAtom = currentAtom;
            }

            Utility.LogMessage(nameof(RemoveAndRebuild), "next atom UID:", nextAtom.uid);

            // Remove the atom from the local list
            if (ParticleSystemAtoms != null)
            {
                ParticleSystemAtoms.Remove(atom);
            }

            //SuperController.singleton.StartCoroutine(WaitUntilEndOfFrameCoroutine(nextAtom));
            Defer.UntilNextFrame(() =>
            {
                // Find, Set & Build
                FindParticleSystems();
                SetCurrentAtom(nextAtom);

                if (_particleEditor.UIManager) _particleEditor.UIManager.BuildUI();
            });

            Utility.LogMessage(nameof(RemoveAndRebuild), "complete UID:", nextAtom.uid);
        }

        private IEnumerator WaitUntilEndOfFrameCoroutine(Atom nextAtom)
        {
            yield return new WaitForEndOfFrame();
            Utility.LogMessage(nameof(RemoveAndRebuild), " deffered Find, Set & Build for nextAtom UID:", nextAtom.uid);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(nextAtom);
            _particleEditor.UIManager.BuildUI();
        }

        public void FindParticleSystems(bool findAll = false)
        {
            Utility.LogMessage(nameof(FindParticleSystems), " findAll:", findAll);

            if (ParticleSystemAtoms != null && ParticleSystemAtoms.Any()) ParticleSystemAtoms.Clear();

            List<ParticleSystem> foundParticleSystems = new List<ParticleSystem>();

            if (findAll == false)
            {
                // Finds ALL particle systems, even if they're disabled or inside assetbundles
                foundParticleSystems = (Resources.FindObjectsOfTypeAll(typeof(ParticleSystem)) as ParticleSystem[]).ToList();
            }
            else
            {
                // Finds active particle systems, not those that are disabled or inside assetbundles
                foundParticleSystems = FindObjectsOfType<ParticleSystem>().ToList(); // _particleEditor.FindParticleSystems();
            }

            Utility.LogMessage(nameof(FindParticleSystems), " foundParticleSystems:", foundParticleSystems.Count);

            foreach (var particleSystem in foundParticleSystems)
            {
                var atom = particleSystem.GetComponentInParent<Atom>();

                var allowedAtomTypes = new List<string>() { "Empty", "CustomUnityAsset" };

                if (atom != null && allowedAtomTypes.Contains(atom.type))
                {
                    if (ParticleSystemAtoms != null && ParticleSystemAtoms.Any()) ParticleSystemAtoms.Add(atom);
                }
            }

            if (ParticleSystemAtoms != null && ParticleSystemAtoms.Any()) ParticleSystemAtoms = ParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).ToList();

            // Check if we have particle systems on our containing atom
            if (_particleEditor && _particleEditor.containingAtom)
            {
                var particleSystems = _particleEditor.containingAtom.GetComponentInChildren<ParticleSystem>();
                if (particleSystems)
                {
                    _particleEditor.HasChildParticleSystem = true;
                }
            }
            else
            {
                _particleEditor.HasChildParticleSystem = false;
            }
        }

    }
}