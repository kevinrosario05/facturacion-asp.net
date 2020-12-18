using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using Rotativa;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    public class ReportesController : Controller
    {
        ClienteContext _Context;


        public ReportesController()
        {

            _Context = new ClienteContext();

        }

       

        public async Task<IActionResult> Index()
        {
            return View(await _Context.Productos.ToListAsync());
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

        public ActionResult MasVendidos()
        {
            List<Productos> Productos = _Context.Productos.OrderByDescending(x => x.Contador).ToList();
            return View(Productos);
        }

        public ActionResult MasVendidosServicios()
        {
            List<Servicio> Servicios = _Context.Servicios.OrderByDescending(x => x.Contador).ToList();
            return View(Servicios);
        }

        public ActionResult ClientesBuenos()
        {
            List<Cliente> Clientes = _Context.Clientes.Where(x => x.Contador > 2).OrderByDescending(x => x.Contador).ToList();
            return View(Clientes);

        } 
        public ActionResult ClientesSuperInversiones()
        {
            List<Cliente> Clientes = _Context.Clientes.OrderByDescending(x => x.MontoTotal).ToList();
            return View(Clientes);
        }

        public ActionResult ListaCumpleaños()
        {
            List<Cliente> clientes = _Context.Clientes.OrderByDescending(x => x.FechaCumpleaños).ToList();
            return View(clientes);
        }
    }
}