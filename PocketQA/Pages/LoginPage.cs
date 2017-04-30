using OpenQA.Selenium.Remote;

namespace PocketQA.Pages
{
    public abstract class LoginPage : Page
    {
        public const string PageUrl = "Account/Login";

        public override string Url => PageUrl;

        protected LoginPage(RemoteWebDriver driver, string baseUrl)
            : base(driver, baseUrl)
        {
        }

        public string UserNameValidationError => FindElementById("UserName-error")?.Text;

        public string PasswordValidationError => FindElementById("Password-error")?.Text;

        public string SummaryValidationError => FindElementById(SummaryValidationErrorElementId)?.Text;

        public abstract string SummaryValidationErrorElementId { get; }

        public void Login(string email, string password)
        {
            TypeEmail(email);
            TypePassword(password);
            SubmitPage();
            WaitForRedirect();
        }

        public void Login()
        {
            Login(TestsSettings.ValidUserEmail, TestsSettings.ValidUserPassword);
        }

        public void TypeEmail(string email)
        {
            TypeFieldValue(EmailFieldId, email);
        }

        public abstract string EmailFieldId { get; }

        public void TypePassword(string password)
        {
            TypeFieldValue(PasswordFieldId, password);
        }

        public abstract string PasswordFieldId { get; }

        public string Email => GetFieldValue(EmailFieldId);

        public string Password => GetFieldValue(PasswordFieldId);

        public virtual string PageTitle
        {
            get
            {
                var element = FindElementByTagName("h4");
                return element?.Text;
            }
        }

        public override void Open()
        {
            Open(true);
        }

        public void Open(bool clearCookies)
        {
            if (clearCookies)
            {
                Driver.Manage().Cookies.DeleteAllCookies();
            }

            base.Open();
        }
    }
}
