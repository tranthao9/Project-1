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
    public class SVDetaiBusiness : ISVDetaiBusiness
    {
        private ISVDetaiDA svDA = new SVDetaiDA();
        private ITuanDetaiBusiness tDA = new TuanDetaiBusiness();
        private IGiangVienDA gvDA = new GiangVienDA();
        private ILopSinhVienBusiness LsvDA = new LopSinhVienBusiness();
        //Thực thi các yêu cầu
        public List<SVDetai> GetAllData()
        {
           
            List<LopSinhVien> lsv = LsvDA.GetAllData();
            List<TuanDetai> tdt = tDA.GetAllData();
            List<SVDetai> list = svDA.GetAllData();
            foreach (var lop in list)
            {
                foreach (var ch in tdt)
                {
                    foreach (var ls in lsv)
					{
                        if(lop.Madetai == ch.Madettai && lop.MaSV == ls.MaSV)
						{
                            int d = 0;
                            foreach (var gv in gvDA.GetAllData())
                            {
                                if (lop.MaGVHD == gv.MaGV)
                                {

                                    lop.GiangvienHD = new GiangVien(gv);
                                    d++;
                                }
                                if ( lop.MaGVPB == gv.MaGV)
                                {
                                    lop.GiangvienPB = new GiangVien(gv);
                                    d++;
                                }
                                if (d == 2)
                                {
                                    lop.LopSV = new LopSinhVien(ls);
                                    lop.Tuandt = new TuanDetai(ch);
                                    break;
                                }
                            }
                        }
                    }
                }
            }        
            return list;
         }
        public void Insert(SVDetai sv)
        {
            svDA.Insert(sv);
        }
        //kiểm tra một đề tài xem đã có ai làm hay chưa
        public bool ExistSV1(int ma)
        {
            List<SVDetai> list = svDA.GetAllData();
            if (list.Find(m => m.Madetai == ma) != null)
                return true;
            return false;
        }
        // Liệt kê sinh viên đó đã làm nhưng đồ án nào
        public List<int> KT(int ma)
		{
			List<int> a = new List<int>();
            List<SVDetai> list = GetAllData();
            foreach (var x in list)
            {
                if (x.MaSV == ma)
                {
                    a.Add(x.Tuandt.Detai.Mada);
                }
            }
            return a;
        }
        // kiểm tra sinh viên đó có được làm thêm đề tài đó nữa không
        public bool ExistSV2(int ma,int msv)
        {
            List<int> x = new List<int>();
            x = KT(msv);
            List<TuanDetai> list =tDA.GetAllData();
            foreach(var a in list)
			{
                if(a.Madettai==ma)
                {
                    foreach(var c in x)
					{
                        if (a.Detai.Mada == c)
						{
                            return false;
						} 
                    }                        
                }
                
            }
            return
                true;
        }
        //kiểm tra một mã sinh viên xem đã tồn tại hay chưa
        public bool ExistSV(int ma)
        {
            List<LopSinhVien> list = LsvDA.GetAllData();
            if (list.Find(m => m.MaSV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã giảng viên xem đã tồn tại hay chưa
        public bool ExistGV(int ma)
        {
            List<GiangVien> list = gvDA.GetAllData();
            if (list.Find(m => m.MaGV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một mã đề tài xem đã tồn tại hay chưa
        public bool ExistDT(int ma)
        {
            List<TuanDetai> list = tDA.GetAllData();
            if (list.Find(m => m.Madettai == ma) != null)
                return true;
            return false;
        }
        public void Delete(int ma,int m2)
        {
            if (KiemTraMa(ma, m2))
                svDA.Delete(ma, m2);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id,int ma, SVDetai newInfo)
        {
            svDA.Edit(id,ma, newInfo);
        }
        public List<SVDetai> Tim(SVDetai sv)
        {
            List<SVDetai> list = svDA.GetAllData();
            List<SVDetai> kq = new List<SVDetai>();
            //Voi gai tri ngam dinh ban dau
            if (sv.MaSV == 0 && sv.Madetai==0 &&sv.MaGVHD==0&&sv.MaGVPB==0 )
            {
                kq = list;
            }
            //Tim theo ma sv
            else if (sv.MaSV != 0 && sv.Madetai == 0 && sv.MaGVHD == 0 && sv.MaGVPB == 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaSV== sv.MaSV)
                    {
                        kq.Add(new SVDetai(s));
                    }
            }
            //Tim theo ma de tai
            else if (sv.MaSV == 0 && sv.Madetai != 0 && sv.MaGVHD == 0 && sv.MaGVPB == 0)
            {
                foreach (SVDetai s in list)
                    if (s.Madetai == sv.Madetai)
                    {
                        kq.Add(new SVDetai(s));
                    }
            }
            //Tim theo ma GVHD
            else if (sv.MaSV == 0 && sv.Madetai == 0 && sv.MaGVHD != 0 && sv.MaGVPB == 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaGVHD == sv.MaGVHD)
                    {
                        kq.Add(new SVDetai(s));
                    }
            }
            //Tim theo ma gvpb
            else if (sv.MaSV == 0 && sv.Madetai == 0 && sv.MaGVHD == 0 && sv.MaGVPB != 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaGVPB == sv.MaGVPB)
                    {
                        kq.Add(new SVDetai(s));
                    }
            }
            //Tim ket hop tat ca
            else if (sv.MaSV != 0 && sv.Madetai != 0 && sv.MaGVHD != 0 && sv.MaGVPB != 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaGVPB == sv.MaGVPB && s.MaGVHD == sv.MaGVHD && s.Madetai == sv.Madetai && s.MaSV == sv.MaSV)
                    {
                        kq.Add(new SVDetai(s));
                    }
            }
            else kq = null;
            return kq;
        }
        //Các phương thức hỗ trợ cho việc thực thi các yêu cầu
        public bool KiemTraMa(int ma,int m2)
        {
            bool ok = false;
            foreach (SVDetai sv in svDA.GetAllData())
                if (sv.MaSV== ma && sv.Madetai == m2)
                {
                    ok = true; break;
                }
            return ok;
        }
    }
}
