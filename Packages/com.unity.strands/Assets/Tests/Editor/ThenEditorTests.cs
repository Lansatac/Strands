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
            
            Assert.That(secondStrand.ExecuteCalled, Is.True);
        }

        [Test]
        public void ThenStrandShouldNotExecuteNextStrandUntilComplete()
        {
            var firstStrand = new StepCounterStrand(2);
            var secondStrand = new NoOpStrand();

            var composed = firstStrand.Then(_ => secondStrand);
            composed.MoveNext();
            
            Assert.That(secondStrand.ExecuteCalled, Is.False);
        }
        
        [Test]
        public void ConditionalThenShouldExecuteNextWhenTrue()
        {
            var firstStrand = new NoOpStrand();
            var secondStrand = new NoOpStrand();

            var composed = firstStrand.Then(_ => true,_ => secondStrand);
            composed.MoveNext();
            
            Assert.That(secondStrand.ExecuteCalled, Is.True);
        }
        
        [Test]
        public void ConditionalThenShouldNotExecuteNextWhenFalse()
        {
            var firstStrand = new NoOpStrand();
            var secondStrand = new NoOpStrand();

            var composed = firstStrand.Then(_ => false,_ => secondStrand);
            composed.MoveNext();
            
            Assert.That(secondStrand.ExecuteCalled, Is.False);
        }
    }
}