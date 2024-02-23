using ICannotDie.Plugins.ParticleSystems;
using ICannotDie.Plugins.UI;
using System.Collections.Generic;
using UnityEngine;

namespace ICannotDie.Plugins
{
    public class ParticleEditor : MVRScript
    {
        public bool? IsInitialised { get; private set; }
        public UIManager UiManager { get; private set; }
        public ParticleSystemManager ParticleSystemManager { get; private set; }
        public bool EnableDebug { get; private set; } = true;

        public override void Init()
        {
            UiManager = new UIManager(this);
            ParticleSystemManager = new ParticleSystemManager(this);

            ParticleSystemManager.Initialise();
            UiManager.RegisterStorables();
            UiManager.BuildUI();
        }

        public List<ParticleSystem> FindParticleSystems() => FindObjectsOfType<ParticleSystem>().ToList();

    }
}