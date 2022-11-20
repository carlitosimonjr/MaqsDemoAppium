using CognizantSoftvision.Maqs.BaseAppiumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the LoginPageModel inheriting from the BasePageModel
    /// </summary>
    public class LoginPageModel : BaseAppiumPageModel
    {
        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        private LazyMobileElement UserNameInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/userNameField"), "User Name Field"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        private LazyMobileElement PasswordInput
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/passwordField"), "Password Field"); }
        }

        /// <summary>
        /// The login button element 'By' finder
        /// </summary>
        private LazyMobileElement LoginButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/loginButton"), "Login Button"); }
        }

        /// <summary>
        /// The error message element 'By' finder
        /// </summary>
        private LazyMobileElement ErrorMessage
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("android:id/message"), "Error Message Label"); }
        }

        /// <summary>
        /// The ok button element 'By' finder
        /// </summary>
        private LazyMobileElement InvalidCredentialOkButton
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("android:id/button3"), "Ok Button"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The appium test object</param>
        public LoginPageModel(IAppiumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Enter the user credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void EnterCredentials(string userName, string password)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(userName);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        /// <summary>
        /// Enter the use credentials and try to log in - Verify login failed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void LoginWithInvalidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();
        }

        /// <summary>
        /// Enter the use credentials and log in - Navigation sample
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        /// <returns>Home Page Object Model</returns>
        public HomePageModel LoginWithValidCredentials(string userName, string password)
        {
            EnterCredentials(userName, password);
            LoginButton.Click();
            return new HomePageModel(this.TestObject);
        }

        /// <summary>
        /// Get text from error message label
        /// </summary>
        /// <returns>Error Message text string</returns>
        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        /// <summary>
        /// Clicks Ok button from the invalid credential dialog
        /// </summary>
        public void CloseInvalidCredentialDialog()
        {
            InvalidCredentialOkButton.Click();
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the login button is displayed</returns>
        public override bool IsPageLoaded()
        {
            return LoginButton.Exists;
        }
    }
}