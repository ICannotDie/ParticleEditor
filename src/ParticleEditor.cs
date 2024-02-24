using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.ParticleSystems;
using ICannotDie.Plugins.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ICannotDie.Plugins
{
    public class ParticleEditor : MVRScript
    {
        public bool? IsInitialised { get; private set; }
        public UIManager UIManager { get; private set; }
        public ParticleSystemManager ParticleSystemManager { get; private set; }
        public bool EnableDebug { get; private set; } = true;

        public override void Init()
        {
            IsInitialised = false;

            try
            {
                UIManager = new UIManager(this);
                ParticleSystemManager = new ParticleSystemManager(this);

                ParticleSystemManager.Initialise();
                UIManager.RegisterStorables();
                UIManager.BuildUI();

                //StartCoroutine(DeferredInit());
            }
            catch (Exception e)
            {
                enabled = false;
                Utility.LogError($"Init: {e}");
            }
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

            UIManager = new UIManager(this);
            ParticleSystemManager = new ParticleSystemManager(this);

            yield return new WaitForEndOfFrame();

            ParticleSystemManager.Initialise();
            UIManager.RegisterStorables();
            UIManager.BuildUI();

            IsInitialised = true;

        }

        public List<ParticleSystem> FindParticleSystems() => FindObjectsOfType<ParticleSystem>().ToList();

    }
}