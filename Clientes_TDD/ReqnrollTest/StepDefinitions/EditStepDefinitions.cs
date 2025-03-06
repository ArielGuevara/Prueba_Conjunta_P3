using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Reqnroll;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class EditStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();
        private Cliente _clienteExistente;
        private Cliente _clienteEditado;

        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public EditStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtendReport2.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("Verificar si el cliente existe en la BDD")]
        public void GivenLlenarLosCamposDelFormularioParaEditar(DataTable dataTable)
        {
            try
            {
                Console.WriteLine("Verificando si el cliente existe en la BDD...");
                var row = dataTable.Rows[0];
                var cedula = row["Cedula"].ToString();

                _clienteExistente = _clienteDAL.GetClientes().FirstOrDefault(c => c.Cedula == cedula);

                if (_clienteExistente == null)
                {
                    _test.Log(Status.Fail, "El cliente no existe en la base de datos");
                    throw new Exception("El cliente no existe en la base de datos.");
                }
                _test.Log(Status.Pass, "El cliente existe en la base de datos");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        [When("Actualizar el usuario en la BDD")]
        public void WhenActualizarElUsuarioEnLaBDD(DataTable dataTable)
        {
            try
            {
                _clienteEditado = dataTable.CreateSet<Cliente>().ToList().First();
                _clienteEditado.Codigo = _clienteExistente.Codigo;
                _clienteDAL.UpdateCliente(_clienteEditado);
                _test.Log(Status.Info, $"El cliente {_clienteEditado.Nombres} con cedula {_clienteEditado.Cedula} se ha editado correctamente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        [Then("El resultado de la actualización en la BDD")]
        public void ThenElResultadoDeLaActualizacionEnLaBDD(DataTable dataTable)
        {
            try
            {
                var registrosBDD = _clienteDAL.GetClientes();
                var registroActualizado = dataTable.CreateSet<Cliente>().ToList().First();

                var clienteActualizado = registrosBDD.Find(c => c.Codigo == _clienteEditado.Codigo);

                Assert.NotNull(clienteActualizado);
                Assert.Equal(registroActualizado.Cedula, clienteActualizado.Cedula);
                Assert.Equal(registroActualizado.Apellidos, clienteActualizado.Apellidos);
                Assert.Equal(registroActualizado.Nombres, clienteActualizado.Nombres);
                Assert.Equal(registroActualizado.FechaNacimiento, clienteActualizado.FechaNacimiento);
                Assert.Equal(registroActualizado.Mail, clienteActualizado.Mail);
                Assert.Equal(registroActualizado.Telefono, clienteActualizado.Telefono);
                Assert.Equal(registroActualizado.Direccion, clienteActualizado.Direccion);
                Assert.Equal(registroActualizado.Estado, clienteActualizado.Estado);

                _test.Log(Status.Pass, "El cliente coincide con los datos enviados");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Generando reporte...");
            _extent.Flush();
        }
    }
}
