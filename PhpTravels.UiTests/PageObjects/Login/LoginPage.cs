using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PhpTravels.UiTests.PageObjects.Account;

namespace PhpTravels.UiTests.PageObjects.Login
{
  public class LoginPage : PageObjectBase
  {
    #region Private fields.

    private IWebElement UserName
    {
      get
      {
        return GetElement(By.Name("username"));
      }
    }

    private IWebElement Password
    {
      get
      {
        return GetElement(By.Name("password"));
      }
    }

    private IWebElement LoginButton
    {
      get
      {
        return GetElement(By.ClassName("loginbtn"));
      }
    }

    #endregion

    #region Properties.

    public override string RelativeUrl => TestContext.Properties["loginPageRelativeUrl"].ToString();

    #endregion

    #region Construction.

    public LoginPage(IWebDriver webDriver, TestContext testContext)
      : base(webDriver, testContext)
    {
      WebDriver.Navigate().GoToUrl(PageUrl);
    }

    #endregion

    #region Public methods.

    public LoginPage TypeUserName(string userName)
    {
      UserName.SendKeys(userName);
      return this;
    }

    public LoginPage TypePassword(string password)
    {
      Password.SendKeys(password);
      return this;
    }

    public AccountPage PressLoginButton()
    {
      LoginButton.Click();
      return new AccountPage(WebDriver, TestContext);
    }

    #endregion
  }
}