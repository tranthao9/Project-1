using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	public interface IKhoaDA
	{
		List<Khoa> GetAllData();
		void Insert(Khoa k);
		void Edit(int id, Khoa newInfo);
		void GhiLaiDanhsach(List<Khoa> List);
	}
}
