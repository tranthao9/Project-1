using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;
using Project_1.DataAccess.Interface;
using Project_1.DataAccess;
using Project_1.Business_Layer.Interface;

namespace Project_1.Business_Layer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại tang Business.interface
    public class TuanDetaiBusiness : ITuanDetaiBusiness
    {
        private ITuanDetaiDA tuandtDA = new TuanDetaiDA();
        private IDetaiBusiness chDA = new DetaiBusiness();
        //Thực thi các yêu cầu
        public List<TuanDetai> GetAllData()
        {
            List<TuanDetai> listlop = tuandtDA.GetAllData();
            foreach (var lop in listlop)
            {
                foreach(Detai dt in chDA.GetAllData())
				{
                    if (lop.Madettai == dt.Madetai)
					{
                        lop.Detai = new Detai(dt);
                        break;
                    }
				}
				                   
            }
            return listlop;
        }
        //kiểm tra  đề tài đó đã có đủ các tuần hay chưa xem đã tồn tại hay chưa
        public bool ExistKT(int ma)
        {
            List<TuanDetai> list = tuandtDA.GetAllData();
            int d = 0;
            for (int i = 1; i < 16; i++)
                if (list.Find(m => m.Madettai == ma && m.Matuan == i) != null)
                    d++;
            if (d == 15)
                return true;
            return false;
        }
        //kiểm tra một mã tuần của đề tài đó xem đã tồn tại hay chưa
        public bool Exist(int ma,int m2)
        {
            List<TuanDetai> list = tuandtDA.GetAllData();
            if (list.Find(m => m.Matuan == ma && m.Madettai==m2) != null)
                return true;
            return false;
        }
        public void Insert(TuanDetai lop)
        {
           
             tuandtDA.Insert(lop);
        }
        public void Delete(int matuan,int madetai)
        {
            if (Exist(matuan,madetai))
                tuandtDA.Delete(matuan,madetai);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, int ma, TuanDetai newInfo)
        {
            tuandtDA.Edit(id, ma, newInfo);
        }
        public List<TuanDetai> Tim(TuanDetai t)
        {
            List<TuanDetai> list = tuandtDA.GetAllData();
            List<TuanDetai> kq = new List<TuanDetai>();
            //Voi gai tri ngam dinh ban dau
            if (t.Madettai==0 && t.Matuan==0 )
            {
                kq = list;
            }
            //Tim theo ma de tai
            else if (t.Madettai != 0 && t.Matuan == 0)
            {
                foreach (TuanDetai a in list)
                    if (a.Matuan== t.Matuan)
                    {
                        kq.Add(new TuanDetai(a));
                    }
            }
            //Tim theo ma tuan
            else if (t.Madettai == 0 && t.Matuan != 0)
            {
                foreach (TuanDetai a in list)
                    if (a.Madettai == t.Madettai)
                    {
                        kq.Add(new TuanDetai(a));
                    }
            }
            //Tim ket hop giua ma va ten lop
            else if (t.Madettai != 0 && t.Matuan != 0)
            {
                foreach (TuanDetai a in list)
                    if (a.Madettai == t.Madettai && a.Matuan == t.Matuan)
                    {
                        kq.Add(new TuanDetai(a));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
