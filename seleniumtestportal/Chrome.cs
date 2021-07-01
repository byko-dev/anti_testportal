using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace seleniumtestportal
{
    public static class Chrome
    {
        public static String GetChromeVerion()
        {
            object path;
            path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Google\Chrome\BLBeacon", "version", null);
            if (path != null)
                return (String)path;
            return null;
        }

        public static String version;

        public static void Initialize()
        {   // get and set actually chrome driver version
            ///https://github.com/rosolko/WebDriverManager.Net

            String[] path = GetChromeVerion().Split('.');
            version = new WebClient().DownloadString("https://chromedriver.storage.googleapis.com/LATEST_RELEASE_" + path[0]);
            new DriverManager().SetUpDriver(new ChromeConfig(), version, Architecture.X64);

        }

        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        public static void chujdll(String url)
        {

            Initialize();
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            try
            {
                driver.Navigate().GoToUrl(url);
            }catch(Exception ex)
            {
                DialogResult result = MessageBox.Show("Your url address must be correct!" + "\n" + "For example: https://www.testportal.pl/test.html?t=fTLxE4g7yvef", "Wrong url path!", MessageBoxButtons.OK);
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
           
            while (true)
            {
                try
                {
                    js.ExecuteAsyncScript("window.removeEventListener(\"blur\", blurSpy.blurHandler)");
                }catch(Exception ex)
                {
                    Thread.Sleep(1000);
                }
                
            }
        }
    }
}
