using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhpTravels.UiTests.PageObjects.Account;

namespace PhpTravels.UiTests.Tests.Account
{
  [TestClass]
  public class AccountPageTests : LoginTestBase
  {
    [TestMethod]
    public void TestChangePassword_ShouldSucceed()
    {
      // Arrange.
      AccountPage accountPage = new AccountPage(WebDriver, TestContext);
      accountPage.PressMyProfileButton();
      MyProfileContent myProfile = accountPage.Content as MyProfileContent;

      // Act.
      myProfile.TypePassword("demouser");
      myProfile.TypeConfirmPassword("demouser");
      myProfile.PressUpdateProfileButton();

      // Assert.
      Assert.IsTrue(myProfile.AlertSuccessIsShown);
    }

    [TestMethod]
    public void TestChangePassword_ShouldSucceed_But_We_Let_It_Fail()
    {
      // Arrange.
      AccountPage accountPage = new AccountPage(WebDriver, TestContext);
      accountPage.PressMyProfileButton();
      MyProfileContent myProfile = accountPage.Content as MyProfileContent;

      // Act.
      myProfile.TypePassword("demouser");
      myProfile.TypeConfirmPassword("demo");
      myProfile.PressUpdateProfileButton();

      // Assert.
      Assert.IsTrue(myProfile.AlertSuccessIsShown);
    }
  }
}