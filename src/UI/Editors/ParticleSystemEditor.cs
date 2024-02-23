using ICannotDie.Plugins.Common;

namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemEditor : EditorBase
    {
        public JSONStorableString ParticleSystemLabel;
        public JSONStorableBool IsPlaying;
        public JSONStorableBool IsStopped;

        public ParticleSystemEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            _particleEditorScript.RemoveTextField(ParticleSystemLabel);
            _particleEditorScript.RemoveToggle(IsPlaying);
            _particleEditorScript.RemoveToggle(IsStopped);
        }

        public override void Build()
        {
            ParticleSystemLabel = CreateLabel("particleSystemLabel", "Particle System", true);
            _particleEditorScript.CreateToggle(IsPlaying, true);
            _particleEditorScript.CreateToggle(IsStopped, true);
        }

        public override void DeregisterStorables()
        {
            _particleEditorScript.UiManager.DeregisterBool(IsPlaying);
            _particleEditorScript.UiManager.DeregisterBool(IsStopped);
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
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsPlaying)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                    }
                }
            );

            IsPlaying.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isPlaying : ParticleSystemEditorDefaults.IsPlaying);

            _particleEditorScript.RegisterBool(IsPlaying);

            // Is Stopped Toggle
            IsStopped = new JSONStorableBool
            (
                "Is Stopped",
                ParticleSystemEditorDefaults.IsStopped,
                (selectedIsStopped) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsStopped)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                        else
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                    }
                }
            );

            IsStopped.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isStopped : ParticleSystemEditorDefaults.IsStopped);

            _particleEditorScript.RegisterBool(IsStopped);

        }
    }
}