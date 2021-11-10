using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface ILopHocBusiness
	{
		List<LopHoc> GetAllData();
		void Insert(LopHoc lop);
		void Delete(int malop);
		List<LopHoc> TimLopHoc(LopHoc lop);
		bool Exist(int ma);
		void Edit(int id, LopHoc newInfo);
		bool ExistCN(int ma);
	}
}
