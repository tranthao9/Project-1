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
            foreach (var lsv in listng)
            {
                foreach (var kh in lDA.GetAllData())
				{
                    foreach(var sv in svDA.GetAllData())
					{
                        if(lsv.Malop==kh.Malop && lsv.MaSV==sv.MaSV)
						{
                            lsv.Lop = new LopHoc(kh);
                            lsv.Sinhvien = new SinhVien(sv);
                            break;
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
        public void Insert(LopSinhVien ng)
        {
            DA.Insert(ng);
        }
        public void Delete(int ma,int m1)
        {
            if (KiemTraMa(ma,m1))
                DA.DeleteLSV(ma,m1);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id,int ma, LopSinhVien newInfo)
        {
            DA.Edit(id,ma, newInfo);
        }
        public List<LopSinhVien> Tim(LopSinhVien ng)
        {
            List<LopSinhVien> list = DA.GetAllData();
            List<LopSinhVien> kq = new List<LopSinhVien>();
            //Voi gai tri ngam dinh ban dau
            if (ng.MaSV == 0 && ng.Malop == 0 && ng.Namhoc==0 && ng.Hocky==0)
            {
                kq = list;
            }
            //Tim theo ma sv
            else if (ng.MaSV != 0 && ng.Malop == 0 && ng.Namhoc == 0 && ng.Hocky == 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.MaSV == ng.MaSV)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            // Tim theo ma lop
            else if (ng.MaSV == 0 && ng.Malop != 0 && ng.Namhoc == 0 && ng.Hocky == 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Malop == ng.Malop)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            // Tim kiem theo nam hoc
            else if (ng.MaSV == 0 && ng.Malop == 0 && ng.Namhoc != 0 && ng.Hocky == 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Namhoc == ng.Namhoc)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            // Tim kiem theo hoc ky
            else if (ng.MaSV == 0 && ng.Malop == 0 && ng.Namhoc == 0 && ng.Hocky != 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Hocky == ng.Hocky)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            // tim kiem theo nam hoc va hoc ky
            else if (ng.MaSV == 0 && ng.Malop == 0 && ng.Namhoc != 0 && ng.Hocky != 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Hocky == ng.Hocky && lsv.Namhoc == ng.Namhoc)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            //tim kiem theo lop va hoc ky
            else if (ng.MaSV == 0 && ng.Malop != 0 && ng.Namhoc == 0 && ng.Hocky != 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Hocky == ng.Hocky && lsv.Malop == ng.Malop)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            //tim kiem theo lop va nam hoc
            else if (ng.MaSV == 0 && ng.Malop != 0 && ng.Namhoc != 0 && ng.Hocky == 0)
            {
                foreach (LopSinhVien lsv in list)
                    if (lsv.Namhoc == ng.Namhoc && lsv.Malop == ng.Malop)
                    {
                        kq.Add(new LopSinhVien(lsv));
                    }
            }
            else kq = null;
            return kq;
        }
        //Các phương thức hỗ trợ cho việc thực thi các yêu cầu
        public bool KiemTraMa(int ma,int m1)
        {
            bool ok = false;
            foreach (LopSinhVien ng in DA.GetAllData())
                if (ng.MaSV == ma && ng.Malop ==m1)
                {
                    ok = true; break;
                }
            return ok;
        }
    }
}
