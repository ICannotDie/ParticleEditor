using System.Linq;

namespace ICannotDie.Plugins.Common.Extensions
{

    public static class AtomExtensions
    {
        public static int UidAsInt(this Atom atom, int defaultIfEmpty = 1) => atom.uid.Contains("#") ? int.Parse(atom.uid.Split('#').Last()) : defaultIfEmpty;
    }

}