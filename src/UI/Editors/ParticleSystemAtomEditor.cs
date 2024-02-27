using ICannotDie.Plugins.Common;
using System.Collections.Generic;
using System.Linq;

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

        private readonly ParticleEditor _particleEditor;

        public ParticleSystemAtomEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            _particleEditor.RemoveToggle(CreatePluginOnAdd);
            _particleEditor.RemoveTextField(ParticleSystemAtomsLabel);
            _particleEditor.RemoveButton(AddParticleSystemButton);
            _particleEditor.RemoveButton(FindParticleSystemsButton);
            _particleEditor.RemovePopup(ParticleSystemChooser);
            _particleEditor.RemoveButton(SelectParticleSystemAtomButton);
            _particleEditor.RemoveButton(RemoveSelectedParticleSystemButton);
        }

        public override void Build()
        {
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
