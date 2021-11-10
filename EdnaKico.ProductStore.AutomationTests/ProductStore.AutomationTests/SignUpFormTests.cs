using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using ProductStore.AutomationTests.Helpers;
using OpenQA.Selenium.Support.UI;

namespace ProductStore.AutomationTests
{
    public class SignUpFormTests
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver(Constants.DRIVER_URL);
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void SignUpFormSmokeTest_DisplaysFormContent_SuccessfullyOpened()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var signUpButton = _webDriver.FindElement(By.Id(Constants.SIGNUP_BUTTON_ID));

            // Act
            signUpButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH)));

            var signUpFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_USERNAME_INPUT_FIELD_ID));
            var signUpFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_PASSWORD_INPUT_FIELD_ID));
            var signUpFormSignUpButton = _webDriver.FindElement(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH));

            // Assert
            Assert.That(signUpFormUsernameInputField.Displayed, Is.True);
            Assert.That(signUpFormPasswordInputField.Displayed, Is.True);
            Assert.That(signUpFormSignUpButton.Displayed, Is.True);

            _webDriver.Close();
            _webDriver.Quit();
        }

        [Test]
        public void SingUpFormRegistrationTest_FillsOutTheFormAndSubmits_WillCreateANewUser()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var signUpButton = _webDriver.FindElement(By.Id(Constants.SIGNUP_BUTTON_ID));

            // Act
            signUpButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH)));

            var signUpFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_USERNAME_INPUT_FIELD_ID));
            var signUpFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_PASSWORD_INPUT_FIELD_ID));
            var signUpFormSignUpButton = _webDriver.FindElement(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH));

            signUpFormUsernameInputField.SendKeys(Guid.NewGuid().ToString());
            signUpFormPasswordInputField.SendKeys(Guid.NewGuid().ToString());
            signUpFormSignUpButton.Click();
            _wait.Until(driver => driver.SwitchTo().Alert());

            var alert = _webDriver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();

            // Assert
            Assert.IsTrue(alertText.Contains(Constants.SIGNUP_SUCCESSFUL_RESPONSE_TEXT));

            _webDriver.Close();
            _webDriver.Quit();
        }

        [Test]
        public void SingUpFormRegistrationTest_FillsOutTheFormWithExistingUsernameAndSubmits_WillFailToCreateANewUser()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var signUpButton = _webDriver.FindElement(By.Id(Constants.SIGNUP_BUTTON_ID));

            // Act
            signUpButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH)));

            var signUpFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_USERNAME_INPUT_FIELD_ID));
            var signUpFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.SIGNUP_FORM_PASSWORD_INPUT_FIELD_ID));
            var signUpFormSignUpButton = _webDriver.FindElement(By.XPath(Constants.SIGNUP_FORM_SIGNUP_BUTTON_XPATH));

            signUpFormUsernameInputField.SendKeys(Constants.EXISTING_USERNAME_TEXT);
            signUpFormPasswordInputField.SendKeys(Guid.NewGuid().ToString());
            signUpFormSignUpButton.Click();
            _wait.Until(driver => driver.SwitchTo().Alert());

            var alert = _webDriver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();

            // Assert
            Assert.IsTrue(alertText.Contains(Constants.SIGNUP_USERNAMEEXISTS_RESPONSE_TEXT));

            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}