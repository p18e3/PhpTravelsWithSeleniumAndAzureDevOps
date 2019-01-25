using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Diagnostics;
using System.IO;

namespace PhpTravels.UiTests.Tests
{
  [TestClass]
  public abstract class UiTestBase
  {
    #region Protected fields.

    protected IWebDriver WebDriver;

    #endregion

    #region Properties.

    public TestContext TestContext { get; set; }

    #endregion

    #region TestCleanup.

    [TestCleanup]
    public void TestCleanup()
    {
      Trace.TraceInformation("TestCleanup()");

      if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
      {
        HandleFailedTest();
        TakeScreenshot();
      }

      WebDriver.Quit();
    }

    #endregion

    #region Private methods.

    private void HandleFailedTest()
    {
      Trace.TraceError("Test failed.");
      Trace.TraceInformation($"Current URL of the WebDriver: {WebDriver.Url}");

      // Maybe create a bug in the Azure DevOps backlog.
    }

    private void TakeScreenshot()
    {
      Trace.TraceInformation($"Tacking screenshot ...");
      Screenshot screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
      string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
      string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
      screenshot.SaveAsFile(filePath);
      TestContext.AddResultFile(filePath);
      Trace.TraceInformation($"Saved Screenshot to {filePath}");
    }

    #endregion
  }
}