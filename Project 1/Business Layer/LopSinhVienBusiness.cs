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
    public class LopSinhVienBusiness : ILopSinhVienBusiness
    {
        private ILopSinhVienDA DA = new LopSinhVienDA();
        private ILopHocDA lDA = new LopHocDA();
        private ISinhVienDA svDA = new SinhVienDA();
        //Thực thi các yêu cầu
        public List<LopSinhVien> GetAllData()
        {
            List<LopSinhVien> listng = DA.GetAllData();
            List<LopHoc> listl = lDA.GetAllData();
            List<SinhVien> listsv = svDA.GetAllData();
            foreach (var lsv in listng)
            {
                foreach (var kh in listl)
                {
                    foreach (var sv in listsv)
                    {
                        if (lsv.Malop == kh.Malop && lsv.MaSV == sv.MaSV)
                        {
                            lsv.Lop = new LopHoc(kh);
                            lsv.Sinhvien = new SinhVien(sv);

                        }
                    }
                }
            }
            return listng;
        }

        //kiểm tra một mã lớp học xem đã tồn tại hay chưa
        public bool ExistL(int ma)
        {
            List<LopHoc> list = lDA.GetAllData();
            if (list.Find(m => m.Malop == ma) != null)
                return true;
            return false;
        }

        //kiểm tra một mã sinh viên xem đã tồn tại hay chưa
        public bool ExistSV(int ma)
        {
            List<SinhVien> list = svDA.GetAllData();
            if (list.Find(m => m.MaSV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra lớp đã tồn tại trong bảng lớp siinh viên hay chưa
        public bool ExistKTL(int ma)
        {
            List<LopSinhVien> list = GetAllData();
            if (list.Find(m => m.Malop == ma) != null)
                return true;
            return false;
        }
        //kiểm tra sv đã tồn tại trong bảng lớp sinh viên hay chưa
        public bool ExistKTSV(int ma)
        {
            List<LopSinhVien> list = GetAllData();
            if (list.Find(m => m.MaSV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra sv có tồn tại trong lớp đó hay chưa
        public bool ExistKTSVL(int ma, int lop)
        {
            List<LopSinhVien> list = GetAllData();
            if (list.Find(m => m.MaSV == ma && m.Malop == lop) != null)
                return true;
            return false;
        }
        // kiểm tra năm học có tồn tại hay không
        public bool ExistKTNH(string ma)
        {
            List<LopSinhVien> list = GetAllData();
            if (list.Find(m => m.Namhocbdau.Contains(ma)) != null)
                return true;
            return false;
        }
        // kiểm tra học kỳ có tồn tại hay không
        public bool ExistKTHK(int ma)
        {
            List<LopSinhVien> list = GetAllData();
            if (list.Find(m => m.Hockybdau == ma) != null)
                return true;
            return false;
        }
        public void Insert(LopSinhVien ng)
        {
            DA.Insert(ng);
        }
        public void Delete(int ma,int lop) 
        {
            DA.DeleteLSV(ma,lop);
        }
        public void Edit(int id,int lop, LopSinhVien newInfo)
        {
            DA.Edit(id,lop, newInfo);
        }
        public List<SinhVien> Tim(LopSinhVien ng)
        {
            List<LopSinhVien> list = GetAllData();
            List<SinhVien> kq = new List<SinhVien>();
            //Voi gai tri ngam dinh ban dau
            if (ng.MaSV == 0 && ng.Malop == 0 && ng.Namhocbdau==null && ng.Hockybdau==0)
            {
                foreach (var a in list)
                    kq.Add(a.Sinhvien);
            }
            //Tim theo ma sv
            else if (ng.MaSV != 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.MaSV == ng.MaSV)
                    {
                        kq.Add((new LopSinhVien(lsv).Sinhvien));
                    }
            }
            // Tim theo ma lop
            else if (ng.Malop != 0 )
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Malop == ng.Malop)
                    {
                        kq.Add((new LopSinhVien(lsv).Sinhvien));
                    }
            }
            // Tim kiem theo nam hoc
            else if ( ng.Namhocbdau != null )
            {
                foreach (LopSinhVien lsv in list)
				{
                    string[] a = lsv.Namhocbdau.Split('-');
                    string[] c = lsv.Namhockthuc.Split('-');
                    string[] b = ng.Namhocbdau.Split('-');
                    if (lsv.Namhocbdau.Contains(ng.Namhocbdau) || lsv.Namhockthuc.Contains(ng.Namhocbdau))
                    {
                        kq.Add((new LopSinhVien(lsv).Sinhvien));
                    }
                    else
					{
                        if (int.Parse(b[0]) >= int.Parse(a[0]) && int.Parse(b[1]) <= int.Parse(c[1]))
                            kq.Add((new LopSinhVien(lsv).Sinhvien));
                    }                        
                }                    
                    
            }
            // Tim kiem theo hoc ky
            else if ( ng.Hockybdau != 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (ng.Hockybdau >= lsv.Hockybdau && ng.Hockybdau<= lsv.Hockykthuc)
                    {
                        kq.Add((new LopSinhVien(lsv).Sinhvien));
                    }
            }
            return kq;
        }
    }
}
