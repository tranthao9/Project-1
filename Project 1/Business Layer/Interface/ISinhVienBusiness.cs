using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.Entities;
using System.Threading.Tasks;
using Project_1.DataAccess;

namespace Project_1.Business_Layer.Interface
{
	public interface ISinhVienBusiness
	{
		List<SinhVien> GetAllData();
		void Insert(SinhVien sv);
		bool Exist(int ma);
		void Delete(int masv);
		List<SinhVien> TimSinhVien(SinhVien sv);
		void Edit(int id, SinhVien newInfo);
		bool ExistTEN(string ma);
	}
}
