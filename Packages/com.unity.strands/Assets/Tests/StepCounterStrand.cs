using System.Collections;

namespace Strands.Tests.Shared
{
    public class StepCounterStrand : Strand
    {
        public int StepsTaken = 0;
        private readonly int _stepsToTake;

        public StepCounterStrand(int stepsToTake)
        {
            _stepsToTake = stepsToTake;
        }
        
        protected override IEnumerator Execute()
        {
            while (StepsTaken < _stepsToTake)
            {
                StepsTaken += 1;
                yield return null;
            }
        }
    }
}