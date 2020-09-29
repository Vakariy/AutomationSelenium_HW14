using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDevEduc
{
    class POM_Footer
    {
        private IWebDriver driver;
        By iconFacebook = By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(2)");
        By iconInstagram = By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(3)");
        By iconYouTube = By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(5)");
        By iconLinkedIn = By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(6)");
        By iconTwitter = By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(7)");

        public POM_Footer(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string CheckGoToMessengers(string messenger)
        {
            for (; ; )
            {

                if (messenger == "Facebook")
                {
                    driver.FindElement(iconFacebook).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "Instagram")
                {
                    driver.FindElement(iconInstagram).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "Twitter")
                {
                    driver.FindElement(iconTwitter).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "LinkedIn")
                {
                    driver.FindElement(iconLinkedIn).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "YouTube")
                {
                    driver.FindElement(iconYouTube).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
            }
        }
    }
}
