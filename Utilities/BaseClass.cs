using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace SpecFlowProjectAppium.Utilities
{
    public class BaseClass
    {
        public AppiumLocalService AppiumServiceContext;
        public static AndroidDriver AndroidContext;
        public AppiumUtilities AppiumUtilities => new AppiumUtilities(AppiumServiceContext, AndroidContext);
        public AndroidDriver StartAppiumServerForHybrid()
        {
            AppiumServiceContext = AppiumUtilities.StartAppiumLocalService();
            AndroidContext = AppiumUtilities.InitializeAndroidNativeApp();
            return AndroidContext;


        }
    }
}