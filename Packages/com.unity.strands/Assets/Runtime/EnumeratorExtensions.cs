using System.Collections;

namespace Strands
{
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Promotes an IEnumerator interface to a Strand.
        /// </summary>
        /// <param name="enumerator">IEnumerator to convert to a strand.</param>
        /// <returns>enumerator as a strand.</returns>
        public static Strand AsStrand(this IEnumerator enumerator)
        {
            if (enumerator is Strand strand)
                return strand;
            return new EnumeratorStrand(enumerator);
        }
    }
}