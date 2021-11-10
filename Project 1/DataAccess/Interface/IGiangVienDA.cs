using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	public interface IGiangVienDA
	{
		List<GiangVien> GetAllData();
		void Insert(GiangVien gv);
		void Delete(int magv);
		void Edit(int id, GiangVien newInfo);
	}
}
