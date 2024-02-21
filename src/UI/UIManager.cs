using UnityEngine;
using UnityEngine.UI;
using MeshVR;
using System.Linq;
using System.Collections.Generic;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.ParticleSystems;
using ICannotDie.Plugins.UI.Editors;

namespace ICannotDie.Plugins.UI
{
    public class UIManager
    {
        private ParticleEditor _particleEditorScript;
        private ParticleSystemEditor _particleSystemEditor;
        private ParticleSystemAtomEditor _particleSystemAtomEditor;
        private ParticleSystemRendererEditor _particleSystemRendererEditor;
        private MainModuleEditor _mainModuleEditor;

        public UIManager(ParticleEditor particleEditor)
        {
            _particleEditorScript = particleEditor;

            _particleSystemEditor = new ParticleSystemEditor(_particleEditorScript, this);
            _particleSystemAtomEditor = new ParticleSystemAtomEditor(_particleEditorScript, this);
            _mainModuleEditor = new MainModuleEditor(_particleEditorScript, this);
            _particleSystemRendererEditor = new ParticleSystemRendererEditor(_particleEditorScript, this);

            _particleEditorScript.LogForDebug($"Constructed {nameof(UIManager)}");
        }

        private void ClearUI()
        {
            _particleEditorScript.LogForDebug($"{nameof(UIManager)}: Clearing UI");

            _particleSystemEditor.Clear();
            _particleSystemAtomEditor.Clear();
            _mainModuleEditor.Clear();
            _particleSystemRendererEditor.Clear();

            _particleEditorScript.LogForDebug($"{nameof(UIManager)}: Cleared UI");
        }

        public void BuildUI()
        {
            _particleEditorScript.LogForDebug($"{nameof(UIManager)}: Building UI");

            // Clear before build so we replace existing UI, rather than duplicate it
            ClearUI();

            // Call Build() on all editors
            _particleSystemEditor.Build();
            _particleSystemAtomEditor.Build();
            _mainModuleEditor.Build();
            _particleSystemRendererEditor.Build();

            _particleEditorScript.LogForDebug($"{nameof(UIManager)}: Built UI");
        }

    }

}