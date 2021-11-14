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
		void Delete(int ma);
		List<SVDetai> Tim(SVDetai t);
		bool ExistDT(int ma);
		bool ExistGV(int ma);
		bool ExistSV(int ma);
		void Edit(int id, int ma, SVDetai newInfo);
		bool ExistSV1(int ma);
		bool ExistSV2(int ma,int msv);
		double Diemgvpb(SVDetai x);
		double TongDiem(SVDetai x);
		string xeploai(SVDetai x);
		string Danhgia(SVDetai x);
		bool ExistKTL(int ma);
		bool ExistKTSV(int ma);
		bool ExistKTGVHD(int ma);
		bool ExistKTGVPB(int ma);
		bool ExistKTDA(int ma);
		bool ExistTDT(int ma);

	}
}
