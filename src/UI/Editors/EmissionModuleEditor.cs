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

        public EmissionModuleEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            _particleEditorScript.RemoveTextField(EmissionLabel);
            _particleEditorScript.RemoveToggle(Enabled);
            _particleEditorScript.RemoveSlider(RateOverDistance);
            _particleEditorScript.RemoveSlider(RateOverDistanceMultiplier);
            _particleEditorScript.RemoveSlider(RateOverTime);
            _particleEditorScript.RemoveSlider(RateOverTimeMultiplier);
            _particleEditorScript.RemoveSlider(BurstCount);
        }

        public override void Build()
        {
            EmissionLabel = CreateLabel("EmissionLabel", "Emission", true);

            _particleEditorScript.CreateToggle(Enabled, true);

            _particleEditorScript.CreateSlider(RateOverDistance, true);
            RateOverDistance.constrained = false;

            _particleEditorScript.CreateSlider(RateOverDistanceMultiplier, true);
            RateOverDistanceMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(RateOverTime, true);
            RateOverTime.constrained = false;

            _particleEditorScript.CreateSlider(RateOverTimeMultiplier, true);
            RateOverTimeMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(BurstCount, true);
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
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.enabled = selectedEnabled;
                    }
                }
            );
            Enabled.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.enabled : EmissionModuleEditorDefaults.Enabled);

            // Rate Over Distance Slider - MinMaxCurve
            RateOverDistance = new JSONStorableFloat
            (
                "Rate Over Distance",
                EmissionModuleEditorDefaults.RateOverDistance,
                (selectedRateOverDistance) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverDistance = selectedRateOverDistance;
                    }
                },
                0f,
                100.0f
            );
            RateOverDistance.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.rateOverDistance.constant : EmissionModuleEditorDefaults.RateOverDistance);

            // Rate Over Distance Multiplier Slider
            RateOverDistanceMultiplier = new JSONStorableFloat
            (
                "Rate Over Distance Multiplier",
                EmissionModuleEditorDefaults.RateOverDistanceMultiplier,
                (selectedRateOverDistanceMultiplierS) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverDistanceMultiplier = selectedRateOverDistanceMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            RateOverDistanceMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.rateOverDistanceMultiplier : EmissionModuleEditorDefaults.RateOverDistanceMultiplier);

            // Rate Over Time Slider - MinMaxCurve
            RateOverTime = new JSONStorableFloat
            (
                "Rate Over Time",
                EmissionModuleEditorDefaults.RateOverTime,
                (selectedRateOverTime) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverTime = selectedRateOverTime;
                    }
                },
                0f,
                100.0f
            );
            RateOverTime.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.rateOverTime.constant : EmissionModuleEditorDefaults.RateOverTime);

            // Rate Over Time Multiplier Slider
            RateOverTimeMultiplier = new JSONStorableFloat
            (
                "Rate Over Time Multiplier",
                EmissionModuleEditorDefaults.RateOverTimeMultiplier,
                (selectedRateOverTimeMultiplierS) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.rateOverTimeMultiplier = selectedRateOverTimeMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            RateOverTimeMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.rateOverTimeMultiplier : EmissionModuleEditorDefaults.RateOverTimeMultiplier);

            // Burst Count - TODO: Implement full burst system
            BurstCount = new JSONStorableFloat
            (
                "Burst Count",
                EmissionModuleEditorDefaults.BurstCount,
                (selectedBurstCount) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var emission = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission;
                        emission.burstCount = (int)selectedBurstCount;
                    }
                },
                0f,
                100.0f
            );
            BurstCount.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.emission.burstCount : EmissionModuleEditorDefaults.BurstCount);


            _particleEditorScript.RegisterBool(Enabled);
            _particleEditorScript.RegisterFloat(RateOverDistance);
            _particleEditorScript.RegisterFloat(RateOverDistanceMultiplier);
            _particleEditorScript.RegisterFloat(RateOverTime);
            _particleEditorScript.RegisterFloat(RateOverTimeMultiplier);
            _particleEditorScript.RegisterFloat(BurstCount);
        }

        public override void DeregisterStorables()
        {
            _particleEditorScript.DeregisterBool(Enabled);
            _particleEditorScript.DeregisterFloat(RateOverDistance);
            _particleEditorScript.DeregisterFloat(RateOverDistanceMultiplier);
            _particleEditorScript.DeregisterFloat(RateOverTime);
            _particleEditorScript.DeregisterFloat(RateOverTimeMultiplier);
            _particleEditorScript.DeregisterFloat(BurstCount);
        }
    }
}