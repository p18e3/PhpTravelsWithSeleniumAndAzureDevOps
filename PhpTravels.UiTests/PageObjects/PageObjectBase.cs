using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Diagnostics;

namespace PhpTravels.UiTests.PageObjects
{
  public abstract class PageObjectBase
  {
    #region Private fields.

    private TimeSpan _waitTimeout;

    #endregion

    #region Properties.

    public abstract string RelativeUrl { get; }
    public string WebAppUrl { get => TestContext.Properties["webAppUrl"].ToString(); }
    public string PageUrl { get => $"{WebAppUrl}{RelativeUrl}"; }
    public bool IsShown
    {
      get
      {
        try
        {
          var webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10))
                                         .Until(ExpectedConditions.UrlToBe(PageUrl));
          return true;
        }
        catch (Exception ex)
        {
          Trace.TraceError($"Requested PageUrl ({PageUrl}) is not shown:");
          Trace.TraceError(ex.ToString());
          return false;
        }
      }
    }

    public IWebDriver WebDriver { get; }

    public TestContext TestContext { get; set; }

    #endregion

    #region Construction.

    protected PageObjectBase(IWebDriver webDriver, TestContext testContext)
    {
      this.WebDriver = webDriver;
      this.TestContext = testContext;
      SetConfigurationParameters();
    }

    private void SetConfigurationParameters()
    {
      int.TryParse(TestContext.Properties["waitTimeout"].ToString(), out int waitTimeout);
      _waitTimeout = TimeSpan.FromSeconds(waitTimeout);
    }

    #endregion

    #region Public Methods.

    public void WaitForElementToBePresent(By locator)
    {
      try
      {
        Trace.TraceInformation($"Waiting for element to be present: {locator.ToString()}");
        var wait = new WebDriverWait(WebDriver, _waitTimeout)
                      .Until(ExpectedConditions.ElementIsVisible(locator));
      }
      catch (Exception exception)
      {
        Trace.TraceError(exception.ToString());
      }
    }

    public IWebElement GetElement(By locator)
    {
      WaitForElementToBePresent(locator);
      return WebDriver.FindElement(locator);
    }

    #endregion
  }
}