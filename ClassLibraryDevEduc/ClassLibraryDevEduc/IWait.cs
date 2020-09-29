using OpenQA.Selenium;
using System;

namespace ClassLibraryDevEduc
{
    internal interface IWait
    {
        IWebElement Until(Func<IWebDriver, IWebElement> func);
    }
}