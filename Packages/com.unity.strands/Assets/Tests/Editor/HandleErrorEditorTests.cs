using System;
using NUnit.Framework;
using Strands.Tests.Shared;

namespace Strands.Tests.Editor
{
    public class HandleErrorEditorTests
    {
        [Test]
        public void ErrorHandlerShouldNotBeCalledIfNoError()
        {
            var strand = new NoOpStrand();
            var handler = new NoOpStrand();

            var composed = strand.HandleError((Exception e) => handler);
            composed.MoveNext();

            Assert.That(handler.ExecuteCalled, Is.False);
        }

        [Test]
        public void ErrorHandlerShouldBeCalledIfErrorOccurs()
        {
            var strand = new AlwaysFailsStrand<Exception>(() => new Exception());
            var handler = new NoOpStrand();

            var composed = strand.HandleError((Exception e) => handler);
            composed.MoveNext();

            Assert.That(handler.ExecuteCalled, Is.True);
        }

        [Test]
        public void ErrorHandlerShouldNotBeCalledIfErrorOfWrongType()
        {
            var strand = new AlwaysFailsStrand<Exception>(() => new Exception());
            var handler = new NoOpStrand();

            var composed = strand.HandleError((ArgumentNullException e) => handler);

            Assert.That(() => composed.MoveNext(), Throws.Exception);
        }

        [Test]
        public void ErrorHandlerShouldBeCalledIfErrorOfCorrectType()
        {
            var strand = new AlwaysFailsStrand<ArgumentNullException>(() => new ArgumentNullException());
            var handler = new NoOpStrand();

            var composed = strand.HandleError((ArgumentNullException e) => handler);
            composed.MoveNext();

            Assert.That(handler.ExecuteCalled, Is.True);
        }
    }
}