using System;
using System.Collections;

namespace Strands
{
    public abstract class Strand : IEnumerator
    {
        protected abstract IEnumerator Execute();

        private IEnumerator _enumerator;

        public bool Running = true;

        public bool MoveNext()
        {
            _enumerator ??= Execute();

            Running = _enumerator.MoveNext();

            return Running;
        }

        public void Reset()
        {
            reset();
        }

        protected virtual void reset()
        {
            throw new NotSupportedException();
        }

        public object Current
        {
            get
            {
                if (_enumerator == null)
                {
                    throw new InvalidOperationException(
                        "Current may not be called before the first call to MoveNext()!");
                }

                return _enumerator.Current;
            }
        }
    }
}