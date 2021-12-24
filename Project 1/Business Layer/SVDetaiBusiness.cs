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
        private IDetaiBusiness dt = new DetaiBusiness();
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
                        if (lop.Madetai == ch.Madettai && lop.MaSV == ls.MaSV)
                        {
                            int d = 0;
                            foreach (var gv in gvDA.GetAllData())
                            {
                                if (lop.MaGVHD == gv.MaGV)
                                {
                                    lop.GiangvienHD = new GiangVien(gv);
                                    d++;
                                }
                                if (lop.MaGVPB == gv.MaGV)
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
        //kiểm tra một chuyên ngành có tồn tại không
        public bool ExistCN(int ma)
		{
            List<SVDetai> list = svDA.GetAllData();
            if (list.Find(m => m.LopSV.Lop.Mach == ma) != null)
                return true;
            return false;
        }
        //kiểm tra một ngành có tồn tại không
        public bool ExistN(int ma)
        {
            List<SVDetai> list = svDA.GetAllData();
            if (list.Find(m => m.LopSV.Lop.Cn.Manganh== ma) != null)
                return true;
            return false;
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
            List<Detai> list = dt.GetAllData();
            if (list.Find(m => m.Madetai == ma) != null)
                return true;
            return false;
        }
        // kiểm tra mã đề tài có trong tuần đề tài không
        public bool ExistTDT(int ma)
        {
            List<TuanDetai> list = tDA.GetAllData();
            if (list.Find(m => m.Madettai == ma) != null)
                return true;
            return false;
        }
        //kiểm tra mã lớp có tồn tại trong bảng không
        public bool ExistKTL(int ma)
        {
            List<SVDetai> list = GetAllData();
            if (list.Find(m => m.Lop() == ma) != null)
                return true;
            return false;
        }
        //kiểm tra mã sinh viên có tồn tại trong bảng không
        public bool ExistKTSV(int ma)
        {
            List<SVDetai> list = GetAllData();
            if (list.Find(m => m.MaSV == ma) != null)
                return true;
            return false;
        }
        //kiểm tra mã GVHD có tồn tại trong bảng không
        public bool ExistKTGVHD(int ma)
        {
            List<SVDetai> list = GetAllData();
            if (list.Find(m => m.MaGVHD == ma) != null)
                return true;
            return false;
        }
        //kiểm tra mã GVPB có tồn tại trong bảng không
        public bool ExistKTGVPB(int ma)
        {
            List<SVDetai> list = GetAllData();
            if (list.Find(m => m.MaGVPB == ma) != null)
                return true;
            return false;
        }
        // kiểm tra mã đồ án
        public bool ExistKTDA(int ma)
        {
            List<SVDetai> list = GetAllData();
            if (list.Find(m => m.Tuandt.Detai.Mada == ma) != null)
                return true;
            return false;
        }

        public void Delete(int ma)
        {
            if (ExistDT(ma))
                svDA.Delete(ma);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void Edit(int id,int ma, SVDetai newInfo)
        {
            svDA.Edit(id,ma, newInfo);
        }
        public List<SVDetai> Tim(SVDetai sv)
        {
            List<SVDetai> list =GetAllData();
            List<SVDetai> kq = new List<SVDetai>();
            //Voi gai tri ngam dinh ban dau
            if (sv.MaSV == 0 && sv.Tuandt.Detai.Mada==0 &&sv.MaGVHD==0&&sv.MaGVPB==0 )
            {
                return list;
            }
            //Tim theo ma sv
            if (sv.MaSV != 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaSV== sv.MaSV)
                    {
                        kq.Add(s);
                    }
            }
            //Tim theo ma đồ án
            else if (sv.Tuandt.Detai.Mada != 0)
            {
                foreach (SVDetai s in list)
                    if (s.Madetai == sv.Madetai)
                    {
                        kq.Add(s);
                    }
            }
            //Tim theo ma GVHD
            else if (sv.MaGVHD != 0 )
            {
                foreach (SVDetai s in list)
                    if (s.MaGVHD == sv.MaGVHD)
                    {
                        kq.Add(s);
                    }
            }
            //Tim theo ma gvpb
            else if (sv.MaGVPB != 0)
            {
                foreach (SVDetai s in list)
                    if (s.MaGVPB == sv.MaGVPB)
                    {
                        kq.Add(s);
                    }
            }
            return kq;
        }
        public double Diemgvpb(SVDetai x)
        {
            double s=0;
            List<TuanDetai> tdt = tDA.GetAllData();
            foreach(var a in tdt)
			{
                if (x.Madetai == a.Madettai)
                    s = s + a.Diem;

			}
            return Math.Round( (s / 2),2);
        }


        public double TongDiem(SVDetai x)
        {
            return Math.Round((((x.DiemGVHD + Diemgvpb(x)) / 2 + x.DiemBV) / 2),2);
        }
        public string xeploai(SVDetai x)
        {
            if (TongDiem(x) >= 9)
                return "Xuất Sắc";
            else if (TongDiem(x) >= 8)
                return "Giỏi";
            else if (TongDiem(x) >= 7)
                return "Khá";
            else if (TongDiem(x) >= 6)
                return "TB khá";
            else if (TongDiem(x) >= 5)
                return "Trung bình";
            else
                return "Yếu";
        }
        public string Danhgia(SVDetai x)
        {
            if (Diemgvpb(x) >= 5 && x.DiemBV >= 5 && x.DiemGVHD >= 5)
                return "Đạt";
            else
                return "KHông đạt";
        }
    }
}
