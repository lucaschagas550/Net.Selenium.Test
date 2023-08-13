using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Util;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Fixture>
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;
        public AposRealizarLogin(Fixture fixture, ITestOutputHelper _saidaConsoleTeste)
        {
            driver = fixture.Driver;
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            ////Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");//Seta valore no campo login
            //senha.SendKeys("senha01"); //Seta valore no campo senha

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("Agência", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            ////login.SendKeys("andre@email.com");
            ////senha.SendKeys("senha01");

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("The Email field is required.", driver.PageSource);
            //Assert.Contains("The Senha field is required.", driver.PageSource);


            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("", "");
            loginPO.Logar();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            ////Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha010");//senha inválida.

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("Login", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01x");
            loginPO.Logar();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }

    }
}
