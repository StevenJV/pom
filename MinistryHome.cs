using System;

namespace pom
{
    public class MinistryHome : PageBase
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchtxtbox = null!;

        [FindsBy(How = How.Id, Using = "learnNav")]
        private IWebElement _topnavlearn = null!;

        public MinistryHome(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            PageFactory.InitElements(driver, this);
            full_test_uri = Path.Combine(test_url, test_page);
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(test_url);
        }

        public void Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.SendKeys(Keys.Return);
        }
        public void Learn()
        {
            _topnavlearn.Click();
        }
    }
}