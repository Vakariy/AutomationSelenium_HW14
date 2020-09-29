using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDevEduc
{
    class News_POM
    {
        private IWebDriver driver;
        By SignToNewsLetter = By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[3]/div/div/form/button");
        By logField = By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[3]/div/div/form/div/input[1]");

        public News_POM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public News_POM FillLogField(string login)
        {
            driver.FindElement(logField).SendKeys(login);
            return this;
        }
    }
}
