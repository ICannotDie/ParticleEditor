using UnityEngine;
using ICannotDie.Plugins;
using ICannotDie.Plugins.UI;
using System.Collections.Generic;
using Random = System.Random;

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
            if (MainLabel != null)
            {
                _particleEditorScript.RemoveTextField(MainLabel);
            }

            if (IsLooping != null)
            {
                _particleEditorScript.RemoveToggle(IsLooping);
                _particleEditorScript.DeregisterBool(IsLooping);
            }

            if (Prewarm != null)
            {
                _particleEditorScript.RemoveToggle(Prewarm);
                _particleEditorScript.DeregisterBool(Prewarm);
            }

            if (Duration != null)
            {
                _particleEditorScript.RemoveSlider(Duration);
                _particleEditorScript.DeregisterFloat(Duration);
            }

            if (StartDelay != null)
            {
                _particleEditorScript.RemoveSlider(StartDelay);
                _particleEditorScript.DeregisterFloat(StartDelay);
            }

            if (StartDelayMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartDelayMultiplier);
                _particleEditorScript.DeregisterFloat(StartDelayMultiplier);
            }

            if (StartLifetime != null)
            {
                _particleEditorScript.RemoveSlider(StartLifetime);
                _particleEditorScript.DeregisterFloat(StartLifetime);
            }

            if (StartLifetimeMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartLifetimeMultiplier);
                _particleEditorScript.DeregisterFloat(StartLifetimeMultiplier);
            }

            if (StartSpeed != null)
            {
                _particleEditorScript.RemoveSlider(StartSpeed);
                _particleEditorScript.DeregisterFloat(StartSpeed);
            }

            if (StartSpeedMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartSpeedMultiplier);
                _particleEditorScript.DeregisterFloat(StartSpeedMultiplier);
            }

            if (StartSize != null)
            {
                _particleEditorScript.RemoveSlider(StartSize);
                _particleEditorScript.DeregisterFloat(StartSize);
            }

            if (StartRotation3D != null)
            {
                _particleEditorScript.RemoveToggle(StartRotation3D);
                _particleEditorScript.DeregisterBool(StartRotation3D);
            }

            if (StartRotationX != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationX);
                _particleEditorScript.DeregisterFloat(StartRotationX);
            }

            if (StartRotationXMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationXMultiplier);
                _particleEditorScript.DeregisterFloat(StartRotationXMultiplier);
            }

            if (StartRotationY != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationY);
                _particleEditorScript.DeregisterFloat(StartRotationY);
            }

            if (StartRotationYMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationYMultiplier);
                _particleEditorScript.DeregisterFloat(StartRotationYMultiplier);
            }

            if (StartRotationZ != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationZ);
                _particleEditorScript.DeregisterFloat(StartRotationZ);
            }

            if (StartRotationZMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationZMultiplier);
                _particleEditorScript.DeregisterFloat(StartRotationZMultiplier);
            }

            if (StartRotation != null)
            {
                _particleEditorScript.RemoveSlider(StartRotation);
                _particleEditorScript.DeregisterFloat(StartRotation);
            }

            if (StartRotationMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(StartRotationMultiplier);
                _particleEditorScript.DeregisterFloat(StartRotationMultiplier);
            }

            if (FlipRotation != null)
            {
                _particleEditorScript.RemoveSlider(FlipRotation);
                _particleEditorScript.DeregisterFloat(FlipRotation);
            }

            if (StartColor != null)
            {
                _particleEditorScript.RemoveColorPicker(StartColor);
                _particleEditorScript.DeregisterColor(StartColor);
            }

            if (GravityModifier != null)
            {
                _particleEditorScript.RemoveSlider(GravityModifier);
                _particleEditorScript.DeregisterFloat(GravityModifier);
            }

            if (GravityModifierMultiplier != null)
            {
                _particleEditorScript.RemoveSlider(GravityModifierMultiplier);
                _particleEditorScript.DeregisterFloat(GravityModifierMultiplier);
            }

            if (SimulationSpace != null)
            {
                _particleEditorScript.RemovePopup(SimulationSpace);
                _particleEditorScript.DeregisterStringChooser(SimulationSpace);
            }

            if (SimulationSpeed != null)
            {
                _particleEditorScript.RemoveSlider(SimulationSpeed);
                _particleEditorScript.DeregisterFloat(SimulationSpeed);
            }

            if (DeltaTime != null)
            {
                _particleEditorScript.RemovePopup(DeltaTime);
                _particleEditorScript.DeregisterStringChooser(DeltaTime);
            }

            if (ScalingMode != null)
            {
                _particleEditorScript.RemovePopup(ScalingMode);
                _particleEditorScript.DeregisterStringChooser(ScalingMode);
            }

            if (PlayOnAwake != null)
            {
                _particleEditorScript.RemoveToggle(PlayOnAwake);
                _particleEditorScript.DeregisterBool(PlayOnAwake);
            }

            if (EmitterVelocityMode != null)
            {
                _particleEditorScript.RemovePopup(EmitterVelocityMode);
                _particleEditorScript.DeregisterStringChooser(EmitterVelocityMode);
            }

            if (MaxParticles != null)
            {
                _particleEditorScript.RemoveSlider(MaxParticles);
                _particleEditorScript.DeregisterFloat(MaxParticles);
            }

            if (AutoRandomSeed != null)
            {
                _particleEditorScript.RemoveToggle(AutoRandomSeed);
                _particleEditorScript.DeregisterBool(AutoRandomSeed);
            }

            if (Seed != null)
            {
                _particleEditorScript.RemoveSlider(Seed);
                _particleEditorScript.DeregisterFloat(Seed);
            }

            _particleEditorScript.RemoveButton(ReseedButton);

            if (StopAction != null)
            {
                _particleEditorScript.RemovePopup(StopAction);
                _particleEditorScript.DeregisterStringChooser(StopAction);
            }
        }

        public override void Build()
        {
            // Main Label
            MainLabel = CreateLabel("mainLabel", "Main", true);

            // Is Looping Toggle
            var isLoopingDefaultValue = true;
            IsLooping = new JSONStorableBool
            (
                "Is Looping",
                isLoopingDefaultValue,
                (selectedIsLooping) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.loop = selectedIsLooping;
                    }
                }
            );
            IsLooping.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.loop : isLoopingDefaultValue);

            _particleEditorScript.CreateToggle(IsLooping, true);
            _particleEditorScript.RegisterBool(IsLooping);

            // Prewarm Toggle
            var prewarmDefaultValue = false;
            Prewarm = new JSONStorableBool
            (
                "Prewarm",
                prewarmDefaultValue,
                (selectedPrewarm) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.prewarm = selectedPrewarm;
                    }
                }
            );
            Prewarm.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.prewarm : prewarmDefaultValue);

            _particleEditorScript.CreateToggle(Prewarm, true);
            _particleEditorScript.RegisterBool(Prewarm);

            // Duration Slider
            var durationDefaultValue = 5.0f;
            Duration = new JSONStorableFloat
            (
                "Duration",
                durationDefaultValue,
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
            Duration.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.duration : durationDefaultValue);
            Duration.constrained = false;

            _particleEditorScript.CreateSlider(Duration, true);
            _particleEditorScript.RegisterFloat(Duration);

            // Start Delay Slider - MinMaxCurve
            var startDelayDefaultValue = 0f;
            StartDelay = new JSONStorableFloat
            (
                "Start Delay",
                startDelayDefaultValue,
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
            StartDelay.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelay.constant : startDelayDefaultValue);
            StartDelay.constrained = false;

            _particleEditorScript.CreateSlider(StartDelay, true);
            _particleEditorScript.RegisterFloat(StartDelay);

            // Start Delay Multiplier Slider
            var startDelayMultiplierDefaultValue = 0.0f;
            StartDelayMultiplier = new JSONStorableFloat
            (
                "Start Delay Multiplier",
                startDelayMultiplierDefaultValue,
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
            StartDelayMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelayMultiplier : startDelayMultiplierDefaultValue);
            StartDelayMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartDelayMultiplier, true);
            _particleEditorScript.RegisterFloat(StartDelayMultiplier);

            // Start Lifetime Slider - MinMaxCurve
            var startLifetimeDefaultValue = 5.0f;
            StartLifetime = new JSONStorableFloat
            (
                "Start Lifetime",
                startLifetimeDefaultValue,
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
            StartLifetime.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetime.constant : startLifetimeDefaultValue);
            StartLifetime.constrained = false;

            _particleEditorScript.CreateSlider(StartLifetime, true);
            _particleEditorScript.RegisterFloat(StartLifetime);

            // Start Lifetime Multiplier Slider
            var startLifetimeMultiplierDefaultValue = 5.0f;
            StartLifetimeMultiplier = new JSONStorableFloat
            (
                "Start Lifetime Multiplier",
                startLifetimeMultiplierDefaultValue,
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
            StartLifetimeMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetimeMultiplier : startLifetimeMultiplierDefaultValue);
            StartLifetimeMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartLifetimeMultiplier, true);
            _particleEditorScript.RegisterFloat(StartLifetimeMultiplier);

            // Start Speed Slider - MinMaxCurve
            var startSpeedDefaultValue = 5.0f;
            StartSpeed = new JSONStorableFloat
            (
                "Start Speed",
                startSpeedDefaultValue,
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
            StartSpeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeed.constant : startSpeedDefaultValue);
            StartSpeed.constrained = false;

            _particleEditorScript.CreateSlider(StartSpeed, true);
            _particleEditorScript.RegisterFloat(StartSpeed);

            // Start Speed Multiplier Slider
            var startSpeedMultiplierDefaultValue = 5.0f;
            StartSpeedMultiplier = new JSONStorableFloat
            (
                "Start Speed Multiplier",
                startSpeedMultiplierDefaultValue,
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
            StartSpeedMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeedMultiplier : startSpeedMultiplierDefaultValue);
            StartSpeedMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartSpeedMultiplier, true);
            _particleEditorScript.RegisterFloat(StartSpeedMultiplier);

            // Start Size Slider
            var startSizeDefaultValue = 1.0f;
            StartSize = new JSONStorableFloat
            (
                "Start Size",
                startSizeDefaultValue,
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
            StartSize.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.startSize : startSizeDefaultValue);
            StartSize.constrained = false;

            _particleEditorScript.CreateSlider(StartSize, true);
            _particleEditorScript.RegisterFloat(StartSize);

            // Start Rotation 3D Toggle
            var startRotation3DDefaultValue = false;
            StartRotation3D = new JSONStorableBool
            (
                "Start Rotation 3D",
                startRotation3DDefaultValue,
                (selectedStartRotation3D) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startRotation3D = selectedStartRotation3D;
                    }
                }
            );
            StartRotation3D.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotation3D : startRotation3DDefaultValue);

            _particleEditorScript.CreateToggle(StartRotation3D, true);
            _particleEditorScript.RegisterBool(StartRotation3D);

            // Start Rotation X Slider - MinMaxCurve
            var startRotationXDefaultValue = 0.0f;
            StartRotationX = new JSONStorableFloat
            (
                "Start Rotation X",
                startRotationXDefaultValue,
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
            StartRotationX.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationX.constant : startRotationXDefaultValue);
            StartRotationX.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationX, true);
            _particleEditorScript.RegisterFloat(StartRotationX);

            // Start Rotation X Multiplier Slider
            var startRotationXMultiplierDefaultValue = 0.0f;
            StartRotationXMultiplier = new JSONStorableFloat
            (
                "Start Rotation X Multiplier",
                startRotationXMultiplierDefaultValue,
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
            StartRotationXMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationXMultiplier : startRotationXMultiplierDefaultValue);
            StartRotationXMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationXMultiplier, true);
            _particleEditorScript.RegisterFloat(StartRotationXMultiplier);

            // Start Rotation Y Slider - MinMaxCurve
            var startRotationYDefaultValue = 0.0f;
            StartRotationY = new JSONStorableFloat
            (
                "Start Rotation Y",
                startRotationYDefaultValue,
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
            StartRotationY.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationY.constant : startRotationYDefaultValue);
            StartRotationY.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationY, true);
            _particleEditorScript.RegisterFloat(StartRotationY);

            // Start Rotation Y Multiplier Slider
            var startRotationYMultiplierDefaultValue = 0.0f;
            StartRotationYMultiplier = new JSONStorableFloat
            (
                "Start Rotation Y Multiplier",
                startRotationYMultiplierDefaultValue,
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
            StartRotationYMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationYMultiplier : startRotationYMultiplierDefaultValue);
            StartRotationYMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationYMultiplier, true);
            _particleEditorScript.RegisterFloat(StartRotationYMultiplier);

            // Start Rotation Z Slider - MinMaxCurve
            var startRotationZDefaultValue = 0.0f;
            StartRotationZ = new JSONStorableFloat
            (
                "Start Rotation Z",
                startRotationZDefaultValue,
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
            StartRotationZ.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationZ.constant : startRotationZDefaultValue);
            StartRotationZ.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationZ, true);
            _particleEditorScript.RegisterFloat(StartRotationZ);

            // Start Rotation Z Multiplier Slider
            var startRotationZMultiplierDefaultValue = 0.0f;
            StartRotationZMultiplier = new JSONStorableFloat
            (
                "Start Rotation Z Multiplier",
                startRotationZMultiplierDefaultValue,
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
            StartRotationZMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationZMultiplier : startRotationZMultiplierDefaultValue);
            StartRotationZMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationZMultiplier, true);
            _particleEditorScript.RegisterFloat(StartRotationZMultiplier);

            // Start Rotation Slider - MinMaxCurve
            var startRotationDefaultValue = 0.0f;
            StartRotation = new JSONStorableFloat
            (
                "Start Rotation",
                startRotationDefaultValue,
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
            StartRotation.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotation.constant : startRotationDefaultValue);
            StartRotation.constrained = false;

            _particleEditorScript.CreateSlider(StartRotation, true);
            _particleEditorScript.RegisterFloat(StartRotation);

            // Start Rotation Multiplier Slider
            var startRotationMultiplierDefaultValue = 0.0f;
            StartRotationMultiplier = new JSONStorableFloat
            (
                "Start Rotation Multiplier",
                startRotationMultiplierDefaultValue,
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
            StartRotationMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startRotationMultiplier : startRotationMultiplierDefaultValue);
            StartRotationMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(StartRotationMultiplier, true);
            _particleEditorScript.RegisterFloat(StartRotationMultiplier);

            // Flip Rotation Slider
            var flipRotationDefaultValue = 0.0f;
            FlipRotation = new JSONStorableFloat
            (
                "Flip Rotation",
                flipRotationDefaultValue,
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
            FlipRotation.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.flipRotation : flipRotationDefaultValue);
            FlipRotation.constrained = false;

            _particleEditorScript.CreateSlider(FlipRotation, true);
            _particleEditorScript.RegisterFloat(FlipRotation);

            // Start Color Picker - MinMaxGradient
            var startColorDefaultValue = new HSVColor();
            StartColor = new JSONStorableColor
            (
                "Start Color",
                startColorDefaultValue,
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
                colorToSetTo = startColorDefaultValue;
            }

            StartColor.SetVal(colorToSetTo.H, colorToSetTo.S, colorToSetTo.V);
            StartColor.SetDefaultFromCurrent();

            _particleEditorScript.CreateColorPicker(StartColor, true);
            _particleEditorScript.RegisterColor(StartColor);

            // Gravity Modifier Slider - MinMaxCurve
            var gravityModifierDefaultValue = 0.0f;
            GravityModifier = new JSONStorableFloat
            (
                "Gravity Modifier",
                gravityModifierDefaultValue,
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
            GravityModifier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.gravityModifier.constant : gravityModifierDefaultValue);
            GravityModifier.constrained = false;

            _particleEditorScript.CreateSlider(GravityModifier, true);
            _particleEditorScript.RegisterFloat(GravityModifier);

            // Gravity Modifier Multiplier Slider
            var gravityModifierMultiplierDefaultValue = 0.0f;
            GravityModifierMultiplier = new JSONStorableFloat
            (
                "Gravity Modifier Multiplier",
                gravityModifierMultiplierDefaultValue,
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
            GravityModifierMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.gravityModifierMultiplier : gravityModifierMultiplierDefaultValue);
            GravityModifierMultiplier.constrained = false;

            _particleEditorScript.CreateSlider(GravityModifierMultiplier, true);
            _particleEditorScript.RegisterFloat(GravityModifierMultiplier);

            // Simulation Space Popup - TODO: Support for Custom Simulation Space
            SimulationSpace = new JSONStorableStringChooser
            (
                "SimulationSpace",
                new List<string>() { "Local", "World" },
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystem
                    ? ((ParticleSystemSimulationSpace)_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.simulationSpace).ToString()
                    : ((ParticleSystemSimulationSpace)ParticleSystemSimulationSpace.Local).ToString(),
                "Simulation Space",
                (selectedSimulationSpace) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.simulationSpace = selectedSimulationSpace == "Local" ? ParticleSystemSimulationSpace.Local : ParticleSystemSimulationSpace.World;
                    }
                }
            );

            _particleEditorScript.CreatePopup(SimulationSpace, true);
            _particleEditorScript.RegisterStringChooser(SimulationSpace);

            // Simulation Speed Slider
            var simulationSpeedDefaultValue = 1.0f;
            SimulationSpeed = new JSONStorableFloat
            (
                "Simulation Speed",
                simulationSpeedDefaultValue,
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
            SimulationSpeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.simulationSpeed : simulationSpeedDefaultValue);
            SimulationSpeed.constrained = false;

            _particleEditorScript.CreateSlider(SimulationSpeed, true);
            _particleEditorScript.RegisterFloat(SimulationSpeed);

            // Delta Time Popup
            DeltaTime = new JSONStorableStringChooser
            (
                "DeltaTime",
                new List<string>() { "Scaled", "Unscaled" },
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystem
                    ? (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.useUnscaledTime ? "Unscaled" : "Scaled")
                    : "Scaled",
                "Delta Time",
                (selectedDeltaTime) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.useUnscaledTime = selectedDeltaTime == "Scaled" ? false : true;
                    }
                }
            );

            _particleEditorScript.CreatePopup(DeltaTime, true);
            _particleEditorScript.RegisterStringChooser(DeltaTime);

            // Scaling Mode Popup
            ScalingMode = new JSONStorableStringChooser
            (
                "ScalingMode",
                new List<string>() { "Hierarchy", "Local", "Shape" },
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystem
                    ? ((ParticleSystemScalingMode)_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.scalingMode).ToString()
                    : ((ParticleSystemScalingMode)ParticleSystemScalingMode.Local).ToString(),
                "Scaling Mode",
                (selectedScalingMode) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        switch (selectedScalingMode)
                        {
                            case "Hierarchy":
                                main.scalingMode = ParticleSystemScalingMode.Hierarchy;
                                break;
                            case "Local":
                                main.scalingMode = ParticleSystemScalingMode.Local;
                                break;
                            case "Shape":
                                main.scalingMode = ParticleSystemScalingMode.Shape;
                                break;
                        }
                    }
                }
            );

            _particleEditorScript.CreatePopup(ScalingMode, true);
            _particleEditorScript.RegisterStringChooser(ScalingMode);

            // Play On Awake Toggle
            var playOnAwakeDefaultValue = false;
            PlayOnAwake = new JSONStorableBool
            (
                "Play On Awake",
                playOnAwakeDefaultValue,
                (playOnAwake) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.playOnAwake = playOnAwake;
                    }
                }
            );
            PlayOnAwake.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.playOnAwake : playOnAwakeDefaultValue);

            _particleEditorScript.CreateToggle(PlayOnAwake, true);
            _particleEditorScript.RegisterBool(PlayOnAwake);

            // Emitter Velocity Mode Popup
            EmitterVelocityMode = new JSONStorableStringChooser
            (
                "EmitterVelocityMode",
                new List<string>() { "Transform", "Rigidbody" },
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystem
                    ? ((ParticleSystemEmitterVelocityMode)_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.emitterVelocityMode).ToString()
                    : ((ParticleSystemEmitterVelocityMode)ParticleSystemEmitterVelocityMode.Rigidbody).ToString(),
                "Emitter Velocity Mode",
                (selectedEmitterVelocityMode) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.emitterVelocityMode = selectedEmitterVelocityMode == "Rigidbody" ? ParticleSystemEmitterVelocityMode.Rigidbody : ParticleSystemEmitterVelocityMode.Transform;
                    }
                }
            );

            _particleEditorScript.CreatePopup(EmitterVelocityMode, true);
            _particleEditorScript.RegisterStringChooser(EmitterVelocityMode);

            // Max Particles
            var maxParticlesDefaultValue = 1000f;
            MaxParticles = new JSONStorableFloat
            (
                "Max Particles",
                maxParticlesDefaultValue,
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
            MaxParticles.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.maxParticles : maxParticlesDefaultValue);
            MaxParticles.constrained = false;

            _particleEditorScript.CreateSlider(MaxParticles, true);
            MaxParticles.slider.wholeNumbers = true;

            _particleEditorScript.RegisterFloat(MaxParticles);

            // Auto Random Seed Toggle
            var autoRandomSeedDefaultValue = true;
            AutoRandomSeed = new JSONStorableBool
            (
                "Auto Random Seed",
                autoRandomSeedDefaultValue,
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
            AutoRandomSeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.useAutoRandomSeed : autoRandomSeedDefaultValue);

            _particleEditorScript.CreateToggle(AutoRandomSeed, true);
            _particleEditorScript.RegisterBool(AutoRandomSeed);

            // Seed Slider - this is a uint in the Unity docs, but in the Unity editor the Reseed button can go negative, which is not possible for unsigned integrals...
            var seedDefaultValue = 0f;
            var intMinAsFloat = (float)uint.MaxValue * -1;
            var intMaxAsFloat = (float)uint.MaxValue;

            Seed = new JSONStorableFloat
            (
                "Seed",
                seedDefaultValue,
                (selectedSeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.randomSeed = (uint)selectedSeed;
                    }
                },
                intMinAsFloat,
                intMaxAsFloat
            );
            Seed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.randomSeed : seedDefaultValue);

            _particleEditorScript.CreateSlider(Seed, true);
            Seed.slider.wholeNumbers = true;

            _particleEditorScript.RegisterFloat(Seed);

            // Reseed Button
            ReseedButton = _particleEditorScript.CreateButton("Reseed", true);
            ReseedButton.button.onClick.AddListener(() =>
            {
                if (Seed != null)
                {
                    AutoRandomSeed.SetVal(false);
                    Seed.SetVal(GetRandomUInt());
                }
            });

            // Stop Action Popup
            StopAction = new JSONStorableStringChooser
            (
                "StopAction",
                new List<string>() { "None", "Disable", "Destroy", "Callback" },
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystem
                    ? ((ParticleSystemStopAction)_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.stopAction).ToString()
                    : ((ParticleSystemStopAction)ParticleSystemStopAction.None).ToString(),
                "Stop Action",
                (selectedStopAction) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        switch (selectedStopAction)
                        {
                            case "None":
                                main.stopAction = ParticleSystemStopAction.None;
                                break;
                            case "Disable":
                                main.stopAction = ParticleSystemStopAction.Disable;
                                break;
                            case "Destroy":
                                main.stopAction = ParticleSystemStopAction.Destroy;
                                break;
                            case "Callback":
                                main.stopAction = ParticleSystemStopAction.Callback;
                                break;
                        }
                    }
                }
            );

            _particleEditorScript.CreatePopup(StopAction, true);
            _particleEditorScript.RegisterStringChooser(StopAction);
        }

        private float GetRandomUInt()
        {
            Random random = new Random();
            float sample = random.Next(0, 100);
            uint thirtyBits = (uint)random.Next(1 << 30);
            uint twoBits = (uint)random.Next(1 << 2);
            uint fullRange = (thirtyBits << 2) | twoBits;

            if (sample >= 50)
            {
                return (float)fullRange * -1;
            }

            return (float)fullRange;
        }

    }

}