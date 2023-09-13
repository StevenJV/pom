using System;

namespace pom
{
    public class SearchPage : PageBase
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _urlPage = "search";
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(_driver, this);
            _url = Path.Combine(_urlBase, _urlPage);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private readonly IWebElement _searchtxtbox = null!;

        private IWebElement? _resultsBox = null!;

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(_urlBase);
        }

        private IWebElement? Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.SendKeys(Keys.Return);
            if(_driver.WaitUntilVisible(By.ClassName("card-header")) == null) return null;
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
            return (_resultsBox.Text.Contains("Displaying results"));
        }
    }
}