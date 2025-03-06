using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTest.Utilities;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();
        private int resultado = 0;

        //private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public InsertStepDefinitions(ScenarioContext scenarioContext)
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

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }
        [Given("Llenar los campos del formulario")]
        public void GivenLlenarLosCamposDelFormulario(DataTable dataTable)
        {
            resultado = dataTable.Rows.Count();
            Assert.True(resultado > 0);//resultado.Should().BeGreaterThanOrEqualTo(1); -> esto se usaba en Specflow
            _test.Log(Status.Pass, "Los campos del formulario se encuentran cargados");
        }

        [When("Registro del usuario en la BDD")]
        public void WhenRegistroDelUsuarioEnLaBDD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            Cliente cls = new Cliente();

            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Nombres = item.Nombres;
                cls.Apellidos = item.Apellidos;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
            }
            if (cls.Cedula.Length < 10)
            {
                _test.Log(Status.Fail, $"Usuario de nombre: {cls.Nombres} tinene mal ingresada su cedula");
            }
            else
            {
                _clienteDAL.AddCliente(cls);
                _test.Log(Status.Info, $"Usuario de nombre: {cls.Nombres} y cedula {cls.Cedula} se ha insertado en la BDD");
            }
               
        }

        [Then("El resultado del registro en la BDD")]
        public void ThenElResultadoDelRegistroEnLaBDD(DataTable dataTable)
        {
            var registrosBDD = _clienteDAL.GetClientes();
            var newRegistro = dataTable.CreateSet<Cliente>().ToList().First();

            var bandera = false;

            try
            {
                foreach (var registro in registrosBDD)
                {
                    if (registro.Cedula == newRegistro.Cedula &&
                        registro.Nombres == newRegistro.Nombres)
                    {
                        bandera = true; break;
                    }
                }
                Assert.True(bandera);
                _test.Log(Status.Pass, "usuario existe en la BDD");
            }
            catch
            {
                _test.Log(Status.Fail, "El usuario no se encuentra registrado en la BDD");
            }
            
        }
    }
}