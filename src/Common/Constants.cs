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
        public const string ShaderMaterialTextureAllowedFileTypes = "png|jpg|jpeg";
        public const string DefaultShaderTextureFolderPath = "Custom/Assets/ICannotDie/ParticleEditor";
        public const string DefaultShaderTextureName = "default-particle.png";
    }

    public static class ShaderNames
    {
        public const string ParticlesAdditive = "Particles/Additive";
    }

    public static class SimulationSpaceOptions
    {
        public const string Local = "Local";
        public const string World = "World";
    }

    public static class DeltaTimeOptions
    {
        public const string Scaled = "Scaled";
        public const string Unscaled = "Unscaled";
    }

    public static class ScalingModeOptions
    {
        public const string Hierarchy = "Hierarchy";
        public const string Local = "Local";
        public const string Shape = "Shape";
    }

    public static class EmitterVelocityModeOptions
    {
        public const string Transform = "Transform";
        public const string Rigidbody = "Rigidbody";
    }

    public static class ParticleSystemStopActionOptions
    {
        public const string None = "None";
        public const string Disable = "Disable";
        public const string Destroy = "Destroy";
        public const string Callback = "Callback";
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
        public const float StartColorH = 0.0f;
        public const float StartColorS = 0.0f;
        public const float StartColorV = 100.0f;
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

    public static class EmissionModuleEditorDefaults
    {
        public const bool Enabled = true;
        public const float RateOverDistance = 0.0f;
        public const float RateOverDistanceMultiplier = 1.0f;
        public const float RateOverTime = 10.0f;
        public const float RateOverTimeMultiplier = 1.0f;
        public const float BurstCount = 0.0f;
    }

}