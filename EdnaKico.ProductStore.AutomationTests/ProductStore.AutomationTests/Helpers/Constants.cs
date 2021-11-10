namespace ProductStore.AutomationTests.Helpers
{
    public static class Constants
    {
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Base

        /// <summary>
        /// Installed Google Chrome Web Driver PATH
        /// </summary>
        public static string DRIVER_URL = @"C:\Driver";

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Web Page

        /// <summary>
        /// Demoblaze web size HOME page
        /// </summary>
        public static string HOME_PAGE = @"https://www.demoblaze.com/index.html";

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Elemet ids

        /// <summary>
        /// Signup button id, located on HOME page
        /// </summary>
        public static string SIGNUP_BUTTON_ID = @"signin2";

        /// <summary>
        /// Username input field on signup form
        /// </summary>
        public static string SIGNUP_FORM_USERNAME_INPUT_FIELD_ID = @"sign-username";

        /// <summary>
        /// Password input field on sigunp form
        /// </summary>
        public static string SIGNUP_FORM_PASSWORD_INPUT_FIELD_ID = @"sign-password";

        /// <summary>
        /// Login button id, located on HOME page
        /// </summary>
        public static string LOGIN_BUTTON_ID = @"login2";

        /// <summary>
        /// Username input field on login form
        /// </summary>
        public static string LOGIN_FORM_USERNAME_INPUT_FIELD_ID = @"loginusername";

        /// <summary>
        /// Password input field on login form
        /// </summary>
        public static string LOGIN_FORM_PASSWORD_INPUT_FIELD_ID = @"loginpassword";

        /// <summary>
        /// Wellcome username when logged in
        /// </summary>
        public static string WELCOME_USERNAME_ANCHOR_ID = @"nameofuser";
        
        /// <summary>
        /// Cart button, located on HOME page
        /// </summary>
        public static string CART_BUTTON_ID = @"cartur";

        /// <summary>
        /// Name input field in place order form
        /// </summary>
        public static string PLACE_ORDER_NAME_INPUT_FIELD_ID = @"name";

        /// <summary>
        /// Card input field in place order form
        /// </summary>
        public static string PLACE_ORDER_CARD_INPUT_FIELD_ID = @"card";

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Element Xpath

        /// <summary>
        /// Submit button on sigunp form
        /// </summary>
        public static string SIGNUP_FORM_SIGNUP_BUTTON_XPATH = @"//*[@id=""signInModal""]/div/div/div[3]/button[2]";

        /// <summary>
        /// Submit button on login form
        /// </summary>
        public static string LOGIN_FORM_LOGIN_BUTTON_XPATH = @"//*[@id=""logInModal""]/div/div/div[3]/button[2]";

        /// <summary>
        /// Samsung Galaxy s6 Anchor
        /// </summary>
        public static string SAMSUNG_GALAXY_S6_ANCHOR_XPATH = @"//*[@id=""tbodyid""]/div[1]/div/div/h4/a";

        /// <summary>
        /// Add to cart Anchor
        /// </summary>
        public static string ADD_TO_CART_ANCHOR_XPATH = @"//*[@id=""tbodyid""]/div[2]/div/a";

        /// <summary>
        /// Add to cart Anchor
        /// </summary>
        public static string PLACE_ORDER_BUTTON_XPATH = @"//*[@id=""page-wrapper""]/div/div[2]/button";

        /// <summary>
        /// Add to cart Anchor
        /// </summary>
        public static string PLACE_ORDER_FORM_PURCHASE_BUTTON_XPATH = @"//*[@id=""orderModal""]/div/div/div[3]/button[2]";

        /// <summary>
        /// Thank you for your purchase text
        /// </summary>
        public static string THANK_YOU_FOR_YOUR_PURCHASE_PLACE_ORDER_H2_XPATH = @"/html/body/div[10]/h2";

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Responses

        /// <summary>
        /// Response after successfull sign up
        /// </summary>
        public static string SIGNUP_SUCCESSFUL_RESPONSE_TEXT = @"Sign up successful.";

        /// <summary>
        /// Response if the username exists 
        /// </summary>
        public static string SIGNUP_USERNAMEEXISTS_RESPONSE_TEXT = @"This user already exist.";

        /// <summary>
        /// Response if the password is incorrect 
        /// </summary>
        public static string LOGIN_INCORRECT_PASSWORD_RESPONSE_TEXT = @"Wrong password.";

        /// <summary>
        /// Response if the product is added to cart 
        /// </summary>
        public static string PRODUCT_ADDED_TO_CART_RESPONSE_TEXT = @"Product added";

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Texts

        /// <summary>
        /// A username that already exists. This was checked by previously performing exploratory testing
        /// </summary>
        public static string EXISTING_USERNAME_TEXT = "test";

        /// <summary>
        /// A username that already exists. This was previously created manually
        /// </summary>
        public static string LOGIN_FORM_EXISTING_USERNAME_TEXT = "ednakico";

        /// <summary> 
        /// A Password from user ednakico that was previously created
        /// </summary>
        public static string LOGIN_FORM_EXISTING_PASSWORD_TEXT = "edna76";

        /// <summary> 
        /// Welcome username text that is displayed id navbar after successfull login
        /// </summary>
        public static string WELCOME_USERNAME_AFTER_SUCCESSFULL_LOGIN_TEXT = $"Welcome {LOGIN_FORM_EXISTING_USERNAME_TEXT}";

        /// <summary> 
        /// Randomly generated credit card number
        /// </summary>
        public static string GENERATED_CREDIT_CARD_NUMBER_TEXT = "377070698163159";

        /// <summary> 
        /// Thank you for your purchase text 
        /// </summary>
        public static string THANK_YOU_FOR_YOUR_PURCHASE_TEXT = "Thank you for your purchase!";
        
    }
}
