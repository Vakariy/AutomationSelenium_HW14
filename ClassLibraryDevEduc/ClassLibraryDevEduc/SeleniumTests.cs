using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibraryDevEduc
{
    public class SeleniumTests
    {
        IWebDriver chrome = new ChromeDriver(@"C:\Users\ЛордКотДотКом\Desktop\WebdriverChrome");
        POM_HomePage hp_POM;
        POM_ContactsPage cp_POM;
        POM_Footer footer_POM;

        SignOnCourse_POM si_POM;
        Menu_POM mn_POM;
        News_POM nw_POM;

        [SetUp]
        public void Settings()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            hp_POM = new POM_HomePage(chrome);
            cp_POM = new POM_ContactsPage(chrome);
            footer_POM = new POM_Footer(chrome);
            mn_POM = new Menu_POM(chrome);
            si_POM = new SignOnCourse_POM(chrome);
            nw_POM = new News_POM(chrome);
            chrome.Manage().Window.Maximize();
        }


        [TestCase(Description ="Проверка полей на валидацию. Проверка с пустыми полями.")]
        public void CheckSignUpForACourseInputInvalidData()
        {
            hp_POM = hp_POM.ClickOnsignUpForACourseButton();
            hp_POM = hp_POM.InputFullName();
            hp_POM = hp_POM.InputMobNumber();
            hp_POM = hp_POM.InputEmail();
            hp_POM = hp_POM.SelectCityCourse();
            hp_POM = hp_POM.SelectCourse();
            hp_POM = hp_POM.InputFullName();
            IWebElement textErrorName = chrome.FindElement(By.LinkText("Поле обязательно для заполнения"));
            IWebElement textErrorMobNum = chrome.FindElement(By.LinkText("Введите правильный номер телефона"));
            IWebElement textErroremail = chrome.FindElement(By.LinkText("Поле обязательно для заполнения"));
            IWebElement textErrorSelectCity = chrome.FindElement(By.LinkText("Поле обязательно для заполнения"));
            IWebElement textErrorSelectCourse = chrome.FindElement(By.LinkText("Поле обязательно для заполнения"));
            
            Assert.AreEqual("Поле обязательно для заполнения", textErrorName.Text);
            Assert.AreEqual("Введите правильный номер телефона", textErrorMobNum.Text);
            Assert.AreEqual("Поле обязательно для заполнения", textErroremail.Text);
            Assert.AreEqual("Поле обязательно для заполнения", textErrorSelectCity.Text);
            Assert.AreEqual("Поле обязательно для заполнения", textErrorSelectCourse.Text);
            chrome.Quit();
        }


        [TestCase("Dnepr", "ул.Симферопольская, 17", Description = "Проверка корректности адреса филиалла по соотношению к городу")]
        [TestCase("Kiev", "ст. метро Васильковская, ул. Сумская,1")]
        [TestCase("Baku", "Баку, проспект Гейдара Алиева 125, Qafqaz Business Center, 2 этаж, AZ1029")]
        [TestCase("Sankt_Peterburg", "площадь Карла Фаберже, 8Б, офис 440\r\nБЦ Золотая Долина")]
        [TestCase("Harkov", "ул. Донец Захаржевского, 2,\r\nздание Сбербанка, этаж 5")]
        [Obsolete]
        public void CheckContactInformationAddress(string city, string expectedResult)
        {
            chrome.Manage().Window.Size = new Size(900, 700);
            chrome.Navigate().GoToUrl("https://deveducation.com/contacts/");        
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            By close = By.CssSelector("body > div.wrapper > main > div.popups.subscribe - pop.closing - pop.show > div > button");
            cp_POM = cp_POM.ClickOnTheCityForGetInfo(city);
            IWebElement actualResult = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section.contacts-section > div > div.contacts-list > div.contacts-list__item.entered > div.contacts-list__content > div.contacts-list__info > div:nth-child(1)"));
            Assert.AreEqual(expectedResult, actualResult.Text);
        }


        [TestCase("Facebook", "https://www.facebook.com/IT.DevEducation/", Description = "Проверка перехода на ресурс при нажатии на иконку Facebook в подвале сайта Deveducation")]
        [TestCase("Instagram", "https://www.instagram.com/dev.education/", Description = "Проверка перехода на ресурс при нажатии на иконку Instagram в подвале сайта Deveducation")]
        [TestCase("Twitter", "https://twitter.com/DevEducation2", Description = "Проверка перехода на ресурс при нажатии на иконку Twitter в подвале сайта Deveducation")]
        [TestCase("LinkedIn", "https://www.linkedin.com/company/deveducation-school/", Description = "Проверка перехода на ресурс при нажатии на иконку LinkedIn в подвале сайта Deveducation")]
        [TestCase("YouTube", "https://www.youtube.com/channel/UCOgVyVrC6Plr8QZK6pom9Bg", Description = "Проверка перехода на ресурс при нажатии на иконку YouTube в подвале сайта Deveducation")]
        public void CheckGoToMessengers(string messenger, string expectedResult)
        {
            string actualResult = footer_POM.CheckGoToMessengers(messenger);
            Assert.AreEqual(expectedResult, actualResult);

            //закрытие вкладки
            var tabs = chrome.WindowHandles;
            if (tabs.Count > 1)
            {
                chrome.SwitchTo().Window(tabs[1]);
                chrome.Close();
                chrome.SwitchTo().Window(tabs[0]);
            }
        }

        [TestCase("EN", "https://deveducation.com/en/", Description = "Проверка смены языка на главной странице на en")]
        [TestCase("UA", "https://deveducation.com/ua/", Description = "Проверка смены языка на главной странице на ua")]
        [TestCase("AZ", "https://deveducation.com/az/", Description = "Проверка смены языка на главной странице на az")]
        [TestCase("RU", "https://deveducation.com/", Description = "Проверка смены языка на главной странице на ru")]
        public void CheckLocalization(string language, string expectedResult)
        {
            string actualResult = hp_POM.SelectLocalization(language);
            Assert.AreEqual(expectedResult, actualResult);
        }
        

        [Test]
        public void SuccessLogInToDeveducation()
        {
            si_POM = hp_POM.ClickOnSignOnCourseButton();
            si_POM.FillLogInField("User");
        }

        [Test]
        public void SuccessAskQuestion()
        {

            mn_POM = mn_POM.AskQuestion("User", "+380999999999");
            string actualResult_URL = chrome.Url;
            Assert.AreEqual("https://lp.deveducation.com/course-v1/thank-you-page.html", actualResult_URL);
        }


        [Test]
        public void SuccessGoToNewsPage()
        {
            mn_POM = mn_POM.ClickOnNewsLink();
            IWebElement newsText = chrome.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[1]/div/h1"));
            Assert.AreEqual("Новости", newsText.Text);
        }


        [Test]
        public void SuccessGoToCoursesPage()
        {
            mn_POM = mn_POM.ClickOnCoursesLink();
            IWebElement coursesText = chrome.FindElement(By.XPath("/ html / body / div[2] / main / section[1] / div / h1"));
            Assert.AreEqual("Наши курсы", coursesText.Text);
        }


        [Test]
        public void SuccessGoToBlogPage()
        {
            mn_POM = mn_POM.ClickOnBlogLink();
            IWebElement coursesText = chrome.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[1]/div/h1"));
            Assert.AreEqual("Блог", coursesText.Text);
        }


        [Test]
        public void SuccessGetToJavaDeveloperProf()
        {
            si_POM = si_POM.GetInfoAboutJavaDeveloperProf();
            IWebElement coursesText = chrome.FindElement(By.XPath("/html/body/div[2]/main/section[1]/div/h1"));
            Assert.AreEqual("JAVA-РАЗРАБОТЧИК", coursesText.Text);
        }


        [Test]
        public void SuccessSignToNewsLetter()
        {
            nw_POM = hp_POM.ClickOnSignButton("sms@i.ua");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement actualReesult = chrome.FindElement(By.CssSelector("body > div.subscribe > div > div.subscribe__terms > div > a:nth-child(3)"));
            Assert.AreEqual("Антиспам-политика", actualReesult);
            chrome.Quit();
        }
    }
}
