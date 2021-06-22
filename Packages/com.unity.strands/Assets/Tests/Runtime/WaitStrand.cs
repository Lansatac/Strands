using System;
using System.Collections;

namespace Strands.Tests.Runtime
{
    public class WaitStrand : Strand
    {
        private readonly Func<object> _waitObject;

        public WaitStrand(Func<object> waitObject)
        {
            _waitObject = waitObject;
        }

        protected override IEnumerator Execute()
        {
            yield return _waitObject();
        }
    }
}