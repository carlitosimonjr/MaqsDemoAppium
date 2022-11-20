using CognizantSoftvision.Maqs.BaseAppiumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;
using System;

namespace Tests
{
    /// <summary>
    /// AppiumTestsVSUnit test class with VSUnit
    /// </summary>
    [TestClass]
    public class MaqsAppiumTests : BaseAppiumTest
    {

        /// <summary>
        /// Login test
        /// </summary>
        [TestMethod]
        public void LoginTest()
        {
            // ++++ ARRANGE - setup the testing objects and prepare the prerequisites for your test ++++
            string expectedError = $"Use the following credentials: {Environment.NewLine}(User Name: Ted Password: 123)";
            string username = "Ted";
            string password = "123";
            string expectedGreeting = $"Welcome {username}!";
            string expectedTimeDescription = "The current time is:";

            // Instantiate Login page object model
            LoginPageModel startingPage = new LoginPageModel(this.TestObject);

            // ++++ ACT - perform the actual work of the test ++++

            // Login using invalid credentials
            startingPage.LoginWithInvalidCredentials("Not", "Valid");

            // ++++ ASSERT - verify the result ++++
            Assert.AreEqual(expectedError, startingPage.GetErrorMessage());

            // Closes the invalid credentials dialog box
            startingPage.CloseInvalidCredentialDialog();

            // Log in using valid credentials
            HomePageModel homePage = startingPage.LoginWithValidCredentials(username, password);

            // Verifies if details on home page are correct
            SoftAssert.Assert(() => Assert.AreEqual(expectedGreeting, homePage.GetGreetingMessage(), "Incorrect message"));
            SoftAssert.Assert(() => Assert.AreEqual(expectedTimeDescription, homePage.GetTimeDiscription()), "Incorrect description");
            SoftAssert.Assert(() => Assert.IsTrue(DateTime.TryParse(homePage.GetTime(), out DateTime time), "Time Parsing"));

            // Provides proper summary when assert fails
            SoftAssert.FailTestIfAssertFailed();
        }
    }
}
