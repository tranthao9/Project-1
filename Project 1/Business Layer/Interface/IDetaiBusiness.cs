using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface IDetaiBusiness
	{
		List<Detai> GetAllData();
		void Insert(Detai l);
		void Delete(int mal);
		List<Detai> Tim(Detai dt);
		bool Exist(int ma);
		bool ExistKT(int ma);
		void Edit(int id, Detai newInfo);
		bool ExistTen(string a);
		bool ExistDA(int a);
	}
}
