using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	public interface IChuyenNganhDA
	{
		List<ChuyenNganh> GetAllData();
		void Insert(ChuyenNganh cn);
		void Delete(int macn);
		void Edit(int id, ChuyenNganh newInfo);
		void GhiLaiDanhsach(List<ChuyenNganh> List);
	}
}
