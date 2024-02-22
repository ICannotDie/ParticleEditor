using UnityEngine;
using MeshVR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICannotDie.Plugins;
using ICannotDie.Plugins.UI;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.Common.Extensions;

namespace ICannotDie.Plugins.ParticleSystems
{
    public class ParticleSystemManager
    {
        public Atom CurrentAtom { get; private set; }
        public ParticleSystem CurrentParticleSystem => CurrentAtom != null ? CurrentAtom.GetComponentInChildren<ParticleSystem>() : null;
        public ParticleSystemRenderer CurrentParticleSystemRenderer => CurrentParticleSystem != null ? CurrentParticleSystem.GetComponent<ParticleSystemRenderer>() : null;
        public List<Atom> ParticleSystemAtoms { get; private set; } = new List<Atom>();
        public List<string> ParticleSystemUids => ParticleSystemAtoms.Any() ? ParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).Select(atom => atom.uid).ToList() : new List<string>();

        private ParticleEditor _particleEditorScript;
        private Atom _atomToRemove;

        public ParticleSystemManager(ParticleEditor particleEditor)
        {
            _particleEditorScript = particleEditor;

            _particleEditorScript.LogForDebug($"Constructed {nameof(ParticleSystemManager)}");
        }

        public void Initialise()
        {
            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Initialising");

            FindParticleSystems();

            if (ParticleSystemAtoms.Any())
            {
                SetCurrentAtom(ParticleSystemAtoms.FirstOrDefault());
            }

            RegisterEventHandlers();

            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Initialised");
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
                _particleEditorScript.StartCoroutine(RemoveAtomCoroutine(atom.uid));
            }
        }

        private void OnAtomRemoved(Atom atom)
        {
            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: OnAtomRemoved invoked for {atom.uid}");

            // We're removing this atom ourselves so we don't need to rebuild again
            if (_atomToRemove != null && _atomToRemove == atom)
            {
                _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: OnAtomRemoved ignored for {atom.uid} as we're removing it ourselves");
                return;
            }

            if (ParticleSystemAtoms.Any() && ParticleSystemAtoms.Contains(atom))
            {
                RemoveAndRebuild(atom);
            }
        }

        public void SetCurrentAtom(string uid) => SetCurrentAtom(SuperController.singleton.GetAtomByUid(uid));

        public void SetCurrentAtom(Atom atom)
        {
            if (atom != null)
            {
                _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Setting Current Atom to {atom.uid}");
                CurrentAtom = atom;
            }
            else
            {
                _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Setting Current Atom to null");
                CurrentAtom = null;
            }
        }

        public IEnumerator CreateAtomCoroutine()
        {
            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Adding Atom");

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

            MVRPluginManager manager = atom.GetStorableByID("PluginManager") as MVRPluginManager;
            var plugin = manager.CreatePlugin();

            var path = GetPluginPath(_particleEditorScript);

            plugin.pluginURLJSON.val = $"{path}//ParticleEditor.cslist";

            // Add the particle system to the atom
            AddParticleSystemToAtom(atom);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(atom);
            SetParticleSystemDefaults(CurrentParticleSystem);
            SetParticleSystemRendererDefaults(CurrentParticleSystemRenderer);

            _particleEditorScript.UiManager.BuildUI();

            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Added Atom: {atom.uid}");
        }

        private void AddParticleSystemToAtom(Atom atom)
        {
            if (atom.type != Constants.EmptyAtomTypeName)
            {
                throw new ArgumentException(nameof(atom));
            }

            // Gets the Empty atom's rescaleObject
            var rescaleObject = Utility.GetChildByName(atom.transform, Constants.RescaleObjectName);

            if (rescaleObject != null)
            {
                // Add a ParticleSystem to the rescaleObject
                ParticleSystemAtoms.Add(atom);
                rescaleObject.transform.gameObject.AddComponent<ParticleSystem>();
            }
        }

        private void SetParticleSystemDefaults(ParticleSystem particleSystem)
        {

        }

        private void SetParticleSystemRendererDefaults(ParticleSystemRenderer particleSystemRenderer)
        {
            var texturePath = $"{GetPackagePath(_particleEditorScript)}{Constants.DefaultShaderTextureFolderPath}/{Constants.DefaultShaderTextureName}";
            particleSystemRenderer.material = GetMaterial(Constants.ShaderName_ParticlesAdditive, texturePath);
        }

        public IEnumerator RemoveAtomCoroutine(string uid, bool forDestroy = false)
        {
            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Removing Atom: {uid}");

            // Get atom to remove by uid
            _atomToRemove = SuperController.singleton.GetAtomByUid(uid);

            // Remove the atom
            SuperController.singleton.RemoveAtom(_atomToRemove);

            // Yield now so the atom gets removed before we continue 
            yield return new WaitForEndOfFrame();

            // Get the atom by uid again, to confirm it was removed
            if (!forDestroy)
            {
                var atom = SuperController.singleton.GetAtomByUid(uid);

                if (atom != null)
                {
                    throw new NullReferenceException("Atom was not removed");
                }
            }

            RemoveAndRebuild(_atomToRemove, forDestroy);
        }

        private void RemoveAndRebuild(Atom atom, bool forDestroy = false)
        {
            // Choose a new atom to be set as current, or set null
            // Do this before we change the list to ensurre we select correctly
            Atom nextAtom = null;

            if (!forDestroy)
            {
                nextAtom = Utility.GetAtomBefore(atom, ParticleSystemAtoms);
            }

            // Remove the atom from the local list
            ParticleSystemAtoms.Remove(atom);

            if (!forDestroy)
            {
                // Find, Set & Build
                FindParticleSystems();
                SetCurrentAtom(nextAtom);

                _particleEditorScript.UiManager.BuildUI();
            }

            // Reset _atomToRemove
            _atomToRemove = null;

            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Removed Atom: {atom.uid}");
        }

        public void FindParticleSystems(bool findAll = false)
        {
            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Finding Particle Systems");

            ParticleSystemAtoms.Clear();

            List<ParticleSystem> foundParticleSystems = new List<ParticleSystem>();

            if (findAll = false)
            {
                // Finds ALL particle systems, even if they're disabled or inside assetbundles
                foundParticleSystems = (Resources.FindObjectsOfTypeAll(typeof(ParticleSystem)) as ParticleSystem[]).ToList();
            }
            else
            {
                // Finds active particle systems, not those that are disabled or inside assetbundles
                foundParticleSystems = _particleEditorScript.FindParticleSystems();
            }

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

            _particleEditorScript.LogForDebug($"{nameof(ParticleSystemManager)}: Found {foundParticleSystems.Count} Particle Systems");
        }

        #region Shaders/Textures

        public Material GetMaterial(string shaderName, string texturePath)
        {
            Texture2D texture2D = TextureLoader.LoadTexture(texturePath);

            var material = new Material(Shader.Find(shaderName));
            material.mainTexture = (Texture)texture2D;

            return material;
        }

        #endregion

        #region Package Helpers

        // Macgruber PostMagic
        // Get directory path where the plugin is located. Based on Alazi's & VAMDeluxe's method.
        public static string GetPluginPath(MVRScript self)
        {
            var id = self.name.Substring(0, self.name.IndexOf('_'));
            var filename = self.manager.GetJSON()["plugins"][id].Value;

            return filename.Substring(0, filename.LastIndexOfAny(new char[] { '/', '\\' }));
        }

        // Macgruber PostMagic
        // Get path prefix of the package that contains our plugin.
        public static string GetPackagePath(MVRScript self)
        {
            var filename = GetPluginPath(self);
            var index = filename.IndexOf(":/");

            return index >= 0 ? filename.Substring(0, index + 2) : string.Empty;
        }

        #endregion
    }
}