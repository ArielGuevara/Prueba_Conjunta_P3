using System;
using Reqnroll;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();
        private int  resultado = 0;
        [Given("Llenar los campos del formulario")]
        public void GivenLlenarLosCamposDelFormulario(DataTable dataTable)
        {
            resultado = dataTable.Rows.Count();
            Assert.True(resultado > 0);//resultado.Should().BeGreaterThanOrEqualTo(1); -> esto se usaba en Specflow
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

            _clienteDAL.AddCliente(cls);
        }

        [Then("El resultado del registro en la BDD")]
        public void ThenElResultadoDelRegistroEnLaBDD(DataTable dataTable)
        {
            var registrosBDD = _clienteDAL.GetClientes();
            var newRegistro = dataTable.CreateSet<Cliente>().ToList().First();

            var bandera = false;
            
            foreach (var registro in registrosBDD)
            {
                if (registro.Cedula == newRegistro.Cedula &&
                    registro.Nombres == newRegistro.Nombres) 
                { 
                    bandera = true; break;
                }
            }
            Assert.True(bandera);
        }
    }
}