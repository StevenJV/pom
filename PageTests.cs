namespace pom;

public class PageTests : IDisposable
{
    private IWebDriver _driver;

    public PageTests()
    {
        _driver = new FirefoxDriver();
    }
    public void Dispose()
        {
            _driver.Close();
        }

    [Fact]
    public void TopNavLearnLink()
    {
        MinistryHome ministryHome = new MinistryHome(_driver);
        ministryHome.GoTo();
        ministryHome.Learn();
        Assert.Contains("Learn with Ministry of Testing", _driver.Title);
    }
}