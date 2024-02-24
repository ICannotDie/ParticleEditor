using ICannotDie.Plugins.UI.Editors;
using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.UI
{
    public class UIManager : JSONStorable
    {
        private readonly ParticleEditor _particleEditor;

        private readonly ParticleSystemAtomEditor _particleSystemAtomEditor;
        private readonly ParticleSystemEditor _particleSystemEditor;
        private readonly MainModuleEditor _mainModuleEditor;
        private readonly ParticleSystemRendererEditor _particleSystemRendererEditor;
        private readonly EmissionModuleEditor _emissionModuleEditor;

        private readonly List<IEditor> _editors = new List<IEditor>();

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;

            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditor);
            _editors.Add(_particleSystemAtomEditor);

            _particleSystemEditor = new ParticleSystemEditor(_particleEditor);
            _editors.Add(_particleSystemEditor);

            _mainModuleEditor = new MainModuleEditor(_particleEditor);
            _editors.Add(_mainModuleEditor);

            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditor);
            _editors.Add(_particleSystemRendererEditor);

            _emissionModuleEditor = new EmissionModuleEditor(_particleEditor);
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
                // If we have a current atom, build all editors
                _editors.ForEach(editor => editor.Build());
            }
            else
            {
                // If we don't have a current atom, only build the atom editor
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
            DeregisterStringChooser(storable);
        }

        public void Deregister(JSONStorableColor storable)
        {
            if (storable != null) DeregisterColor(storable);
        }

    }

}