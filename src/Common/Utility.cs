using System;
using System.Collections.Generic;
using System.Linq;
using ICannotDie.Plugins.Common.Extensions;

namespace ICannotDie.Plugins.Common
{
    public static class Utility
    {
        public static void LogError(params object[] args) => SuperController.LogError(Format(args));
        public static void LogMessage(params object[] args) => SuperController.LogMessage(Format(args));
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
        /// Get the atom before the specified one in the list 
        /// Circular - if the first atom in list is specified, this will return the last atom in the list
        /// </summary>
        /// <param name="atom">The atom whose position we will start at</param>
        /// <param name="list">The list of atoms to check against</param>
        /// <returns>An atom in the specified list that appears immediately before the specified atom, or the last atom in the list if the first was specified</returns>
        public static Atom GetAtomBefore(Atom atom, List<Atom> list)
        {
            return list
            .TakeWhile(x => x.UidAsInt() != atom.UidAsInt())
            .DefaultIfEmpty(list.Any() ? list[list.Count - 1] : null)
            .LastOrDefault();
        }

        /// <summary>
        /// Get the atom after the specified one in the list 
        /// Circular - if the last atom in list is specified, this will return the first atom in the list
        /// </summary>
        /// <param name="atom">The atom whose position we will start at</param>
        /// <param name="list">The list of atoms to check against</param>
        /// <returns>An atom in the specified list that appears immediately after the specified atom, or the first atom in the list if the last was specified</returns>
        public static Atom GetAtomAfter(Atom atom, List<Atom> list)
        {
            return list
            .SkipWhile(x => x.UidAsInt() != atom.UidAsInt())
            .Skip(1)
            .DefaultIfEmpty(list.Any() ? list[0] : null)
            .FirstOrDefault();
        }
    }
}