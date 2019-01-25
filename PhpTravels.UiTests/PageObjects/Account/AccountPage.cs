using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PhpTravels.UiTests.PageObjects.Account
{
  public class AccountPage : PageObjectBase
  {
    public PageObjectBase Content { get; set; }
    private IWebElement MyProfileButton
    {
      get
      {        
        return GetElement(By.XPath("//a[contains(@href, '#profile')]"));
      }
    }

    public AccountPage(IWebDriver webDriver, TestContext testContext)
      : base(webDriver, testContext)
    {

    }

    public override string RelativeUrl => TestContext.Properties["accountPageRelativeUrl"].ToString();

    public void PressMyProfileButton()
    {
      MyProfileButton.Click();
      Content = new MyProfileContent(WebDriver, TestContext);
    }
  }
}