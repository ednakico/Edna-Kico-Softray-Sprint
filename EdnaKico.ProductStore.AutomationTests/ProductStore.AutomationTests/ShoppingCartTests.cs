using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductStore.AutomationTests.Helpers;
using System;

namespace ProductStore.AutomationTests
{
    public class ShoppingCartTests
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
        public void ShoppingCartTest_SimulatesOrderFlow_OrderSuccessfullyPlaced()
        {
            // Arange
            _webDriver.Navigate().GoToUrl(Constants.HOME_PAGE);

            // Act
            var itemFailedToBeAddedToCart = AddItemToCart(_webDriver);

            if (itemFailedToBeAddedToCart)
            {
                Assert.IsTrue(false);
            }

            OpenCartPage(_webDriver);
            OpenPlaceOrderForm(_webDriver);

            var placeOrderFormNameInputField = _webDriver.FindElement(By.Id(Constants.PLACE_ORDER_NAME_INPUT_FIELD_ID));
            var placeOrderFormCardInputField = _webDriver.FindElement(By.Id(Constants.PLACE_ORDER_CARD_INPUT_FIELD_ID));
            var placeOrderPurchaseButton = _webDriver.FindElement(By.XPath(Constants.PLACE_ORDER_FORM_PURCHASE_BUTTON_XPATH));

            placeOrderFormNameInputField.SendKeys(Constants.LOGIN_FORM_EXISTING_USERNAME_TEXT);
            placeOrderFormCardInputField.SendKeys(Constants.GENERATED_CREDIT_CARD_NUMBER_TEXT);
            placeOrderPurchaseButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.THANK_YOU_FOR_YOUR_PURCHASE_PLACE_ORDER_H2_XPATH))); // wait until the "thank you for your purchace" displays

            var thankYouForYourPurchasePlaceOrderTag= _webDriver.FindElement(By.XPath(Constants.THANK_YOU_FOR_YOUR_PURCHASE_PLACE_ORDER_H2_XPATH));

            // Assert
            Assert.AreEqual(thankYouForYourPurchasePlaceOrderTag.Text, Constants.THANK_YOU_FOR_YOUR_PURCHASE_TEXT);

            _webDriver.Close();
            _webDriver.Quit();
        }

        /// <summary>
        /// Method that ads item to the cart and accepts the alert message
        /// </summary>
        /// <param name="webDriver">chrome web driver object</param>
        /// <returns>True if alert text is different from successfull added item to cart text, false if the item was added to cart sucessfully</returns>
        private bool AddItemToCart(IWebDriver webDriver)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.SAMSUNG_GALAXY_S6_ANCHOR_XPATH))); // wait until products load
            var samsungGalaxyS6Anchor = webDriver.FindElement(By.XPath(Constants.SAMSUNG_GALAXY_S6_ANCHOR_XPATH));

            samsungGalaxyS6Anchor.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.ADD_TO_CART_ANCHOR_XPATH))); // wait until products load

            var addToCartAnchor = webDriver.FindElement(By.XPath(Constants.ADD_TO_CART_ANCHOR_XPATH));

            addToCartAnchor.Click();
            _wait.Until(driver => driver.SwitchTo().Alert());

            var alert = webDriver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();

            return alertText != Constants.PRODUCT_ADDED_TO_CART_RESPONSE_TEXT;
        }

        /// <summary>
        /// Method that opens cart page by clicking on Cart navbar button
        /// </summary>
        /// <param name="webDriver">chrome web driver object</param>
        private void OpenCartPage(IWebDriver webDriver)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Constants.CART_BUTTON_ID)));
            var cartButton = webDriver.FindElement(By.Id(Constants.CART_BUTTON_ID));
            cartButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Constants.PLACE_ORDER_BUTTON_XPATH))); // wait until the cart page loads
        }

        /// <summary>
        /// Method that opens purchace form by clicking on place order button on cart page
        /// </summary>
        /// <param name="webDriver">chrome web driver object</param>
        private void OpenPlaceOrderForm(IWebDriver webDriver)
        {
            var placeOrderButton = webDriver.FindElement(By.XPath(Constants.PLACE_ORDER_BUTTON_XPATH));
            placeOrderButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Constants.PLACE_ORDER_NAME_INPUT_FIELD_ID))); // wait until the form opens
        }
    }
}
