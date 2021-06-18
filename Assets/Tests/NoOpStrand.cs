using System.Collections;

namespace Strands.Tests.Shared
{
    public class NoOpStrand : Strand
    {
        public bool ExecuteCalled;
        protected override IEnumerator Execute()
        {
            ExecuteCalled = true;
            yield break;
        }
    }
}