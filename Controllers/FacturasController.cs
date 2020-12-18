using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using Grpc.Core;
using SelectPdf;
using Newtonsoft.Json;

namespace proyecto.Controllers
{
    public class FacturasController : Controller
    {
 
        ClienteContext _Context;
      

        public FacturasController()
        {

            _Context = new ClienteContext();
            
        }

        public ActionResult Index()
        {
            List<Factura> facturas = GetAllFactura();
            return View(facturas);
        }

        public ActionResult IndexCancelados()
        {
            List<Factura> facturas = GetAllFacturaCanceladas();
            return View(facturas);
        }

        public IActionResult GetPrecios(int id)
        {
            var precio = _Context.Productos.Find(id).Precio;
            return Json(JsonConvert.SerializeObject(precio));
        }

        public IActionResult GetPreciosServicio(int id)
        {
            var precio = _Context.Servicios.Find(id).Precio;
            return Json(JsonConvert.SerializeObject(precio));
        }

        public ActionResult Create()
        {
            FillProductos();
            FillCliente();
            FillServicio();
            return View(new Factura());
        }



        [HttpPost]
        public ActionResult Create(Factura f)
        {
            FillProductos();
            FillCliente();
            FillServicio();
           var cantidad = _Context.Productos.Where(x => x.IdProducto == f.IdProducto).Select(x => x.Cantidad).FirstOrDefault();
            if(f.IdProducto > 0)
            {
                if (cantidad < f.Cantidad_Art)
                {
                    ViewBag.error = "No hay suficiente producto";
                    return View(f);
                }
            }


            f.FechaRegistro = DateTime.Now;
            f.Cancelada = false;
            _Context.Add(f);
            _Context.SaveChanges();
            DescontarProductos(f.IdProducto, f.Cantidad_Art);
            ProductosVendidos(f.IdProducto);
            ServiciosVendidos(f.IdServicio);
            ContadorCliente(f.ClienteId, f.Total);


            return RedirectToAction("Index");
        }

        public void ProductosVendidos(int Id)
        {
            if (Id > 0)
            {
                var producto = _Context.Productos.Where(x => x.IdProducto == Id).FirstOrDefault();
                var cont = producto.Contador + 1;
                producto.Contador = cont;
                _Context.Update(producto);
                _Context.SaveChanges();
            }
        }
        public void ServiciosVendidos(int Id)
        {
            if(Id > 0)
            {
                var servicios = _Context.Servicios.Where(x => x.IdServicio == Id).FirstOrDefault();
                var cont = servicios.Contador + 1;
                servicios.Contador = cont;
                _Context.Update(servicios);
                _Context.SaveChanges();
            }
        }
 
        public void ContadorCliente(int Id, float total)
        {
            if (Id > 0)
            {
                var Clientes = _Context.Clientes.Where(x => x.ClienteId == Id).FirstOrDefault();
                var cont = Clientes.Contador + 1;
                var Monto = Clientes.MontoTotal + total;
                Clientes.Contador = cont;
                Clientes.MontoTotal = Monto;
                _Context.Update(Clientes);
                _Context.SaveChanges();
            }

        }

        
        public void DescontarProductos(int p, int cant)
        {
            if (p > 0)
            {
                var producto = _Context.Productos.Where(x => x.IdProducto == p).FirstOrDefault();
                var cantidad = producto.Cantidad - cant;
                producto.Cantidad = cantidad;
                _Context.Productos.Update(producto);
                _Context.SaveChanges();
            }
        }

        public void RestablecerProductos(int p, int cant)
        {
            if (p > 0)
            {
                var producto = _Context.Productos.Where(x => x.IdProducto == p).FirstOrDefault();
                var cantidad = producto.Cantidad + cant;
                producto.Cantidad = cantidad;
                _Context.Productos.Update(producto);
                _Context.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult Cancelar(Factura f)
        {
            f.Cancelada = true;
            _Context.Facturas.Update(f);
            _Context.SaveChanges();
            RestablecerProductos(f.IdProducto, f.Cantidad_Art);
            return RedirectToAction("Index");
        }

        //public ActionResult Resultado(Factura f, Productos p)
        //{         

        //    FillProductos();
        //    FillCliente();
        //    FillServicio();
        //    f.Precio = precio.Precio;
        //    f.SubTotal = p.Precio * f.Cantidad_Art;
        //    f.Itbis = p.Precio * f.Cantidad_Art * (18 / 100);
        //    f.Total = p.Precio * f.Cantidad_Art * (18 / 100) + p.Precio * f.Cantidad_Art;
        //    return View("Create", f);
        //}

        //public ActionResult Resultado()
        //{
        //    var resultados = (from f in this._Context.Facturas
        //                      join p in this._Context.Productos on f.Idfactura equals p.IdProducto
        //                      join s in this._Context.Servicios on f.Idfactura equals s.IdServicio
        //                      into tblresultado
        //                      from s in tblresultado
        //                      select new { f, p, s }).ToList()
        //                      .Select(x => new Factura
        //                      {
        //                          Precio = x.p.Precio,
        //                          SubTotal = x.p.Precio * x.p.Cantidad,
        //                          Itbis = x.f.SubTotal * (18 / 100),
        //                          Total = x.f.Itbis + x.f.SubTotal
        //                      }).FirstOrDefault();
        //}

        public SelectListItem[] GetProductos()
        {
            var producto = _Context.Productos;
            SelectListItem[] product = producto.Select(x => new SelectListItem
            {
                Text = x.Nombre_Produc +"("+ x.Cantidad +")",
                Value = x.IdProducto.ToString(),
                Selected = false
            }).ToArray();
            return product;
        }

    
        //public SelectListItem[] GetPrecio(int id)
        //{
        //    var producto = _Context.Productos;
        //    SelectListItem[] product = producto.Where(x=>x.IdProducto == id).Select(x => new SelectListItem
        //    {
        //        Text = x.Precio.ToString(),
        //        Value = x.Precio.ToString(),
        //        Selected = false
        //    }).ToArray();
        //    return product;
        //}

        public SelectListItem[] GetClientes()
        {
            var Cliente = _Context.Clientes;
            SelectListItem[] Client = Cliente.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.ClienteId.ToString(),
                Selected = false
            }).ToArray();
            return Client;
        }
        public SelectListItem[] GetServicios()
        {
            var Servicio = _Context.Servicios;
            SelectListItem[] service = Servicio.Select(x => new SelectListItem
            {
                Text = x.Nombre_Servic,
                Value = x.IdServicio.ToString(),
                Selected = false
            }).ToArray();
            return service;
        }

        public void FillProductos()
        {
            ViewBag.productos = GetProductos();
        }
        public void FillCliente()
        {
            ViewBag.Cliente = GetClientes();
        }
        public void FillServicio()
        {
            ViewBag.Servicio = GetServicios();
        }


        public List<Factura> GetAllFactura()
		{
            var factura = (from f in this._Context.Facturas
                           join cli in this._Context.Clientes on f.ClienteId equals cli.ClienteId
                           join pro in this._Context.Productos on f.IdProducto equals pro.IdProducto
                           join ser in this._Context.Servicios on f.IdServicio equals ser.IdServicio
                           into tblFactura
                           from ser in tblFactura
                           select new { f, cli, pro, ser })
                           .Select(x => new Factura
                           {
                               Idfactura = x.f.Idfactura,
                               IdProducto = x.pro.IdProducto,
                               IdServicio = x.ser.IdServicio,
                               ClienteId = x.cli.ClienteId,
                               NombreProducto = x.pro.Nombre_Produc,
                               NombreServicios = x.ser.Nombre_Servic,
                               NombreCliente = x.cli.Nombre,
                               Cantidad_Art = x.f.Cantidad_Art,
                               Descripcion = x.f.Descripcion,
                               Precio = x.f.Precio,
                               Itbis = x.f.Itbis,
                               Total = x.f.Total,
                               FechaRegistro = x.f.FechaRegistro,
                               Cancelada = x.f.Cancelada,
                               SubTotal = x.f.SubTotal
                           }).Where(x=>x.Cancelada==false).ToList();
            return factura;
        }
        public List<Factura> GetAllFacturaCanceladas()
        {
            var factura = (from f in this._Context.Facturas
                           join cli in this._Context.Clientes on f.ClienteId equals cli.ClienteId
                           join pro in this._Context.Productos on f.IdProducto equals pro.IdProducto
                           join ser in this._Context.Servicios on f.IdServicio equals ser.IdServicio
                           into tblFactura
                           from ser in tblFactura
                           select new { f, cli, pro, ser })
                           .Select(x => new Factura
                           {
                               Idfactura = x.f.Idfactura,
                               IdProducto = x.pro.IdProducto,
                               IdServicio = x.ser.IdServicio,
                               ClienteId = x.cli.ClienteId,
                               NombreProducto = x.pro.Nombre_Produc,
                               NombreServicios = x.ser.Nombre_Servic,
                               NombreCliente = x.cli.Nombre,
                               Cantidad_Art = x.f.Cantidad_Art,
                               Descripcion = x.f.Descripcion,
                               Precio = x.f.Precio,
                               Itbis = x.f.Itbis,
                               Total = x.f.Total,
                               FechaRegistro = x.f.FechaRegistro,
                               Cancelada = x.f.Cancelada,
                               SubTotal = x.f.SubTotal
                           }).Where(x => x.Cancelada == true).ToList();
            return factura;
        }

        public ActionResult Exportar(string html)
        {
            html = html.Replace("StrTag", "<").Replace("EndTag", ">");
            HtmlToPdf ohtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = ohtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();
            return File(
                pdf,
                "aplication/pdf",
                "Factura.pdf"
                );
        }
        public ActionResult Details(int id)
        {
            var factura = (from f in this._Context.Facturas
                           join cli in this._Context.Clientes on f.ClienteId equals cli.ClienteId
                           join pro in this._Context.Productos on f.IdProducto equals pro.IdProducto
                           join ser in this._Context.Servicios on f.IdServicio equals ser.IdServicio
                           into tblFactura
                           from ser in tblFactura
                           select new { f, cli, pro, ser }).Select(x => new Factura
                           {
                               Idfactura = x.f.Idfactura,
                               IdProducto = x.pro.IdProducto,
                               IdServicio = x.ser.IdServicio,
                               ClienteId = x.cli.ClienteId,
                               NombreProducto = x.pro.Nombre_Produc,
                               NombreServicios = x.ser.Nombre_Servic,
                               NombreCliente = x.cli.Nombre,
                               Cantidad_Art = x.f.Cantidad_Art,
                               Descripcion = x.f.Descripcion,
                               Precio = x.f.Precio,
                               Itbis = x.f.Itbis,
                               Total = x.f.Total,
                               FechaRegistro = x.f.FechaRegistro,
                               Cancelada = x.f.Cancelada
                           }).Where(x => x.Idfactura == id).FirstOrDefault();

            return View(factura);

        }

    }
}
