using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDevEduc
{
    class SignOnCourse_POM
    {
        private IWebDriver driver;

        By loginButton = By.XPath("/html/body/div[2]/main/div[7]/button");
        By loginField = By.XPath("/html/body/div[2]/main/div[2]/div/div/form/div[1]/input");
        By coursesLink = By.XPath("/html/body/div[2]/div/header/div/div[1]/nav/ul/li[1]/a");
        By baseCourseJavaLink = By.XPath("/html/body/div[2]/main/section[1]/div/div/ul/li[1]/ul/li[1]/a/span[1]");
        public SignOnCourse_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SignOnCourse_POM ClickOnLogInButton()
        {
            driver.FindElement(loginButton).Click();
            return this;
        }

        public SignOnCourse_POM FillLogInField(string login)
        {
            driver.FindElement(loginField).SendKeys(login);
            return this;
        }

        public SignOnCourse_POM GetInfoAboutJavaDeveloperProf()
        {
            driver.FindElement(coursesLink).Click();
            driver.FindElement(baseCourseJavaLink).Click();

            return this;
        }
    }
}
