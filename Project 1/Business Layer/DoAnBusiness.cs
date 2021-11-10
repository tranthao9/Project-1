using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.DataAccess;
using Project_1.DataAccess.Interface;
using Project_1.Entities;
using Project_1.Business_Layer.Interface;

namespace Project_1.Business_Layer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IDoAnBusiness
    public class DoAnBusiness : IDoAnBusiness
    {
        private IDoAnDA DA = new DoAnDA();
        //Thực thi các yêu cầu
        public List<DoAn> GetAllData()
        {
            List<DoAn> list = DA.GetAllData();
            
            return list;
        }
        //kiểm tra một mã đồ án xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<DoAn> list = GetAllData();
            if (list.Find(m => m.Mada == ma) != null)
                return true;
            return false;
        }
        public void Insert(DoAn da)
        {
            if (da.Tenda != "")
            {
                da.Tenda = Project_1.Utility.Congcu.Chuanhoaxau(da.Tenda);
                DA.Insert(da);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public void Delete(int ma)
        {
            if (Exist(ma))
                DA.Delete(ma);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, DoAn newInfo)
        {
            DA.Edit(id, newInfo);
        }
        public List<DoAn> Tim(DoAn da)
        {
            List<DoAn> list = DA.GetAllData();
            List<DoAn> kq = new List<DoAn>();
            //Voi gai tri ngam dinh ban dau
            if (da.Mada==0 && da.Tenda==null &&da.Sotc==0)
            {
                kq = list;
            }
            //Tim theo ma
            else if (da.Mada != 0 && da.Tenda == null && da.Sotc == 0)
            {
                foreach (DoAn d in list)
                    if (d.Mada==da.Mada)
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            // Tim theo ten
            else if (da.Mada == 0 && da.Tenda != null && da.Sotc == 0)
            {
                foreach (DoAn d in list)
                    if (d.Tenda.Contains(da.Tenda))
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            //Tim theo sotc
            else if (da.Mada == 0 && da.Tenda == null && da.Sotc != 0)
            {
                foreach (DoAn d in list)
                    if (d.Sotc == da.Sotc)
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
