using System;
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
        [Given("Verificar si el cliente existe en la BDD")]
        public void GivenLlenarLosCamposDelFormularioParaEditar(DataTable dataTable)
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

        [When("Actualizar el usuario en la BDD")]
        public void WhenActualizarElUsuarioEnLaBDD(DataTable dataTable)
        {
            _clienteEditado = dataTable.CreateSet<Cliente>().ToList().First();
            _clienteEditado.Codigo = _clienteExistente.Codigo; 
            _clienteDAL.UpdateCliente(_clienteEditado);
        }

        [Then("El resultado de la actualización en la BDD")]
        public void ThenElResultadoDeLaActualizacionEnLaBDD(DataTable dataTable)
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
        }
    }
}
