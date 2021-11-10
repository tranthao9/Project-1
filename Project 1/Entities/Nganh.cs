using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class Nganh
	{
		#region Các thành phần dữ liệu
		private int manganh;
		private int makhoa;
		private string tennganh;
		private string mota;
		private string trangthai;
		private int matruongnganh;
		private GiangVien giangvien;
		private Khoa khoa;
		#endregion

		#region Các thuộc tính
		public GiangVien Giangvien
		{
			get { return giangvien; }
			set
			{
				if (value != null)
					giangvien = value;
			}
		}
		public Khoa Khoa
		{
			get { return khoa; }
			set
			{
				if (value != null)
					khoa = value;
			}
		}
		public int Manganh
		{
			get { return manganh; }
			set
			{
				if (value >= 1 && value.ToString().Length == 3)
					manganh = value;
			}
		}
		public int Matruongnganh
		{
			get { return matruongnganh; }
			set
			{
				matruongnganh = value;
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
		public string Tennganh
		{
			get { return tennganh; }
			set
			{
				if (value != "")
					tennganh = value;
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
		public Nganh() { }
		public Nganh(Nganh n)
		{
			this.makhoa = n.makhoa;
			this.manganh = n.manganh;
			this.tennganh = (n.tennganh);
			this.mota = (n.mota);
			this.trangthai = (n.trangthai);
			this.matruongnganh = n.matruongnganh;
		}
		public Nganh(int manganh, string ten,int matruongnganh, string mota, string trangthai,int makhoa)
		{
			this.makhoa = makhoa;
			this.manganh = manganh;
			this.tennganh = ten;
			this.mota = mota;
			this.trangthai = trangthai;
			this.matruongnganh = matruongnganh;
		}
		#endregion
	}
}
