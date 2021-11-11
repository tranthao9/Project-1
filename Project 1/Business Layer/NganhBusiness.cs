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
                ngDA.Delete(mang);
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
            if (ng.Manganh == 0 && ng.Tennganh == null && ng.Mota == null && ng.Trangthai == null)
            {
                kq = list;
            }
            //Tim theo ma nganh
            if (ng.Manganh != 0 && ng.Tennganh == null && ng.Mota == null && ng.Trangthai == null)
            {
                foreach (Nganh nganh in list)
                    if (nganh.Manganh == ng.Manganh)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            // Tim theo ten nganh
            else if (ng.Manganh == 0 && ng.Tennganh != null && ng.Mota == null && ng.Trangthai == null)
            {
                foreach (Nganh nganh in list)
                    if (nganh.Tennganh.IndexOf(ng.Tennganh) >= 0)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            // Tim kiem theo mo ta
            else if (ng.Manganh == 0 && ng.Tennganh == null &&ng.Mota != null && ng.Trangthai == null)
            {
                foreach (Nganh nganh in list)
                    if (nganh.Mota.IndexOf(ng.Mota) >= 0)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            // Tim kiem theo trang thai
            else if (ng.Manganh == 0 && ng.Tennganh == null && ng.Mota == null && ng.Trangthai != null)
            {
                foreach (Nganh nganh in list)
                    if (nganh.Trangthai.IndexOf(ng.Trangthai) >= 0)
                    {
                        kq.Add(new Nganh(nganh));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
