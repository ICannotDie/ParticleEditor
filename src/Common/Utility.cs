using System;
using System.Collections.Generic;
using System.Linq;

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

    }
}