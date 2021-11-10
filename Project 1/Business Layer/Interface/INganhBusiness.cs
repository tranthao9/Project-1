using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface INganhBusiness
	{
		List<Nganh> GetAllData();
		void Insert(Nganh ng);
		void Delete(int mang);
		List<Nganh> TimNganh(Nganh ng);
		bool Exist(int ma);
		bool ExistGV(int ma);
		void Edit(int id, Nganh newInfo);
	}
}
