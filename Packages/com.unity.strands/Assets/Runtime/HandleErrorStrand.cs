using System;
using System.Collections;

namespace Strands
{
    public sealed class HandleErrorStrand<TStrand, TError, THandler> : Strand
        where TStrand : IEnumerator
        where TError : Exception
        where THandler : IEnumerator
    {
        private readonly TStrand _strand;
        private readonly Func<TError, THandler> _handlerGenerator;
        private TError _error;

        public HandleErrorStrand(TStrand strand, Func<TError, THandler> handlerGenerator)
        {
            _strand = strand;
            _handlerGenerator = handlerGenerator;
        }

        protected override IEnumerator Execute()
        {
            while (StepWithCatch(_strand))
            {
                yield return _strand.Current;
            }

            if (_error == null) yield break;

            var handler = _handlerGenerator(_error);
            while (handler.MoveNext())
            {
                yield return handler.Current;
            }
        }

        private bool StepWithCatch(TStrand strand)
        {
            bool moveNext;
            try
            {
                moveNext = strand.MoveNext();
            }
            catch (TError e)
            {
                _error = e;
                moveNext = false;
            }

            return moveNext;
        }
    }
}