﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace SpecFlowProjectAppium.Utilities
{
    public class AppiumUtilities
    {
        
        private AppiumLocalService _appiumLocalService;
        private AndroidDriver _androidDriver;

        public AppiumUtilities(AppiumLocalService appiumLocalService, AndroidDriver androidDriver)
        {
            this._appiumLocalService = appiumLocalService;
            _androidDriver = androidDriver;
        }
        public AndroidDriver InitializeAndroidNativeApp()
        {
            var appPath = "C:\\Users\\rkadr\\Downloads\\ApiDemos-debug.apk";
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
            var driverOption = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "emulator-5554",
            };

            driverOption.AddAdditionalAppiumOption("Application", appPath);
            driverOption.AddAdditionalAppiumOption("noReset", true);

            AndroidDriver androidDriver = new AndroidDriver(serverUri, driverOption, TimeSpan.FromSeconds(180));
            return androidDriver;
        }

        public AndroidDriver InitializeAndroidWebApp()
        {
            var appPath = "C:\\Users\\rkadr\\Downloads\\ApiDemos-debug.apk";
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "emulator-5554",

            };
            driverOptions.AddAdditionalAppiumOption("Application", appPath);
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            AndroidDriver androidDriver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

            List<string> AllContexts = new List<string>();
            foreach (var context in androidDriver.Contexts)
            {
                Console.WriteLine(context);
            }
            var driv = androidDriver.Contexts.First(x => x.Contains("WEBVIEW_io.appium.android.apis"));
            androidDriver.Context = driv;

            return androidDriver;
        }
        public AppiumLocalService StartAppiumLocalService()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            if (!_appiumLocalService.IsRunning)
            {
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }
        public AppiumLocalService StartAppiumLocalService(int portNumber)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingPort(portNumber).Build();
            if (!_appiumLocalService.IsRunning)
            {
                _appiumLocalService.Start();
            }
            return _appiumLocalService;
        }
        public void CloseAppiumServer()
        {
            _appiumLocalService.Dispose();
        }
    }
}
