using System;

namespace pom
{
    public class PageBase
    {
        public IWebDriver _driver;
        public WebDriverWait? _wait;
        public string _urlBase = "https://www.ministryoftesting.com";
        public string _urlPage = "";
        public string? _url;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}