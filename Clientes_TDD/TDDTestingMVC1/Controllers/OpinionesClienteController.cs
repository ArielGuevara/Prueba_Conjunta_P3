using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TDDTestingMVC1.Controllers
{
    public class OpinionesClienteController : Controller
    {
        private readonly OpinionesClienteDataAccessLayer _opinionesClienteDAL = new OpinionesClienteDataAccessLayer();

        // Mostrar lista de opiniones
        public IActionResult Index()
        {
            List<OpinionesCliente> opiniones = _opinionesClienteDAL.GetOpiniones();
            return View(opiniones);
        }

        // Mostrar formulario para crear una opinión
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_opinionesClienteDAL.GetClientes(), "Codigo", "NombreCompleto");
            ViewBag.Productos = new SelectList(_opinionesClienteDAL.GetProductos(), "ProductoID", "Nombre");
            return View();
        }

        // Procesar la creación de una opinión
        [HttpPost]
        public IActionResult Create(OpinionesCliente opinion)
        {
            if (ModelState.IsValid)
            {
                _opinionesClienteDAL.AddOpinion(opinion);
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = new SelectList(_opinionesClienteDAL.GetClientes(), "Codigo", "NombreCompleto");
            ViewBag.Productos = new SelectList(_opinionesClienteDAL.GetProductos(), "ProductoID", "Nombre");
            return View(opinion);
        }

        // Mostrar detalles de una opinión
        public IActionResult Details(int id)
        {
            OpinionesCliente opinion = _opinionesClienteDAL.GetOpinionById(id);
            if (opinion == null)
                return NotFound();
            return View(opinion);
        }

        // Mostrar formulario para editar una opinión
        public IActionResult Edit(int id)
        {
            OpinionesCliente opinion = _opinionesClienteDAL.GetOpinionById(id);
            if (opinion == null)
                return NotFound();
            ViewBag.Clientes = new SelectList(_opinionesClienteDAL.GetClientes(), "Codigo", "NombreCompleto");
            ViewBag.Productos = new SelectList(_opinionesClienteDAL.GetProductos(), "ProductoID", "Nombre");
            return View(opinion);
        }

        // Procesar la edición de una opinión
        [HttpPost]
        public IActionResult Edit(OpinionesCliente opinion)
        {
            if (ModelState.IsValid)
            {
                _opinionesClienteDAL.UpdateOpinion(opinion);
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = new SelectList(_opinionesClienteDAL.GetClientes(), "Codigo", "NombreCompleto");
            ViewBag.Productos = new SelectList(_opinionesClienteDAL.GetProductos(), "ProductoID", "Nombre");
            return View(opinion);
        }

        // Mostrar formulario para eliminar una opinión
        public IActionResult Delete(int id)
        {
            OpinionesCliente opinion = _opinionesClienteDAL.GetOpinionById(id);
            if (opinion == null)
                return NotFound();
            return View(opinion);
        }

        // Procesar la eliminación de una opinión
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _opinionesClienteDAL.DeleteOpinion(id);
            return RedirectToAction("Index");
        }
    }
}
