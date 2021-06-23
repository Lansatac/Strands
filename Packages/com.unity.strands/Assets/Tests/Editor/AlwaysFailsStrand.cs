using System;
using System.Collections;

namespace Strands.Tests.Editor
{
    public class AlwaysFailsStrand<TException> : Strand
        where TException : Exception
    {
        private readonly Func<TException> _exception;

        public AlwaysFailsStrand(Func<TException> exception)
        {
            _exception = exception;
        }
        
        protected override IEnumerator Execute()
        {
            throw _exception();
        }
    }
}