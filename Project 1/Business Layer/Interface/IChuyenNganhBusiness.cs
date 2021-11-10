using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface IChuyenNganhBusiness
	{
		List<ChuyenNganh> GetAllData();
		void Insert(ChuyenNganh ch);
		void Delete(int mach);
		List<ChuyenNganh> TimChuyenNganh(ChuyenNganh ch);
		bool ExistKTCN(int ma);
		bool ExistKTN(int ma);
		bool ExistKTGV(int ma);
		void Edit(int id, ChuyenNganh newInfo);
	}
}