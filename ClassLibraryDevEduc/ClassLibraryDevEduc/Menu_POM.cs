using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDevEduc
{
    class Menu_POM
    {
        private IWebDriver driver;
        By newsLink = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/nav/ul/li[3]/a");
        By coursesLink = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/nav/ul/li[1]/a");
        By blogLink = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/nav/ul/li[4]/a");
        By youtubeLink = By.XPath(@"/html/body/div[2]/footer/div/ul/li[5]/a/img");
        By contactsLink = By.XPath(@"/html/body/div[2]/div/header/div/div[1]/nav/ul/li[6]/a");
        By askQuestionButton = By.XPath(@"/html/body/div[2]/main/section[2]/div/button");
        By loginField = By.XPath(@"/html/body/div[2]/main/div[3]/div/div/form/div[1]/input");
        By phoneField = By.XPath(@"/html/body/div[2]/main/div[3]/div/div/form/div[2]/input");
        By sendContactsButton = By.XPath(@"/html/body/div[2]/main/div[3]/div/div/form/div[3]/button[1]");
        public Menu_POM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Menu_POM ClickOnNewsLink()
        {
            driver.FindElement(newsLink).Click();
            return new Menu_POM(driver);
        }

        public Menu_POM ClickOnCoursesLink()
        {
            driver.FindElement(coursesLink).Click();
            return new Menu_POM(driver);
        }

        public Menu_POM ClickOnBlogLink()
        {
            driver.FindElement(blogLink).Click();
            return new Menu_POM(driver);
        }

        public Menu_POM AskQuestion(string login, string phone)
        {
            driver.FindElement(contactsLink).Click();
            driver.FindElement(askQuestionButton).Click();
            driver.FindElement(loginField).SendKeys(login);
            driver.FindElement(phoneField).SendKeys(phone);
            driver.FindElement(sendContactsButton).Click();


            return new Menu_POM(driver);
        }
    }
}
