using ICannotDie.Plugins.Common;
using MVR.FileManagementSecure;
using System.Collections.Generic;

namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemRendererEditor : EditorBase
    {
        public JSONStorableString RendererLabel;
        public UIDynamicButton SelectParticleTextureButton;
        public JSONStorableString MaterialTexturePath;
        public JSONStorableString MaterialTextureLabel;

        private string _lastAccessedDirectoryPath = "";

        public ParticleSystemRendererEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            _particleEditorScript.RemoveTextField(RendererLabel);
            _particleEditorScript.RemoveTextField(MaterialTextureLabel);
            _particleEditorScript.RemoveButton(SelectParticleTextureButton);
        }

        public override void Build()
        {
            // Renderer Label
            RendererLabel = CreateLabel("RendererLabel", "Renderer", true);

            // Material Texture Label
            MaterialTextureLabel = CreateLabel("MaterialTextureLabel", $"Material Texture: {MaterialTexturePath.val}", true);

            SelectParticleTextureButton = _particleEditorScript.CreateButton("Select Particle Texture", true);
            SelectParticleTextureButton.button.onClick.AddListener(() =>
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
                            MaterialTexturePath.SetVal(path);
                            SetMaterial(ShaderNames.ParticlesAdditive, path);
                        }
                    },
                    filter: Constants.ShaderMaterialTextureAllowedFileTypes,
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

        public override void RegisterStorables()
        {
            // Material Texture Path
            MaterialTexturePath = new JSONStorableString
            (
                "MaterialTexturePath",
                string.Empty,
                (selectedMaterialTexturePath) =>
                {
                    SetMaterial(ShaderNames.ParticlesAdditive, selectedMaterialTexturePath);
                }
            );
            MaterialTexturePath.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer.material.mainTexture.name : GetFullTexturePath());

            _particleEditorScript.RegisterString(MaterialTexturePath);
        }

        public override void DeregisterStorables()
        {
            _particleEditorScript.DeregisterString(MaterialTexturePath);
        }

        private string GetFullTexturePath(string shader = Constants.DefaultShaderTextureFolderPath, string path = Constants.DefaultShaderTextureName)
        {
            return $"{Utility.GetPackagePath(_particleEditorScript)}{shader}/{path}";
        }

        private void SetMaterial(string shader, string path)
        {
            if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer)
            {
                _particleEditorScript.ParticleSystemManager.CurrentParticleSystemRenderer.material = Utility.GetMaterial(shader, path);
            }
        }


    }
}