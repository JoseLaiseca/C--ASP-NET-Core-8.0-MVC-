using Microsoft.AspNetCore.Mvc;
using EjemploReporte.Models;
using EjemploReporte.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploReporte.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // Acción principal para mostrar la vista de productos
        public IActionResult Index()
        {
            var productos = _context.Productos
                .Where(p => !p.EliminadoProducto)
                .ToList();

            if (productos == null || !productos.Any())
            {
                return View(); // O puedes pasar un mensaje de error si no se encuentran productos
            }

            return View(productos);
        }
        [HttpGet]
        public IActionResult ObtenerProductos()
        {
            var productos = _context.Productos
                .Where(p => !p.EliminadoProducto) // Filtra productos no eliminados
                .Select(p => new {
                    IdProducto =   p.IdProducto,
                    TipoProducto = p.TipoProducto,
                    MarcaProducto = p.MarcaProducto,
                    ModeloProducto = p.ModeloProducto,
                    MedidasProducto = p.MedidasProducto,
                    ColorProducto = p.ColorProducto,
                    PrecioCosto = p.PrecioCosto,
                    PrecioVenta = p.PrecioVenta,           
                })
                .ToList();

            return Json(productos);
        }

        // API: Obtener productos (Ajax)
        //[HttpGet]
        //public IActionResult ObtenerProductos()
        //{
        //    var productos = _context.Productos
        //        .Where(p => !p.EliminadoProducto)
        //        .Select(p => new
        //        {
        //            p.IdProducto,
        //            p.TipoProducto,
        //            p.MarcaProducto,
        //            p.ModeloProducto,
        //            p.MedidasProducto,
        //            p.ColorProducto,
        //            p.PrecioCosto,
        //            p.PrecioVenta
        //        })
        //        .ToList();

        //    return Json(productos);
        //}

        // GET: Crear producto
        public IActionResult Create()
        {
            return View(); // Retorna la vista para crear un producto
        }

        // POST: Crear producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                // No asignamos IdProducto ya que se generará automáticamente
                _context.Productos.Add(producto);  // Agrega el producto al contexto
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

                return RedirectToAction("Index"); // Redirige a la vista principal
            }

            return View(producto); // Si hay errores, vuelve a mostrar el formulario con los errores
        }

        // GET: Editar producto
        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound(); // Si no se encuentra el producto, devuelve un error
            }
            return View(producto);
        }

        // POST: Editar producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto); // Actualiza el producto en la base de datos
                _context.SaveChanges(); // Guarda los cambios

                return RedirectToAction("Index"); // Redirige al listado de productos
            }
            return View(producto); // Si el modelo no es válido, vuelve a mostrar la vista de edición
        }

        // Acción para mostrar la vista de confirmación de eliminación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto); // Elimina el producto de la base de datos
                _context.SaveChanges(); // Guarda los cambios
            }
            return RedirectToAction("Index"); // Redirige al listado de productos
        }

        // GET: Eliminar producto (confirmación)
        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound(); // Si el producto no existe, mostrar error
            }
            return View(producto); // Pasar el producto a la vista para confirmación
        }
    }
}
