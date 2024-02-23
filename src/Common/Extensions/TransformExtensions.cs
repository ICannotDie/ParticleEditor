using UnityEngine;

namespace ICannotDie.Plugins.Common.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Recursively search transforms for a child with a specifiec name
        /// </summary>
        /// <param name="parentTransform">The transform to begin searching from</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first transform with the specified name, or null if none are found</returns>
        public static Transform GetChildByName(this Transform parentTransform, string name)
        {
            foreach (Transform child in parentTransform)
            {
                if (child.name == name)
                {
                    return child;
                }
                else
                {
                    Transform grandchild = GetChildByName(child, name);
                    if (grandchild != null)
                    {
                        return grandchild;
                    }
                }
            }

            return null;
        }
    }
}