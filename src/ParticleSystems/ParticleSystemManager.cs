using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.Common.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ICannotDie.Plugins.ParticleSystems
{
    public class ParticleSystemManager : MonoBehaviour
    {
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

            if (ParticleSystemAtoms.Any())
            {
                if (_particleEditor?.containingAtom?.GetComponentInChildren<ParticleSystem>())
                {
                    SetCurrentAtom(ParticleSystemAtoms.FirstOrDefault(atom => atom.uid == _particleEditor.containingAtom.uid));
                }
                else
                {
                    SetCurrentAtom(ParticleSystemAtoms.FirstOrDefault());
                }
            }

            RegisterEventHandlers();
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
            }
            else
            {
                CurrentAtom = null;
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

            // Load a ParticleEditor plugin on the atom
            //CreateAndLoadPlugin(atom);

            // Add the particle system to the atom
            AddParticleSystemToAtom(atom);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(atom);

            _particleEditor.UIManager.BuildUI();

            Utility.LogMessage("Created Atom");
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
            if (atom.type != Constants.EmptyAtomTypeName)
            {
                throw new ArgumentException(nameof(atom));
            }

            // Gets the Empty atom's rescaleObject
            var rescaleObject = atom.transform.GetChildByName(Constants.RescaleObjectName);

            if (rescaleObject != null)
            {
                // Add a ParticleSystem to the rescaleObject
                ParticleSystemAtoms.Add(atom);
                rescaleObject.transform.gameObject.AddComponent<ParticleSystem>();
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
            Utility.LogMessage(nameof(RemoveAndRebuild), "UID:", atom.uid);

            // Choose a new atom to be set as current, or set null
            // Do this before we change the list to ensure we select correctly
            Atom nextAtom = null;

            if (atom == _particleEditor.ParticleSystemManager.CurrentAtom)
            {
                nextAtom = ParticleSystemAtoms.GetAtomBefore(atom);
            }
            else
            {
                nextAtom = _particleEditor.ParticleSystemManager.CurrentAtom;
            }

            Utility.LogMessage(nameof(RemoveAndRebuild), "next atom UID:", nextAtom.uid);

            // Remove the atom from the local list
            ParticleSystemAtoms.Remove(atom);

            SuperController.singleton.StartCoroutine(WaitUntilEndOfFrameCoroutine(nextAtom));

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

            ParticleSystemAtoms.Clear();

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
                    ParticleSystemAtoms.Add(atom);
                }
            }

            ParticleSystemAtoms = ParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).ToList();
        }

    }
}