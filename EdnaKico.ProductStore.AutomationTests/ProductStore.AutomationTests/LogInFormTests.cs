using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using ProductStore.AutomationTests.Helpers;
using OpenQA.Selenium.Support.UI;

namespace ProductStore.AutomationTests
{
    public class LogInFormTests
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
        public void LogInFormSmokeTest_DisplaysFormContent_SuccessfullyOpened()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var loginButton = _webDriver.FindElement(By.Id(Constants.LOGIN_BUTTON_ID));

            // Act
            loginButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH)));

            var loginFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_USERNAME_INPUT_FIELD_ID));
            var loginFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_PASSWORD_INPUT_FIELD_ID));
            var loginFormLoginButton = _webDriver.FindElement(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH));

            // Assert
            Assert.That(loginFormUsernameInputField.Displayed, Is.True);
            Assert.That(loginFormPasswordInputField.Displayed, Is.True);
            Assert.That(loginFormLoginButton.Displayed, Is.True);

            _webDriver.Close();
            _webDriver.Quit();
        }

        [Test]
        public void LogInFormLoginTest_FillsOutTheFormAndSubmits_WillLoginExistingUser()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var loginButton = _webDriver.FindElement(By.Id(Constants.LOGIN_BUTTON_ID));

            // Act
            loginButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH)));

            var loginFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_USERNAME_INPUT_FIELD_ID));
            var loginFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_PASSWORD_INPUT_FIELD_ID));
            var loginFormLoginButton = _webDriver.FindElement(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH));

            loginFormUsernameInputField.SendKeys(Constants.LOGIN_FORM_EXISTING_USERNAME_TEXT);
            loginFormPasswordInputField.SendKeys(Constants.LOGIN_FORM_EXISTING_PASSWORD_TEXT);
            loginFormLoginButton.Click();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Constants.WELCOME_USERNAME_ANCHOR_ID)));
            var welcomeUser = _webDriver.FindElement(By.Id(Constants.WELCOME_USERNAME_ANCHOR_ID));

            // Assert
            Assert.That(welcomeUser.Displayed, Is.True);
            Assert.That(welcomeUser.Text.Contains(Constants.WELCOME_USERNAME_AFTER_SUCCESSFULL_LOGIN_TEXT));

            _webDriver.Close();
            _webDriver.Quit();
        }

        [Test]
        public void LogInFormLoginTest_FillsOutTheFormWithExistingUserAndWrongPasswordAndSubmits_WillShowWrongPasswordAlert()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            var loginButton = _webDriver.FindElement(By.Id(Constants.LOGIN_BUTTON_ID));

            // Act
            loginButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH)));

            var loginFormUsernameInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_USERNAME_INPUT_FIELD_ID));
            var loginFormPasswordInputField = _webDriver.FindElement(By.Id(Constants.LOGIN_FORM_PASSWORD_INPUT_FIELD_ID));
            var loginFormLoginButton = _webDriver.FindElement(By.XPath(Constants.LOGIN_FORM_LOGIN_BUTTON_XPATH));

            loginFormUsernameInputField.SendKeys(Constants.LOGIN_FORM_EXISTING_USERNAME_TEXT);
            loginFormPasswordInputField.SendKeys(Guid.NewGuid().ToString());
            loginFormLoginButton.Click();

            _wait.Until(driver => driver.SwitchTo().Alert());
            var alert = _webDriver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();

            // Assert
            Assert.IsTrue(alertText.Contains(Constants.LOGIN_INCORRECT_PASSWORD_RESPONSE_TEXT));

            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}