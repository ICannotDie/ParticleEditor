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
        private ParticleEditor _particleEditorScript;

        public Atom CurrentAtom;
        public ParticleSystem CurrentParticleSystem => CurrentAtom != null ? CurrentAtom.GetComponentInChildren<ParticleSystem>() : null;
        public ParticleSystemRenderer CurrentParticleSystemRenderer => CurrentParticleSystem != null ? CurrentParticleSystem.GetComponent<ParticleSystemRenderer>() : null;
        public List<Atom> ParticleSystemAtoms = new List<Atom>();
        public List<string> ParticleSystemUids => ParticleSystemAtoms.Any() ? ParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).Select(atom => atom.uid).ToList() : new List<string>();

        public void Initialise()
        {
            FindParticleSystems();

            if (ParticleSystemAtoms.Any())
            {
                SetCurrentAtom(ParticleSystemAtoms.FirstOrDefault());
            }
        }

        public ParticleSystemManager(ParticleEditor particleEditor)
        {
            _particleEditorScript = particleEditor;
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

        public string GetNextAtomUID()
        {
            var usedUIDs = ParticleSystemAtoms.Select(x => x.uid).ToList();

            if (!usedUIDs.Contains(Constants.RootObjectName))
            {
                return Constants.RootObjectName;
            }

            for (int i = 2; i < 1000; i++)
            {
                var uid = $"{Constants.RootObjectName}#{i}";
                if (!usedUIDs.Contains(uid))
                {
                    return uid;
                }
            }

            return Constants.RootObjectName + Guid.NewGuid();
        }

        public IEnumerator CreateAtomCoroutine()
        {
            // Get a new UID for the atom
            var nextUID = GetNextAtomUID();

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

            // Add the particle system to the atom
            AddParticleSystemToAtom(atom);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(atom);
            SetParticleSystemDefaults(CurrentParticleSystem);
            SetParticleSystemRendererDefaults(CurrentParticleSystemRenderer);

            _particleEditorScript.UiManager.BuildUI();
        }

        private void AddParticleSystemToAtom(Atom atom)
        {
            if (atom.type != Constants.EmptyAtomTypeName)
            {
                throw new ArgumentException(nameof(atom));
            }

            // Gets the Empty atom's sphere collider
            var sphereCollider = atom.transform.GetComponentsInChildren<SphereCollider>().First();

            if (sphereCollider != null)
            {
                // Add a ParticleSystem to the sphere collider
                ParticleSystemAtoms.Add(atom);
                sphereCollider.transform.gameObject.AddComponent<ParticleSystem>();
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

        public IEnumerator RemoveAtomCoroutine(string uid)
        {
            // Get atom to remove by uid
            var atomToRemove = SuperController.singleton.GetAtomByUid(uid);

            // Remove the atom
            SuperController.singleton.RemoveAtom(atomToRemove);

            // Yield now so the atom gets removed before we continue 
            yield return new WaitForEndOfFrame();

            // Get the atom by uid again, to confirm it was removed
            var atom = SuperController.singleton.GetAtomByUid(uid);

            if (atom != null)
            {
                throw new NullReferenceException("Atom was not removed");
            }

            // Choose a new atom to be set as current, or set null
            // Do this before we change the list to ensurre we select correctly
            var nextAtom = GetAtomBefore(atomToRemove);

            // Remove the atom from the local list
            ParticleSystemAtoms.Remove(atomToRemove);

            // Find, Set & Build
            FindParticleSystems();
            SetCurrentAtom(nextAtom);

            _particleEditorScript.UiManager.BuildUI();
        }

        public void FindParticleSystems(bool findAll = false)
        {
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
        }

        /// <summary>
        /// Get the atom before the specified one in the list 
        /// Circular - if the first atom in list is specified, this will return the last atom in the list
        /// </summary>
        private Atom GetAtomBefore(Atom atom)
        {
            return ParticleSystemAtoms
            .TakeWhile(x => x.UidAsInt() != atom.UidAsInt())
            .DefaultIfEmpty(ParticleSystemAtoms.Any() ? ParticleSystemAtoms[ParticleSystemAtoms.Count - 1] : null)
            .LastOrDefault();
        }

        /// <summary>
        /// Get the atom after the specified one in the list 
        /// Circular - if the last atom in list is specified, this will return the first atom in the list
        /// </summary>
        private Atom GetAtomAfter(Atom atom)
        {
            return ParticleSystemAtoms
            .SkipWhile(x => x.UidAsInt() != atom.UidAsInt())
            .Skip(1)
            .DefaultIfEmpty(ParticleSystemAtoms.Any() ? ParticleSystemAtoms[0] : null)
            .FirstOrDefault();
        }

        #region Shaders/Textures

        public Material GetMaterial(string shaderName, string texturePath)
        {
            Texture2D texture2D = TextureLoader.LoadTexture(texturePath);

            var material = new Material(Shader.Find(shaderName));
            material.mainTexture = (Texture)texture2D;

            return material;
        }

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