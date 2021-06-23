using System.Collections;

namespace Strands.Tests.Editor
{
    public class SimpleValueStrand : Strand<int>
    {
        public SimpleValueStrand()
        {
            Value = 0;
        }
        
        protected override IEnumerator Execute()
        {
            Value = 5;
            yield break;
        }
    }
}