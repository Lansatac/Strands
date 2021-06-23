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
        /// <param name="condition">The condition that if true will cause the second Strand to execute.</param>
        /// <param name="secondGenerator">After the first coroutine is run, if the condition function returns true, this function is invoked to generate the second action.</param>
        public static ThenStrand<TFirst, TSecond> Then<TFirst, TSecond>(this TFirst first, Func<TFirst, bool> condition,
            Func<TFirst, TSecond> secondGenerator)
            where TFirst : IEnumerator
            where TSecond : IEnumerator
        {
            return new ThenStrand<TFirst, TSecond>(first, secondGenerator, condition);
        }

        /// <summary>
        /// Composes an IEnumerators together with an action invocation. Runs the coroutine, then invokes the method once it is complete.
        /// </summary>
        /// <param name="first">IEnumerator to be executed first.</param>
        /// <param name="second">After the first coroutine is run, this function is invoked.</param>
        public static ThenStrand<TFirst, ActionStrand> Then<TFirst>(this TFirst first,
            Action<TFirst> second)
            where TFirst : IEnumerator
        {
            return new ThenStrand<TFirst, ActionStrand>(first,
                firstPostExecute => new ActionStrand(() => second(firstPostExecute)));
        }

        /// <summary>
        /// Composes an IEnumerators together with an action invocation.
        /// Runs the coroutine, then invokes the method once it is complete, if the condition is true.
        /// </summary>
        /// <param name="first">IEnumerator to be executed first.</param>
        /// <param name="condition">The condition that if true will cause the action to be invoked.</param>
        /// <param name="second">After the first coroutine is run, this function is invoked.</param>
        public static ThenStrand<TFirst, ActionStrand> Then<TFirst>(this TFirst first, Func<TFirst, bool> condition,
            Action<TFirst> second)
            where TFirst : IEnumerator
        {
            return new ThenStrand<TFirst, ActionStrand>(first,
                firstPostExecute => new ActionStrand(() => second(firstPostExecute)), condition);
        }

        /// <summary>
        /// Composes two different IEnumerators together. Runs the first coroutine, then the second once the first is complete.
        /// </summary>
        /// <param name="first">IEnumerator to be executed first.</param>
        /// <param name="secondGenerator">After the first coroutine is run, this function is invoked to generate the second action.</param>
        public static ThenStrand<Strand<TFirstValue>, TSecond> Then<TFirstValue, TSecond>(
            this Strand<TFirstValue> first,
            Func<TFirstValue, TSecond> secondGenerator)
            where TSecond : IEnumerator
        {
            return new ThenStrand<Strand<TFirstValue>, TSecond>(first, f => secondGenerator(f.Value));
        }
    }
}