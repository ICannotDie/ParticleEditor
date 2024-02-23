using ICannotDie.Plugins.Common;
using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemAtomEditor : EditorBase
    {
        public JSONStorableString ParticleSystemAtomsLabel;
        public UIDynamicButton AddParticleSystemButton;
        public UIDynamicButton FindParticleSystemsButton;
        public JSONStorableStringChooser ParticleSystemChooser;
        public UIDynamicButton SelectParticleSystemAtomButton;
        public UIDynamicButton RemoveSelectedParticleSystemButton;

        public ParticleSystemAtomEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            _particleEditorScript.RemoveTextField(ParticleSystemAtomsLabel);
            _particleEditorScript.RemoveButton(AddParticleSystemButton);
            _particleEditorScript.RemoveButton(FindParticleSystemsButton);
            _particleEditorScript.RemovePopup(ParticleSystemChooser);
            _particleEditorScript.RemoveButton(SelectParticleSystemAtomButton);
            _particleEditorScript.RemoveButton(RemoveSelectedParticleSystemButton);
        }

        public override void Build()
        {
            Utility.LogMessage("ParticleSystemAtomEditor.Build called");

            ParticleSystemAtomsLabel = CreateLabel("particleSystemAtomsLabel", "Particle System Atoms", false);

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
                _particleEditorScript.UiManager.BuildUI();
            });

            ParticleSystemChooser = new JSONStorableStringChooser
            (
                "ParticleSystemChooser",
                _particleEditorScript.ParticleSystemManager.ParticleSystemUids.Any() ? _particleEditorScript.ParticleSystemManager.ParticleSystemUids : new List<string>(),
                _particleEditorScript.ParticleSystemManager.CurrentAtom ? _particleEditorScript.ParticleSystemManager.CurrentAtom.uid : null,
                "Particle Systems",
                (selectedParticleSystemUid) =>
                {
                    _particleEditorScript.ParticleSystemManager.SetCurrentAtom(selectedParticleSystemUid);
                    _particleEditorScript.ParticleSystemManager.FindParticleSystems();
                    _particleEditorScript.UiManager.BuildUI();
                }
            );

            _particleEditorScript.CreatePopup(ParticleSystemChooser);

            // Select Particle System Atom Button
            SelectParticleSystemAtomButton = _particleEditorScript.CreateButton("Select Particle System Atom");
            SelectParticleSystemAtomButton.button.onClick.AddListener(() =>
            {
                SuperController.singleton.SelectController(_particleEditorScript.ParticleSystemManager.CurrentAtom.uid, Constants.ControlObjectName);
            });

            // Remove Particle System Button
            RemoveSelectedParticleSystemButton = _particleEditorScript.CreateButton("Remove Selected Particle System");
            RemoveSelectedParticleSystemButton.button.onClick.AddListener(() =>
            {
                _particleEditorScript.StartCoroutine(_particleEditorScript.ParticleSystemManager.RemoveAtomCoroutine(_particleEditorScript.ParticleSystemManager.CurrentAtom.uid));
            });
        }

        public override void DeregisterStorables()
        {
            _particleEditorScript.DeregisterStringChooser(ParticleSystemChooser);
        }

        public override void RegisterStorables()
        {
            ParticleSystemChooser = new JSONStorableStringChooser
            (
                "ParticleSystemChooser",
                new List<string>(),
                null,
                "Particle Systems",
                (string selectedParticleSystemUid) => { }
            );

            _particleEditorScript.RegisterStringChooser(ParticleSystemChooser);
        }
    }
}
