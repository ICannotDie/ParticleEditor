using ICannotDie.Plugins.Common;

namespace ICannotDie.Plugins.UI.Editors
{
    /// <summary>
    /// Editor for Particle System data.
    /// Includes the Add, Find, Select & Remove buttons, and the Particle System chooser
    /// </summary>
    public class ParticleSystemEditor : EditorBase
    {
        public JSONStorableString ParticleSystemLabel;
        public JSONStorableBool IsPlaying;
        public JSONStorableBool IsStopped;

        private readonly ParticleEditor _particleEditor;

        public ParticleSystemEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemEditor), nameof(Clear), "starting");

            _particleEditor.RemoveTextField(ParticleSystemLabel);
            _particleEditor.RemoveToggle(IsPlaying);
            _particleEditor.RemoveToggle(IsStopped);

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemEditor), nameof(Clear), "complete");
        }

        public override void Build()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemEditor), nameof(Build), "starting");

            ParticleSystemLabel = CreateLabel("ParticleSystemLabel", "Particle System", true);
            _particleEditor.CreateToggle(IsPlaying, true);
            _particleEditor.CreateToggle(IsStopped, true);

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemEditor), nameof(Build), "complete");
        }

        public override void RegisterStorables()
        {
            // Is Playing Toggle
            IsPlaying = new JSONStorableBool
            (
                "Is Playing",
                ParticleSystemEditorDefaults.IsPlaying,
                (selectedIsPlaying) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsPlaying)
                        {
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                    }
                }
            );

            IsPlaying.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.isPlaying : ParticleSystemEditorDefaults.IsPlaying);

            _particleEditor.RegisterBool(IsPlaying);

            // Is Stopped Toggle
            IsStopped = new JSONStorableBool
            (
                "Is Stopped",
                ParticleSystemEditorDefaults.IsStopped,
                (selectedIsStopped) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsStopped)
                        {
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                        else
                        {
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                    }
                }
            );

            IsStopped.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.isStopped : ParticleSystemEditorDefaults.IsStopped);

            _particleEditor.RegisterBool(IsStopped);

        }

        public override void DeregisterStorables()
        {
            _particleEditor.DeregisterBool(IsPlaying);
            _particleEditor.DeregisterBool(IsStopped);
        }
    }
}