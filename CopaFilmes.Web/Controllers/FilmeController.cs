using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CopaFilmes.Web.Models;

namespace CopaFilmes.Web.Controllers
{
    public class FilmeController : Controller
    {
        // GET: Filme
        public ActionResult Index()
        {
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
            return View(repositorio.GetAll().OrderBy(c => c.titulo).ToList());
        }

		[HttpPost]
		public ActionResult Index(List<string> idFilmes)
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilmes = repositorio.GetAll();
			List<Filme> lstFilmesSelecionado = new List<Filme>();
			List<Filme> lstFilmesFinais;

			foreach (var item in idFilmes)
			{
				lstFilmesSelecionado.Add(lstFilmes.FirstOrDefault(c => c.id.Equals(item)));
			}

			lstFilmesFinais = new FilmeRepositorio().GerarCampeonato(lstFilmesSelecionado.OrderBy(c => c.titulo).ToList());
			return Json(new {Resultado = lstFilmesFinais });
		}
    }
}