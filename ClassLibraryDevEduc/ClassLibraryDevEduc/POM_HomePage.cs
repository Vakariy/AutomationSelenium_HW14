using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace ClassLibraryDevEduc
{
    class POM_HomePage
    {
        private IWebDriver driver;
        By signUpForACourseButton = By.ClassName("modal-btn");
        By fullNameInput = By.CssSelector("#entry-popup-form > div:nth-child(1) > input");
        By mobNumberInput = By.CssSelector("#entry-popup-form > div:nth-child(2) > input");
        By emailInput = By.CssSelector("#entry-popup-form > div:nth-child(3) > input");
        By selectCityField = By.CssSelector("#city-popup");
        By selectCourseField = By.CssSelector("#course-popup");

        By signOnCourseButton = By.XPath("/html/body/div[2]/main/div[7]/button");
        By newsLink = By.XPath("/html/body/div[2]/div/header/div/div[1]/nav/ul/li[3]/a");
        By coursesLink = By.XPath("/html/body/div[2]/div/header/div/div[1]/nav/ul/li[1]/a");
        By SignToNewsLetterButton = By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[3]/div/div/form/button");
        By logField = By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[3]/div/div/form/div/input[1]");

        By selectEn = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/ul/li/ul/li[2]/a");
        By selectRu = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/ul/li/ul/li[1]/a");
        By selectUa = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/ul/li/ul/li[3]/a");
        By selectAz = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/ul/li/ul/li[4]/a");

        public POM_HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        public POM_HomePage ClickOnsignUpForACourseButton()
        {
            driver.FindElement(signUpForACourseButton).Click();
            return this;
        }

        public POM_HomePage InputFullName()
        {
            driver.FindElement(fullNameInput).Click();
            return this;
        }

        public POM_HomePage InputMobNumber()
        {
            driver.FindElement(mobNumberInput).Click();
            return this;
        }

        public POM_HomePage InputEmail()
        {
            driver.FindElement(emailInput).Click();
            return this;
        }

        public POM_HomePage SelectCityCourse()
        {
            driver.FindElement(selectCityField).Click();
            return this;
        }

        public POM_HomePage SelectCourse()
        {
            driver.FindElement(selectCourseField).Click();
            return this;
        }

        public string SelectLocalization(string language)
        {
            IWebElement selectLanguage = driver.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > button"));
            IWebElement en = driver.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > ul > li:nth-child(2) > a"));
            IWebElement ru = driver.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > ul > li.lang-switcher-header__item.active > a"));
            IWebElement ua = driver.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > ul > li:nth-child(3) > a"));
            IWebElement az = driver.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > ul > li:nth-child(4) > a"));
            if (language == "EN")
            {
                selectLanguage.Click();
                en.Click();
                string actualResult_URL = driver.Url;
                return actualResult_URL;
            }
            else if (language == "UA")
            {
                selectLanguage.Click();
                ua.Click();
                string actualResult_URL = driver.Url;
                return actualResult_URL;
            }
            else if (language == "RU")
            {
                selectLanguage.Click();
                ru.Click();
                string actualResult_URL = driver.Url;
                return actualResult_URL;
            }
            else if (language == "AZ")
            {
                selectLanguage.Click();
                az.Click();
                string actualResult_URL = driver.Url;
                return actualResult_URL;
            }
            string error = "Error";
            return error;
        }

        public SignOnCourse_POM ClickOnSignOnCourseButton()
        {
            driver.FindElement(signOnCourseButton).Click();
            return new SignOnCourse_POM(driver);
        }

        public News_POM ClickOnSignButton(string login)
        {
            driver.FindElement(newsLink).Click();
            driver.FindElement(logField).SendKeys(login);
            driver.FindElement(SignToNewsLetterButton).Click();
            return new News_POM(driver);
        }
    }
}
