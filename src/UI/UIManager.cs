using UnityEngine;
using UnityEngine.UI;
using MeshVR;
using System.Linq;
using System.Collections.Generic;
using MVR.FileManagementSecure;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.ParticleSystems;

namespace ICannotDie.Plugins.UI
{
    public class UIManager
    {
        private ParticleEditor ParticleEditor;

        // UI
        public UIDynamicButton AddParticleSystemButton;
        public UIDynamicButton FindParticleSystemsButton;
        public JSONStorableStringChooser ParticleSystemChooser;
        private string _previouslySelectedParticleSystemUid = null;
        private UIDynamicButton SelectParticleSystemAtomButton;
        private UIDynamicButton RemoveSelectedParticleSystemButton;

        // Particle System Main
        public JSONStorableString MainLabel;
        public JSONStorableBool IsPlaying;
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

        // Particle System Renderer
        public UIDynamicButton SelectParticleImageButton;
        private string _lastAccessedDirectoryPath = "";

        public UIManager(ParticleEditor particleEditor)
        {
            ParticleEditor = particleEditor;
        }

        private void ClearUI()
        {
            RemoveButton(AddParticleSystemButton);
            RemoveButton(FindParticleSystemsButton);

            if (ParticleSystemChooser != null)
            {
                RemovePopup(ParticleSystemChooser);
                DeregisterStringChooser(ParticleSystemChooser);
            }

            RemoveButton(SelectParticleSystemAtomButton);
            RemoveButton(RemoveSelectedParticleSystemButton);

            // Particle System Main
            if (MainLabel != null)
            {
                RemoveTextField(MainLabel);
            }

            if (IsPlaying != null)
            {
                RemoveToggle(IsPlaying);
                DeregisterBool(IsPlaying);
            }

            if (IsLooping != null)
            {
                RemoveToggle(IsLooping);
                DeregisterBool(IsLooping);
            }

            if (Prewarm != null)
            {
                RemoveToggle(Prewarm);
                DeregisterBool(Prewarm);
            }

            if (Duration != null)
            {
                RemoveSlider(Duration);
                DeregisterFloat(Duration);
            }

            if (StartDelay != null)
            {
                RemoveSlider(StartDelay);
                DeregisterFloat(StartDelay);
            }

            if (StartDelayMultiplier != null)
            {
                RemoveSlider(StartDelayMultiplier);
                DeregisterFloat(StartDelayMultiplier);
            }

            if (StartLifetime != null)
            {
                RemoveSlider(StartLifetime);
                DeregisterFloat(StartLifetime);
            }

            if (StartLifetimeMultiplier != null)
            {
                RemoveSlider(StartLifetimeMultiplier);
                DeregisterFloat(StartLifetimeMultiplier);
            }

            if (StartSpeed != null)
            {
                RemoveSlider(StartSpeed);
                DeregisterFloat(StartSpeed);
            }

            if (StartSpeedMultiplier != null)
            {
                RemoveSlider(StartSpeedMultiplier);
                DeregisterFloat(StartSpeedMultiplier);
            }

            if (StartSize != null)
            {
                RemoveSlider(StartSize);
                DeregisterFloat(StartSize);
            }

            // Particle System Renderer
            RemoveButton(SelectParticleImageButton);
        }

        public void BuildUI()
        {
            SuperController.LogError("Entered BuildUI");

            ClearUI();

            // Add Particle System Button
            AddParticleSystemButton = CreateButton("Add Particle System");
            AddParticleSystemButton.button.onClick.AddListener(() =>
            {
                StartCoroutine(ParticleEditor.ParticleSystemManager.CreateAtomCoroutine());
            });

            // Find Particle Systems Button
            FindParticleSystemsButton = CreateButton("Find Particle Systems");
            FindParticleSystemsButton.button.onClick.AddListener(() =>
            {
                ParticleEditor.ParticleSystemManager.FindParticleSystems();
                BuildUI();
            });

            // Particle System Chooser
            ParticleSystemChooser = new JSONStorableStringChooser
            (
                "ParticleSystemChooser",
                ParticleEditor.ParticleSystemManager.ParticleSystemUids,
                ParticleEditor.ParticleSystemManager.CurrentAtom ? ParticleEditor.ParticleSystemManager.CurrentAtom.uid : null,
                "Particle Systems",
                (selectedParticleSystemUid) =>
                {
                    ParticleEditor.ParticleSystemManager.SetCurrentAtom(selectedParticleSystemUid);
                    ParticleEditor.ParticleSystemManager.FindParticleSystems();
                    BuildUI();
                }
            );

            CreatePopup(ParticleSystemChooser);
            RegisterStringChooser(ParticleSystemChooser);

            // Select Particle System Atom Button
            SelectParticleSystemAtomButton = CreateButton("Select Particle System Atom");
            SelectParticleSystemAtomButton.button.onClick.AddListener(() =>
            {
                if (ParticleEditor.ParticleSystemManager.CurrentAtom != null)
                {
                    SuperController.singleton.SelectController(ParticleEditor.ParticleSystemManager.CurrentAtom.uid, "control");
                }
            });

            // Remove Particle System Button
            RemoveSelectedParticleSystemButton = CreateButton("Remove Selected Particle System");
            RemoveSelectedParticleSystemButton.button.onClick.AddListener(() =>
            {
                StartCoroutine(ParticleEditor.ParticleSystemManager.RemoveAtomCoroutine(ParticleEditor.ParticleSystemManager.CurrentAtom.uid));
            });

            // Main Label
            MainLabel = CreateLabel("mainLabel", "Main", true);

            // Is Playing Toggle
            var isPlayingDefaultValue = true;
            IsPlaying = new JSONStorableBool
            (
                "Is Playing",
                isPlayingDefaultValue,
                (isPlaying) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (isPlaying)
                        {
                            ParticleEditor.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            ParticleEditor.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                    }
                }
            );
            IsPlaying.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.isPlaying : isPlayingDefaultValue);

            CreateToggle(IsPlaying, true);
            RegisterBool(IsPlaying);

            // Is Looping Toggle
            var isLoopingDefaultValue = true;
            IsLooping = new JSONStorableBool
            (
                "Is Looping",
                isLoopingDefaultValue,
                (isLooping) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.loop = isLooping;
                    }
                }
            );
            IsLooping.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.loop : isLoopingDefaultValue);

            CreateToggle(IsLooping, true);
            RegisterBool(IsLooping);

            // Prewarm
            var prewarmDefaultValue = false;
            Prewarm = new JSONStorableBool
            (
                "Prewarm",
                prewarmDefaultValue,
                (prewarm) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.prewarm = prewarm;
                    }
                }
            );
            Prewarm.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.prewarm : prewarmDefaultValue);

            CreateToggle(Prewarm, true);
            RegisterBool(Prewarm);

            // Duration Slider
            var durationDefaultValue = 5.0f;
            Duration = new JSONStorableFloat
            (
                "Duration",
                durationDefaultValue,
                (duration) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;

                        if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem.isPlaying)
                        {
                            ParticleEditor.ParticleSystemManager.CurrentParticleSystem.Stop();
                            main.duration = duration;
                            ParticleEditor.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            main.duration = duration;
                        }
                    }
                },
                0f,
                60.0f
            );
            Duration.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.duration : durationDefaultValue);

            CreateSlider(Duration, true);
            RegisterFloat(Duration);

            // Start Delay Slider - MinMaxCurve
            var startDelayDefaultValue = 0f;
            StartDelay = new JSONStorableFloat
            (
                "Start Delay",
                startDelayDefaultValue,
                (startDelay) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelay = startDelay;
                    }
                },
                0f,
                60.0f
            );
            StartDelay.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startDelay.constant : startDelayDefaultValue);

            CreateSlider(StartDelay, true);
            RegisterFloat(StartDelay);

            // Start Delay Multiplier Slider
            var startDelayMultiplierDefaultValue = 0.0f;
            StartDelayMultiplier = new JSONStorableFloat
            (
                "Start Delay Multiplier",
                startDelayMultiplierDefaultValue,
                (startDelayMultiplier) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelayMultiplier = startDelayMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartDelayMultiplier.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startDelayMultiplier : startDelayMultiplierDefaultValue);

            CreateSlider(StartDelayMultiplier, true);
            RegisterFloat(StartDelayMultiplier);

            // Start Lifetime Slider - MinMaxCurve
            var startLifetimeDefaultValue = 5.0f;
            StartLifetime = new JSONStorableFloat
            (
                "Start Lifetime",
                startLifetimeDefaultValue,
                (startLifetime) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetime = startLifetime;
                    }
                },
                0f,
                60.0f
            );
            StartLifetime.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startLifetime.constant : startLifetimeDefaultValue);

            CreateSlider(StartLifetime, true);
            RegisterFloat(StartLifetime);

            // Start Lifetime Multiplier Slider
            var startLifetimeMultiplierDefaultValue = 5.0f;
            StartLifetimeMultiplier = new JSONStorableFloat
            (
                "Start Lifetime Multiplier",
                startLifetimeMultiplierDefaultValue,
                (startLifetimeMultiplier) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetimeMultiplier = startLifetimeMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartLifetimeMultiplier.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startLifetimeMultiplier : startLifetimeMultiplierDefaultValue);

            CreateSlider(StartLifetimeMultiplier, true);
            RegisterFloat(StartLifetimeMultiplier);

            // Start Speed Slider - MinMaxCurve
            var startSpeedDefaultValue = 5.0f;
            StartSpeed = new JSONStorableFloat
            (
                "Start Speed",
                startSpeedDefaultValue,
                (startSpeed) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeed = startSpeed;
                    }
                },
                0f,
                60.0f
            );
            StartSpeed.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSpeed.constant : startSpeedDefaultValue);

            CreateSlider(StartSpeed, true);
            RegisterFloat(StartSpeed);

            // Start Speed Multiplier Slider
            var startSpeedMultiplierDefaultValue = 5.0f;
            StartSpeedMultiplier = new JSONStorableFloat
            (
                "Start Speed Multiplier",
                startSpeedMultiplierDefaultValue,
                (startSpeedMultiplier) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeedMultiplier = startSpeedMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartSpeedMultiplier.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main.startSpeedMultiplier : startSpeedMultiplierDefaultValue);

            CreateSlider(StartSpeedMultiplier, true);
            RegisterFloat(StartSpeedMultiplier);

            // Start Size Slider
            var startSizeDefaultValue = 1.0f;
            StartSize = new JSONStorableFloat
            (
                "Start Size",
                startSizeDefaultValue,
                (startSize) =>
                {
                    if (ParticleEditor.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = ParticleEditor.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSize = startSize;
                    }
                },
                0f,
                10.0f
            );
            StartSize.SetVal(ParticleEditor.ParticleSystemManager.CurrentParticleSystem ? ParticleEditor.ParticleSystemManager.CurrentParticleSystem.startSize : startSizeDefaultValue);

            CreateSlider(StartSize, true);
            RegisterFloat(StartSize);

            // Select Particle Image Buttom
            SelectParticleImageButton = CreateButton("Select Particle Image", true);
            SelectParticleImageButton.button.onClick.AddListener(() =>
            {
                if (_lastAccessedDirectoryPath == string.Empty)
                {
                    _lastAccessedDirectoryPath = Constants.DefaultShaderTextureFolderPath;
                }

                SuperController.singleton.GetMediaPathDialog
                (
                    (string path) =>
                    {
                        if (!string.IsNullOrEmpty(path))
                        {
                            ParticleEditor.ParticleSystemManager.CurrentParticleSystemRenderer.material = ParticleEditor.ParticleSystemManager.GetMaterial(Constants.ShaderName_ParticlesAdditive, path);
                        }
                    },
                    filter: "png|jpg|jpeg",
                    suggestedFolder: _lastAccessedDirectoryPath,
                    fullComputerBrowse: true,
                    showDirs: true,
                    showKeepOpt: true,
                    fileRemovePrefix: null,
                    hideExtenstion: false,
                    shortCuts: new List<ShortCut>(),
                    browseVarFilesAsDirectories: true,
                    showInstallFolderInDirectoryList: false
                );

            });
        }

        private JSONStorableString CreateLabel(string id, string text, bool isRightSide = false)
        {
            var jsonStorableString = new JSONStorableString(id, text);
            var uiDynamic = CreateTextField(jsonStorableString, isRightSide);
            uiDynamic.height = 12;
            uiDynamic.backgroundColor = Color.clear;
            uiDynamic.textColor = Color.black;
            uiDynamic.UItext.fontSize = 36;
            uiDynamic.UItext.alignment = TextAnchor.LowerCenter;

            var layoutElement = uiDynamic.GetComponent<LayoutElement>();
            layoutElement.minHeight = 0f;
            layoutElement.preferredHeight = 42f;

            return jsonStorableString;
        }

    }

}