using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class Khoa
	{
		#region Các thành phần dữ liệu
		private int makhoa;
		private string tenkhoa;
		private string mota;
		private string trangthai;
		private int matruongkhoa;
		private GiangVien giangvien;
		#endregion

		#region Các thuộc tính
		public GiangVien Giangvien
		{
			get { return giangvien; }
			set
			{
				giangvien = value;
			}
		}
		public int Makhoa
		{
			get { return makhoa; }
			set
			{
				if (value >= 1 && value.ToString().Length == 3)
					makhoa = value;
			}
		}
		public int Matruongkhoa
		{
			get { return matruongkhoa; }
			set
			{
				matruongkhoa = value;
			}
		}
		public string Tenkhoa
		{
			get { return tenkhoa; }
			set
			{
				if (value != "")
					tenkhoa = value;
			}
		}
		public string Mota
		{
			get { return mota; }
			set
			{
				if (value != "")
					mota = value;
			}
		}
		public string Trangthai
		{
			get { return trangthai; }
			set
			{
				if (value != "")
					trangthai = value;
			}
		}
		#endregion

		#region Các phương thức
		public Khoa() { }
		public Khoa(Khoa k)
		{
			this.makhoa = k.makhoa;
			this.tenkhoa = string.Copy(k.tenkhoa);
			this.mota = string.Copy(k.mota);
			this.trangthai = string.Copy(k.trangthai);
			this.matruongkhoa = k.matruongkhoa;
		}
		public Khoa(int ma,string ten,int matruongkhoa,string mota, string trangthai)
		{
			this.makhoa = ma;
			this.tenkhoa = ten;
			this.mota = mota;
			this.trangthai = trangthai;
			this.matruongkhoa = matruongkhoa;
		}
		#endregion
	}
}
