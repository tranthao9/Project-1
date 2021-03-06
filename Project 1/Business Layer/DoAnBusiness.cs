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
        private IDetaiDA dtDA = new DetaiDA();
        //Thực thi các yêu cầu
        public List<DoAn> GetAllData()
        {
            List<DoAn> list = DA.GetAllData();
            
            return list;
        }
        // kiểm tra tên đồ án có tồn tại hay không
        public bool ExistTEN(string ma)
        {
            List<DoAn> list = GetAllData();
            if (list.Find(m => m.Tenda == ma) != null)
                return true;
            return false;
        }
        //kiểm tra số tín chỉ của đồ án
        public bool ExistTC(int ma)
        {
            List<DoAn> list = GetAllData();
            if (list.Find(m => m.Sotc == ma) != null)
                return true;
            return false;
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
			{
                DA.Delete(ma);
                List<Detai> l = dtDA.GetAllData();
                foreach (var s in l)
                {
                    if (s.Mada == ma)
                        dtDA.Delete(s.Madetai);
                }
            }                
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, DoAn newInfo)
        {
            DA.Edit(id, newInfo);
            if(id != newInfo.Mada)
			{
                List<Detai> l = dtDA.GetAllData();
                foreach(var s in l)
				{
                    if (s.Mada == id)
                        s.Mada = newInfo.Mada;
				}
                dtDA.GhiLaiDanhsach(l);
			}                
        }
        public List<DoAn> Tim(DoAn da)
        {
            List<DoAn> list = GetAllData();
            List<DoAn> kq = new List<DoAn>();
            //Voi gai tri ngam dinh ban dau
            if (da.Mada==0 && da.Tenda==null &&da.Sotc==0)
            {
                return list;
            }
            //Tim theo ma
            if (da.Mada != 0)
            {
                foreach (DoAn d in list)
                    if (d.Mada==da.Mada)
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            // Tim theo ten
            else if (da.Tenda != null)
            {
                foreach (DoAn d in list)
                    if (d.Tenda.Contains(da.Tenda))
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            //Tim theo sotc
            else if (da.Sotc != 0)
            {
                foreach (DoAn d in list)
                    if (d.Sotc == da.Sotc)
                    {
                        kq.Add(new DoAn(da));
                    }
            }
            return kq;
        }
    }
}
