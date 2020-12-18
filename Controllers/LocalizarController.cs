using Microsoft.AspNetCore.Mvc;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace proyecto.Controllers
{
	public class LocalizarController : Controller
	{
		ClienteContext _context;

        public LocalizarController()
		{
			_context = new ClienteContext();
		}
		public ActionResult Index()
		{
			List<Cliente> clientes = _context.Clientes.ToList();
			return View(clientes);
		}

		public JsonResult GetCoordenadas()
		{
			var cli = _context.Clientes.ToList();
			return Json(cli);
		}
	}
}

