using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.ParticleSystems;
using ICannotDie.Plugins.UI;
using System;
using System.Collections;
using UnityEngine;

namespace ICannotDie.Plugins
{
    public class ParticleEditor : MVRScript

    {
        public bool FullMode { get; private set; } = false;
        public bool HasChildParticleSystem { get; set; } = false;
        public bool? IsInitialised { get; private set; }
        public UIManager UIManager { get; private set; }
        public ParticleSystemManager ParticleSystemManager { get; private set; }
        public bool EnableDebug { get; private set; } = true;
        public bool DeferInit { get; private set; } = false;

        public override void Init()
        {
            IsInitialised = false;

            try
            {
                if (DeferInit)
                {
                    StartCoroutine(DeferredInit());
                }
                else
                {
                    CreateManagers(this);
                    InitialiseManagers();
                }
            }
            catch (Exception e)
            {
                enabled = false;
                Utility.LogError($"Init: {e}");
            }

            IsInitialised = true;
        }

        public IEnumerator DeferredInit()
        {
            yield return new WaitForEndOfFrame();
            while (SuperController.singleton.isLoading)
            {
                yield return null;
            }

            // Wait for other plugin permissions to be accepted
            var confirmPanel = SuperController.singleton.errorLogPanel.parent.Find(Constants.UserConfirmCanvas);
            while (confirmPanel != null && confirmPanel.childCount > 0)
            {
                yield return null;
            }

            CreateManagers(this);

            yield return new WaitForEndOfFrame();

            InitialiseManagers();
        }

        //public override void InitUI()
        //{
        //    base.InitUI();

        //    Defer.UntilNextFrame(() =>
        //    {
        //        Utility.LogMessage(nameof(ParticleEditor), nameof(InitUI), "called");

        //        ParticleSystemManager.FindParticleSystems(this);

        //        if (ParticleSystemManager.ParticleSystemAtoms.Any(x => x.uid == ParticleSystemManager.CurrentAtom.uid))
        //        {
        //            // Our current atom is still in the list after a refresh
        //            Utility.LogMessage(nameof(ParticleEditor), nameof(InitUI), "our current atom is still in the list after a find");
        //        }
        //        else
        //        {
        //            // Our current atom is not in the list after a refresh, choose another atom and set it as current
        //            Utility.LogMessage(nameof(ParticleEditor), nameof(InitUI), "our current atom is not in the list after a find");
        //            var nextAtom = ParticleSystemManager.ParticleSystemAtoms.GetAtomBefore(ParticleSystemManager.CurrentAtom);
        //            Utility.LogMessage(nameof(ParticleEditor), nameof(InitUI), "nextAtom:", nextAtom.uid);
        //        }
        //    });
        //}

        private void CreateManagers(ParticleEditor self)
        {
            UIManager = new UIManager(self);
            ParticleSystemManager = new ParticleSystemManager(self);
        }

        private void InitialiseManagers()
        {
            ParticleSystemManager.Initialise();
            UIManager.RegisterStorables();
            UIManager.BuildUI();
        }

    }
}