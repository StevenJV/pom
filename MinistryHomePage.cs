using System;

namespace pom
{
    public class MinistryHomePage : PageBase
    {
        [FindsBy(How = How.Id, Using = "learnNav")]
        private readonly IWebElement _topnavlearn = null!;

        public MinistryHomePage(IWebDriver driver): base(driver)
        {
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(500));
            _url = Path.Combine(_urlBase, _urlPage);
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(_urlBase);
        }

        public void Learn()
        {
            _topnavlearn.Click();
        }
    }
}