using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	public interface ISinhVienDA
	{
		List<SinhVien> GetAllData();
		void Insert(SinhVien sv);
		void Delete(int masv);
		void Edit(int id, SinhVien newInfo);
	}
}
