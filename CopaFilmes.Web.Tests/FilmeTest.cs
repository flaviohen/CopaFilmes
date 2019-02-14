using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopaFilmes.Web.Models;
using System.Threading.Tasks;

namespace CopaFilmes.Web.Tests
{
	/// <summary>
	/// Descrição resumida para FilmeTest
	/// </summary>
	[TestClass]
	public class FilmeTest
	{
		/// <summary>
		/// IDs dos filmes do teste
		/// </summary>
		public string filmesTest = "tt5463162,tt3778644,tt7784604,tt4881806,tt5164214,tt3606756,tt3501632,tt4154756";

		[TestMethod]
		public void GetAllTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();
			Assert.IsTrue(lstFilme.Count > 0);
		}

		[TestMethod]
		public void GerarCampeonatoTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();
			List<Filme> lstFilmeTest = RetornoFilmesTeste(filmesTest, lstFilme);
			
			lstFilme = new FilmeRepositorio().GerarCampeonato(lstFilmeTest);

			Assert.IsTrue(lstFilme.Count == 2);
		}

		[TestMethod]
		public void DecidirDisputaTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll().Take(2).ToList();
			Filme vencedor = new FilmeRepositorio().DecidirDisputa(lstFilme[0], lstFilme[1]);

			Assert.IsTrue(vencedor != null);
		}

		[TestMethod]
		public void DecidirQuartasDeFinalTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();
			List<Filme> lstFilmeTest = RetornoFilmesTeste(filmesTest, lstFilme);
			lstFilme = new FilmeRepositorio().DecidirQuartasDeFinal(lstFilmeTest);

			Assert.IsTrue(lstFilme.Count == 4);
		}

		[TestMethod]
		public void DecidirSemiFinalTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();
			List<Filme> lstFilmeTest = RetornoFilmesTeste(filmesTest, lstFilme);

			lstFilme = new FilmeRepositorio().DecidirSemiFinal(new FilmeRepositorio().DecidirQuartasDeFinal(lstFilmeTest));

			Assert.IsTrue(lstFilme.Count == 2);
		}

		[TestMethod]
		public void DecidirFinalTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();
			List<Filme> lstFilmeTest = RetornoFilmesTeste(filmesTest, lstFilme);

			lstFilme = new FilmeRepositorio().DecidirFinal(new FilmeRepositorio()
				.DecidirSemiFinal(new FilmeRepositorio().DecidirQuartasDeFinal(lstFilmeTest)));

			Assert.IsTrue(lstFilme.Count == 2);
		}

		private List<Filme> RetornoFilmesTeste(string idsFilmes, List<Filme> lstFilmes)
		{
			List<Filme> lstFilmeTest = new List<Filme>();
			string[] filmes = idsFilmes.Split(',');

			foreach (var item in filmes)
			{
				lstFilmeTest.Add(lstFilmes.FirstOrDefault(c => c.id.Equals(item)));
			}

			return lstFilmeTest;
		}
	}
}
