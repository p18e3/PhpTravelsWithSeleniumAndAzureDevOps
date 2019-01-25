using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using PhpTravels.UiTests.PageObjects.Login;
using System.Diagnostics;

namespace PhpTravels.UiTests.Tests
{
  [TestClass]
  public abstract class LoginTestBase : UiTestBase
  {
    #region Test initialize.

    [TestInitialize]
    public void TestInitialize()
    {
      Trace.TraceInformation("TestInitialize()");

      WebDriver = new ChromeDriver();
      WebDriver.Manage().Window.Maximize();
      Login();
    }

    #endregion

    #region Login.

    private void Login()
    {
      LoginPage loginPage = new LoginPage(WebDriver, TestContext);
      string webAppUserName = TestContext.Properties["webAppUserName"].ToString();
      string webAppPasword = TestContext.Properties["webAppPassword"].ToString();

      var accountPage = loginPage.TypeUserName(webAppUserName)
                           .TypePassword(webAppPasword)
                           .PressLoginButton();
    }

    #endregion
  }
}