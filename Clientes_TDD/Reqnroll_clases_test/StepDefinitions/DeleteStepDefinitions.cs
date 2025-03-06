using System;
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

        [Given("Llenar los campos del formulario para eliminar")]
        public void GivenLlenarLosCamposDelFormularioParaEliminar(DataTable dataTable)
        {
            var row = dataTable.Rows[0];
            var cedula = row["Cedula"];

            // Validar si el cliente ya existe
            _clienteExistente = _clienteDAL.GetClientes().FirstOrDefault(c => c.Cedula == cedula);

            if (_clienteExistente == null)
            {
                throw new Exception("El cliente no existe en la base de datos.");
            }
        }

        [When("Eliminar el usuario de la BDD")]
        public void WhenEliminarElUsuarioDeLaBDD(DataTable dataTable)
        {
            _clienteDAL.DeleteCliente(_clienteExistente.Codigo);
        }

        [Then("El resultado de la eliminación en la BDD")]
        public void ThenElResultadoDeLaEliminacionEnLaBDD(DataTable dataTable)
        {
            var registrosBDD = _clienteDAL.GetClientes();
            var clienteEliminado = registrosBDD.FirstOrDefault(c => c.Codigo == _clienteExistente.Codigo);

            Assert.Null(clienteEliminado);
        }
    }
}
