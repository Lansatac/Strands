using NUnit.Framework;
using Strands.Tests.Shared;

namespace Strands.Tests.Editor
{
    public class StrandEditorTests
    {

        // A Test behaves as an ordinary method
        [Test]
        public void StrandShouldNotStepExecuteBeforeFirstMoveNext()
        {
            var strand = new NoOpStrand();
            Assert.That(strand.ExecuteCalled, Is.False);
        }
    
        [Test]
        public void StrandMoveNextShouldCallExecute()
        {
            var strand = new NoOpStrand();
            strand.MoveNext();
            Assert.That(strand.ExecuteCalled, Is.True);
        }
    
        [Test]
        public void StrandCompletionShouldStopRunning()
        {
            var strand = new NoOpStrand();
            strand.MoveNext();
            Assert.That(strand.Running, Is.False);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void MultiStepStrandShouldTakeExpectedNumberOfSteps(int steps)
        {
            var strand = new StepCounterStrand(steps);
            while (strand.MoveNext())
            {
                Assert.That(strand.Running, Is.True);
            }
            Assert.That(strand.StepsTaken, Is.EqualTo(steps));
            Assert.That(strand.Running, Is.False);
        }
    }
}
