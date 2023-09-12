using System;

namespace pom
{
    public class SearchPage : PageBase
    {


        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            test_page = "search";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
            full_test_uri = Path.Combine(test_url, test_page);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchtxtbox = null!;

        private IWebElement _resultsBox = null!;

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(test_url);
        }

        private IWebElement Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.SendKeys(Keys.Return);
            IWebElement cardContainer = _driver.WaitUntilVisible(By.ClassName("card-header"));
            //FirstOrDefault from a list can get us null rather than the exception that a single FindElement would throw
            return _driver.FindElements(By.ClassName("me-5")).ToList().FirstOrDefault();
        }

        public string ResultsCountDescription(string searchText)
        {
            _resultsBox = Search(searchText);
            if (_resultsBox == null) return String.Empty;
            return _resultsBox.Text;
        }
        public bool ResultsFound(string searchText)
        {
            _resultsBox = Search(searchText);
            if (_resultsBox == null) return false;
            string theText = _resultsBox.Text;
            return (theText.Contains("Displaying results"));
        }
    }
}