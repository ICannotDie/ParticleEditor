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
        public JSONStorableString MaterialTextureHeadingLabel;
        public JSONStorableString MaterialTextureLabel;

        private readonly ParticleEditor _particleEditor;

        private string _lastAccessedDirectoryPath = "";

        public ParticleSystemRendererEditor(ParticleEditor particleEditor) : base(particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public override void Clear()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemRendererEditor), nameof(Clear), "starting");

            _particleEditor.RemoveTextField(RendererLabel);
            _particleEditor.RemoveTextField(MaterialTextureHeadingLabel);
            _particleEditor.RemoveTextField(MaterialTextureLabel);
            _particleEditor.RemoveButton(SelectParticleTextureButton);

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemRendererEditor), nameof(Clear), "complete");
        }

        public override void Build()
        {
            if (!_particleEditor)
            {
                return;
            }

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemRendererEditor), nameof(Build), "starting");

            // Renderer Label
            RendererLabel = CreateLabel("RendererLabel", "Renderer", true);

            // Material Texture Label
            MaterialTextureHeadingLabel = CreateHeadingLabel("MaterialTextureHeadingLabel", $"Material Texture", true);
            MaterialTextureLabel = CreateUrlLabel("MaterialTextureLabel", $"{MaterialTexturePath.val}", true);

            SelectParticleTextureButton = _particleEditor.CreateButton("Select Particle Texture", true);
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
                            _particleEditor.UIManager.BuildUI();
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

            Utility.LogForDebug(_particleEditor.enabled, nameof(ParticleSystemRendererEditor), nameof(Build), "complete");

        }

        public override void RegisterStorables()
        {
            Utility.LogMessage(nameof(ParticleSystemRendererEditor), nameof(RegisterStorables), "starting");

            // Material Texture Path
            MaterialTexturePath = new JSONStorableString
            (
                "MaterialTexturePath",
                string.Empty,
                (selectedMaterialTexturePath) =>
                {
                    if (MaterialTexturePath.val != null)
                    {
                        SetMaterial(ShaderNames.ParticlesAdditive, MaterialTexturePath.val);
                    }
                    else
                    {
                        SetMaterial(ShaderNames.ParticlesAdditive, selectedMaterialTexturePath);
                    }
                }
            );

            Utility.LogMessage(nameof(ParticleSystemRendererEditor), nameof(RegisterStorables), "setting value");

            if (_particleEditor && _particleEditor.ParticleSystemManager && _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer)
            {
                MaterialTexturePath.SetVal(_particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer.material.mainTexture.name);
            }
            else
            {
                MaterialTexturePath.SetVal(GetFullTexturePath());
            }

            Utility.LogMessage(nameof(ParticleSystemRendererEditor), nameof(RegisterStorables), nameof(MaterialTexturePath), "set to"); //, MaterialTexturePath.val);

            _particleEditor.RegisterString(MaterialTexturePath);
        }

        public override void DeregisterStorables()
        {
            _particleEditor.DeregisterString(MaterialTexturePath);
        }

        private string GetFullTexturePath(string shader = Constants.DefaultShaderTextureFolderPath, string path = Constants.DefaultShaderTextureName)
        {
            return $"{Utility.GetPackagePath(_particleEditor)}{shader}/{path}";
        }

        private void SetMaterial(string shader, string path)
        {
            if (_particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer)
            {
                _particleEditor.ParticleSystemManager.CurrentParticleSystemRenderer.material = Utility.GetMaterial(shader, path);
            }
        }


    }
}