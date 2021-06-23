using System;
using System.Collections;

namespace Strands
{
    public static class HandleErrorExtensions
    {
        public static HandleErrorStrand<TStrand, TError, THandler> HandleError<TStrand, TError, THandler>(
            this TStrand strand, Func<TError, THandler> handlerGenerator)
            where TStrand : IEnumerator
            where TError : Exception
            where THandler : IEnumerator
        {
            return new HandleErrorStrand<TStrand, TError, THandler>(strand, handlerGenerator);
        }
    }
}