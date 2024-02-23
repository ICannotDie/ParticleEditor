namespace ICannotDie.Plugins.Common
{

    public static class Constants
    {
        public const string UserConfirmCanvas = "UserConfirmCanvas";
        public const string RootObjectName = "ParticleSystem";
        public const string RescaleObjectName = "rescaleObject";
        public const string PluginManagerName = "PluginManager";
        public const string EmptyAtomTypeName = "Empty";
        public const string PluginCSListFilename = "ParticleEditor.cslist";
        public const string ShaderMaterialTestureAllowedFileTypes = "png|jpg|jpeg";
        public const string DefaultShaderTextureFolderPath = "Custom/Assets/ICannotDie/ParticleEditor";
        public const string DefaultShaderTextureName = "default-particle.png";
    }

    public static class ShaderNames
    {
        public const string ParticlesAdditive = "Particles/Additive";
    }

    public static class ParticleSystemAtomEditorDefaults
    {

    }

    public static class ParticleSystemEditorDefaults
    {
        public const bool IsPlaying = true;
        public const bool IsStopped = false;
    }

    public static class MainModuleEditorDefaults
    {
        public const float StartColorH = 0f;
        public const float StartColorS = 0f;
        public const float StartColorV = 0f;
    }
    public static class ParticleSystemRendererEditorDefaults
    {

    }

}