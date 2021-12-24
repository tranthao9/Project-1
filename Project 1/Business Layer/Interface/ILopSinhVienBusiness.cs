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
		void Delete(int ma,int lop);
		List<SinhVien> Tim(LopSinhVien ng);
		bool ExistL(int ma);
		bool ExistSV(int ma);
		void Edit(int id,int lop,LopSinhVien newInfo);
		bool ExistKTL(int ma);
		bool ExistKTSV(int ma);
		bool ExistKTNH(string ma);
		bool ExistKTHK(int ma);
		bool ExistKTSVL(int ma, int lop);
	}
}
