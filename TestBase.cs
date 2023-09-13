namespace pom;

public class TestBase : IDisposable
{
    public IWebDriver _driver;

    public TestBase()
    {
        _driver = new FirefoxDriver();
    }
    public void Dispose()
    {
        _driver.Close();
        _driver.Quit();
    }
}