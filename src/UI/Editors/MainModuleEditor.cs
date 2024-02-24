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

        private readonly ParticleEditor _particleEditor;

        public MainModuleEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            _particleEditor.RemoveTextField(MainLabel);
            _particleEditor.RemoveToggle(IsLooping);
            _particleEditor.RemoveToggle(Prewarm);
            _particleEditor.RemoveSlider(Duration);
            _particleEditor.RemoveSlider(StartDelay);
            _particleEditor.RemoveSlider(StartDelayMultiplier);
            _particleEditor.RemoveSlider(StartLifetime);
            _particleEditor.RemoveSlider(StartLifetimeMultiplier);
            _particleEditor.RemoveSlider(StartSpeed);
            _particleEditor.RemoveSlider(StartSpeedMultiplier);
            _particleEditor.RemoveSlider(StartSize);
            _particleEditor.RemoveSlider(StartSizeMultiplier);
            _particleEditor.RemoveToggle(StartRotation3D);
            _particleEditor.RemoveSlider(StartRotationX);
            _particleEditor.RemoveSlider(StartRotationXMultiplier);
            _particleEditor.RemoveSlider(StartRotationY);
            _particleEditor.RemoveSlider(StartRotationYMultiplier);
            _particleEditor.RemoveSlider(StartRotationZ);
            _particleEditor.RemoveSlider(StartRotationZMultiplier);
            _particleEditor.RemoveSlider(StartRotation);
            _particleEditor.RemoveSlider(StartRotationMultiplier);
            _particleEditor.RemoveSlider(FlipRotation);
            _particleEditor.RemoveColorPicker(StartColor);
            _particleEditor.RemoveSlider(GravityModifier);
            _particleEditor.RemoveSlider(GravityModifierMultiplier);
            _particleEditor.RemovePopup(SimulationSpace);
            _particleEditor.RemoveSlider(SimulationSpeed);
            _particleEditor.RemovePopup(DeltaTime);
            _particleEditor.RemovePopup(ScalingMode);
            _particleEditor.RemoveToggle(PlayOnAwake);
            _particleEditor.RemovePopup(EmitterVelocityMode);
            _particleEditor.RemoveSlider(MaxParticles);
            _particleEditor.RemoveToggle(AutoRandomSeed);
            _particleEditor.RemoveSlider(Seed);
            _particleEditor.RemoveButton(ReseedButton);
            _particleEditor.RemovePopup(StopAction);
        }

        public override void Build()
        {
            MainLabel = CreateLabel("MainLabel", "Main", true);

            _particleEditor.CreateToggle(IsLooping, true);

            _particleEditor.CreateToggle(Prewarm, true);

            _particleEditor.CreateSlider(Duration, true);
            Duration.constrained = false;

            _particleEditor.CreateSlider(StartDelay, true);
            StartDelay.constrained = false;

            _particleEditor.CreateSlider(StartDelayMultiplier, true);
            StartDelayMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartLifetime, true);
            StartLifetime.constrained = false;

            _particleEditor.CreateSlider(StartLifetimeMultiplier, true);
            StartLifetimeMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartSpeed, true);
            StartSpeed.constrained = false;

            _particleEditor.CreateSlider(StartSpeedMultiplier, true);
            StartSpeedMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartSize, true);
            StartSize.constrained = false;

            _particleEditor.CreateSlider(StartSizeMultiplier, true);
            StartSizeMultiplier.constrained = false;

            _particleEditor.CreateToggle(StartRotation3D, true);

            _particleEditor.CreateSlider(StartRotationX, true);
            StartRotationX.constrained = false;

            _particleEditor.CreateSlider(StartRotationXMultiplier, true);
            StartRotationXMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartRotationY, true);
            StartRotationY.constrained = false;

            _particleEditor.CreateSlider(StartRotationYMultiplier, true);
            StartRotationYMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartRotationZ, true);
            StartRotationZ.constrained = false;

            _particleEditor.CreateSlider(StartRotationZMultiplier, true);
            StartRotationZMultiplier.constrained = false;

            _particleEditor.CreateSlider(StartRotation, true);
            StartRotation.constrained = false;

            _particleEditor.CreateSlider(StartRotationMultiplier, true);
            StartRotationMultiplier.constrained = false;

            _particleEditor.CreateSlider(FlipRotation, true);
            FlipRotation.constrained = false;

            _particleEditor.CreateColorPicker(StartColor, true);

            _particleEditor.CreateSlider(GravityModifier, true);
            GravityModifier.constrained = false;

            _particleEditor.CreateSlider(GravityModifierMultiplier, true);
            GravityModifierMultiplier.constrained = false;

            _particleEditor.CreatePopup(SimulationSpace, true);

            _particleEditor.CreateSlider(SimulationSpeed, true);
            SimulationSpeed.constrained = false;

            _particleEditor.CreatePopup(DeltaTime, true);

            _particleEditor.CreatePopup(ScalingMode, true);

            _particleEditor.CreateToggle(PlayOnAwake, true);

            _particleEditor.CreatePopup(EmitterVelocityMode, true);

            _particleEditor.CreateSlider(MaxParticles, true);
            MaxParticles.constrained = false;
            MaxParticles.slider.wholeNumbers = true;

            _particleEditor.CreateToggle(AutoRandomSeed, true);

            _particleEditor.CreateSlider(Seed, true);
            Seed.slider.wholeNumbers = true;

            ReseedButton = _particleEditor.CreateButton("Reseed", true);
            ReseedButton.button.onClick.AddListener(() =>
            {
                if (AutoRandomSeed != null && Seed != null)
                {
                    AutoRandomSeed.SetVal(false);
                    Seed.SetVal(Utility.GetRandomUInt());
                }
            });

            _particleEditor.CreatePopup(StopAction, true);
        }

        public override void RegisterStorables()
        {
            IsLooping = new JSONStorableBool
            (
                "Is Looping",
                MainModuleEditorDefaults.IsLooping,
                (selectedIsLooping) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.loop = selectedIsLooping;
                    }
                }
            );
            IsLooping.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.loop : MainModuleEditorDefaults.IsLooping);

            // Prewarm Toggle
            Prewarm = new JSONStorableBool
            (
                "Prewarm",
                MainModuleEditorDefaults.Prewarm,
                (selectedPrewarm) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.prewarm = selectedPrewarm;
                    }
                }
            );
            Prewarm.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.prewarm : MainModuleEditorDefaults.Prewarm);

            // Duration Slider
            Duration = new JSONStorableFloat
            (
                "Duration",
                MainModuleEditorDefaults.Duration,
                (selectedDuration) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;

                        if (_particleEditor.ParticleSystemManager.CurrentParticleSystem.isPlaying)
                        {
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Stop();
                            main.duration = selectedDuration;
                            _particleEditor.ParticleSystemManager.CurrentParticleSystem.Play();
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
            Duration.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.duration : MainModuleEditorDefaults.Duration);

            // Start Delay Slider - MinMaxCurve
            StartDelay = new JSONStorableFloat
            (
                "Start Delay",
                MainModuleEditorDefaults.StartDelay,
                (selectedStartDelay) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelay = selectedStartDelay;
                    }
                },
                0f,
                60.0f
            );
            StartDelay.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startDelay.constant : MainModuleEditorDefaults.StartDelay);

            // Start Delay Multiplier Slider
            StartDelayMultiplier = new JSONStorableFloat
            (
                "Start Delay Multiplier",
                MainModuleEditorDefaults.StartDelayMultiplier,
                (selectedStartDelayMultiplierS) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelayMultiplier = selectedStartDelayMultiplierS;
                    }
                },
                0f,
                100.0f
            );
            StartDelayMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startDelayMultiplier : MainModuleEditorDefaults.StartDelayMultiplier);

            // Start Lifetime Slider - MinMaxCurve
            StartLifetime = new JSONStorableFloat
            (
                "Start Lifetime",
                MainModuleEditorDefaults.StartLifetime,
                (selectedstartLifetims) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetime = selectedstartLifetims;
                    }
                },
                0f,
                60.0f
            );
            StartLifetime.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startLifetime.constant : MainModuleEditorDefaults.StartLifetime);

            // Start Lifetime Multiplier Slider
            StartLifetimeMultiplier = new JSONStorableFloat
            (
                "Start Lifetime Multiplier",
                MainModuleEditorDefaults.StartLifetimeMultiplier,
                (selectedStartLifetimeMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetimeMultiplier = selectedStartLifetimeMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartLifetimeMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startLifetimeMultiplier : MainModuleEditorDefaults.StartLifetimeMultiplier);

            // Start Speed Slider - MinMaxCurve
            StartSpeed = new JSONStorableFloat
            (
                "Start Speed",
                MainModuleEditorDefaults.StartSpeed,
                (selectedStartSpeed) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeed = selectedStartSpeed;
                    }
                },
                0f,
                60.0f
            );
            StartSpeed.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSpeed.constant : MainModuleEditorDefaults.StartSpeed);

            // Start Speed Multiplier Slider
            StartSpeedMultiplier = new JSONStorableFloat
            (
                "Start Speed Multiplier",
                MainModuleEditorDefaults.StartSpeedMultiplier,
                (selectedStartSpeedMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeedMultiplier = selectedStartSpeedMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartSpeedMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSpeedMultiplier : MainModuleEditorDefaults.StartSpeedMultiplier);

            // Start Size Slider
            StartSize = new JSONStorableFloat
            (
                "Start Size",
                MainModuleEditorDefaults.StartSize,
                (selectedStartSize) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSize = selectedStartSize;
                    }
                },
                0f,
                10.0f
            );
            StartSize.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSize.constant : MainModuleEditorDefaults.StartSize);

            // Start Size Multiplier Slider
            StartSizeMultiplier = new JSONStorableFloat
            (
                "Start Size Multiplier",
                MainModuleEditorDefaults.StartSizeMultiplier,
                (selectedStartSizeMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSizeMultiplier = selectedStartSizeMultiplier;
                    }
                },
                0f,
                10.0f
            );
            StartSizeMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSizeMultiplier : MainModuleEditorDefaults.StartSizeMultiplier);

            // Start Rotation 3D Toggle
            StartRotation3D = new JSONStorableBool
            (
                "Start Rotation 3D",
                MainModuleEditorDefaults.StartRotation3D,
                (selectedStartRotation3D) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotation3D = selectedStartRotation3D;
                    }
                }
            );
            StartRotation3D.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotation3D : MainModuleEditorDefaults.StartRotation3D);

            // Start Rotation X Slider - MinMaxCurve
            StartRotationX = new JSONStorableFloat
            (
                "Start Rotation X",
                MainModuleEditorDefaults.StartRotationX,
                (selectedStartRotationX) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationX = selectedStartRotationX;
                    }
                },
                0f,
                360.0f
            );
            StartRotationX.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationX.constant : MainModuleEditorDefaults.StartRotationX);

            // Start Rotation X Multiplier Slider
            StartRotationXMultiplier = new JSONStorableFloat
            (
                "Start Rotation X Multiplier",
                MainModuleEditorDefaults.StartRotationXMultiplier,
                (selectedStartRotationXMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationXMultiplier = selectedStartRotationXMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationXMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationXMultiplier : MainModuleEditorDefaults.StartRotationXMultiplier);

            // Start Rotation Y Slider - MinMaxCurve
            StartRotationY = new JSONStorableFloat
            (
                "Start Rotation Y",
                MainModuleEditorDefaults.StartRotationY,
                (selectedStartRotationY) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationY = selectedStartRotationY;
                    }
                },
                0f,
                360.0f
            );
            StartRotationY.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationY.constant : MainModuleEditorDefaults.StartRotationY);

            // Start Rotation Y Multiplier Slider
            StartRotationYMultiplier = new JSONStorableFloat
            (
                "Start Rotation Y Multiplier",
                MainModuleEditorDefaults.StartRotationYMultiplier,
                (selectedStartRotationYMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationYMultiplier = selectedStartRotationYMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationYMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationYMultiplier : MainModuleEditorDefaults.StartRotationYMultiplier);

            // Start Rotation Z Slider - MinMaxCurve
            StartRotationZ = new JSONStorableFloat
            (
                "Start Rotation Z",
                MainModuleEditorDefaults.StartRotationZ,
                (selectedStartRotationZ) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationZ = selectedStartRotationZ;
                    }
                },
                0f,
                360.0f
            );
            StartRotationZ.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationZ.constant : MainModuleEditorDefaults.StartRotationZ);

            // Start Rotation Z Multiplier Slider
            StartRotationZMultiplier = new JSONStorableFloat
            (
                "Start Rotation Z Multiplier",
                MainModuleEditorDefaults.StartRotationZMultiplier,
                (selectedStartRotationZMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationZMultiplier = selectedStartRotationZMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationZMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationZMultiplier : MainModuleEditorDefaults.StartRotationZMultiplier);

            // Start Rotation Slider - MinMaxCurve
            StartRotation = new JSONStorableFloat
            (
                "Start Rotation",
                MainModuleEditorDefaults.StartRotation,
                (selectedStartRotation) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotation = selectedStartRotation;
                    }
                },
                0f,
                360.0f
            );
            StartRotation.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotation.constant : MainModuleEditorDefaults.StartRotation);

            // Start Rotation Multiplier Slider
            StartRotationMultiplier = new JSONStorableFloat
            (
                "Start Rotation Multiplier",
                MainModuleEditorDefaults.StartRotationMultiplier,
                (selectedStartRotationMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotationMultiplier = selectedStartRotationMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartRotationMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startRotationMultiplier : MainModuleEditorDefaults.StartRotationMultiplier);

            // Flip Rotation Slider
            FlipRotation = new JSONStorableFloat
            (
                "Flip Rotation",
                MainModuleEditorDefaults.FlipRotation,
                (selectedFlipRotation) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.flipRotation = selectedFlipRotation;
                    }
                },
                0f,
                1.0f
            );
            FlipRotation.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.flipRotation : MainModuleEditorDefaults.FlipRotation);

            // Start Color Picker - MinMaxGradient
            StartColor = new JSONStorableColor
            (
                "Start Color",
                MainModuleEditorDefaults.StartColor(),
                (H, S, V) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        var color = HSVColorPicker.HSVToRGB(H, S, V);
                        main.startColor = new ParticleSystem.MinMaxGradient(color, color);
                    }
                }
            );

            var colorToSetTo = new HSVColor();

            if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
            {
                float H, S, V;
                Color.RGBToHSV(_particleEditor.ParticleSystemManager.CurrentParticleSystem.main.startColor.color, out H, out S, out V);
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
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.gravityModifier = selectedGravityModifier;
                    }
                },
                -100f,
                100.0f
            );
            GravityModifier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.gravityModifier.constant : MainModuleEditorDefaults.GravityModifier);

            // Gravity Modifier Multiplier Slider
            GravityModifierMultiplier = new JSONStorableFloat
            (
                "Gravity Modifier Multiplier",
                MainModuleEditorDefaults.GravityModifierMultiplier,
                (selectedGravityModifierMultiplier) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.gravityModifierMultiplier = selectedGravityModifierMultiplier;
                    }
                },
                0f,
                100.0f
            );
            GravityModifierMultiplier.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.gravityModifierMultiplier : MainModuleEditorDefaults.GravityModifierMultiplier);

            // Simulation Space Popup - TODO: Support for Custom Simulation Space
            SimulationSpace = new JSONStorableStringChooser
            (
                "SimulationSpace",
                new List<string>() { SimulationSpaceOptions.Local, SimulationSpaceOptions.World },
                _particleEditor.ParticleSystemManager.CurrentParticleSystem
                    ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.simulationSpace.ToString()
                    : ParticleSystemSimulationSpace.Local.ToString(),
                "Simulation Space",
                (selectedSimulationSpace) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
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
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.simulationSpeed = selectedSimulationSpeed;
                    }
                },
                0f,
                10.0f
            );
            SimulationSpeed.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.simulationSpeed : MainModuleEditorDefaults.SimulationSpeed);
            SimulationSpeed.constrained = false;

            // Delta Time Popup
            DeltaTime = new JSONStorableStringChooser
            (
                "DeltaTime",
                new List<string>() { DeltaTimeOptions.Scaled, DeltaTimeOptions.Unscaled },
                _particleEditor.ParticleSystemManager.CurrentParticleSystem
                    ? (_particleEditor.ParticleSystemManager.CurrentParticleSystem.main.useUnscaledTime ? DeltaTimeOptions.Unscaled : DeltaTimeOptions.Scaled)
                    : DeltaTimeOptions.Scaled,
                DeltaTimeOptions.Unscaled,
                (selectedDeltaTime) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.useUnscaledTime = selectedDeltaTime != DeltaTimeOptions.Scaled;
                    }
                }
            );

            // Scaling Mode Popup
            ScalingMode = new JSONStorableStringChooser
            (
                "ScalingMode",
                new List<string>() { ScalingModeOptions.Hierarchy, ScalingModeOptions.Local, ScalingModeOptions.Shape },
                _particleEditor.ParticleSystemManager.CurrentParticleSystem
                    ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.scalingMode.ToString()
                    : ParticleSystemScalingMode.Local.ToString(),
                "Scaling Mode",
                (selectedScalingMode) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;

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
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.playOnAwake = playOnAwake;
                    }
                }
            );
            PlayOnAwake.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.playOnAwake : MainModuleEditorDefaults.PlayOnAwake);

            // Emitter Velocity Mode Popup
            EmitterVelocityMode = new JSONStorableStringChooser
            (
                "EmitterVelocityMode",
                new List<string>() { EmitterVelocityModeOptions.Transform, EmitterVelocityModeOptions.Rigidbody },
                _particleEditor.ParticleSystemManager.CurrentParticleSystem
                    ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.emitterVelocityMode.ToString()
                    : ParticleSystemEmitterVelocityMode.Rigidbody.ToString(),
                "Emitter Velocity Mode",
                (selectedEmitterVelocityMode) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
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
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.maxParticles = (int)selectedMaxParticles;
                    }
                },
                0f,
                10000.0f
            );
            MaxParticles.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.maxParticles : MainModuleEditorDefaults.MaxParticles);

            // Auto Random Seed Toggle
            AutoRandomSeed = new JSONStorableBool
            (
                "Auto Random Seed",
                MainModuleEditorDefaults.AutoRandomSeed,
                (selectedAutoRandomSeed) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        _particleEditor.ParticleSystemManager.CurrentParticleSystem.useAutoRandomSeed = selectedAutoRandomSeed;

                        if (Seed != null && selectedAutoRandomSeed == true)
                        {
                            Seed.SetVal(0);
                        }
                    }
                }
            );
            AutoRandomSeed.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.useAutoRandomSeed : MainModuleEditorDefaults.AutoRandomSeed);

            // Seed Slider - this is a uint in the Unity docs, but in the Unity editor the Reseed button can go negative, which is not possible for unsigned integers...
            var uintNegativeMaxAsFloat = (float)uint.MaxValue * -1;
            var uintPositiveMaxAsFloat = (float)uint.MaxValue;

            Seed = new JSONStorableFloat
            (
                "Seed",
                MainModuleEditorDefaults.Seed,
                (selectedSeed) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        _particleEditor.ParticleSystemManager.CurrentParticleSystem.randomSeed = (uint)selectedSeed;
                    }
                },
                uintNegativeMaxAsFloat,
                uintPositiveMaxAsFloat
            );

            Seed.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.randomSeed : MainModuleEditorDefaults.Seed);

            // Stop Action Popup
            StopAction = new JSONStorableStringChooser
            (
                "StopAction",
                new List<string>() { ParticleSystemStopActionOptions.None, ParticleSystemStopActionOptions.Disable, ParticleSystemStopActionOptions.Destroy, ParticleSystemStopActionOptions.Callback },
                _particleEditor.ParticleSystemManager.CurrentParticleSystem
                    ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.main.stopAction.ToString()
                    : ParticleSystemStopAction.None.ToString(),
                "Stop Action",
                (selectedStopAction) =>
                {
                    if (_particleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditor.ParticleSystemManager.CurrentParticleSystem.main;

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

            _particleEditor.RegisterBool(IsLooping);
            _particleEditor.RegisterBool(Prewarm);
            _particleEditor.RegisterFloat(Duration);
            _particleEditor.RegisterFloat(StartDelay);
            _particleEditor.RegisterFloat(StartDelayMultiplier);
            _particleEditor.RegisterFloat(StartLifetime);
            _particleEditor.RegisterFloat(StartLifetimeMultiplier);
            _particleEditor.RegisterFloat(StartSpeed);
            _particleEditor.RegisterFloat(StartSpeedMultiplier);
            _particleEditor.RegisterFloat(StartSize);
            _particleEditor.RegisterBool(StartRotation3D);
            _particleEditor.RegisterFloat(StartRotationX);
            _particleEditor.RegisterFloat(StartRotationXMultiplier);
            _particleEditor.RegisterFloat(StartRotationY);
            _particleEditor.RegisterFloat(StartRotationYMultiplier);
            _particleEditor.RegisterFloat(StartRotationZ);
            _particleEditor.RegisterFloat(StartRotationZMultiplier);
            _particleEditor.RegisterFloat(StartRotation);
            _particleEditor.RegisterFloat(StartRotationMultiplier);
            _particleEditor.RegisterFloat(FlipRotation);
            _particleEditor.RegisterColor(StartColor);
            _particleEditor.RegisterFloat(GravityModifier);
            _particleEditor.RegisterFloat(GravityModifierMultiplier);
            _particleEditor.RegisterStringChooser(SimulationSpace);
            _particleEditor.RegisterFloat(SimulationSpeed);
            _particleEditor.RegisterStringChooser(DeltaTime);
            _particleEditor.RegisterStringChooser(ScalingMode);
            _particleEditor.RegisterBool(PlayOnAwake);
            _particleEditor.RegisterStringChooser(EmitterVelocityMode);
            _particleEditor.RegisterFloat(MaxParticles);
            _particleEditor.RegisterBool(AutoRandomSeed);
            _particleEditor.RegisterFloat(Seed);
            _particleEditor.RegisterStringChooser(StopAction);
        }

        public override void DeregisterStorables()
        {
            _particleEditor.DeregisterBool(IsLooping);
            _particleEditor.DeregisterBool(Prewarm);
            _particleEditor.DeregisterFloat(Duration);
            _particleEditor.DeregisterFloat(StartDelay);
            _particleEditor.DeregisterFloat(StartDelayMultiplier);
            _particleEditor.DeregisterFloat(StartLifetime);
            _particleEditor.DeregisterFloat(StartLifetimeMultiplier);
            _particleEditor.DeregisterFloat(StartSpeed);
            _particleEditor.DeregisterFloat(StartSpeedMultiplier);
            _particleEditor.DeregisterFloat(StartSize);
            _particleEditor.DeregisterFloat(StartSizeMultiplier);
            _particleEditor.DeregisterBool(StartRotation3D);
            _particleEditor.DeregisterFloat(StartRotationX);
            _particleEditor.DeregisterFloat(StartRotationXMultiplier);
            _particleEditor.DeregisterFloat(StartRotationY);
            _particleEditor.DeregisterFloat(StartRotationYMultiplier);
            _particleEditor.DeregisterFloat(StartRotationZ);
            _particleEditor.DeregisterFloat(StartRotationZMultiplier);
            _particleEditor.DeregisterFloat(StartRotation);
            _particleEditor.DeregisterFloat(StartRotationMultiplier);
            _particleEditor.DeregisterFloat(FlipRotation);
            _particleEditor.DeregisterColor(StartColor);
            _particleEditor.DeregisterFloat(GravityModifier);
            _particleEditor.DeregisterFloat(GravityModifierMultiplier);
            _particleEditor.DeregisterStringChooser(SimulationSpace);
            _particleEditor.DeregisterFloat(SimulationSpeed);
            _particleEditor.DeregisterStringChooser(DeltaTime);
            _particleEditor.DeregisterStringChooser(ScalingMode);
            _particleEditor.DeregisterBool(PlayOnAwake);
            _particleEditor.DeregisterStringChooser(EmitterVelocityMode);
            _particleEditor.DeregisterFloat(MaxParticles);
            _particleEditor.DeregisterBool(AutoRandomSeed);
            _particleEditor.DeregisterFloat(Seed);
            _particleEditor.DeregisterStringChooser(StopAction);
        }
    }

}