using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Strands.Tests.Runtime
{
    public class StrandRuntimeTests
    {

        /// <summary>
        /// Integration Test to ensure that Strands play nice with unity coroutine timing control objects. 
        /// </summary>
        [UnityTest]
        public IEnumerator StrandYieldingWaitShouldWait()
        {
            const float timeToWait = 0.01f;
            var startTime = Time.time;
            yield return new WaitStrand(()=>new WaitForSeconds(timeToWait));
            Assert.That(Time.time - startTime, Is.GreaterThan(timeToWait));
        }
        
        [UnityTest]
        public IEnumerator StrandYieldingNullShouldSkipFrame()
        {
            var startFrame = Time.frameCount;
            yield return new WaitStrand(()=>null);
            Assert.That(Time.frameCount - startFrame, Is.EqualTo(1));
        }
    }
}
