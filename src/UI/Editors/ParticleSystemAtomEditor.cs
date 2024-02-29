using ICannotDie.Plugins.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ICannotDie.Plugins.UI.Editors
{
    /// <summary>
    /// Editor for Particle System Atom data.
    /// Includes the Add, Find, Select & Remove buttons, and the Particle System chooser
    /// </summary>
    public class ParticleSystemAtomEditor : EditorBase
    {
        public JSONStorableBool CreatePluginOnAdd;
        public JSONStorableString ParticleSystemAtomsLabel;
        public UIDynamicButton AddParticleSystemButton;
        public UIDynamicButton FindParticleSystemsButton;
        public JSONStorableStringChooser ParticleSystemChooser;
        public UIDynamicButton SelectParticleSystemAtomButton;
        public UIDynamicButton RemoveSelectedParticleSystemButton;

        public UIDynamicButton DebugButton;
        public UIDynamicButton DebugButton2;

        private readonly ParticleEditor _particleEditor;

        public ParticleSystemAtomEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemAtomEditor), nameof(Clear), "starting");

            _particleEditor.RemoveToggle(CreatePluginOnAdd);
            _particleEditor.RemoveTextField(ParticleSystemAtomsLabel);
            _particleEditor.RemoveTextField(ParticleSystemAtomsLabel);
            _particleEditor.RemoveButton(AddParticleSystemButton);
            _particleEditor.RemoveButton(FindParticleSystemsButton);
            _particleEditor.RemovePopup(ParticleSystemChooser);
            _particleEditor.RemoveButton(SelectParticleSystemAtomButton);
            _particleEditor.RemoveButton(RemoveSelectedParticleSystemButton);

            if (_particleEditor.EnableDebug)
            {
                _particleEditor.RemoveButton(DebugButton);
                _particleEditor.RemoveButton(DebugButton2);
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemAtomEditor), nameof(Clear), "complete");
        }

        public override void Build()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemAtomEditor), nameof(Build), "starting");

            ParticleSystemAtomsLabel = CreateLabel("ParticleSystemAtomsLabel", "Particle System Atoms", false);

            _particleEditor.CreateToggle(CreatePluginOnAdd);

            // Add Particle System Button
            AddParticleSystemButton = _particleEditor.CreateButton("Add Particle System");
            AddParticleSystemButton.button.onClick.AddListener(() =>
            {
                _particleEditor.StartCoroutine(_particleEditor.ParticleSystemManager.CreateAtomCoroutine());
            });

            // Find Particle Systems Button
            FindParticleSystemsButton = _particleEditor.CreateButton("Find Particle Systems");
            FindParticleSystemsButton.button.onClick.AddListener(() =>
            {
                _particleEditor.ParticleSystemManager.FindParticleSystems();
                _particleEditor.UIManager.BuildUI();
            });

            // Particle System Chooser
            _particleEditor.CreatePopup(ParticleSystemChooser);

            // Only show select/remove buttons if we have a current atom
            if (_particleEditor.ParticleSystemManager.CurrentAtom)
            {
                // Select Particle System Atom Button
                SelectParticleSystemAtomButton = _particleEditor.CreateButton("Select Particle System Atom");
                SelectParticleSystemAtomButton.button.onClick.AddListener(() =>
                {
                    SuperController.singleton.SelectController(_particleEditor.ParticleSystemManager.CurrentAtom.uid, Constants.ControlObjectName);
                });

                // Remove Particle System Button
                RemoveSelectedParticleSystemButton = _particleEditor.CreateButton("Remove Selected Particle System");
                RemoveSelectedParticleSystemButton.button.onClick.AddListener(() =>
                {
                    _particleEditor.StartCoroutine(_particleEditor.ParticleSystemManager.RemoveAtomCoroutine(_particleEditor.ParticleSystemManager.CurrentAtom.uid));
                });
            }

            if (_particleEditor.EnableDebug)
            {
                // Debug Button
                DebugButton = _particleEditor.CreateButton("Test mesh renderer");
                DebugButton.button.onClick.AddListener(() =>
                {
                    if (_particleEditor && _particleEditor.ParticleSystemManager && _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer)
                    {



                    }

                    var particleSystem = _particleEditor.ParticleSystemManager.CurrentParticleSystem;
                    var renderer = _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer;
                    var meshes = _particleEditor.containingAtom.GetComponentsInChildren<Mesh>();
                    var meshRenderers = _particleEditor.containingAtom.GetComponentsInChildren<MeshRenderer>();
                    var skinnedMeshRenderers = _particleEditor.containingAtom.GetComponentsInChildren<SkinnedMeshRenderer>();

                    var shape = particleSystem.shape;

                    shape.enabled = true;

                    Utility.LogMessage($"{meshes.Count()} meshes found");
                    Utility.LogMessage($"{meshRenderers.Count()} meshRenderers found");
                    Utility.LogMessage($"{skinnedMeshRenderers.Count()} skinnedMeshRenderers found");

                    shape.shapeType = ParticleSystemShapeType.MeshRenderer;
                    shape.meshShapeType = ParticleSystemMeshShapeType.Triangle;
                    shape.meshRenderer = meshRenderers[0];

                    if (shape.meshRenderer = meshRenderers[0])
                    {
                        shape.meshRenderer = meshRenderers[1];
                    }
                    else if (shape.meshRenderer = meshRenderers[1])
                    {
                        shape.meshRenderer = meshRenderers[2];
                    }
                    else if (shape.meshRenderer = meshRenderers[2])
                    {
                        shape.meshRenderer = meshRenderers[3];
                    }
                    else if (shape.meshRenderer = meshRenderers[3])
                    {
                        shape.meshRenderer = meshRenderers[0];
                    }


                    //shape.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
                    //shape.meshShapeType = ParticleSystemMeshShapeType.Triangle;
                    //shape.skinnedMeshRenderer = skinnedMeshRenderers[0];



                    //renderer.mesh = mesh;
                    //renderer.renderMode = ParticleSystemRenderMode.Mesh;

                    //renderer.mesh = null;
                    //renderer.renderMode = ParticleSystemRenderMode.Billboard;
                });

                DebugButton2 = _particleEditor.CreateButton("Test lights");
                DebugButton2.button.onClick.AddListener(() =>
                {
                    if (_particleEditor && _particleEditor.ParticleSystemManager && _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer)
                    {



                    }

                    var particleSystem = _particleEditor.ParticleSystemManager.CurrentParticleSystem;
                    var renderer = _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer;
                    var meshes = _particleEditor.containingAtom.GetComponentsInChildren<Mesh>();
                    var meshRenderers = _particleEditor.containingAtom.GetComponentsInChildren<MeshRenderer>();
                    var skinnedMeshRenderers = _particleEditor.containingAtom.GetComponentsInChildren<SkinnedMeshRenderer>();

                    var lights = particleSystem.lights;
                    lights.enabled = false;
                    //lights.maxLights = 8;
                    //lights.useRandomDistribution = true;

                    //var lightObject = new GameObject("light");
                    //var light = lightObject.AddComponent<Light>();
                    //light.enabled = true;
                    //light.color = Color.white;
                    //light.intensity = 2;
                    //light.range = 50;

                    //lights.light = light;

                    var noise = particleSystem.noise;
                    noise.enabled = true;

                    noise.frequency = 0.1f;
                    noise.scrollSpeed = 0.2f;
                    noise.strength = 0.5f;
                    noise.sizeAmount = 1.0f;
                    noise.rotationAmount = 1.0f;
                    noise.octaveCount = 3;
                    noise.octaveScale = 1.0f;
                    noise.octaveMultiplier = 1.0f;
                    noise.quality = ParticleSystemNoiseQuality.High;
                    noise.damping = true;

                });
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemAtomEditor), nameof(Build), "complete");
        }

        public override void RegisterStorables()
        {
            CreatePluginOnAdd = new JSONStorableBool
            (
                "Create Plugin On Add",
                ParticleSystemAtomEditorDefaults.CreatePluginOnAdd
            );

            //CreatePluginOnAdd.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystem ? _particleEditor.ParticleSystemManager.CurrentParticleSystem.isPlaying : ParticleSystemEditorDefaults.IsPlaying);

            _particleEditor.RegisterBool(CreatePluginOnAdd);

            ParticleSystemChooser = new JSONStorableStringChooser
            (
                "ParticleSystemChooser",
                _particleEditor.ParticleSystemManager.ParticleSystemAtoms.Any()
                    ? _particleEditor.ParticleSystemManager.ParticleSystemUids
                    : new List<string>(),
                _particleEditor.ParticleSystemManager.CurrentAtom
                    ? _particleEditor.ParticleSystemManager.CurrentAtom.uid
                    : null,
                "Particle Systems",
                (selectedParticleSystemUid) =>
                {
                    _particleEditor.ParticleSystemManager.SetCurrentAtom(selectedParticleSystemUid);
                    _particleEditor.ParticleSystemManager.FindParticleSystems();
                    _particleEditor.UIManager.BuildUI();
                }
            );

            _particleEditor.RegisterStringChooser(ParticleSystemChooser);
        }

        public override void DeregisterStorables()
        {
            _particleEditor.UIManager.DeregisterBool(CreatePluginOnAdd);
            _particleEditor.UIManager.DeregisterStringChooser(ParticleSystemChooser);
        }
    }
}
