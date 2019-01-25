using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PhpTravels.UiTests.PageObjects.Account
{
  public class MyProfileContent : PageObjectBase
  {
    private IWebElement _password
    {
      get
      {
        return GetElement(By.Name("password"));
      }
    }

    private IWebElement _confirmPassword
    {
      get
      {
        return GetElement(By.Name("confirmpassword"));
      }
    }

    private IWebElement _updateProfileButton
    {
      get
      {
        return GetElement(By.ClassName("updateprofile"));
      }
    }

    private IWebElement _alertSuccess
    {
      get
      {
        return GetElement(By.ClassName("alert-success"));
      }
    }

    public bool AlertSuccessIsShown
    {
      get
      {
        return _alertSuccess.Displayed;
      }
    }


    public MyProfileContent(IWebDriver webDriver, TestContext testContext)
      : base(webDriver, testContext)
    {
    }

    public override string RelativeUrl => TestContext.Properties["accountPageRelativeUrl"].ToString();

    public MyProfileContent TypePassword(string password)
    {
      _password.SendKeys(password);
      return this;
    }

    public MyProfileContent TypeConfirmPassword(string confirmPassword)
    {
      _confirmPassword.SendKeys(confirmPassword);
      return this;
    }

    public void PressUpdateProfileButton()
    {
      _updateProfileButton.Click();
    }
  }
}