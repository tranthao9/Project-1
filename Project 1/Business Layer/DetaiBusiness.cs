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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IDetaiBusiness
    public class DetaiBusiness : IDetaiBusiness
    {
        private IDetaiDA lopDA = new DetaiDA();
        private IDoAnDA chDA = new DoAnDA();
        private ITuanDetaiDA tDA = new TuanDetaiDA();
        private ISVDetaiDA sDA = new SVDetaiDA();
        //Thực thi các yêu cầu
        public List<Detai> GetAllData()
        {
            List<Detai> listlop = lopDA.GetAllData();
            foreach (var lop in listlop)
            {
                foreach (var ch in chDA.GetAllData())
                    if (lop.Mada == ch.Mada)
                    {
                        lop.Da = new DoAn(ch);
                        break;
                    }
            }
            return listlop;
        }
        //kiểm tra một mã đồ án xem đã tồn tại hay chưa
        public bool ExistKT(int ma)
        {
            List<DoAn> list = chDA.GetAllData();
            if (list.Find(m => m.Mada == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã đề tài xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<Detai> list = GetAllData();
            if (list.Find(m => m.Madetai == ma) != null)
                return true;
            return false;
        }
        public void Insert(Detai dt)
        {
                dt.Tendetai = Project_1.Utility.Congcu.Chuanhoaxau(dt.Tendetai);
                lopDA.Insert(dt);
        }
        public void Delete(int ma)
        {
            if (Exist(ma))
			{
                lopDA.Delete(ma);
                List<SVDetai> lsv = sDA.GetAllData();
                List<TuanDetai> lt = tDA.GetAllData();
                foreach (var a in lsv)
                {
                    if (a.Madetai == ma)
                    {
                        sDA.Delete(a.Madetai);
                    }
                }
                foreach (var s in lt)
                {
                    if (s.Madettai == ma)
                    {
                        tDA.Delete(s.Madettai, s.Matuan);
                    }
                }

            }               
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, Detai newInfo)
        {
            lopDA.Edit(id, newInfo);
            if(id != newInfo.Madetai)
			{
                List<SVDetai> lsv = sDA.GetAllData();
                List<TuanDetai> lt = tDA.GetAllData();
                foreach(var a in lsv)
				{
                    if (a.Madetai == id)
					{
                        a.Madetai = newInfo.Madetai;
                    }  
				}
                sDA.GhiLaiDanhsach(lsv);
                foreach(var s in lt)
				{
                    if(s.Madettai==id)
					{
                        s.Madettai = newInfo.Madetai;
					}                        
				}
                tDA.GhiLaiDanhsach(lt);
			}                
        }
        public List<Detai> Tim(Detai dt)
        {
            List<Detai> list = lopDA.GetAllData();
            List<Detai> kq = new List<Detai>();
            //Voi gai tri ngam dinh ban dau
            if (dt.Mada==0&& dt.Tendetai==null)
            {
                kq = list;
            }
            //Tim theo ma 
            else if (dt.Mada != 0 && dt.Tendetai == null)
            {
                foreach (Detai d in list)
                    if (d.Mada== dt.Mada)
                    {
                        kq.Add(new Detai(d));
                    }
            }
            // Tim theo ten lop
            else if (dt.Mada == 0 && dt.Tendetai != null)
            {
                foreach (Detai d in list)
                    if (d.Tendetai == dt.Tendetai)
                    {
                        kq.Add(new Detai(d));
                    }
            }
            //Tim ket hop giua ma va ten lop
            else if (dt.Mada != 0 && dt.Tendetai != null)
            {
                foreach (Detai d in list)
                    if (d.Tendetai == dt.Tendetai&& d.Mada == dt.Mada)
                    {
                        kq.Add(new Detai(d));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
