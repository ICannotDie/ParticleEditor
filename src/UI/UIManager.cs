using ICannotDie.Plugins.UI.Editors;
using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.UI
{
    public class UIManager : JSONStorable
    {
        private readonly ParticleSystemAtomEditor _particleSystemAtomEditor;
        private readonly ParticleSystemEditor _particleSystemEditor;
        private readonly MainModuleEditor _mainModuleEditor;
        private readonly ParticleSystemRendererEditor _particleSystemRendererEditor;
        private readonly EmissionModuleEditor _emissionModuleEditor;

        private readonly List<EditorBase> _editors = new List<EditorBase>();
        private readonly ParticleEditor _particleEditor;

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;

            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditor, this);
            _editors.Add(_particleSystemAtomEditor);

            _particleSystemEditor = new ParticleSystemEditor(_particleEditor, this);
            _editors.Add(_particleSystemEditor);

            _mainModuleEditor = new MainModuleEditor(_particleEditor, this);
            _editors.Add(_mainModuleEditor);

            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditor, this);
            _editors.Add(_particleSystemRendererEditor);

            _emissionModuleEditor = new EmissionModuleEditor(_particleEditor, this);
            _editors.Add(_emissionModuleEditor);
        }

        public void RegisterStorables()
        {
            _editors.ForEach(editor => editor.RegisterStorables());
        }

        public void ClearUI()
        {
            _editors.ForEach(editor => editor.Clear());
        }

        public void BuildUI()
        {
            ClearUI();

            if (_particleEditor.ParticleSystemManager.CurrentAtom)
            {
                _editors.ForEach(editor => editor.Build());
            }
            else
            {
                _editors.Single(x => x is ParticleSystemAtomEditor).Build();
            }
        }

        public void Deregister(JSONStorableBool storable)
        {
            if (storable != null) DeregisterBool(storable);
        }

        public void Deregister(JSONStorableString storable)
        {
            if (storable != null) DeregisterString(storable);
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

    }

}