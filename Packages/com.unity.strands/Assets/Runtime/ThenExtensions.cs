using System;
using System.Collections;

namespace Strands
{
    public static class ThenExtensions
    {
        /// <summary>
        /// Composes two different IEnumerators together. Runs the first coroutine, then the second once the first is complete.
        /// </summary>
        /// <param name="first">IEnumerator to be executed first.</param>
        /// <param name="secondGenerator">After the first coroutine is run, this function is invoked to generate the second action.</param>
        public static ThenStrand<TFirst, TSecond> Then<TFirst, TSecond>(this TFirst first,
            Func<TFirst, TSecond> secondGenerator)
            where TFirst : IEnumerator
            where TSecond : IEnumerator
        {
            return new ThenStrand<TFirst, TSecond>(first, secondGenerator);
        }

        /// <summary>
        /// Composes two different IEnumerators together. Runs the first coroutine, then, only if the provided condition is true,
        /// the second is run.
        /// </summary>
        /// <param name="first">IEnumerator to be executed first.</param>
        /// <param name="condition"></param>
        /// <param name="secondGenerator">After the first coroutine is run, if the condition function returns true, this function is invoked to generate the second action.</param>
        public static ThenStrand<TFirst, TSecond> Then<TFirst, TSecond>(this TFirst first, Func<TFirst, bool> condition,
            Func<TFirst, TSecond> secondGenerator)
            where TFirst : IEnumerator
            where TSecond : IEnumerator
        {
            return new ThenStrand<TFirst, TSecond>(first, secondGenerator, condition);
        }
    }
}