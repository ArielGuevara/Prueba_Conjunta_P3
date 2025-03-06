using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTest.Utilities;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var spartReporter = new ExtentSparkReporter("ExtendReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(spartReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("firefox");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("que el usuario esta en la pagina del login")]
        public void GivenQueElUsuarioEstaEnLaPaginaDelLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la página del login");
        }

        [When("ingresa el correo {string} y la contraseña {string}")]
        public void WhenIngresaElCorreoYLAcontrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario ingresa correo: {email} y contraseña {password}");
        }

        [When("hacer clic en el boton de inicio de sesión")]
        public void WhenHacerClicEnElBotonDeInicioDeSesion()
        {
            try
            {
                bool isLoggedIn = _driver.FindElement(By.ClassName("user-info")) != null;

                _test.Log(Status.Pass, "Inicio de sesion exitoso");
            }
            catch (NoSuchElementException) 
            {
                _test.Log(Status.Fail, "Error en el inicio de sesión");
            }
        }

        [Then("deberia mostrarse un mensaje de error")]
        public void ThenDeberiaMostrarseUnMensajeDeError()
        {
            try
            {
                bool isError = _driver.FindElement(By.ClassName("login_error")) != null;

                _test.Log(Status.Pass, "mensaje de error mostrado correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostro el mensaje de error");
            }
        }

        [AfterScenario]

        public void Down()
        {
            //_driver.Quit();
            _extent.Flush();
        }
    }
}
