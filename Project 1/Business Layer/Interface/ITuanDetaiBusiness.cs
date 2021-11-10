using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface ITuanDetaiBusiness
	{
		List<TuanDetai> GetAllData();
		void Insert(TuanDetai h);
		void Delete(int mah,int a);
		List<TuanDetai> Tim(TuanDetai h);
		bool Exist(int ma,int m2);
		bool ExistKT(int ma);
		void Edit(int id, int ma, TuanDetai newInfo);
	}
}
