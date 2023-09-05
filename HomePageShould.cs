namespace pom;

public class HomePageShould : IDisposable
{
    private IWebDriver _driver;
    private readonly ITestOutputHelper output;

    public HomePageShould(ITestOutputHelper output)
    {
        _driver = new FirefoxDriver();
        this.output = output;
    }
    public void Dispose()
    {
        _driver.Close();
        _driver.Quit();
    }

    [Fact]
    public void GoToLearnPageWhenLearnLinkClicked()
    {
        MinistryHome ministryHome = new MinistryHome(_driver);
        ministryHome.GoTo();
        ministryHome.Learn();
        Assert.Contains("Learn with Ministry of Testing", _driver.Title);
    }
}