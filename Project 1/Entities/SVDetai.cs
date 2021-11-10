using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class SVDetai
	{
		#region Các thành phần dữ liệu
		private int madtai;
		private int masv;
		private double diembv;
		private double diemgvhd;
		private int maGVHD;
		private int maGVPB;
		private TuanDetai tuandt;
		private GiangVien giangvienhd;
		private GiangVien giangvienpb;
		private LopSinhVien lsv;
		#endregion

		#region Các thuộc tính
		public TuanDetai Tuandt
		{
			get { return tuandt; }
			set
			{
				if (value != null)
					tuandt = value;
			}
		}
		public GiangVien GiangvienHD
		{
			get { return giangvienhd; }
			set
			{
				if (value != null)
					giangvienhd = value;
			}
		}
		public GiangVien GiangvienPB
		{
			get { return giangvienpb; }
			set
			{
				if (value != null)
					giangvienpb = value;
			}
		}
		public LopSinhVien LopSV
		{
			get { return lsv; }
			set
			{
					lsv = value;
			}
		}
		public int Lop()
		{
			if (masv == LopSV.MaSV)
				return LopSV.Malop;
			else
				return 0;

		}
		public string TenSV()
		{
			if (masv == LopSV.MaSV)
			{
				return LopSV.Sinhvien.TenSV;
			}
			else
				return "không tồn tại";

		}
		public string TenGVHD()
		{
			if (maGVHD == GiangvienHD.MaGV)
				return giangvienhd.TenGV;
			else
				return "không tồn tại";
		}
		public string TenGVPB()
		{
			if (MaGVPB == GiangvienPB.MaGV)
				return giangvienpb.TenGV;
			else
				return "không tồn tại";
		}
		public int Madetai
		{
			get { return madtai; }
			set
			{
				if (value >= 1)
					madtai = value;
			}
		}
		public int MaSV
		{
			get { return masv; }
			set
			{
				if (value >= 1 && value.ToString().Length == 8)
					masv = value;
			}
		}
		public int MaGVHD
		{
			get { return maGVHD; }
			set
			{
				if (value >= 1 && value.ToString().Length==8)
					maGVHD = value;
			}
		}
		public int MaGVPB
		{
			get { return maGVPB; }
			set
			{
				if (value >= 1 && value.ToString().Length == 8)
					maGVPB = value;
			}
		}
		public string Tendt()
		{
			if (madtai == tuandt.Madettai)
				return tuandt.Detai.Tendetai;
			else
				return "Không tồn tại";
		}
		public double DiemBV
		{
			get { return diembv; }
			set
			{
				if (value >= 0 && value <= 10)
					diembv = value;
			}
		}
		public double DiemGVHD
		{
			get { return diemgvhd; }
			set
			{
				if (value >= 0 && value <= 10)
					diemgvhd = value;
			}
		}
		public double Diemgvpb()
		{
			double a=0, b=0;
			if (madtai == tuandt.Madettai)
			{
				if (tuandt.Matuan == 8)
					a = tuandt.Diem;
				if (tuandt.Matuan == 12)
					b = tuandt.Matuan;
			}	
			if(a!=0 || b!=0)
				return (a + b) / 2;
			else
				return .0;
			
		}
		public double TongDiem()
		{
			return ((diemgvhd+Diemgvpb()) /2+ diembv) / 2; 
		}
		public string xeploai()
		{
			if (TongDiem() >= 9)
				return "Xuất Sắc";
			else if (TongDiem() >= 8)
				return "Giỏi";
			else if (TongDiem() >= 7)
				return "Khá";
			else if (TongDiem() >= 6)
				return "Trung bình khá";
			else if (TongDiem() >= 5)
				return "Trung bình";
			else
				return "Yếu";

		}
		public string Danhgia()
		{
			if (tuandt.Diem >= 5 && this.diembv >= 5 && diemgvhd>=5)
				return "Đạt";
			else
				return "KHông đạt";
		}
		#endregion

		#region Các phương thức 
		public SVDetai() { }
		public SVDetai(SVDetai da)
		{
			this.madtai = da.madtai;
			this.masv = da.masv;
			this.maGVHD = da.maGVHD;
			this.maGVPB = da.maGVPB;
			this.diembv = da.diembv;
			this.diemgvhd = da.diemgvhd;
		}
		public SVDetai(int madetai,int msv,int magvhd,int magvpb,double diemgvhd, double diem)
		{
			this.masv = msv;
			this.madtai = madetai;
			this.maGVHD = magvhd;
			this.maGVPB = magvpb;
			this.diembv = diem;
			this.diemgvhd = diemgvhd;

		}
		#endregion
	}
}
