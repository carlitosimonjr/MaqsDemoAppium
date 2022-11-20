using CognizantSoftvision.Maqs.BaseAppiumTest;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for HomePageModel inheriting from the BasePageModel
    /// </summary>
    public class HomePageModel : BaseAppiumPageModel
    {
        /// <summary>
        /// The greeting message element 'By' finder
        /// </summary>
        private LazyMobileElement GreetingMessage
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/welcomeLabel"), "Welcome Label"); }
        }

        /// <summary>
        /// The time description element 'By' finder
        /// </summary>
        private LazyMobileElement TimeDisc
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/timeDesc"), "Timer Label"); }
        }

        /// <summary>
        /// The time element 'By' finder
        /// </summary>
        private LazyMobileElement Time
        {
            get { return new LazyMobileElement(this.TestObject, By.Id("com.magenic.appiumtesting.maqsregistrydemo:id/time"), "Timer"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The appium test object</param>
        public HomePageModel(IAppiumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Get greeting text from label
        /// </summary>
        /// <returns>Greeting text string</returns>
        public string GetGreetingMessage()
        {
            return GreetingMessage.Text;
        }

        /// <summary>
        /// Get the time description text from label
        /// </summary>
        /// <returns>Time description text string</returns>
        public string GetTimeDiscription()
        {
            return TimeDisc.Text;
        }

        /// <summary>
        /// Get time from label
        /// </summary>
        /// /// <returns>Time text string</returns>
        public string GetTime()
        {
            return Time.Text;
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the time is displayed</returns>
        public override bool IsPageLoaded()
        {
            return Time.Exists;
        }
    }
}