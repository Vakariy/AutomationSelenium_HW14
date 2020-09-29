using OpenQA.Selenium;
using System;

namespace ClassLibraryDevEduc
{
    class POM_ContactsPage
    {
        private IWebDriver driver;

        By cityContactBottonDnepr = By.XPath(@"/html/body/div[2]/main/section[1]/div/div[1]/button[1]");
        By cityContactBottonKiev = By.XPath(@"/html/body/div[2]/main/section[1]/div/div[1]/button[2]");
        By cityContactBottonBaku = By.XPath(@"/html/body/div[2]/main/section[1]/div/div[1]/button[3]");
        By cityContactBottonSankt_Peterburg = By.XPath(@"/html/body/div[2]/main/section[1]/div/div[1]/button[4]");
        By cityContactBottonHarkov = By.XPath(@"/html/body/div[2]/main/section[1]/div/div[1]/button[5]");
        By contactListlinkAddress = By.CssSelector("body > div.wrapper > main > section.contacts-section > div > div.contacts-list > div.contacts-list__item.entered > div.contacts-list__content > div.contacts-list__info > div:nth-child(1)");

        public POM_ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public POM_ContactsPage ClickOnTheCityForGetInfo(string city)
        {
            

            if (city == "Dnepr")
            {
                driver.FindElement(cityContactBottonDnepr).Click();
                return this;
            }
            else if (city == "Kiev")
            {
                driver.FindElement(cityContactBottonKiev).Click();
                return this;
            } else if(city == "Baku")
            {
                driver.FindElement(cityContactBottonBaku).Click();
                return this;
            }
            else if (city == "Sankt_Peterburg")
            {
                driver.FindElement(cityContactBottonSankt_Peterburg).Click();
                return this;
            }
            else if (city == "Harkov")
            {
                driver.FindElement(cityContactBottonHarkov).Click();
                return this;
            }
            return this;
        }

       
    }
}
