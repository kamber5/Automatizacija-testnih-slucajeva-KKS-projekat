using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automatizacija_testnih_slucajeva___KKS
{
    [TestFixture]
    public class ProductDetails
    {
        private IWebDriver driver = null!;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.intersport.ba");
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            driver.Quit();
        }

        [Test]
        public void TestNavigacijaDoDetaljaProizvoda()
        {
            var proizvodLink = driver.FindElement(By.CssSelector("img.product-image.seg-qa-image\n"));
            proizvodLink.Click();

            // Pričekajte neko vrijeme da se stranica učita
            Thread.Sleep(2000); // Pauzirajte izvršavanje na 2 sekunde (prilagodite prema potrebi)

            // Provjerite je li korisnik preusmjeren na stranicu detalja o proizvodu
            var expectedUrl = "https://www.intersport.ba/helly-hansen-hh-logo-t-shirt-muska-majica-508087?_sgm_campaign=scn_9accf1e4d4000&_sgm_source=33979-508087&_sgm_action=click";
            bool isDetaljiProizvodaDisplayed = driver.Url == expectedUrl;

            // Provjera da li je korisnik uspješno preusmjeren na stranicu detalja o proizvodu
            Assert.IsTrue(isDetaljiProizvodaDisplayed, "Korisnik nije preusmjeren na stranicu detalja o proizvodu.");
        }

    }
}
