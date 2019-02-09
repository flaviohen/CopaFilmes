using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaFilmes.Web.Models
{
	public class Filme
	{
		public string id { get; set; }
		public string titulo { get; set; }
		public int ano { get; set; }
		public double nota { get; set; }
	}
}