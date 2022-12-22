using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestAQA.BaseUrl;


namespace TestAQA.Pages
{
    public class YouTubePage 
    {
        private IWebDriver driver;

        public YouTubePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By SearchWind = By.Id("search");
        private By Sear = By.CssSelector("#filter-menu");
        private By SearchWindow = By.XPath("//input[@id='search']");
        private By ResaultWindow = By.XPath("//div[@id='text-container']//*[text()='Test IT']");
        
        

        public string SearchChanel()
        {            
            AllureLifecycle.Instance.WrapInStep(() =>
            {                
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                wait.Until(ExpectedConditions.ElementToBeClickable(SearchWindow));
                driver.FindElement(SearchWindow).SendKeys("Test IT");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("search-icon-legacy")));
                driver.FindElement(By.Id("search-icon-legacy")).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Sear));
            }, "Название канала Test IT в поиске");
            return driver.FindElement(ResaultWindow).Text;
        }       

        public YouTubePage OpenYouTube()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Navigate().GoToUrl(CommonService.BaseUrl);
            }, "Открыть страницу youtube");
            return this;
        }            
    }
}
