using System;
using System.Collections;

namespace Strands
{
    public class ThenStrand<TFirst, TSecond> : Strand
        where TFirst : IEnumerator
        where TSecond : IEnumerator
    {
        private readonly TFirst _first;
        private readonly Func<TFirst, TSecond> _secondGenerator;

        public ThenStrand(TFirst first, Func<TFirst, TSecond> secondGenerator)
        {
            _first = first;
            _secondGenerator = secondGenerator;
        }

        protected override IEnumerator Execute()
        {
            while (_first.MoveNext())
            {
                yield return _first.Current;
            }

            var second = _secondGenerator(_first);
            while (second.MoveNext())
            {
                yield return second.Current;
            }
        }
    }
}