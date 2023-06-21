using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automatizacija_testnih_slucajeva___KKS
{
    [TestFixture]
    public class CorrectLogin
    {
        //Mo�e sadr�avati null vrijednost
        private IWebDriver driver = null!;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Postavljanje WebDrivera i otvaranje stranice samo jednom prije po�etka svih testova
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.intersport.ba/customer/account/login/");
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            // Zatvaranje preglednika nakon zavr�etka svih testova
            driver.Quit();
        }

        [Test]
        public void LoginWithCorrectCredentials_ShouldSucceed()
        {
            // Unos ispravnih kredencijala za prijavu
            string email = "amar.kamberovic.20@size.ba";
            string password = "sifra123";

            // Unos emaila i lozinke
            driver.FindElement(By.Id("username")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Klik na gumb za prijavu
            driver.FindElement(By.CssSelector("button.action.login.primary#send2")).Click();

            // Provjera da li je prijava uspje�na - provjera prisutnosti elementa na prijavljenoj stranici
            bool isLoggedIn = driver.FindElement(By.Id("a.level-top[href=\"https://www.intersport.ba/sportovi\"]")).Displayed;

            // Provjera o�ekivanog rezultata
            Assert.IsTrue(isLoggedIn, "Prijavljivanje je uspjelo!");
        }
    }
}