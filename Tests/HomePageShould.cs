namespace pom;

public class HomePageShould : TestBase, IDisposable
{
    private readonly ITestOutputHelper output;

    public HomePageShould(ITestOutputHelper output)
    {
        this.output = output;
    }


    [Fact]
    public void GoToLearnPageWhenLearnLinkClicked()
    {
        MinistryHomePage ministryHome = new MinistryHomePage(_driver);
        ministryHome.GoTo();
        ministryHome.Learn();
        Assert.Contains("Learn with Ministry of Testing", _driver.Title);
    }
}