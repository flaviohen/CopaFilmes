using System;
using System.Text;
using System.Collections.Generic;
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
		public FilmeTest()
		{
			//
			// TODO: Adicionar lógica de construtor aqui
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Obtém ou define o contexto do teste que provê
		///informação e funcionalidade da execução de teste atual.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Atributos de teste adicionais
		//
		// É possível usar os seguintes atributos adicionais enquanto escreve os testes:
		//
		// Use ClassInitialize para executar código antes de executar o primeiro teste na classe
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup para executar código após a execução de todos os testes em uma classe
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize para executar código antes de executar cada teste 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup para executar código após execução de cada teste
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void GetAllTest()
		{
			IRepositorio<Filme> repositorio = new FilmeRepositorio();
			List<Filme> lstFilme = repositorio.GetAll();

			Assert.IsTrue(lstFilme.Count > 0);
		}
	}
}
