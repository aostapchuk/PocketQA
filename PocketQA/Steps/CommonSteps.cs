using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace PocketQA.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        [Given("I have waited (\\d+) milliseconds")]
        [Given("I have waited (\\d+) ms")]
        [When("I wait (\\d+) milliseconds")]
        [When("I wait (\\d+) ms")]
        public void WaitMilliseconds(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        [Given("I have waited (\\d+) seconds")]
        [Given("I have waited (\\d+) s")]
        [When("I wait (\\d+) seconds")]
        [When("I wait (\\d+) s")]
        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
