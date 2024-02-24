using ICannotDie.Plugins.Common;

namespace ICannotDie.Plugins.UI.Editors
{
    public class EmissionModuleEditor : EditorBase
    {
        public JSONStorableString EmissionLabel;
        public JSONStorableBool Enabled;
        public JSONStorableFloat RateOverDistance;
        public JSONStorableFloat RateOverDistanceMultiplier;
        public JSONStorableFloat RateOverTime;
        public JSONStorableFloat RateOverTimeMultiplier;
        public JSONStorableFloat BurstCount;

        private readonly ParticleEditor _particleEditor;

        public EmissionModuleEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            _particleEditor.RemoveTextField(EmissionLabel);
            _particleEditor.RemoveToggle(Enabled);
            _particleEditor.RemoveSlider(RateOverDistance);
            _particleEditor.RemoveSlider(RateOverDistanceMultiplier);
            _particleEditor.RemoveSlider(RateOverTime);
            _particleEditor.RemoveSlider(RateOverTimeMultiplier);
            _particleEditor.RemoveSlider(BurstCount);
        }

        public override void Build()
        {
            EmissionLabel = CreateLabel("EmissionLabel", "Emission", true);

            _particleEditor.CreateToggle(Enabled, true);

            _particleEditor.CreateSlider(RateOverDistance, true);
            RateOverDistance.constrained = false;

            _particleEditor.CreateSlider(RateOverDistanceMultiplier, true);
            RateOverDistanceMultiplier.constrained = false;

            _particleEditor.CreateSlider(RateOverTime, true);
            RateOverTime.constrained = false;

            _particleEditor.CreateSlider(RateOverTimeMultiplier, true);
            RateOverTimeMultiplier.constrained = false;

            _particleEditor.CreateSlider(BurstCount, true);
            BurstCount.slider.wholeNumbers = true;
        }

        public override void RegisterStorables()
        {
            // Enabled Toggle
            Enabled = new JSONStorableBool
            (
                "Enabled",
                EmissionModuleEditorDefaults.Enabled,
                (selectedEnabled) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.enabled = selectedEnabled;
                    }
                }
            );
            Enabled.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.enabled : EmissionModuleEditorDefaults.Enabled);

            // Rate Over Distance Slider - MinMaxCurve
            RateOverDistance = new JSONStorableFloat
            (
                "Rate Over Distance",
                EmissionModuleEditorDefaults.RateOverDistance,
                (selectedRateOverDistance) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverDistance = selectedRateOverDistance;
                    }
                },
                0f,
                100.0f
            );
            RateOverDistance.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.rateOverDistance.constant : EmissionModuleEditorDefaults.RateOverDistance);

            // Rate Over Distance Multiplier Slider
            RateOverDistanceMultiplier = new JSONStorableFloat
            (
                "Rate Over Distance Multiplier",
                EmissionModuleEditorDefaults.RateOverDistanceMultiplier,
                (selectedRateOverDistanceMultiplierS) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverDistanceMultiplier = selectedRateOverDistanceMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            RateOverDistanceMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.rateOverDistanceMultiplier : EmissionModuleEditorDefaults.RateOverDistanceMultiplier);

            // Rate Over Time Slider - MinMaxCurve
            RateOverTime = new JSONStorableFloat
            (
                "Rate Over Time",
                EmissionModuleEditorDefaults.RateOverTime,
                (selectedRateOverTime) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverTime = selectedRateOverTime;
                    }
                },
                0f,
                100.0f
            );
            RateOverTime.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.rateOverTime.constant : EmissionModuleEditorDefaults.RateOverTime);

            // Rate Over Time Multiplier Slider
            RateOverTimeMultiplier = new JSONStorableFloat
            (
                "Rate Over Time Multiplier",
                EmissionModuleEditorDefaults.RateOverTimeMultiplier,
                (selectedRateOverTimeMultiplierS) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverTimeMultiplier = selectedRateOverTimeMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            RateOverTimeMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.rateOverTimeMultiplier : EmissionModuleEditorDefaults.RateOverTimeMultiplier);

            // Burst Count - TODO: Implement full burst system
            BurstCount = new JSONStorableFloat
            (
                "Burst Count",
                EmissionModuleEditorDefaults.BurstCount,
                (selectedBurstCount) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.burstCount = (int)selectedBurstCount;
                    }
                },
                0f,
                100.0f
            );
            BurstCount.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.emission.burstCount : EmissionModuleEditorDefaults.BurstCount);


            _particleEditor.RegisterBool(Enabled);
            _particleEditor.RegisterFloat(RateOverDistance);
            _particleEditor.RegisterFloat(RateOverDistanceMultiplier);
            _particleEditor.RegisterFloat(RateOverTime);
            _particleEditor.RegisterFloat(RateOverTimeMultiplier);
            _particleEditor.RegisterFloat(BurstCount);
        }

        public override void DeregisterStorables()
        {
            _particleEditor.DeregisterBool(Enabled);
            _particleEditor.DeregisterFloat(RateOverDistance);
            _particleEditor.DeregisterFloat(RateOverDistanceMultiplier);
            _particleEditor.DeregisterFloat(RateOverTime);
            _particleEditor.DeregisterFloat(RateOverTimeMultiplier);
            _particleEditor.DeregisterFloat(BurstCount);
        }
    }
}