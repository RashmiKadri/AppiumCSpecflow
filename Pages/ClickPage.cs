using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace SpecFlowProjectAppium.Pages
{
    public class ClickPage
    {
        private AndroidDriver androiddriver;

        public ClickPage(AndroidDriver androidDriver) 
        {
            PageFactory.InitElements(androidDriver, this);
        }
        [FindsBy(How=How.XPath,Using= "//android.widget.TextView[@content-desc=\"Views\"]")]
        private IWebElement Views { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]

        private IWebElement AllElements { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Radio Group\"]")]

        private IWebElement Radio { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@content-desc=\"Dinner\"]")]

        private IWebElement Dinner { get; set; }

        public void ClickViews()
        { 
            Views.Click(); 
        }
        public void HandlingRadioCheckboxes()
        {
            ActionBuilder actionBuilder = new ActionBuilder();
            var touch = new OpenQA.Selenium.Appium.Interactions.PointerInputDevice(PointerKind.Touch, "finger");

            IList<AppiumElement> els = androiddriver.FindElements((By)AllElements);
            // add the actions move, tap, pause,up
            var moveaction = touch.CreatePointerMove(Views, 0, 0, TimeSpan.FromMilliseconds(0));
            var tapactiondown = touch.CreatePointerDown(PointerButton.TouchContact);
            var tapactionpause = touch.CreatePause(TimeSpan.FromMilliseconds(400));
            var tapactionup = touch.CreatePointerUp(PointerButton.TouchContact);

            Interaction[] Tapinteractions = new Interaction[]
                {
                    moveaction,
                    tapactiondown, tapactionpause, tapactionup

                };
            actionBuilder.AddActions(Tapinteractions);

            var sequenceActions = actionBuilder.ToActionSequenceList();
            androiddriver.PerformActions(sequenceActions);
            IWebElement RadioGroup=androiddriver.FindElement((By)Radio);
            RadioGroup.Click();
            IWebElement dinner = androiddriver.FindElement((By)Dinner);
            dinner.Click();

        }
    }
}
