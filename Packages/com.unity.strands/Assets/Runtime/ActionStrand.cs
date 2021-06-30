using System;
using System.Collections;

namespace Strands
{
    public sealed class ActionStrand : Strand
    {
        private readonly Action _action;

        public ActionStrand(Action action)
        {
            _action = action;
        }

        protected override IEnumerator Execute()
        {
            _action();
            yield break;
        }
    }
}