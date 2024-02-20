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
        private ParticleEditor _particleEditorScript;

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
            _particleEditorScript = particleEditor;
        }

        private void ClearUI()
        {
            _particleEditorScript.RemoveButton(AddParticleSystemButton);
            _particleEditorScript.RemoveButton(FindParticleSystemsButton);

            if (ParticleSystemChooser != null)
            {
                _particleEditorScript.RemovePopup(ParticleSystemChooser);
                _particleEditorScript.DeregisterStringChooser(ParticleSystemChooser);
            }

            _particleEditorScript.RemoveButton(SelectParticleSystemAtomButton);
            _particleEditorScript.RemoveButton(RemoveSelectedParticleSystemButton);

            // Particle System Main
            if (MainLabel != null)
            {
                _particleEditorScript.RemoveTextField(MainLabel);
            }

            if (IsPlaying != null)
            {
                _particleEditorScript.RemoveToggle(IsPlaying);
                _particleEditorScript.DeregisterBool(IsPlaying);
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

            // Particle System Renderer
            _particleEditorScript.RemoveButton(SelectParticleImageButton);
        }

        public void BuildUI()
        {
            SuperController.LogError("Entered BuildUI");

            ClearUI();

            // Add Particle System Button
            AddParticleSystemButton = _particleEditorScript.CreateButton("Add Particle System");
            AddParticleSystemButton.button.onClick.AddListener(() =>
            {
                _particleEditorScript.StartCoroutine(_particleEditorScript.ParticleSystemManager.CreateAtomCoroutine());
            });

            // Find Particle Systems Button
            FindParticleSystemsButton = _particleEditorScript.CreateButton("Find Particle Systems");
            FindParticleSystemsButton.button.onClick.AddListener(() =>
            {
                _particleEditorScript.ParticleSystemManager.FindParticleSystems();
                BuildUI();
            });

            // Particle System Chooser
            ParticleSystemChooser = new JSONStorableStringChooser
            (
                "ParticleSystemChooser",
                _particleEditorScript.ParticleSystemManager.ParticleSystemUids,
                _particleEditorScript.ParticleSystemManager.CurrentAtom ? _particleEditorScript.ParticleSystemManager.CurrentAtom.uid : null,
                "Particle Systems",
                (selectedParticleSystemUid) =>
                {
                    _particleEditorScript.ParticleSystemManager.SetCurrentAtom(selectedParticleSystemUid);
                    _particleEditorScript.ParticleSystemManager.FindParticleSystems();
                    BuildUI();
                }
            );

            _particleEditorScript.CreatePopup(ParticleSystemChooser);
            _particleEditorScript.RegisterStringChooser(ParticleSystemChooser);

            // Select Particle System Atom Button
            SelectParticleSystemAtomButton = _particleEditorScript.CreateButton("Select Particle System Atom");
            SelectParticleSystemAtomButton.button.onClick.AddListener(() =>
            {
                if (_particleEditorScript.ParticleSystemManager.CurrentAtom != null)
                {
                    SuperController.singleton.SelectController(_particleEditorScript.ParticleSystemManager.CurrentAtom.uid, "control");
                }
            });

            // Remove Particle System Button
            RemoveSelectedParticleSystemButton = _particleEditorScript.CreateButton("Remove Selected Particle System");
            RemoveSelectedParticleSystemButton.button.onClick.AddListener(() =>
            {
                _particleEditorScript.StartCoroutine(_particleEditorScript.ParticleSystemManager.RemoveAtomCoroutine(_particleEditorScript.ParticleSystemManager.CurrentAtom.uid));
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
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (isPlaying)
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
            IsPlaying.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isPlaying : isPlayingDefaultValue);

            _particleEditorScript.CreateToggle(IsPlaying, true);
            _particleEditorScript.RegisterBool(IsPlaying);

            // Is Looping Toggle
            var isLoopingDefaultValue = true;
            IsLooping = new JSONStorableBool
            (
                "Is Looping",
                isLoopingDefaultValue,
                (isLooping) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.loop = isLooping;
                    }
                }
            );
            IsLooping.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.loop : isLoopingDefaultValue);

            _particleEditorScript.CreateToggle(IsLooping, true);
            _particleEditorScript.RegisterBool(IsLooping);

            // Prewarm
            var prewarmDefaultValue = false;
            Prewarm = new JSONStorableBool
            (
                "Prewarm",
                prewarmDefaultValue,
                (prewarm) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.prewarm = prewarm;
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
                (duration) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;

                        if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isPlaying)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                            main.duration = duration;
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
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
            Duration.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.duration : durationDefaultValue);

            _particleEditorScript.CreateSlider(Duration, true);
            _particleEditorScript.RegisterFloat(Duration);

            // Start Delay Slider - MinMaxCurve
            var startDelayDefaultValue = 0f;
            StartDelay = new JSONStorableFloat
            (
                "Start Delay",
                startDelayDefaultValue,
                (startDelay) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelay = startDelay;
                    }
                },
                0f,
                60.0f
            );
            StartDelay.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelay.constant : startDelayDefaultValue);

            _particleEditorScript.CreateSlider(StartDelay, true);
            _particleEditorScript.RegisterFloat(StartDelay);

            // Start Delay Multiplier Slider
            var startDelayMultiplierDefaultValue = 0.0f;
            StartDelayMultiplier = new JSONStorableFloat
            (
                "Start Delay Multiplier",
                startDelayMultiplierDefaultValue,
                (startDelayMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startDelayMultiplier = startDelayMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartDelayMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startDelayMultiplier : startDelayMultiplierDefaultValue);

            _particleEditorScript.CreateSlider(StartDelayMultiplier, true);
            _particleEditorScript.RegisterFloat(StartDelayMultiplier);

            // Start Lifetime Slider - MinMaxCurve
            var startLifetimeDefaultValue = 5.0f;
            StartLifetime = new JSONStorableFloat
            (
                "Start Lifetime",
                startLifetimeDefaultValue,
                (startLifetime) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetime = startLifetime;
                    }
                },
                0f,
                60.0f
            );
            StartLifetime.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetime.constant : startLifetimeDefaultValue);

            _particleEditorScript.CreateSlider(StartLifetime, true);
            _particleEditorScript.RegisterFloat(StartLifetime);

            // Start Lifetime Multiplier Slider
            var startLifetimeMultiplierDefaultValue = 5.0f;
            StartLifetimeMultiplier = new JSONStorableFloat
            (
                "Start Lifetime Multiplier",
                startLifetimeMultiplierDefaultValue,
                (startLifetimeMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startLifetimeMultiplier = startLifetimeMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartLifetimeMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startLifetimeMultiplier : startLifetimeMultiplierDefaultValue);

            _particleEditorScript.CreateSlider(StartLifetimeMultiplier, true);
            _particleEditorScript.RegisterFloat(StartLifetimeMultiplier);

            // Start Speed Slider - MinMaxCurve
            var startSpeedDefaultValue = 5.0f;
            StartSpeed = new JSONStorableFloat
            (
                "Start Speed",
                startSpeedDefaultValue,
                (startSpeed) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeed = startSpeed;
                    }
                },
                0f,
                60.0f
            );
            StartSpeed.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeed.constant : startSpeedDefaultValue);

            _particleEditorScript.CreateSlider(StartSpeed, true);
            _particleEditorScript.RegisterFloat(StartSpeed);

            // Start Speed Multiplier Slider
            var startSpeedMultiplierDefaultValue = 5.0f;
            StartSpeedMultiplier = new JSONStorableFloat
            (
                "Start Speed Multiplier",
                startSpeedMultiplierDefaultValue,
                (startSpeedMultiplier) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSpeedMultiplier = startSpeedMultiplier;
                    }
                },
                0f,
                100.0f
            );
            StartSpeedMultiplier.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main.startSpeedMultiplier : startSpeedMultiplierDefaultValue);

            _particleEditorScript.CreateSlider(StartSpeedMultiplier, true);
            _particleEditorScript.RegisterFloat(StartSpeedMultiplier);

            // Start Size Slider
            var startSizeDefaultValue = 1.0f;
            StartSize = new JSONStorableFloat
            (
                "Start Size",
                startSizeDefaultValue,
                (startSize) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        var main = _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.main;
                        main.startSize = startSize;
                    }
                },
                0f,
                10.0f
            );
            StartSize.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.startSize : startSizeDefaultValue);

            _particleEditorScript.CreateSlider(StartSize, true);
            _particleEditorScript.RegisterFloat(StartSize);

            // Select Particle Image Buttom
            SelectParticleImageButton = _particleEditorScript.CreateButton("Select Particle Image", true);
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
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer.material = _particleEditorScript.ParticleSystemManager.GetMaterial(Constants.ShaderName_ParticlesAdditive, path);
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
            var uiDynamic = _particleEditorScript.CreateTextField(jsonStorableString, isRightSide);
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