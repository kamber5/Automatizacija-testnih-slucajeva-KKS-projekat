using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automatizacija_testnih_slucajeva___KKS
{
    [TestFixture]
    internal class IncorrectLogin
    {
        private IWebDriver driver = null!;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.intersport.ba/customer/account/login/");
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            driver.Quit();
        }

        [Test]
        public void LoginWithIncorrectCredentials_ShouldFail()
        {
            string email = "kamberovic.amar.19@size.ba";
            string password = "123sifra";

            driver.FindElement(By.Id("username")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);

            driver.FindElement(By.CssSelector("button.action.login.primary#send2")).Click();

            // Provjera pojave poruke o neuspješnoj prijavi
            bool isErrorMessageDisplayed = driver.FindElement(By.ClassName("help-block")).Displayed;

            // Provjera očekivanog rezultata
            Assert.IsTrue(isErrorMessageDisplayed, "Poruka o neuspješnoj prijavi se ne prikazuje!");
        }
    }
}
