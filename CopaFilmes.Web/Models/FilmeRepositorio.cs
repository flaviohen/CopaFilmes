using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace CopaFilmes.Web.Models
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{

		private List<Filme> lstFilme = null;

		public FilmeRepositorio()
		{
			lstFilme = Deserialize("http://copadosfilmes.azurewebsites.net/api/filmes");
		}

		public List<Filme> GetAll()
		{
			try
			{	
				return lstFilme;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}

		public List<Filme> Deserialize(string urlServico)
		{
			var responseValue = string.Empty;
			var request = (HttpWebRequest)WebRequest.Create(urlServico);
			request.Method = "GET";
			request.ContentLength = 0;
			request.ContentType = "application/json";
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				using (var responseStream = response.GetResponseStream())
				{
					if (responseStream != null)
						using (var reader = new StreamReader(responseStream))
						{
							responseValue = reader.ReadToEnd();
						}
				}
			}

			DataContractJsonSerializer jsonConvert = new DataContractJsonSerializer(typeof(List<Filme>));
			MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseValue));
			List<Filme> lstFilme = (List<Filme>)jsonConvert.ReadObject(ms);
			return lstFilme;
		}

		public List<Filme> GerarCampeonato(List<Filme> filmes)
		{
			List<Filme> lstFilmesVencedoresQuartas = DecidirQuartasDeFinal(filmes);
			List<Filme> lstFilmeVencedoresSemiFinal = DecidirSemiFinal(lstFilmesVencedoresQuartas);
			List<Filme> lstFilmeVencedoresFinal = DecidirFinal(lstFilmeVencedoresSemiFinal);
			return lstFilmeVencedoresFinal;
		}

		public Filme DecidirDisputa(Filme filme1, Filme filme2)
		{
			Filme filmeGanhador = null;
			if (filme1.nota > filme2.nota)
			{
				filmeGanhador = filme1;
			}
			else if (filme2.nota > filme1.nota)
			{
				filmeGanhador = filme2;
			}
			else if (filme1.nota == filme2.nota)
			{
				List<Filme> lstFilmeOrdenada = new List<Filme>();
				lstFilmeOrdenada.Add(filme1);
				lstFilmeOrdenada.Add(filme2);
				filmeGanhador = lstFilmeOrdenada.OrderBy(c => c.titulo).ToList()[0];
			}
			return filmeGanhador;
		}

		public List<Filme> DecidirQuartasDeFinal(List<Filme> filmesSelecionados)
		{
			List<Filme> lstFilmesQuartas = new List<Filme>();

			lstFilmesQuartas.Add(DecidirDisputa(filmesSelecionados[0], filmesSelecionados[7]));
			lstFilmesQuartas.Add(DecidirDisputa(filmesSelecionados[1], filmesSelecionados[6]));
			lstFilmesQuartas.Add(DecidirDisputa(filmesSelecionados[2], filmesSelecionados[5]));
			lstFilmesQuartas.Add(DecidirDisputa(filmesSelecionados[3], filmesSelecionados[4]));

			return lstFilmesQuartas;
		}

		public List<Filme> DecidirSemiFinal(List<Filme> filmesQuartas)
		{
			List<Filme> lstSemiFinal = new List<Filme>();

			lstSemiFinal.Add(DecidirDisputa(filmesQuartas[0], filmesQuartas[1]));
			lstSemiFinal.Add(DecidirDisputa(filmesQuartas[2], filmesQuartas[3]));

			return lstSemiFinal;
		}

		public List<Filme> DecidirFinal(List<Filme> filmesSemiFinal)
		{
			List<Filme> lstFilmeFinal = new List<Filme>();

			Filme FilmePrimeiroLugar = DecidirDisputa(filmesSemiFinal[0], filmesSemiFinal[1]);
			Filme FilmeSegundoLugar = null;

			foreach (var item in filmesSemiFinal)
			{
				if (!item.id.Equals(FilmePrimeiroLugar.id))
				{
					FilmeSegundoLugar = item;
				}
			}
			lstFilmeFinal.Add(FilmePrimeiroLugar);
			lstFilmeFinal.Add(FilmeSegundoLugar);

			return lstFilmeFinal;
		}

	}
}