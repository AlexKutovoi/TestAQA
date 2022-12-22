using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using TestAQA.BaseUrl;

namespace TestAQA.Pages
{
    public class ChanelPage
    {
        private IWebDriver driver;

        public ChanelPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        private By VideoButton = By.XPath("//*[@id='tabsContent']/tp-yt-paper-tab[2]");        
        private By Content = By.Id("metadata");
        private By ChanelTitle = By.Id("channel-title");       
        private By SearchWindow = By.XPath("//input[@id='search']");
        

        public ChanelPage GoToChanelPage()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                wait.Until(ExpectedConditions.ElementToBeClickable(SearchWindow));
                driver.FindElement(ChanelTitle).Click();
            }, "Переход на канал");
            return this;
        }
        public ChanelPage TapOnVideoButton()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementToBeClickable(SearchWindow));
                driver.FindElement(VideoButton).Click();
            }, "переход на страницу Видео");
            return this;
        }

        public ChanelPage TapOnNeedVideo()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Thread.Sleep(300);
                var content = driver.FindElements(Content);                
                content[6].Click();                        
            }, "клик на нужное Видео 7");
            return this;
        }

        public bool CheckPlayVideo()
        {
            bool notDisplayed = false;
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 30));                                
                if(driver.Url.Contains("watch"))
                notDisplayed = true;
            }, "Проверка того что видео не отображается");
            return notDisplayed;
        }

        public ChanelPage OpenChanel()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Navigate().GoToUrl(CommonService.BaseUrl + "/@TestITTMS");
            }, "Открыть страницу биржи");
            return this;
        }
    }
}