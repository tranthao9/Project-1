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

    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IGiangVienBusiness
    public class GiangVienBusiness : IGiangVienBusiness
    {
        private IGiangVienDA gvDA = new GiangVienDA();
        private IChuyenNganhDA cnDA = new ChuyenNganhDA();
        private INganhDA nDA = new NganhDA();
        private IKhoaDA kDA = new KhoaDA();
        private ISVDetaiDA svDA = new SVDetaiDA();
        //Thực thi các yêu cầu
        public List<GiangVien> GetAllData()
        {
            List<GiangVien> listSV = gvDA.GetAllData();

            return listSV;
        }
        //kiểm tra một mã giảng viên xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<GiangVien> list = GetAllData();
            if (list.Find(m => m.MaGV == ma) != null)
                return true;
            return false;
        }
        // liểm tra tên giảng viên có tồn tại không
        public bool ExistTEN(string ma)
        {
            List<GiangVien> list = GetAllData();
            if (list.Find(m => m.TenGV == ma) != null)
                return true;
            return false;
        }
        public void Insert(GiangVien gv)
        {
            gv.TenGV = Project_1.Utility.Congcu.Chuanhoaxau(gv.TenGV);
            gv.Diachi = Project_1.Utility.Congcu.Chuanhoaxau(gv.Diachi);
            gvDA.Insert(gv);
            
        }
        public void Delete(int magv)
        {
            if (Exist(magv))
			{
                gvDA.Delete(magv);
                List<ChuyenNganh> lcn = cnDA.GetAllData();
                List<Nganh> ln = nDA.GetAllData();
                List<Khoa> lk = kDA.GetAllData();
                List<SVDetai> lsv = svDA.GetAllData();
                foreach (var s in lcn)
                {
                    if (s.Maphutrach == magv)
                        s.Maphutrach = 0;
                }
                cnDA.GhiLaiDanhsach(lcn);
                foreach (var s in ln)
                {
                    if (s.Matruongnganh == magv)
                        s.Matruongnganh = 0;
                }
                nDA.GhiLaiDanhsach(ln);
                foreach (var s in lk)
                {
                    if (s.Matruongkhoa == magv)
                        s.Matruongkhoa = 0;
                }
                kDA.GhiLaiDanhsach(lk);
                foreach (var s in lsv)
                {
                    if (s.MaGVHD == magv)
                        s.MaGVHD = 0;
                    if (s.MaGVPB == magv)
                        s.MaGVPB = 0;
                }
                svDA.GhiLaiDanhsach(lsv);
            }                
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, GiangVien newInfo)
        {
            gvDA.Edit(id, newInfo);
            if(id != newInfo.MaGV)
			{
                List<ChuyenNganh> lcn = cnDA.GetAllData();
                List<Nganh> ln = nDA.GetAllData();
                List<Khoa> lk = kDA.GetAllData();
                List<SVDetai> lsv = svDA.GetAllData();
                foreach(var s in lcn)
				{
                    if (s.Maphutrach == id)
                        s.Maphutrach = newInfo.MaGV;
				}
                cnDA.GhiLaiDanhsach(lcn);
                foreach(var s in ln)
				{
                    if (s.Matruongnganh == id)
                        s.Matruongnganh = newInfo.MaGV;
				}
                nDA.GhiLaiDanhsach(ln);
                foreach(var s in lk)
				{
                    if (s.Matruongkhoa == id)
                        s.Matruongkhoa = newInfo.MaGV;
				}
                kDA.GhiLaiDanhsach(lk);
                foreach(var s in lsv)
				{
                    if (s.MaGVHD == id)
                        s.MaGVHD = newInfo.MaGV;
                    if (s.MaGVPB == id)
                        s.MaGVPB = newInfo.MaGV;
				}
                svDA.GhiLaiDanhsach(lsv);
			}                
        }
        public List<GiangVien> TimGiangVien(GiangVien gv)
        {
            List<GiangVien> list = gvDA.GetAllData();
            List<GiangVien> kq = new List<GiangVien>();
            //Voi gai tri ngam dinh ban dau
            if (gv.TenGV == null && gv.MaGV==0)
            {
                return list;
            }
            //Tim theo ho ten
            if (gv.TenGV != null)
            {
                foreach (GiangVien giangvien in list)
                    if (giangvien.TenGV.IndexOf(gv.TenGV) >= 0)
                    {
                        kq.Add(new GiangVien(giangvien));
                    }
            }
            //Tim theo ma
            else if ( gv.MaGV != 0)
            {
                foreach (GiangVien giangvien in list)
                    if (giangvien.MaGV == gv.MaGV)
                    {
                        kq.Add(new GiangVien(giangvien));
                    }
            }
            return kq;
        }
    }
}
