using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class TestClienteInsert : IDisposable
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait _wait;

    public TestClienteInsert()
    {
        var options = new FirefoxOptions();
        options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
        driver = new FirefoxDriver(@"C:\WebDriver", options);
        driver.Manage().Window.Maximize();

        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
    }

    [Fact]
    public void Create_Cliente_ReturnData()
    {
        //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Cedula")).SendKeys("1050238649");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Apellidos")).SendKeys("Silva");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Nombres")).SendKeys("Raul");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("FechaNacimiento")).SendKeys("2025-01-01");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Mail")).SendKeys("sjosemail@gmail.com");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Telefono")).SendKeys("0939225866");
        Thread.Sleep(1000);
        driver.FindElement(By.Id("Direccion")).SendKeys("Quito");
        Thread.Sleep(1000);

        driver.FindElement(By.Id("btn-create")).Click();

        Assert.Equal("https://localhost:7221/Cliente", driver.Url);
    }

    public void Dispose()
    {
        driver?.Dispose();
    }
}
