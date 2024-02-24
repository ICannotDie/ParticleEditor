
using System;
using System.Collections;
using UnityEngine;

namespace ICannotDie.Plugins.Common
{
    public static class Defer
    {
        public static void StartCoroutine(IEnumerator coRoutine)
        {
            SuperController.singleton.StartCoroutine(coRoutine);
        }

        public static void UntilNextFrame(Action action)
        {
            StartCoroutine(UntilNextFrameEnumerator(action));
        }

        public static IEnumerator UntilNextFrameEnumerator(Action action)
        {
            if (action == null)
            {
                yield break;
            }

            yield return new WaitForEndOfFrame();

            action();
        }

        public static void UntilNextFrame<T>(Predicate<T> predicate, T item)
        {
            StartCoroutine(UntilNextFrameEnumerator<T>(predicate, item));
        }

        public static IEnumerator UntilNextFrameEnumerator<T>(Predicate<T> predicate, T item)
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