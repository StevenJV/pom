public static class WaitHelper
{
    // use: element = driver.WaitUntilVisible(By.XPath("//input[@value='Save']"));
    public static IWebElement? WaitUntilVisible(this IWebDriver driver,
                                                By itemSpecifier,
                                                int secondsTimeout = 10)
    {
        var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsTimeout));
        var element = wait.Until<IWebElement>(driver =>
        {
            IWebElement? elementToBeDisplayed = driver.FindElement(itemSpecifier);
            return elementToBeDisplayed;
        });
        return element;
    }
}