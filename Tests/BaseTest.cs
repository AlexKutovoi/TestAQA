using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAQA.Tests
{
    /// <summary>
    /// Базовый класс для всех классов тестов
    /// </summary>
    public class BaseTest 
    {
        /// <summary>
        /// Экзепляр драйвера, используемый всеми тестами
        /// </summary>
        protected readonly IWebDriver driver;

        protected BaseTest()
        {
            ChromeOptions ChOptions = new ChromeOptions();
            //ChOptions.AddArguments(new List<string>() { "headless", "window-size=1920,1080", "disable-gpu" });
            ChOptions.AddArguments(new List<string>() { "--no-sandbox", "--disable-dev-shm-usage" });
            driver = new ChromeDriver(ChOptions);                 
        } 
    }
}