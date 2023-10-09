public static class WaitHelper
{
    // use: element = driver.WaitUntilVisible(By.XPath("//input[@value='Save']"));
    public static IWebElement WaitUntilVisible(
        this IWebDriver driver,
        By itemSpecifier,
        int secondsTimeout = 10)
    {
        var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsTimeout));
        var element = wait.Until<IWebElement>(driver =>
        {
                var elementToBeDisplayed = driver.FindElement(itemSpecifier);
                if (!elementToBeDisplayed.Displayed)
                {
                    return null!;
                }
                return elementToBeDisplayed;
        });
        return element;
    }
}