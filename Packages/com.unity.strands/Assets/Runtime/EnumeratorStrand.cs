using System.Collections;

namespace Strands
{
    public class EnumeratorStrand : Strand
    {
        private readonly IEnumerator _enumerator;

        public EnumeratorStrand(IEnumerator enumerator)
        {
            _enumerator = enumerator;
        }

        protected override IEnumerator Execute()
        {
            while (_enumerator.MoveNext())
            {
                yield return _enumerator.Current;
            }
        }
    }
}