using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface IKhoaBusiness
	{
		List<Khoa> GetAllData();
		void Insert(Khoa kh);
		bool ExistKTGV(int ma);
		void Edit(int id, Khoa newInfo);
	}
}
