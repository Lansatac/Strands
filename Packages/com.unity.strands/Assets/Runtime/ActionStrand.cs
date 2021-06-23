using System;
using System.Collections;

namespace Strands
{
    public class ActionStrand : Strand
    {
        private Action _action;

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