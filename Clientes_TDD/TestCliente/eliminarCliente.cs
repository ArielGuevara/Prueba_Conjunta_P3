using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestCliente
{
    public class eliminarCliente : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait _wait;

        public eliminarCliente()
        {
            var options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(@"C:\WebDriver", options);
            driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        [Fact]
        public void Eliminar_Cliente_ReturnData()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://localhost:7221/Cliente");

            var codigoBuscado = "11";
            var errorMessageElement = _wait.Until(d => d.FindElements(By.CssSelector("td")));
            bool encontrado = errorMessageElement.Any(element => element.Text.Contains(codigoBuscado, StringComparison.OrdinalIgnoreCase));
            Thread.Sleep(1000);
            if (encontrado)
            {
                Thread.Sleep(1000);
                driver.FindElement(By.Id(codigoBuscado)).Click();
            }


            Assert.True(encontrado,"No existe un cliente con codigo: " + codigoBuscado);
            Assert.Equal("https://localhost:7221/Cliente", driver.Url);
        }

        public void Dispose()
        {
            driver?.Dispose();
        }
    }

}

