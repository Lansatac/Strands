using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Strands.Tests.Runtime
{
    public class ThenRuntimeTests
    {
        [UnityTest]
        public IEnumerator ThenShouldChainUnityYieldNull()
        {
            var startFrame = Time.frameCount;
            var composed = new WaitStrand(() => null)
                .Then(_ => new WaitStrand(() => null));
            yield return composed;
            Assert.That(Time.frameCount - startFrame, Is.EqualTo(2));
        }

        [UnityTest]
        public IEnumerator ThenShouldChainUnityYieldSeconds()
        {
            const float waitTime = 0.05f;
            var startTime = Time.time;
            var composed = new WaitStrand(() => new WaitForSeconds(waitTime))
                .Then(_ => new WaitStrand(() => new WaitForSeconds(waitTime)));
            yield return composed;
            Assert.That(Time.time - startTime, Is.GreaterThan(waitTime * 2f));
        }
    }
}