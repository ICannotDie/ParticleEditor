namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemAtomEditor : EditorBase
    {
        public UIDynamicButton AddParticleSystemButton;
        public UIDynamicButton FindParticleSystemsButton;
        public JSONStorableStringChooser ParticleSystemChooser;
        private UIDynamicButton SelectParticleSystemAtomButton;
        private UIDynamicButton RemoveSelectedParticleSystemButton;

        public ParticleSystemAtomEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
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
        }

        public override void Build()
        {
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
                _uiManager.BuildUI();
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
                    _uiManager.BuildUI();
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
        }

    }
}
