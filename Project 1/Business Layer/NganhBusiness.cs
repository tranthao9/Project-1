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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IChuyenNganhBusiness
    public class NganhBusiness : INganhBusiness
    {
        private INganhDA ngDA = new NganhDA();
        private IKhoaDA khDA = new KhoaDA();
        private IGiangVienDA gvDA = new GiangVienDA();
        private IChuyenNganhDA cnDA = new ChuyenNganhDA();
        //Thực thi các yêu cầu
        public List<Nganh> GetAllData()
        {
            List<Nganh> listng = ngDA.GetAllData();
            List<Khoa> listkh = khDA.GetAllData();
            foreach (var nganh in listng)
            {
                foreach (var kh in listkh)
				{
                    foreach(var gv in gvDA.GetAllData())
					{
                        if (nganh.Makhoa == kh.Makhoa && nganh.Matruongnganh==gv.MaGV)
                        {
                            nganh.Khoa = new Khoa(kh);
                            nganh.Giangvien = new GiangVien(gv);
                            break;
                        }
                    }
                    if(nganh.Makhoa == kh.Makhoa && nganh.Matruongnganh == 0)
					{
                        nganh.Khoa = new Khoa(kh);
                        nganh.Giangvien = null ;
                    }                        
				}
                   
            }
            return listng;
        }
        //kiểm tra một mã giảng viên xem đã tồn tại hay chưa
        public bool ExistGV(int ma)
        {
            List<GiangVien> list = gvDA.GetAllData();
            if (list.Find(m => m.MaGV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã ngành xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<Nganh> list = GetAllData();
            if (list.Find(m => m.Manganh == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một tên ngành xem đã tồn tại hay chưa
        public bool ExistTEN(string ma)
        {
            List<Nganh> list = GetAllData();
            if (list.Find(m => m.Tennganh == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã trưởng ngành xem đã tồn tại hay chưa
        public bool ExistTN(int ma)
        {
            List<Nganh> list = GetAllData();
            if (list.Find(m => m.Matruongnganh == ma) != null)
                return true;
            return false;
        }
        public void Insert(Nganh ng)
        {
            if (ng.Tennganh != "" && ng.Mota != null && ng.Trangthai != null)
            {
                ng.Tennganh = Project_1.Utility.Congcu.Chuanhoaxau(ng.Tennganh);
                ng.Mota = Project_1.Utility.Congcu.Chuanhoaxau(ng.Mota);
                ng.Trangthai = Project_1.Utility.Congcu.Chuanhoaxau(ng.Trangthai);
                ngDA.Insert(ng);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public void Delete(int mang)
        {
            if (Exist(mang))
			{
                ngDA.Delete(mang);
                List<ChuyenNganh> l = cnDA.GetAllData();
                foreach (var s in l)
                {
                    if (s.Manganh == mang)
                        cnDA.Delete(s.Machnganh);
                }
            }                
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, Nganh newInfo)
        {
            ngDA.Edit(id, newInfo);
            if(id != newInfo.Manganh)
			{
                List<ChuyenNganh> l = cnDA.GetAllData();
                foreach(var s in l)
				{
                    if (s.Manganh == id)
                        s.Machnganh = newInfo.Manganh;
				}
                cnDA.GhiLaiDanhsach(l);
			}                
        }
        public List<Nganh> TimNganh(Nganh ng)
        {
            List<Nganh> list = ngDA.GetAllData();
            List<Nganh> kq = new List<Nganh>();
            //Voi gai tri ngam dinh ban dau
            if (ng.Manganh == 0 && ng.Tennganh == null && ng.Matruongnganh==0)
            {
                 return list;
            }
            //Tim theo ma nganh
            if (ng.Manganh != 0)
            {
                foreach (Nganh nganh in list)
                    if (nganh.Manganh == ng.Manganh)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            // Tim theo ten nganh
            else if ( ng.Tennganh != null )
            {
                foreach (Nganh nganh in list)
                    if (nganh.Tennganh.IndexOf(ng.Tennganh) >= 0)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            // Tim kiem theo mã trưởng ngành
            else if (ng.Matruongnganh != 0)
            {
                foreach (Nganh nganh in list)
                    if (ng.Matruongnganh == nganh.Matruongnganh)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            return kq;
        }
    }
}
