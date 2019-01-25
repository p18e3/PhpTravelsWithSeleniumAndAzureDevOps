using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PhpTravels.UiTests.PageObjects.Login;
using SeleniumExtras.WaitHelpers;
using System;

namespace PhpTravels.UiTests.Tests.Login
{
  [TestClass]
  public class LoginPageTests : UiTestBase
  {
    [TestInitialize]
    public void Initialize()
    {
      WebDriver = new ChromeDriver();
      WebDriver.Manage().Window.Maximize();
    }

    [TestMethod]
    public void TestLogin_Readable()
    {
      // Arrange.
      LoginPage loginPage = new LoginPage(WebDriver, TestContext);
      string webAppUserName = TestContext.Properties["webAppUserName"].ToString();
      string webAppPassword = TestContext.Properties["webAppPassword"].ToString();

      // Act.      
      var accountPage = loginPage.TypeUserName(webAppUserName)
                                 .TypePassword(webAppPassword)
                                 .PressLoginButton();

      // Assert.
      Assert.IsTrue(accountPage.IsShown);
    }

    [TestMethod]
    public void TestLogin_NotSoReadable()
    {
      // Arrange.
      string webAppUserName = TestContext.Properties["webAppUserName"].ToString();
      string webAppPassword = TestContext.Properties["webAppPassword"].ToString();

      var baseUrl = TestContext.Properties["webAppUrl"].ToString();
      WebDriver.Navigate().GoToUrl(baseUrl);

      var relativeUrl = TestContext.Properties["loginPageRelativeUrl"].ToString();
      WebDriver.Navigate().GoToUrl(new Uri(new Uri(baseUrl), relativeUrl));

      // Act.
      // Write username.
      var usernameWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
      WebDriver.FindElement(By.Name("username")).SendKeys(webAppUserName);

      // Write password.
      var passwordWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
      WebDriver.FindElement(By.Name("password")).SendKeys(webAppPassword);

      // Click login button.
      var loginButtonWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("loginbtn")));
      var loginButton = WebDriver.FindElement(By.ClassName("loginbtn"));
      loginButton.Click();

      // Assert.
      var urlWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlToBe("https://www.phptravels.net/account/"));
    }
  }
}