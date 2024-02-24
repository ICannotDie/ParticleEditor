using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.UI.Editors;
using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.UI
{
    public class UIManager : JSONStorable
    {
        private readonly ParticleEditor _particleEditor;

        private ParticleSystemAtomEditor _particleSystemAtomEditor;
        private ParticleSystemEditor _particleSystemEditor;
        private MainModuleEditor _mainModuleEditor;
        private ParticleSystemRendererEditor _particleSystemRendererEditor;
        private EmissionModuleEditor _emissionModuleEditor;

        private readonly Dictionary<System.Type, IEditor> _editors = new Dictionary<System.Type, IEditor>();

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;

            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditor);
            _editors.Add(typeof(ParticleSystemAtomEditor), _particleSystemAtomEditor);

            _particleSystemEditor = new ParticleSystemEditor(_particleEditor);
            _editors.Add(typeof(ParticleSystemEditor), _particleSystemEditor);

            _mainModuleEditor = new MainModuleEditor(_particleEditor);
            _editors.Add(typeof(MainModuleEditor), _mainModuleEditor);

            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditor);
            _editors.Add(typeof(ParticleSystemRendererEditor), _particleSystemRendererEditor);

            _emissionModuleEditor = new EmissionModuleEditor(_particleEditor);
            _editors.Add(typeof(EmissionModuleEditor), _emissionModuleEditor);
        }

        private void Destroy()
        {
            Utility.LogMessage(nameof(UIManager), nameof(Destroy), "editorsBefore", _editors.Count);
            _editors.ToList().ForEach(editor => editor.Value.Clear());
            _editors.ToList().ForEach(editor => editor.Value.DeregisterStorables());
            Utility.LogMessage(nameof(UIManager), nameof(Destroy), "editorsAfter", _editors.Count);
        }

        #region UI

        public void ClearUI()
        {
            _editors.ToList().ForEach(editor => editor.Value.Clear());
        }

        public void BuildUI()
        {
            ClearUI();

            if (_particleEditor.ParticleSystemManager.CurrentAtom)
            {
                // If we have a current atom, build all editors
                _editors.ToList().ForEach(editor => editor.Value.Build());
            }
            else
            {
                // If we don't have a current atom, only build the atom editor
                _editors.Single(x => x.Value is ParticleSystemAtomEditor).Value.Build();
            }
        }

        #endregion

        #region Storables

        public void RegisterStorables()
        {
            _editors.ToList().ForEach(editor => editor.Value.RegisterStorables());
        }

        public void DeregisterStorables()
        {
            _editors.ToList().ForEach(editor => editor.Value.DeregisterStorables());
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

        #endregion

    }

}