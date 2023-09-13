namespace pom;

public class SearchPageShould : TestBase, IDisposable
{
    private readonly ITestOutputHelper output;

    public SearchPageShould(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void FindArticlesWhenSearchIsUsed()
    {
        SearchPage searchPage = new SearchPage(_driver);
        searchPage.GoTo();
        string resultText = searchPage.ResultsCountDescription("testbash");
        output.WriteLine("resultText: '{0}'", resultText);
        Assert.Contains("Displaying results", resultText);
    }
    [Fact]
    public void DisplayMessageWhenSearchFails()
    {
        SearchPage searchPage = new SearchPage(_driver);
        searchPage.GoTo();
        string resultText = searchPage.ResultsCountDescription("NotAGoodSearch");
        output.WriteLine("resultText: '{0}'", resultText);
        Assert.True(String.IsNullOrEmpty(resultText));
    }
}