namespace pom;

public class SearchPageShould : IDisposable
{
    private IWebDriver _driver;
    private readonly ITestOutputHelper output;

    public SearchPageShould(ITestOutputHelper output)
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
    public void FindArticlesWhenSearchIsUsed()
    {
        SearchPage searchPage = new SearchPage(_driver);
        searchPage.GoTo();
        string resultText = searchPage.ResultsCountDescription("testbash");
        output.WriteLine("resultText: {0}", resultText);
        Assert.Contains("Displaying results", resultText);
    }
}