using System.Collections;
using NUnit.Framework;
using Strands.Tests.Shared;

namespace Strands.Tests.Editor
{
    public class EnumeratorStrandEditorTests
    {
        [Test]
        public void AsStrandEnumeratorShouldExecuteWhenWrapped()
        {
            var executed = false;

            IEnumerator Coroutine()
            {
                executed = true;
                yield break;
            }

            var wrapped = Coroutine().AsStrand();
            wrapped.MoveNext();
            Assert.That(executed, Is.True);
        }
        
        [Test]
        public void AsStrandOnStrandShouldReturnIdentity()
        {
            var strand = new NoOpStrand();
            Assert.That(strand.AsStrand(), Is.EqualTo(strand));
        }
    }
}