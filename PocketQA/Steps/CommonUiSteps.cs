using System;
using System.Linq;
using OpenQA.Selenium;
using PocketQA.Pages;
using TechTalk.SpecFlow;

namespace PocketQA.Steps
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

        [Given("I have entered \"(.*)\" into \"(.*)\" field")]
        public void EnterValueIntoField(string value, string field)
        {
            var webComponent = new WebComponent(Driver);
            webComponent.SetFieldValue(field, value);
        }

        [Given("I have checked \"(.*)\"")]
        public void EnterValueIntoField(string field)
        {
            var webComponent = new WebComponent(Driver);
            var input = webComponent.FindFieldByLabel(field);
            input.Click();
        }

        [Given("I have checked \"(.*)\" in \"(.*)\" field")]
        public void CheckValueInField(string value, string field)
        {
            var webComponent = new WebComponent(Driver);
            var fieldElement = webComponent.FindFieldByLabel(field);
            var valueElements = fieldElement.FindDescendants(WebComponent.ByText(value));
            var valueElement = valueElements.FirstOrDefault(el => el.Displayed && value.Equals(el.Text, StringComparison.CurrentCultureIgnoreCase));
            valueElement.Click();
        }

        [Given("I have submitted page")]
        [When("I submit page")]
        public void SubmitPage()
        {
            var webComponent = new WebComponent(Driver);
            webComponent.SubmitPage();
        }
    }
}
