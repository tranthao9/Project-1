using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface ILopSinhVienBusiness
	{
		List<LopSinhVien> GetAllData();
		void Insert(LopSinhVien ng);
		void Delete(int mang,int malop);
		List<LopSinhVien> Tim(LopSinhVien ng);
		bool ExistL(int ma);
		bool ExistSV(int ma);
		void Edit(int id, LopSinhVien newInfo);
	}
}
