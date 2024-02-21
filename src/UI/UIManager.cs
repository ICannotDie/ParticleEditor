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
        }

        private void ClearUI()
        {
            _particleSystemEditor.Clear();
            _particleSystemAtomEditor.Clear();
            _mainModuleEditor.Clear();
            _particleSystemRendererEditor.Clear();
        }

        public void BuildUI()
        {
            // Clear before build so we replace existing UI, rather than duplicate it
            ClearUI();

            // Call Build() on all editors
            _particleSystemEditor.Build();
            _particleSystemAtomEditor.Build();
            _mainModuleEditor.Build();
            _particleSystemRendererEditor.Build();
        }

    }

}