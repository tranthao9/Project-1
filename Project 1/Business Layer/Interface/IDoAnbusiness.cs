using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface IDoAnBusiness
	{
		List<DoAn> GetAllData();
		void Insert(DoAn da);
		void Delete(int mada);
		List<DoAn> Tim(DoAn da);
		bool Exist(int ma);
		void Edit(int id, DoAn newInfo);
	}
}
