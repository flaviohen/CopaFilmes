using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Web.Models
{
	public interface IRepositorio<T>
	{
		List<T> GetAll();
		List<T> Deserialize(string urlServico);
	}
}
