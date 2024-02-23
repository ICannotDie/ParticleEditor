using System.Collections.Generic;
using System.Linq;

namespace ICannotDie.Plugins.Common.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Get the atom before the specified one in the list 
        /// Circular - if the first atom in list is specified, this will return the last atom in the list
        /// </summary>
        /// <param name="atom">The atom whose position we will start at</param>
        /// <param name="list">The list of atoms to check against</param>
        /// <returns>An atom in the specified list that appears immediately before the specified atom, or the last atom in the list if the first was specified</returns>
        public static Atom GetAtomBefore(this List<Atom> list, Atom atom)
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
        public static Atom GetAtomAfter(this List<Atom> list, Atom atom)
        {
            return list
            .SkipWhile(x => x.UidAsInt() != atom.UidAsInt())
            .Skip(1)
            .DefaultIfEmpty(list.Any() ? list[0] : null)
            .FirstOrDefault();
        }
    }
}