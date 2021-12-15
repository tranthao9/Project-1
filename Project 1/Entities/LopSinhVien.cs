using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class LopSinhVien
	{
		#region Các thành phần dữ liệu
		private int maSv;
		private int malop;
		private SinhVien sinhvien;
		private LopHoc lop;
		private string namhocbdau;
		private int hockybdau;
		private string namhockthuc;
		private int hockykthuc;
		#endregion

		#region Các thuộc tính
		public SinhVien Sinhvien
		{
			get { return sinhvien; }
			set
			{
					sinhvien = value;
			}
		}
		public LopHoc Lop
		{
			get { return lop; }
			set
			{
				if (value != null)
					lop = value;
			}
		}
		public int MaSV
		{
			get { return maSv; }
			set
			{
				if (value >= 1 && value.ToString().Length == 8)
					maSv = value;
			}
		}
		public int Malop
		{
			get { return malop; }
			set
			{
				if (value >= 1 && value.ToString().Length == 6)
					malop = value;
			}
		}
		public string Namhocbdau
		{
			get { return namhocbdau; }
			set
			{
					namhocbdau = value;
			}
		}
		public int Hockybdau
		{
			get { return hockybdau; }
			set
			{
				if (value >= 1)
					hockybdau = value;
			}
		}
		public string Namhockthuc
		{
			get { return namhockthuc; }
			set
			{
				namhockthuc = value;
			}
		}
		public int Hockykthuc
		{
			get { return hockykthuc; }
			set
			{
				if (value >= 1)
					hockykthuc = value;
			}
		}
		#endregion

		#region Các phương thức
		public LopSinhVien() { }
		public LopSinhVien(LopSinhVien lsv)
		{
			this.malop = lsv.malop;
			this.maSv = lsv.maSv;
			this.namhocbdau = lsv.namhocbdau;
			this.hockybdau = lsv.hockybdau;
			this.namhockthuc = lsv.namhockthuc;
			this.hockykthuc = lsv.hockykthuc;
			this.Sinhvien = lsv.Sinhvien;
			this.Lop = lsv.Lop;
		}
		public LopSinhVien(int malop,int masv,string namhocbdau,int hockybdau,string namhockthuc,int hockykthuc)
		{
			this.malop = malop;
			this.maSv = masv;
			this.namhocbdau = namhocbdau;
			this.hockybdau = hockybdau;
			this.namhockthuc = namhockthuc;
			this.hockykthuc = hockykthuc;
		}
		#endregion
	}
}
