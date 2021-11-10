using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.Business_Layer.Interface
{
	public interface ISVDetaiBusiness
	{
		List<SVDetai> GetAllData();
		void Insert(SVDetai lop);
		void Delete(int malop,int m1);
		List<SVDetai> Tim(SVDetai t);
		bool ExistDT(int ma);
		bool ExistGV(int ma);
		bool ExistSV(int ma);
		void Edit(int id, int ma, SVDetai newInfo);
		bool ExistSV1(int ma);
		bool ExistSV2(int ma,int msv);
	}
}
