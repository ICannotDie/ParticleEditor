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

        public readonly Dictionary<System.Type, IEditor> Editors = new Dictionary<System.Type, IEditor>();

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;

            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditor);
            Editors.Add(typeof(ParticleSystemAtomEditor), _particleSystemAtomEditor);

            _particleSystemEditor = new ParticleSystemEditor(_particleEditor);
            Editors.Add(typeof(ParticleSystemEditor), _particleSystemEditor);

            _mainModuleEditor = new MainModuleEditor(_particleEditor);
            Editors.Add(typeof(MainModuleEditor), _mainModuleEditor);

            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditor);
            Editors.Add(typeof(ParticleSystemRendererEditor), _particleSystemRendererEditor);

            _emissionModuleEditor = new EmissionModuleEditor(_particleEditor);
            Editors.Add(typeof(EmissionModuleEditor), _emissionModuleEditor);
        }

        private void Destroy()
        {
            Utility.LogMessage(nameof(UIManager), nameof(Destroy), "editorsBefore", Editors.Count);
            Editors.ToList().ForEach(editor => editor.Value.Clear());
            Editors.ToList().ForEach(editor => editor.Value.DeregisterStorables());
            Utility.LogMessage(nameof(UIManager), nameof(Destroy), "editorsAfter", Editors.Count);
        }

        #region UI

        public void ClearUI()
        {
            Utility.LogMessage(nameof(UIManager), nameof(ClearUI), "clearing all editors: ", Editors.Count);
            Editors.ToList().ForEach(editor => editor.Value.Clear());
            Utility.LogMessage(nameof(UIManager), nameof(ClearUI), "cleared all editors: ", Editors.Count);
        }

        public void BuildUI()
        {
            ClearUI();

            if (_particleEditor?.ParticleSystemManager?.CurrentAtom != null)
            {
                // If we have a current atom, build all editors
                Utility.LogMessage(nameof(UIManager), nameof(BuildUI), "building all editors: ", Editors.Count);
                Editors.ToList().ForEach(editor => editor.Value.Build());
            }
            else
            {
                // If we don't have a current atom, only build the atom editor
                Utility.LogMessage(nameof(UIManager), nameof(BuildUI), "building atom editor only: ", Editors.Count);
                Editors.Single(x => x.Value is ParticleSystemAtomEditor).Value.Build();
            }

            Utility.LogMessage(nameof(UIManager), nameof(BuildUI), "build complete for editors: ", Editors.Count);
        }

        #endregion

        #region Storables

        public void RegisterStorables()
        {
            Utility.LogMessage(nameof(UIManager), nameof(RegisterStorables), "starting for all editors: ", Editors.Count);
            Editors.ToList().ForEach(editor => editor.Value.RegisterStorables());
            Utility.LogMessage(nameof(UIManager), nameof(RegisterStorables), "complete for all editors: ", Editors.Count);
        }

        public void DeregisterStorables()
        {
            Utility.LogMessage(nameof(UIManager), nameof(DeregisterStorables), "starting for all editors: ", Editors.Count);
            Editors.ToList().ForEach(editor => editor.Value.DeregisterStorables());
            Utility.LogMessage(nameof(UIManager), nameof(DeregisterStorables), "complete for all editors: ", Editors.Count);
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