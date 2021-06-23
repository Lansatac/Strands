using System;
using System.Collections;

namespace Strands
{
    public sealed class ThenStrand<TFirst, TSecond> : Strand
        where TFirst : IEnumerator
        where TSecond : IEnumerator
    {
        private readonly TFirst _first;
        private readonly Func<TFirst, bool> _secondPredicate;
        private readonly Func<TFirst, TSecond> _secondGenerator;

        public ThenStrand(TFirst first, Func<TFirst, TSecond> secondGenerator)
        {
            _first = first;
            _secondPredicate = _ => true;
            _secondGenerator = secondGenerator;
        }

        public ThenStrand(TFirst first, Func<TFirst, TSecond> secondGenerator, Func<TFirst, bool> secondPredicate)
        {
            _first = first;
            _secondGenerator = secondGenerator;
            _secondPredicate = secondPredicate;
        }

        protected override IEnumerator Execute()
        {
            while (_first.MoveNext())
            {
                yield return _first.Current;
            }

            if (!_secondPredicate(_first)) yield break;

            var second = _secondGenerator(_first);
            while (second.MoveNext())
            {
                yield return second.Current;
            }
        }
    }
}