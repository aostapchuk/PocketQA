using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace PocketQA
{
    public sealed class CommonUiSteps : BaseUiSteps
    {
        [When("I press (.*)")]
        public void WhenIPressKey(string key)
        {
            var code = GetKeyCode(key);
            Driver.Keyboard.PressKey(code);
        }

        private static string GetKeyCode(string key)
        {
            switch (key)
            {
                case "Enter":
                    return Keys.Enter;

                default:
                    throw new NotSupportedException($"Key {key} is not supported.");
            }
        }
    }
}
