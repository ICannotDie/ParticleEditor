
using System;
using System.Collections;
using UnityEngine;

namespace ICannotDie.Plugins.Common
{

    public static class Defer
    {
        public static IEnumerator UntilNextFrame(Action action)
        {
            if (action == null)
            {
                yield break;
            }

            yield return new WaitForEndOfFrame();

            action();
        }

        public static IEnumerator UntilNextFrame<T>(Predicate<T> predicate, T item)
        {
            if (predicate == null)
            {
                yield break;
            }

            yield return new WaitForEndOfFrame();

            yield return predicate(item);
        }
    }
}