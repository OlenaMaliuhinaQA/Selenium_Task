using OpenQA.Selenium;

public class BasePage
{
    // locators : tabs, darkmode button, options ..
    // actions: GoToCareerTab
    public By acceptButton = By.Id("onetrust-accept-btn-handler");
    public By careerTab = By.XPath("//a[text()='Careers']");
    public By servicesTab = By.XPath("//a[text()='Services']");
}