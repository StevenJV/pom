using System;

namespace pom
{
    public class SearchPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;
        private string test_url = "https://www.ministryoftesting.com/search";

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchtxtbox = null!;

        [FindsBy(How = How.ClassName, Using = "me-5")]
        private IWebElement _resultsCount = null!;

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(test_url);
        }

        private IWebElement Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.SendKeys(Keys.Return);
            return _driver.WaitUntilVisible(By.ClassName("me-5"));
        }
        public string ResultsCountDescription(string searchText)
        {
            _resultsCount = Search(searchText);
            string theText = _resultsCount.Text;
            return theText;
        }
        public bool ResultsFound(string searchText)
        {
            _resultsCount = Search(searchText);
            string theText = _resultsCount.Text;
            return (theText.Contains("Displaying results"));
        }
    }
}