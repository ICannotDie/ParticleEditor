using UnityEngine;
using MVR.FileManagementSecure;
using ICannotDie.Plugins;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.UI;
using System.Collections.Generic;

namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemRendererEditor : EditorBase
    {
        public JSONStorableString RendererLabel;
        public UIDynamicButton SelectParticleImageButton;

        private string _lastAccessedDirectoryPath = "";

        public ParticleSystemRendererEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            if (RendererLabel != null)
            {
                _particleEditorScript.RemoveTextField(RendererLabel);
            }

            _particleEditorScript.RemoveButton(SelectParticleImageButton);
        }

        public override void Build()
        {
            // Renderer Label
            RendererLabel = CreateLabel("rendererLabel", "Renderer", true);

            SelectParticleImageButton = _particleEditorScript.CreateButton("Select Particle Image", true);
            SelectParticleImageButton.button.onClick.AddListener(() =>
            {
                if (_lastAccessedDirectoryPath == string.Empty)
                {
                    _lastAccessedDirectoryPath = Constants.DefaultShaderTextureFolderPath;
                }

                SuperController.singleton.GetMediaPathDialog
                (
                    (string path) =>
                    {
                        if (!string.IsNullOrEmpty(path))
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer.material = _particleEditorScript.ParticleSystemManager.GetMaterial(Constants.ShaderName_ParticlesAdditive, path);
                        }
                    },
                    filter: Constants.ShaderMaterialTestureAllowedFileTypes,
                    suggestedFolder: _lastAccessedDirectoryPath,
                    fullComputerBrowse: true,
                    showDirs: true,
                    showKeepOpt: true,
                    fileRemovePrefix: null,
                    hideExtenstion: false,
                    shortCuts: new List<ShortCut>(),
                    browseVarFilesAsDirectories: true,
                    showInstallFolderInDirectoryList: false
                );

            });
        }
    }
}