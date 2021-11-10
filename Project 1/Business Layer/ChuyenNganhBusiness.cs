﻿using System;
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
    public class ChuyenNganhBusiness : IChuyenNganhBusiness
    {
        private IChuyenNganhDA chDA = new ChuyenNganhDA();
        private INganhBusiness ngDA = new NganhBusiness();
        private IGiangVienDA gvDA = new GiangVienDA();
        //Thực thi các yêu cầu
        public List<ChuyenNganh> GetAllData()              
        {
            List<ChuyenNganh> listch= chDA.GetAllData();
            List<Nganh> listng = ngDA.GetAllData();
            foreach (var chnganh in listch)
            {
                foreach (var ng in listng)
				{
                    foreach(var gv in gvDA.GetAllData())
                        if (chnganh.Manganh == ng.Manganh&& chnganh.Maphutrach==gv.MaGV)
                        {
                            chnganh.Nganh = new Nganh(ng);
                            chnganh.Giangvien = new GiangVien(gv);
                            break;
                        }
                }
                   
            }
            return listch;
        }
        //kiểm tra một mã ngành xem đã tồn tại hay chưa
        public bool ExistKTGV(int ma)
        {
            List<GiangVien> list = gvDA.GetAllData();
            if (list.Find(m => m.MaGV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã chuyên  ngành xem đã tồn tại hay chưa
        public bool ExistKTCN(int ma)
        {
            List<ChuyenNganh> list = GetAllData();
            if (list.Find(m => m.Manganh== ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã ngành xem đã tồn tại hay chưa
        public bool ExistKTN(int ma)
        {
            List<Nganh> list = ngDA.GetAllData();
            if (list.Find(m => m.Manganh == ma) != null)
                return true;
            return false;
        }
        public void Insert(ChuyenNganh ch)
        {
            if (ch.Tenchnganh != "" && ch.Mota !=null && ch.Trangthai !=null)
            {
                ch.Tenchnganh = Project_1.Utility.Congcu.Chuanhoaxau(ch.Tenchnganh);
                ch.Mota = Project_1.Utility.Congcu.Chuanhoaxau(ch.Mota);
                ch.Trangthai= Project_1.Utility.Congcu.Chuanhoaxau(ch.Trangthai);
                chDA.Insert(ch);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public void Delete(int mach)
        {
            if (ExistKTCN(mach))
                chDA.Delete(mach);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, ChuyenNganh newInfo)
        {
            chDA.Edit(id, newInfo);
        }
        public List<ChuyenNganh> TimChuyenNganh(ChuyenNganh ch)
        {
            List<ChuyenNganh> list = chDA.GetAllData();
            List<ChuyenNganh> kq = new List<ChuyenNganh>();
            //Voi gai tri ngam dinh ban dau
            if (ch.Machnganh == 0 && ch.Tenchnganh == null && ch.Mota==null && ch.Trangthai==null)
            {
                kq = list;
            }
            //Tim theo ma chuyen nganh
            if (ch.Machnganh != 0 && ch.Tenchnganh == null && ch.Mota == null && ch.Trangthai == null)
            {
                foreach (ChuyenNganh chuyenNganh in list)
                    if (chuyenNganh.Machnganh == ch.Machnganh)
                    {
                        kq.Add(new ChuyenNganh(chuyenNganh));
                    }
            }
            // Tim theo ten chuyen nganh
            else if (ch.Machnganh == 0 && ch.Tenchnganh != null && ch.Mota == null && ch.Trangthai == null)
            {
                foreach (ChuyenNganh chuyenNganh in list)
                    if (chuyenNganh.Tenchnganh.IndexOf(ch.Tenchnganh)>=0)
                    {
                        kq.Add(new ChuyenNganh(chuyenNganh));
                    }
            }
            // Tim kiem theo mo ta
            else if (ch.Machnganh == 0 && ch.Tenchnganh == null && ch.Mota != null && ch.Trangthai == null)
            {
                foreach (ChuyenNganh chuyenNganh in list)
                    if (chuyenNganh.Mota.IndexOf(ch.Mota) >= 0)
                    {
                        kq.Add(new ChuyenNganh(chuyenNganh));
                    }
            }
            // Tim kiem theo trang thai
            else if (ch.Machnganh == 0 && ch.Tenchnganh == null && ch.Mota == null && ch.Trangthai != null)
            {
                foreach (ChuyenNganh chuyenNganh in list)
                    if (chuyenNganh.Trangthai.IndexOf(ch.Trangthai) >= 0)
                    {
                        kq.Add(new ChuyenNganh(chuyenNganh));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}