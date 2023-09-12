using System;

namespace pom
{
    public class PageBase
    {
        public IWebDriver? _driver;
        public WebDriverWait? wait;
        public string test_url = "https://www.ministryoftesting.com";
        public string test_page = "";
        public string? full_test_uri;
    }
}