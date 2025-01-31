using System;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProjectAppium.Hooks;
using SpecFlowProjectAppium.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProjectAppium.StepDefinitions
{
    [Binding]
    public class TapElementStepDefinitions : TestInitialize
    {
        ClickPage cp = new ClickPage((OpenQA.Selenium.Appium.Android.AndroidDriver) ScenarioContext.Current["androidContext"]);
       // ClickPage cp = new ClickPage((OpenQA.Selenium.Appium.Android.AndroidDriver) ScenarioContext.Current["androidContext"]);

        [Given(@"Launch the Application")]
        public void GivenLaunchTheApplication()
        {
           
        }

        [When(@"User taps on the views element")]
        public void WhenUserTapsOnTheViewsElement()
        {
        

            cp.ClickViews();
        }

        [Then(@"User is navigated to views page")]
        public void ThenUserIsNavigatedToViewsPage()
        {
        }

        [When(@"User taps on the expand list element")]
        public void WhenUserTapsOnTheExpandListElement()
        {
        }

        [When(@"User taps on the radio group element")]
        public void WhenUserTapsOnTheRadioGroupElement()
        {
        }
        [Then(@"User clicks on the radio button")]
        public void ThenUserClicksOnTheRadioButton()
        {
            
        }
    }
}
