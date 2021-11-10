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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ISinhVienBusiness
    public class SinhVienBusiness : ISinhVienBusiness
    {
        private ISinhVienDA svDA = new SinhVienDA();
        //Thực thi các yêu cầu
        public List<SinhVien> GetAllData()
        {
            Console.InputEncoding = Encoding.UTF8;
            List<SinhVien> listSV = svDA.GetAllData();
            
            return listSV;
        }
        //kiểm tra một mã sinh viên xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<SinhVien> list = GetAllData();
            if (list.Find(m => m.MaSV == ma) != null)
                return true;
            return false;
        }
        public void Insert(SinhVien sv)
		{
            Console.InputEncoding = Encoding.UTF8;
            if (sv.TenSV != "" && sv.Diachi != "")
            {
                sv.TenSV = Project_1.Utility.Congcu.Chuanhoaxau(sv.TenSV);
                sv.Diachi = Project_1.Utility.Congcu.Chuanhoaxau(sv.Diachi);
                svDA.Insert(sv);
            }
            else
                throw new Exception("Du lieu sai");
        }
    
        public void Delete(int masv)
        {
            if (Exist(masv))
                svDA.Delete(masv);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, SinhVien newInfo)
        {
            svDA.Edit(id, newInfo);
        }
        public List<SinhVien> TimSinhVien(SinhVien sv)
        {
            List<SinhVien> list = svDA.GetAllData();
            List<SinhVien> kq = new List<SinhVien>();
            //Voi gai tri ngam dinh ban dau
            if (sv == null)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (sv.TenSV != null)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.TenSV.IndexOf(sv.TenSV) >= 0)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            // Tim theo que quan
            else if (sv.Diachi != null)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.Diachi.IndexOf(sv.Diachi) >= 0)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            //Tim theo ma
            else if (sv.TenSV == null && sv.Diachi == null && sv.MaSV != 0 && sv.Gioitinh == null && sv.NamsinhSV == null && sv.Sdt == 0)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.MaSV==sv.MaSV)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            // Tim kiem theo sdt
            else if (sv.TenSV == null && sv.Diachi == null && sv.MaSV == 0 && sv.Gioitinh == null && sv.NamsinhSV == null && sv.Sdt != 0)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.Sdt == sv.Sdt)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            // Tim kiem theo gioi tinh 
            else if (sv.TenSV == null && sv.Diachi == null && sv.MaSV == 0 && sv.Gioitinh != null && sv.NamsinhSV == null && sv.Sdt == 0)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.Gioitinh.ToLower()==sv.Gioitinh.ToLower())
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            //Tim theo namsinh
            else if (sv.NamsinhSV != new DateTime())
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.NamsinhSV.Year == sv.NamsinhSV.Year)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (sv.TenSV != null && sv.Diachi != null && sv.MaSV == 0 && sv.Gioitinh == null && sv.NamsinhSV == null && sv.Sdt == 0)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.TenSV.IndexOf(sv.TenSV) >= 0 && sinhVien.Diachi.IndexOf(sv.Diachi) >= 0)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            // Tim kiem ket hop theo tat ca
            else if (sv.TenSV != null && sv.Diachi != null && sv.MaSV != 0 && sv.Gioitinh != null && sv.NamsinhSV != null)
            {
                foreach (SinhVien sinhVien in list)
                    if (sinhVien.TenSV.IndexOf(sv.TenSV) >= 0 && sinhVien.Diachi.IndexOf(sv.Diachi) >= 0 && sinhVien.NamsinhSV.Year == sv.NamsinhSV.Year&& sinhVien.Gioitinh.ToLower() == sv.Gioitinh.ToLower()&& sinhVien.MaSV == sv.MaSV && sinhVien.Sdt == sv.Sdt)
                    {
                        kq.Add(new SinhVien(sinhVien));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
