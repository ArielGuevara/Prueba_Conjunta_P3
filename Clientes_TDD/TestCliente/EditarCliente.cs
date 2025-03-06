using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;

namespace TestCliente
{
    public class EditarCliente : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait _wait;

        public EditarCliente()
        {
            var options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(@"C:\WebDriver", options);
            driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }


        [Fact]
        public void Editar_Cliente_ReturnData()
        {
            var codigoBuscado = "19";
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Edit/"+codigoBuscado);

            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).SendKeys("Maradona");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Nombres")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Nombres")).SendKeys("Diego");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).SendKeys("maradona@gmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btn-guardar")).Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://localhost:7221/Cliente");

            var errorMessageElement = _wait.Until(d => d.FindElements(By.CssSelector("td")));
            bool encontrado = errorMessageElement.Any(element => element.Text.Contains(codigoBuscado, StringComparison.OrdinalIgnoreCase));
  
            Assert.True(encontrado, "No existe un cliente con codigo: " + codigoBuscado);

            //Assert.True(encontrado, "No existe un cliente con codigo: " + codigoBuscado);
            Assert.Equal("https://localhost:7221/Cliente", driver.Url);
        }
        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
   
