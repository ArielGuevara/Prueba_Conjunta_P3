using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Reqnroll;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class DeleteStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();
        private Cliente _clienteExistente;

        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public DeleteStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var spartReporter = new ExtentSparkReporter("ExtendReport3.html");
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
            //_driver = WebDriverManager.GetDriver("firefox");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("Llenar los campos del formulario para eliminar")]
        public void GivenLlenarLosCamposDelFormularioParaEliminar(DataTable dataTable)
        {
            var row = dataTable.Rows[0];
            var cedula = row["Cedula"];

            // Validar si el cliente ya existe
            _clienteExistente = _clienteDAL.GetClientes().FirstOrDefault(c => c.Cedula == cedula);

            if (_clienteExistente == null)
            {
                _test.Log(Status.Fail, $"El cliente no existe en la base de datos");
                throw new Exception("El cliente no existe en la base de datos.");
            }
            _test.Log(Status.Info, $"El cliente con cedula: {_clienteExistente.Cedula} existe en la base de datos");
        }

        [When("Eliminar el usuario de la BDD")]
        public void WhenEliminarElUsuarioDeLaBDD(DataTable dataTable)
        {
            try
            {
                _clienteDAL.DeleteCliente(_clienteExistente.Codigo);
                _test.Log(Status.Pass, "El cliente se elimino de manera exitosa");
            }
            catch (Exception ex) {
                _test.Log(Status.Fail, $"Hubo un problema: {ex.Message}");
            }
            
        }

        [Then("El resultado de la eliminación en la BDD")]
        public void ThenElResultadoDeLaEliminacionEnLaBDD(DataTable dataTable)
        {
            try
            {
                var registrosBDD = _clienteDAL.GetClientes();
                var clienteEliminado = registrosBDD.FirstOrDefault(c => c.Codigo == _clienteExistente.Codigo);

                Assert.Null(clienteEliminado);
                _test.Log(Status.Pass, $"El cliente con registro{_clienteExistente.Codigo} y cedula: {_clienteExistente.Cedula} ya no se encuentra en la base de datos");
            }
            catch (Exception ex) {
                _test.Log(Status.Fail, $"El cliente con registro{_clienteExistente.Codigo} todavia consta en la base de datos, o que ocurrio es: {ex.Message}");
            }
            
        }
    }
}
