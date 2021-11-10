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
		private int namhoc;
		private int hocky;
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
		public int Namhoc
		{
			get { return namhoc; }
			set
			{
				if (value >= 1 && value.ToString().Length == 4)
					namhoc = value;
			}
		}
		public int Hocky
		{
			get { return hocky; }
			set
			{
				if (value >= 1)
					hocky = value;
			}
		}
		#endregion

		#region Các phương thức
		public LopSinhVien() { }
		public LopSinhVien(LopSinhVien lsv)
		{
			this.malop = lsv.malop;
			this.maSv = lsv.maSv;
			this.namhoc = lsv.namhoc;
			this.hocky = lsv.hocky;
			this.Sinhvien = lsv.Sinhvien;
			this.Lop = lsv.Lop;
		}
		public LopSinhVien(int malop,int masv,int namhoc,int hocky)
		{
			this.malop = malop;
			this.maSv = masv;
			this.namhoc = namhoc;
			this.hocky = hocky;
		}
		#endregion
	}
}
