using ICannotDie.Plugins.UI.Editors;
using System.Collections.Generic;

namespace ICannotDie.Plugins.UI
{
    public class UIManager : JSONStorable
    {
        private ParticleSystemEditor _particleSystemEditor;
        private ParticleSystemAtomEditor _particleSystemAtomEditor;
        private ParticleSystemRendererEditor _particleSystemRendererEditor;
        private MainModuleEditor _mainModuleEditor;
        private List<EditorBase> _editors = new List<EditorBase>();
        private ParticleEditor _particleEditor;

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public void Initialise()
        {
            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditor);
            _editors.Add(_particleSystemAtomEditor);

            _particleSystemEditor = new ParticleSystemEditor(_particleEditor);
            _editors.Add(_particleSystemEditor);

            _mainModuleEditor = new MainModuleEditor(_particleEditor);
            _editors.Add(_mainModuleEditor);

            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditor);
            _editors.Add(_particleSystemRendererEditor);
        }

        public void RegisterStorables()
        {
            _editors.ForEach(editor => editor.RegisterStorables());
        }

        private void ClearUI()
        {
            _editors.ForEach(editor => editor.Clear());
        }

        public void BuildUI()
        {
            ClearUI();
            _editors.ForEach(editor => editor.Build());
        }

        public void Deregister(JSONStorableBool storable)
        {
            if (storable != null) DeregisterBool(storable);
        }

        public void Deregister(JSONStorableFloat storable)
        {
            if (storable != null) DeregisterFloat(storable);
        }

        public void Deregister(JSONStorableStringChooser storable)
        {
            if (storable != null) DeregisterStringChooser(storable);
        }

        public void Deregister(JSONStorableColor storable)
        {
            if (storable != null) DeregisterColor(storable);
        }

        public void OnDestroy()
        {
            _editors.ForEach(editor => editor.DeregisterStorables());
        }

    }

}