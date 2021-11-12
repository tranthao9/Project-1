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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ISinhVienBusiness
    public class LopHocBusiness : ILopHocBusiness
    {
        private ILopHocDA lopDA = new LopHocDA();
        private IChuyenNganhBusiness chDA = new ChuyenNganhBusiness();
        private ILopSinhVienDA lDA = new LopSinhVienDA();
        //Thực thi các yêu cầu
        public List<LopHoc> GetAllData()
        {
            List<LopHoc> listlop = lopDA.GetAllData();
            List<ChuyenNganh> listch = chDA.GetAllData();
            foreach (var lop in listlop)
            {
                foreach (var ch in listch)
                    if (lop.Mach == ch.Machnganh)
                    {
                        lop.Cn = new ChuyenNganh(ch);
                        break;
                    }
            }
            return listlop;
        }
        //kiểm tra một mã chuyên ngành xem đã tồn tại hay chưa
        public bool ExistCN(int ma)
        {
            List<ChuyenNganh> list = chDA.GetAllData();
            if (list.Find(m => m.Machnganh == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã lớp học xem đã tồn tại hay chưa
        public bool Exist(int ma)
        {
            List<LopHoc> list = GetAllData();
            if (list.Find(m => m.Malop == ma) != null)
                return true;
            return false;
        }
        public void Insert(LopHoc lop)
        {
            if (lop.Tenlop != "" )
            {
                lop.Tenlop = Project_1.Utility.Congcu.Chuanhoaxau(lop.Tenlop);
                lopDA.Insert(lop);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public void Delete(int malop)
        {
            if (Exist(malop))
			{
                lopDA.Delete(malop);
                List<LopSinhVien> l = lDA.GetAllData();
                foreach (var s in l)
                {
                    if (s.Malop == malop)
                        lDA.DeleteLop(malop);
                }
            }                
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id, LopHoc newInfo)
        {
            lopDA.Edit(id, newInfo);
            if(id != newInfo.Malop)
			{
                List<LopSinhVien> l = lDA.GetAllData();
                foreach(var s in l)
				{
                    if (s.Malop == id)
                        s.Malop = newInfo.Malop;
				}
                lDA.GhiLaiDanhsach(l);
			}                
        }
        public List<LopHoc> TimLopHoc(LopHoc lop)
        {
            List<LopHoc> list = lopDA.GetAllData();
            List<LopHoc> kq = new List<LopHoc>();
            //Voi gai tri ngam dinh ban dau
            if (lop.Malop == 0 && lop.Tenlop == null )
            {
                kq = list;
            }
            //Tim theo ma lop
            if (lop.Malop != 0 && lop.Tenlop == null)
            {
                foreach (LopHoc lopHoc in list)
                    if (lopHoc.Malop== lop.Malop)
                    {
                        kq.Add(new LopHoc(lopHoc));
                    }
            }
            // Tim theo ten lop
            else if (lop.Malop == 0 && lop.Tenlop != null)
            {
                foreach (LopHoc lopHoc in list)
                    if (lopHoc.Malop.ToString().ToLower() == lop.Malop.ToString().ToLower())
                    {
                        kq.Add(new LopHoc(lopHoc));
                    }
            }
            //Tim ket hop giua ma va ten lop
            else if (lop.Malop != 0 && lop.Tenlop != null)
            {
                foreach (LopHoc lopHoc in list)
                    if (lopHoc.Malop.ToString().ToLower() == lop.Malop.ToString().ToLower() && lopHoc.Malop == lop.Malop)
                    {
                        kq.Add(new LopHoc(lopHoc));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
