using NUnit.Framework;
using TestAQA.Pages;
using NUnit.Allure.Core;

namespace TestAQA.Tests.YouTubeTests
{
    [AllureNUnit]
    public class FindChanelTest : BaseTest
    {       
        [Test, Order(1)]
        public void CheckSearchChanelTitle()
        {
            string isName = new YouTubePage(driver)
                 .OpenYouTube()
                 .SearchChanel();
            Assert.That(isName, Is.EqualTo("Test IT"), "В результате поиска не было имени канала Test IT");
        }
        [Test, Order(2)]
        public void CheckOpenVideoInChanel() 
         {
             bool isResault = new ChanelPage(driver) 
                 .OpenChanel()
                 .TapOnVideoButton()
                 .TapOnNeedVideo()
                 .CheckPlayVideo();
             Assert.True(isResault, "Видео с канала Test IT не было открыто");
         }
    }
}
