using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ICannotDie.Plugins.Common
{
    public static class Utility
    {
        public static void LogError(params object[] args) => SuperController.LogError(Format(args));
        public static void LogMessage(params object[] args) => SuperController.LogMessage(Format(args));
        public static void LogForDebug(bool enableDebug = false, params object[] args)
        {
            if (enableDebug) LogMessage(args);
        }

        private static string Format(IEnumerable<object> args) => $"{nameof(ParticleEditor)}: {string.Join(" ", args.Select(arg => arg.ToString()).ToArray())}";

        /// <summary>
        /// Get the next available uid
        /// </summary>
        /// <param name="prefix">The prefix to be used in the uid</param>
        /// <param name="usedUids">A list of uids to check against</param>
        /// <returns>A new uid, with the next available numeric suffix</returns>
        public static string GetNextAtomUID(string prefix, List<string> usedUids)
        {
            if (!usedUids.Contains(prefix))
            {
                return prefix;
            }

            for (int i = 2; i < 1000; i++)
            {
                if (!usedUids.Contains($"{prefix}#{i}"))
                {
                    return $"{prefix}#{i}";
                }
            }

            return $"{prefix}{Guid.NewGuid()}";
        }

        /// <summary>
        /// Gets a random float between uint.MaxValue and -uint.MaxValue
        /// </summary>
        /// <returns>A float between uint.MaxValue and -uint.MaxValue</returns>
        public static float GetRandomUInt()
        {
            System.Random random = new System.Random();
            float sample = random.Next(0, 100);
            uint thirtyBits = (uint)random.Next(1 << 30);
            uint twoBits = (uint)random.Next(1 << 2);
            uint fullRange = (thirtyBits << 2) | twoBits;

            if (sample >= 50)
            {
                return (float)fullRange * -1;
            }

            return (float)fullRange;
        }

        /// <summary>
        /// Creates a Material from the specified texture path and shader name
        /// </summary>
        /// <param name="shaderName">The name of the shader</param>
        /// <param name="texturePath">The path to the texture</param>
        /// <returns>A <see cref="Material"/> configured with the specified texture and shader/></returns>
        public static Material GetMaterial(string shaderName, string texturePath)
        {
            Texture2D texture2D = TextureLoader.LoadTexture(texturePath);

            var material = new Material(Shader.Find(shaderName))
            {
                mainTexture = texture2D
            };

            return material;
        }

        // Macgruber PostMagic
        // Get directory path where the plugin is located. Based on Alazi's & VAMDeluxe's method.
        public static string GetPluginPath(MVRScript self)
        {
            var id = self.name.Substring(0, self.name.IndexOf('_'));
            var filename = self.manager.GetJSON()["plugins"][id].Value;

            return filename.Substring(0, filename.LastIndexOfAny(new char[] { '/', '\\' }));
        }

        // Macgruber PostMagic
        // Get path prefix of the package that contains our plugin.
        public static string GetPackagePath(MVRScript self)
        {
            var filename = GetPluginPath(self);
            var index = filename.IndexOf(":/");

            return index >= 0 ? filename.Substring(0, index + 2) : string.Empty;
        }

    }
}