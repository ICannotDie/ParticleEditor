using ICannotDie.Plugins.Common;
using System.Collections.Generic;
using UnityEngine;

namespace ICannotDie.Plugins.UI.Editors
{
    public class MainModuleEditor : EditorBase
    {
        public JSONStorableString MainLabel;
        public JSONStorableBool IsLooping;
        public JSONStorableBool Prewarm;
        public JSONStorableFloat Duration;
        public JSONStorableFloat StartDelay;
        public JSONStorableFloat StartDelayMultiplier;
        public JSONStorableFloat StartLifetime;
        public JSONStorableFloat StartLifetimeMultiplier;
        public JSONStorableFloat StartSpeed;
        public JSONStorableFloat StartSpeedMultiplier;
        public JSONStorableFloat StartSize;
        public JSONStorableFloat StartSizeMultiplier;
        public JSONStorableBool StartRotation3D;
        public JSONStorableFloat StartRotationX;
        public JSONStorableFloat StartRotationXMultiplier;
        public JSONStorableFloat StartRotationY;
        public JSONStorableFloat StartRotationYMultiplier;
        public JSONStorableFloat StartRotationZ;
        public JSONStorableFloat StartRotationZMultiplier;
        public JSONStorableFloat StartRotation;
        public JSONStorableFloat StartRotationMultiplier;
        public JSONStorableFloat FlipRotation;
        public JSONStorableColor StartColor;
        public JSONStorableFloat GravityModifier;
        public JSONStorableFloat GravityModifierMultiplier;
        public JSONStorableStringChooser SimulationSpace;
        public JSONStorableFloat SimulationSpeed;
        public JSONStorableStringChooser DeltaTime;
        public JSONStorableStringChooser ScalingMode;
        public JSONStorableBool PlayOnAwake;
        public JSONStorableStringChooser EmitterVelocityMode;
        public JSONStorableFloat MaxParticles;
        public JSONStorableBool AutoRandomSeed;
        public JSONStorableFloat Seed;
        public UIDynamicButton ReseedButton;
        public JSONStorableStringChooser StopAction;

        public MainModuleEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            _particleEditorScript.RemoveTextField(MainLabel);
            _particleEditorScript.RemoveToggle(IsLooping);
            _particleEditorScript.RemoveToggle(Prewarm);
            _particleEditorScript.RemoveSlider(Duration);
            _particleEditorScript.RemoveSlider(StartDelay);
            _particleEditorScript.RemoveSlider(StartDelayMultiplier);
            _particleEditorScript.RemoveSlider(StartLifetime);
            _particleEditorScript.RemoveSlider(StartLifetimeMultiplier);
            _particleEditorScript.RemoveSlider(StartSpeed);
            _particleEditorScript.RemoveSlider(StartSpeedMultiplier);
            _particleEditorScript.RemoveSlider(StartSize);
            _particleEditorScript.RemoveSlider(StartSizeMultiplier);
            _particleEditorScript.RemoveToggle(StartRotation3D);
            _particleEditorScript.RemoveSlider(StartRotationX);
            _particleEditorScript.RemoveSlider(StartRotationXMultiplier);
            _particleEditorScript.RemoveSlider(StartRotationY);
            _particleEditorScript.RemoveSlider(StartRotationYMultiplier);
            _particleEditorScript.RemoveSlider(StartRotationZ);
            _particleEditorScript.RemoveSlider(StartRotationZMultiplier);
            _particleEditorScript.RemoveSlider(StartRotation);
            _particleEditorScript.RemoveSlider(StartRotationMultiplier);
            _particleEditorScript.RemoveSlider(FlipRotation);
            _particleEditorScript.RemoveColorPicker(StartColor);
            _particleEditorScript.RemoveSlider(GravityModifier);
            _particleEditorScript.RemoveSlider(GravityModifierMultiplier);
            _particleEditorScript.RemovePopup(SimulationSpace);
            _particleEditorScript.RemoveSlider(SimulationSpeed);
            _particleEditorScript.RemovePopup(DeltaTime);
            _particleEditorScript.RemovePopup(ScalingMode);
            _particleEditorScript.RemoveToggle(PlayOnAwake);
            _particleEditorScript.RemovePopup(EmitterVelocityMode);
            _particleEditorScript.RemoveSlider(MaxParticles);
            _particleEditorScript.RemoveToggle(AutoRandomSeed);
            _particleEditorScript.RemoveSlider(Seed);
            _particleEditorScript.RemoveButton(ReseedButton);
            _particleEditorScript.RemovePopup(StopAction);
        }

        public override void Build()
        {
            MainLabel = CreateLabel("MainLabel", "Main", true);

            _particleEditorScript.CreateToggle(IsLooping, true);

            _particleEditorScript.CreateToggle(Prewarm, true);

            _particleEditorScript.CreateSlider(Duration, true);
            Duration.constrained = false;

            _particleEditorScript.CreateSlider(StartDelay, true);
            StartDelay.constrained = false;

            _particleEditorScript.CreateSlider(StartDelayMultiplier, true);
            StartDelayMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartLifetime, true);
            StartLifetime.constrained = false;

            _particleEditorScript.CreateSlider(StartLifetimeMultiplier, true);
            StartLifetimeMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartSpeed, true);
            StartSpeed.constrained = false;

            _particleEditorScript.CreateSlider(StartSpeedMultiplier, true);
            StartSpeedMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartSize, true);
            StartSize.constrained = false;

            _particleEditorScript.CreateSlider(StartSizeMultiplier, true);
            StartSizeMultiplier.constrained = false;

            _particleEditorScript.CreateToggle(StartRotation3D, true);

            _particleEditorScript.CreateSlider(StartRotationX, true);
            StartRotationX.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationXMultiplier, true);
            StartRotationXMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationY, true);
            StartRotationY.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationYMultiplier, true);
            StartRotationYMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationZ, true);
            StartRotationZ.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationZMultiplier, true);
            StartRotationZMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotation, true);
            StartRotation.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationMultiplier, true);
            StartRotationMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(FlipRotation, true);
            FlipRotation.constrained = false;

            _particleEditorScript.CreateColorPicker(StartColor, true);

            _particleEditorScript.CreateSlider(GravityModifier, true);
            GravityModifier.constrained = false;

            _particleEditorScript.CreateSlider(GravityModifierMultiplier, true);
            GravityModifierMultiplier.constrained = false;

            _particleEditorScript.CreatePopup(SimulationSpace, true);

            _particleEditorScript.CreateSlider(SimulationSpeed, true);
            SimulationSpeed.constrained = false;

            _particleEditorScript.CreatePopup(DeltaTime, true);

            _particleEditorScript.CreatePopup(ScalingMode, true);

            _particleEditorScript.CreateToggle(PlayOnAwake, true);

            _particleEditorScript.CreatePopup(EmitterVelocityMode, true);

            _particleEditorScript.CreateSlider(MaxParticles, true);
            MaxParticles.constrained = false;
            MaxParticles.slider.wholeNumbers = true;

            _particleEditorScript.CreateToggle(AutoRandomSeed, true);

            _particleEditorScript.CreateSlider(Seed, true);
            Seed.slider.wholeNumbers = true;

            ReseedButton = _particleEditorScript.CreateButton("Reseed", true);
            ReseedButton.button.onClick.AddListener(() =>
            {
                if (AutoRandomSeed != null && Seed != null)
                {
                    AutoRandomSeed.SetVal(false);
                    Seed.SetVal(Utility.GetRandomUInt());
                }
            });

            _particleEditorScript.CreatePopup(StopAction, true);
        }

        public override void RegisterStorables()
        {
            IsLooping = new JSONStorableBool
            (
                "Is Looping",
                MainModuleEditorDefaults.IsLooping,
                (selectedIsLooping) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.loop = selectedIsLooping;
                    }
                }
            );
            IsLooping.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.loop : MainModuleEditorDefaults.IsLooping);

            // Prewarm Toggle
            Prewarm = new JSONStorableBool
            (
                "Prewarm",
                MainModuleEditorDefaults.Prewarm,
                (selectedPrewarm) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.prewarm = selectedPrewarm;
                    }
                }
            );
            Prewarm.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.prewarm : MainModuleEditorDefaults.Prewarm);

            // Duration Slider
            Duration = new JSONStorableFloat
            (
                "Duration",
                MainModuleEditorDefaults.Duration,
                (selectedDuration) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isPlaying)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                            main.duration = selectedDuration;
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            main.duration = selectedDuration;
                        }
                    }
                },
                0f,
                60.0f
            );
            Duration.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.duration : MainModuleEditorDefaults.Duration);

            // Start Delay Slider - MinMaxCurve
            StartDelay = new JSONStorableFloat
            (
                "Start Delay",
                MainModuleEditorDefaults.StartDelay,
                (selectedStartDelay) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelay = selectedStartDelay;
                    }
                },
                0f,
                60.0f
            );
            StartDelay.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelay.constant : MainModuleEditorDefaults.StartDelay);

            // Start Delay Multiplier Slider
            StartDelayMultiplier = new JSONStorableFloat
            (
                "Start Delay Multiplier",
                MainModuleEditorDefaults.StartDelayMultiplier,
                (selectedStartDelayMultiplierS) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelayMultiplier = selectedStartDelayMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            StartDelayMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelayMultiplier : MainModuleEditorDefaults.StartDelayMultiplier);

            // Start Lifetime Slider - MinMaxCurve
            StartLifetime = new JSONStorableFloat
            (
                "Start Lifetime",
                MainModuleEditorDefaults.StartLifetime,
                (selectedstartLifetims) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetime = selectedstartLifetims;
                    }
                },
                0f,
                60.0f
            );
            StartLifetime.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetime.constant : MainModuleEditorDefaults.StartLifetime);

            // Start Lifetime Multiplier Slider
            StartLifetimeMultiplier = new JSONStorableFloat
            (
                "Start Lifetime Multiplier",
                MainModuleEditorDefaults.StartLifetimeMultiplier,
                (selectedStartLifetimeMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetimeMultiplier = selectedStartLifetimeMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartLifetimeMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetimeMultiplier : MainModuleEditorDefaults.StartLifetimeMultiplier);

            // Start Speed Slider - MinMaxCurve
            StartSpeed = new JSONStorableFloat
            (
                "Start Speed",
                MainModuleEditorDefaults.StartSpeed,
                (selectedStartSpeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeed = selectedStartSpeed;
                    }
                },
                0f,
                60.0f
            );
            StartSpeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeed.constant : MainModuleEditorDefaults.StartSpeed);

            // Start Speed Multiplier Slider
            StartSpeedMultiplier = new JSONStorableFloat
            (
                "Start Speed Multiplier",
                MainModuleEditorDefaults.StartSpeedMultiplier,
                (selectedStartSpeedMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeedMultiplier = selectedStartSpeedMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartSpeedMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeedMultiplier : MainModuleEditorDefaults.StartSpeedMultiplier);

            // Start Size Slider
            StartSize = new JSONStorableFloat
            (
                "Start Size",
                MainModuleEditorDefaults.StartSize,
                (selectedStartSize) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSize = selectedStartSize;
                    }
                },
                0f,
                10.0f
            );
            StartSize.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSize.constant : MainModuleEditorDefaults.StartSize);

            // Start Size Multiplier Slider
            StartSizeMultiplier = new JSONStorableFloat
            (
                "Start Size Multiplier",
                MainModuleEditorDefaults.StartSizeMultiplier,
                (selectedStartSizeMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSizeMultiplier = selectedStartSizeMultiplier;
                    }
                },
                0f,
                10.0f
            );
            StartSizeMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSizeMultiplier : MainModuleEditorDefaults.StartSizeMultiplier);

            // Start Rotation 3D Toggle
            StartRotation3D = new JSONStorableBool
            (
                "Start Rotation 3D",
                MainModuleEditorDefaults.StartRotation3D,
                (selectedStartRotation3D) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotation3D = selectedStartRotation3D;
                    }
                }
            );
            StartRotation3D.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotation3D : MainModuleEditorDefaults.StartRotation3D);

            // Start Rotation X Slider - MinMaxCurve
            StartRotationX = new JSONStorableFloat
            (
                "Start Rotation X",
                MainModuleEditorDefaults.StartRotationX,
                (selectedStartRotationX) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationX = selectedStartRotationX;
                    }
                },
                0f,
                360.0f
            );
            StartRotationX.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationX.constant : MainModuleEditorDefaults.StartRotationX);

            // Start Rotation X Multiplier Slider
            StartRotationXMultiplier = new JSONStorableFloat
            (
                "Start Rotation X Multiplier",
                MainModuleEditorDefaults.StartRotationXMultiplier,
                (selectedStartRotationXMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationXMultiplier = selectedStartRotationXMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationXMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationXMultiplier : MainModuleEditorDefaults.StartRotationXMultiplier);

            // Start Rotation Y Slider - MinMaxCurve
            StartRotationY = new JSONStorableFloat
            (
                "Start Rotation Y",
                MainModuleEditorDefaults.StartRotationY,
                (selectedStartRotationY) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationY = selectedStartRotationY;
                    }
                },
                0f,
                360.0f
            );
            StartRotationY.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationY.constant : MainModuleEditorDefaults.StartRotationY);

            // Start Rotation Y Multiplier Slider
            StartRotationYMultiplier = new JSONStorableFloat
            (
                "Start Rotation Y Multiplier",
                MainModuleEditorDefaults.StartRotationYMultiplier,
                (selectedStartRotationYMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationYMultiplier = selectedStartRotationYMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationYMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationYMultiplier : MainModuleEditorDefaults.StartRotationYMultiplier);

            // Start Rotation Z Slider - MinMaxCurve
            StartRotationZ = new JSONStorableFloat
            (
                "Start Rotation Z",
                MainModuleEditorDefaults.StartRotationZ,
                (selectedStartRotationZ) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationZ = selectedStartRotationZ;
                    }
                },
                0f,
                360.0f
            );
            StartRotationZ.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationZ.constant : MainModuleEditorDefaults.StartRotationZ);

            // Start Rotation Z Multiplier Slider
            StartRotationZMultiplier = new JSONStorableFloat
            (
                "Start Rotation Z Multiplier",
                MainModuleEditorDefaults.StartRotationZMultiplier,
                (selectedStartRotationZMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationZMultiplier = selectedStartRotationZMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationZMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationZMultiplier : MainModuleEditorDefaults.StartRotationZMultiplier);

            // Start Rotation Slider - MinMaxCurve
            StartRotation = new JSONStorableFloat
            (
                "Start Rotation",
                MainModuleEditorDefaults.StartRotation,
                (selectedStartRotation) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotation = selectedStartRotation;
                    }
                },
                0f,
                360.0f
            );
            StartRotation.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotation.constant : MainModuleEditorDefaults.StartRotation);

            // Start Rotation Multiplier Slider
            StartRotationMultiplier = new JSONStorableFloat
            (
                "Start Rotation Multiplier",
                MainModuleEditorDefaults.StartRotationMultiplier,
                (selectedStartRotationMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationMultiplier = selectedStartRotationMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationMultiplier : MainModuleEditorDefaults.StartRotationMultiplier);

            // Flip Rotation Slider
            FlipRotation = new JSONStorableFloat
            (
                "Flip Rotation",
                MainModuleEditorDefaults.FlipRotation,
                (selectedFlipRotation) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.flipRotation = selectedFlipRotation;
                    }
                },
                0f,
                1.0f
            );
            FlipRotation.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.flipRotation : MainModuleEditorDefaults.FlipRotation);

            // Start Color Picker - MinMaxGradient
            StartColor = new JSONStorableColor
            (
                "Start Color",
                MainModuleEditorDefaults.StartColor(),
                (H, S, V) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        var color = HSVColorPicker.HSVToRGB(H, S, V);
                        main.startColor = new ParticleSystem.MinMaxGradient(color, color);
                    }
                }
            );

            var colorToSetTo = new HSVColor();

            if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
            {
                float H, S, V;
                Color.RGBToHSV(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startColor.color, out H, out S, out V);
                colorToSetTo.H = H;
                colorToSetTo.S = S;
                colorToSetTo.V = V;
            }
            else
            {
                colorToSetTo = MainModuleEditorDefaults.StartColor();
            }

            StartColor.SetVal(colorToSetTo.H, colorToSetTo.S, colorToSetTo.V);
            StartColor.SetDefaultFromCurrent();

            // Gravity Modifier Slider - MinMaxCurve
            GravityModifier = new JSONStorableFloat
            (
                "Gravity Modifier",
                MainModuleEditorDefaults.GravityModifier,
                (selectedGravityModifier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.gravityModifier = selectedGravityModifier;
                    }
                },
                -100f,
                100.0f
            );
            GravityModifier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.gravityModifier.constant : MainModuleEditorDefaults.GravityModifier);

            // Gravity Modifier Multiplier Slider
            GravityModifierMultiplier = new JSONStorableFloat
            (
                "Gravity Modifier Multiplier",
                MainModuleEditorDefaults.GravityModifierMultiplier,
                (selectedGravityModifierMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.gravityModifierMultiplier = selectedGravityModifierMultiplier;
                    }
                },
                0f,
                100.0f
            );
            GravityModifierMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.gravityModifierMultiplier : MainModuleEditorDefaults.GravityModifierMultiplier);

            // Simulation Space Popup - TODO: Support for Custom Simulation Space
            SimulationSpace = new JSONStorableStringChooser
            (
                "SimulationSpace",
                new List<string>() { SimulationSpaceOptions.Local, SimulationSpaceOptions.World },
                _particleEditorScript?.ParticleSystemManager?.CurrentParticleSystem != null
                    ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.simulationSpace.ToString()
                    : ParticleSystemSimulationSpace.Local.ToString(),
                "Simulation Space",
                (selectedSimulationSpace) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.simulationSpace = selectedSimulationSpace == SimulationSpaceOptions.Local ? ParticleSystemSimulationSpace.Local : ParticleSystemSimulationSpace.World;
                    }
                }
            );

            // Simulation Speed Slider
            SimulationSpeed = new JSONStorableFloat
            (
                "Simulation Speed",
                MainModuleEditorDefaults.SimulationSpeed,
                (selectedSimulationSpeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.simulationSpeed = selectedSimulationSpeed;
                    }
                },
                0f,
                10.0f
            );
            SimulationSpeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.simulationSpeed : MainModuleEditorDefaults.SimulationSpeed);
            SimulationSpeed.constrained = false;

            // Delta Time Popup
            DeltaTime = new JSONStorableStringChooser
            (
                "DeltaTime",
                new List<string>() { DeltaTimeOptions.Scaled, DeltaTimeOptions.Unscaled },
                _particleEditorScript?.ParticleSystemManager?.CurrentParticleSystem != null
                    ? (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.useUnscaledTime ? DeltaTimeOptions.Unscaled : DeltaTimeOptions.Scaled)
                    : DeltaTimeOptions.Scaled,
                DeltaTimeOptions.Unscaled,
                (selectedDeltaTime) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.useUnscaledTime = selectedDeltaTime != DeltaTimeOptions.Scaled;
                    }
                }
            );

            // Scaling Mode Popup
            ScalingMode = new JSONStorableStringChooser
            (
                "ScalingMode",
                new List<string>() { ScalingModeOptions.Hierarchy, ScalingModeOptions.Local, ScalingModeOptions.Shape },
                _particleEditorScript?.ParticleSystemManager?.CurrentParticleSystem != null
                    ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.scalingMode.ToString()
                    : ParticleSystemScalingMode.Local.ToString(),
                "Scaling Mode",
                (selectedScalingMode) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        switch (selectedScalingMode)
                        {
                            case ScalingModeOptions.Hierarchy:
                                main.scalingMode = ParticleSystemScalingMode.Hierarchy;
                                break;
                            case ScalingModeOptions.Local:
                                main.scalingMode = ParticleSystemScalingMode.Local;
                                break;
                            case ScalingModeOptions.Shape:
                                main.scalingMode = ParticleSystemScalingMode.Shape;
                                break;
                        }
                    }
                }
            );

            // Play On Awake Toggle
            PlayOnAwake = new JSONStorableBool
            (
                "Play On Awake",
                MainModuleEditorDefaults.PlayOnAwake,
                (playOnAwake) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.playOnAwake = playOnAwake;
                    }
                }
            );
            PlayOnAwake.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.playOnAwake : MainModuleEditorDefaults.PlayOnAwake);

            // Emitter Velocity Mode Popup
            EmitterVelocityMode = new JSONStorableStringChooser
            (
                "EmitterVelocityMode",
                new List<string>() { EmitterVelocityModeOptions.Transform, EmitterVelocityModeOptions.Rigidbody },
                _particleEditorScript?.ParticleSystemManager?.CurrentParticleSystem != null
                    ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.emitterVelocityMode.ToString()
                    : ParticleSystemEmitterVelocityMode.Rigidbody.ToString(),
                "Emitter Velocity Mode",
                (selectedEmitterVelocityMode) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.emitterVelocityMode = selectedEmitterVelocityMode == EmitterVelocityModeOptions.Rigidbody ? ParticleSystemEmitterVelocityMode.Rigidbody : ParticleSystemEmitterVelocityMode.Transform;
                    }
                }
            );

            // Max Particles
            MaxParticles = new JSONStorableFloat
            (
                "Max Particles",
                MainModuleEditorDefaults.MaxParticles,
                (selectedMaxParticles) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.maxParticles = (int)selectedMaxParticles;
                    }
                },
                0f,
                10000.0f
            );
            MaxParticles.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.maxParticles : MainModuleEditorDefaults.MaxParticles);

            // Auto Random Seed Toggle
            AutoRandomSeed = new JSONStorableBool
            (
                "Auto Random Seed",
                MainModuleEditorDefaults.AutoRandomSeed,
                (selectedAutoRandomSeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.useAutoRandomSeed = selectedAutoRandomSeed;

                        if (Seed != null && selectedAutoRandomSeed == true)
                        {
                            Seed.SetVal(0);
                        }
                    }
                }
            );
            AutoRandomSeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.useAutoRandomSeed : MainModuleEditorDefaults.AutoRandomSeed);

            // Seed Slider - this is a uint in the Unity docs, but in the Unity editor the Reseed button can go negative, which is not possible for unsigned integers...
            var uintNegativeMaxAsFloat = (float)uint.MaxValue * -1;
            var uintPositiveMaxAsFloat = (float)uint.MaxValue;

            Seed = new JSONStorableFloat
            (
                "Seed",
                MainModuleEditorDefaults.Seed,
                (selectedSeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.randomSeed = (uint)selectedSeed;
                    }
                },
                uintNegativeMaxAsFloat,
                uintPositiveMaxAsFloat
            );

            Seed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.randomSeed : MainModuleEditorDefaults.Seed);

            // Stop Action Popup
            StopAction = new JSONStorableStringChooser
            (
                "StopAction",
                new List<string>() { ParticleSystemStopActionOptions.None, ParticleSystemStopActionOptions.Disable, ParticleSystemStopActionOptions.Destroy, ParticleSystemStopActionOptions.Callback },
                _particleEditorScript?.ParticleSystemManager?.CurrentParticleSystem != null
                    ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.stopAction.ToString()
                    : ParticleSystemStopAction.None.ToString(),
                "Stop Action",
                (selectedStopAction) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        switch (selectedStopAction)
                        {
                            case ParticleSystemStopActionOptions.None:
                                main.stopAction = ParticleSystemStopAction.None;
                                break;
                            case ParticleSystemStopActionOptions.Disable:
                                main.stopAction = ParticleSystemStopAction.Disable;
                                break;
                            case ParticleSystemStopActionOptions.Destroy:
                                main.stopAction = ParticleSystemStopAction.Destroy;
                                break;
                            case ParticleSystemStopActionOptions.Callback:
                                main.stopAction = ParticleSystemStopAction.Callback;
                                break;
                        }
                    }
                }
            );

            _particleEditorScript.RegisterBool(IsLooping);
            _particleEditorScript.RegisterBool(Prewarm);
            _particleEditorScript.RegisterFloat(Duration);
            _particleEditorScript.RegisterFloat(StartDelay);
            _particleEditorScript.RegisterFloat(StartDelayMultiplier);
            _particleEditorScript.RegisterFloat(StartLifetime);
            _particleEditorScript.RegisterFloat(StartLifetimeMultiplier);
            _particleEditorScript.RegisterFloat(StartSpeed);
            _particleEditorScript.RegisterFloat(StartSpeedMultiplier);
            _particleEditorScript.RegisterFloat(StartSize);
            _particleEditorScript.RegisterBool(StartRotation3D);
            _particleEditorScript.RegisterFloat(StartRotationX);
            _particleEditorScript.RegisterFloat(StartRotationXMultiplier);
            _particleEditorScript.RegisterFloat(StartRotationY);
            _particleEditorScript.RegisterFloat(StartRotationYMultiplier);
            _particleEditorScript.RegisterFloat(StartRotationZ);
            _particleEditorScript.RegisterFloat(StartRotationZMultiplier);
            _particleEditorScript.RegisterFloat(StartRotation);
            _particleEditorScript.RegisterFloat(StartRotationMultiplier);
            _particleEditorScript.RegisterFloat(FlipRotation);
            _particleEditorScript.RegisterColor(StartColor);
            _particleEditorScript.RegisterFloat(GravityModifier);
            _particleEditorScript.RegisterFloat(GravityModifierMultiplier);
            _particleEditorScript.RegisterStringChooser(SimulationSpace);
            _particleEditorScript.RegisterFloat(SimulationSpeed);
            _particleEditorScript.RegisterStringChooser(DeltaTime);
            _particleEditorScript.RegisterStringChooser(ScalingMode);
            _particleEditorScript.RegisterBool(PlayOnAwake);
            _particleEditorScript.RegisterStringChooser(EmitterVelocityMode);
            _particleEditorScript.RegisterFloat(MaxParticles);
            _particleEditorScript.RegisterBool(AutoRandomSeed);
            _particleEditorScript.RegisterFloat(Seed);
            _particleEditorScript.RegisterStringChooser(StopAction);
        }

        public override void DeregisterStorables()
        {
            _particleEditorScript.DeregisterBool(IsLooping);
            _particleEditorScript.DeregisterBool(Prewarm);
            _particleEditorScript.DeregisterFloat(Duration);
            _particleEditorScript.DeregisterFloat(StartDelay);
            _particleEditorScript.DeregisterFloat(StartDelayMultiplier);
            _particleEditorScript.DeregisterFloat(StartLifetime);
            _particleEditorScript.DeregisterFloat(StartLifetimeMultiplier);
            _particleEditorScript.DeregisterFloat(StartSpeed);
            _particleEditorScript.DeregisterFloat(StartSpeedMultiplier);
            _particleEditorScript.DeregisterFloat(StartSize);
            _particleEditorScript.DeregisterFloat(StartSizeMultiplier);
            _particleEditorScript.DeregisterBool(StartRotation3D);
            _particleEditorScript.DeregisterFloat(StartRotationX);
            _particleEditorScript.DeregisterFloat(StartRotationXMultiplier);
            _particleEditorScript.DeregisterFloat(StartRotationY);
            _particleEditorScript.DeregisterFloat(StartRotationYMultiplier);
            _particleEditorScript.DeregisterFloat(StartRotationZ);
            _particleEditorScript.DeregisterFloat(StartRotationZMultiplier);
            _particleEditorScript.DeregisterFloat(StartRotation);
            _particleEditorScript.DeregisterFloat(StartRotationMultiplier);
            _particleEditorScript.DeregisterFloat(FlipRotation);
            _particleEditorScript.DeregisterColor(StartColor);
            _particleEditorScript.DeregisterFloat(GravityModifier);
            _particleEditorScript.DeregisterFloat(GravityModifierMultiplier);
            _particleEditorScript.DeregisterStringChooser(SimulationSpace);
            _particleEditorScript.DeregisterFloat(SimulationSpeed);
            _particleEditorScript.DeregisterStringChooser(DeltaTime);
            _particleEditorScript.DeregisterStringChooser(ScalingMode);
            _particleEditorScript.DeregisterBool(PlayOnAwake);
            _particleEditorScript.DeregisterStringChooser(EmitterVelocityMode);
            _particleEditorScript.DeregisterFloat(MaxParticles);
            _particleEditorScript.DeregisterBool(AutoRandomSeed);
            _particleEditorScript.DeregisterFloat(Seed);
            _particleEditorScript.DeregisterStringChooser(StopAction);
        }
    }

}