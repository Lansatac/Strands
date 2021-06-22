using NUnit.Framework;
using Strands.Tests.Shared;

namespace Strands.Tests.Editor
{
    public class ThenEditorTests
    {
        [Test]
        public void ThenStrandShouldExecuteNextStrand()
        {
            var firstStrand = new NoOpStrand();
            var secondStrand = new NoOpStrand();

            var composed = firstStrand.Then(_ => secondStrand);
            composed.MoveNext();
            
            Assert.That(firstStrand.ExecuteCalled, Is.True);
            Assert.That(secondStrand.ExecuteCalled, Is.True);
        }
        
        [Test]
        public void ThenStrandShouldNotExecuteNextStrandUntilComplete()
        {
            var firstStrand = new StepCounterStrand(2);
            var secondStrand = new NoOpStrand();

            var composed = firstStrand.Then(_ => secondStrand);
            composed.MoveNext();
            
            Assert.That(firstStrand.StepsTaken, Is.EqualTo(1));
            Assert.That(secondStrand.ExecuteCalled, Is.False);
        }
    }
}