//using TDDTestingMVC1.Controllers;
//using TDDTestingMVC1.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Xunit;

//namespace ReqnrollTest.StepDefinitions
//{
//    [Binding]
//    public sealed class ClienteStepDefinitions
//    {
//        private readonly ClienteController _controller = new ClienteController();
//        private List<Cliente> _clientes = new List<Cliente>();
//        private IActionResult _result;

//        [Given(@"un cliente con los siguientes datos:")]
//        public void GivenUnClienteConLosSiguientesDatos(Table table)
//        {
//            foreach (var row in table.Rows)
//            {
//                var cliente = new Cliente
//                {
//                    Codigo = int.Parse(row["Codigo"]),
//                    Cedula = row["Cedula"],
//                    Apellidos = row["Apellidos"],
//                    Nombres = row["Nombres"],
//                    FechaNacimiento = DateTime.Parse(row["FechaNacimiento"]),
//                    Mail = row["Mail"],
//                    Telefono = row["Telefono"],
//                    Direccion = row["Direccion"],
//                    Estado = bool.Parse(row["Estado"])
//                };
//                _clientes.Add(cliente);
//            }
//        }

//        [When(@"el cliente es insertado")]
//        public void WhenElClienteEsInsertado()
//        {
//            foreach (var cliente in _clientes)
//            {
//                _result = _controller.Create(cliente);
//            }
//        }

//        [Then(@"el cliente debería ser agregado correctamente")]
//        public void ThenElClienteDeberíaSerAgregadoCorrectamente()
//        {
//            var redirectResult = _result as RedirectToActionResult;
//            Assert.NotNull(redirectResult);
//            Assert.Equal("Index", redirectResult.ActionName);
//        }
//    }
//}
