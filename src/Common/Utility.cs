using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.Common
{
    public static class Utility
    {
        public static void LogError(params object[] args) => SuperController.LogError(Format(args));
        public static void LogMessage(params object[] args) => SuperController.LogMessage(Format(args));
        private static string Format(IEnumerable<object> args) => $"{nameof(ParticleEditor)}: {string.Join(" ", args.Select(arg => arg.ToString()).ToArray())}";
    }
}