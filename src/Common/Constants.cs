namespace ICannotDie.Plugins.Common
{

    public static class Constants
    {
        public const string UserConfirmCanvas = "UserConfirmCanvas";
        public const string RootObjectName = "ParticleSystem";
        public const string RescaleObjectName = "rescaleObject";
        public const string ControlObjectName = "control";
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
        public const bool IsLooping = true;
        public const bool Prewarm = false;
        public const float Duration = 5.0f;
        public const float StartDelay = 0.0f;
        public const float StartDelayMultiplier = 1.0f;
        public const float StartLifetime = 5.0f;
        public const float StartLifetimeMultiplier = 1.0f;
        public const float StartSpeed = 5.0f;
        public const float StartSpeedMultiplier = 1.0f;
        public const float StartSize = 1.0f;
        public const float StartSizeMultiplier = 1.0f;
        public const bool StartRotation3D = false;
        public const float StartRotationX = 0.0f;
        public const float StartRotationXMultiplier = 0.0f;
        public const float StartRotationY = 0.0f;
        public const float StartRotationYMultiplier = 0.0f;
        public const float StartRotationZ = 0.0f;
        public const float StartRotationZMultiplier = 0.0f;
        public const float StartRotation = 0.0f;
        public const float StartRotationMultiplier = 0.0f;
        public const float FlipRotation = 0.0f;
        public const float StartColorH = 255f;
        public const float StartColorS = 255f;
        public const float StartColorV = 255f;
        public const float GravityModifier = 0.0f;
        public const float GravityModifierMultiplier = 0.0f;
        public const float SimulationSpeed = 1.0f;
        public const bool PlayOnAwake = false;
        public const float MaxParticles = 1000.0f;
        public const bool AutoRandomSeed = true;
        public const float Seed = 0.0f;

        public static HSVColor StartColor()
        {
            var startColor = new HSVColor()
            {
                H = StartColorH,
                S = StartColorS,
                V = StartColorV
            };

            return startColor;
        }
    }
    public static class ParticleSystemRendererEditorDefaults
    {

    }

}