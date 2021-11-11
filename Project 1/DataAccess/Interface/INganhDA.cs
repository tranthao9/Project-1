using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	public interface INganhDA
	{
		List<Nganh> GetAllData();
		void Insert(Nganh n);
		void Delete(int macn);
		void Edit(int id, Nganh newInfo);
		void GhiLaiDanhsach(List<Nganh> List);
	}
}
