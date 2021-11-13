using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface IGiangVienBusiness
	{
		List<GiangVien> GetAllData();
		void Insert(GiangVien gv);
		void Delete(int magv);
		List<GiangVien> TimGiangVien(GiangVien gv);
		bool Exist(int ma);
		void Edit(int id, GiangVien newInfo);
		bool ExistTEN(string ma);
	}
}
