using Alura.ByteBank.WebApp.Testes.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome : IClassFixture<Fixture>
    {

        private IWebDriver driver;

        //Setup
        public NavegandoNaPaginaHome(Fixture fixture)
        {
            //diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //driver = new ChromeDriver(diretorio);
            driver = fixture.Driver;
        }

        [Fact]
        public void NavagarAtePaginaHome()
        {
            //Obtendo o webdriver do chrome
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //Navegar ate a pagina home
            driver.Navigate().GoToUrl("https://localhost:44309/");

            Assert.Contains("WebApp", driver.Title);
            driver.Quit();
        }


        [Fact]
        public void CarregadaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); ;
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
            driver.Quit();
        }
    }
}
