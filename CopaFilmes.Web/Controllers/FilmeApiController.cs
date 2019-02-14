using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaFilmes.Web.Models;

namespace CopaFilmes.Web.Controllers
{
    public class FilmeApiController : ApiController
    {
		IRepositorio<Filme> repositorio = new FilmeRepositorio();

		public IEnumerable<Filme> GetAllFilme()
		{
			return repositorio.GetAll();
		}
    }
}
