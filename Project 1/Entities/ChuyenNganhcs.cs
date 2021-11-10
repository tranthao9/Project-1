using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class ChuyenNganh
	{
		#region Các thành phần dữ liệu
		private int manganh;
		private int machnganh;
		private string tenchnganh;
		private string mota;
		private string trangthai;
		private int maphutrach;
		private GiangVien giangvien;
		private Nganh nganh;
		#endregion

		#region Các thuộc tính
		public Nganh Nganh
		{
			get { return nganh; }
			set
			{
				if (value != null)
					nganh = value;
			}
		}
		public GiangVien Giangvien
		{
			get { return giangvien; }
			set
			{
				if (value != null)
					giangvien = value;
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
		public int Maphutrach
		{
			get { return maphutrach; }
			set
			{
					maphutrach = value;
			}
		}
		public int Machnganh
		{
			get { return machnganh; }
			set
			{
				if (value >= 1 && value.ToString().Length == 4)
					machnganh = value;
			}
		}
		public string Tenchnganh
		{
			get { return tenchnganh; }
			set
			{
				if (value != "")
					tenchnganh = value;
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
		public ChuyenNganh() { }
		public ChuyenNganh(ChuyenNganh cn)
		{
			this.manganh = cn.manganh;
			this.machnganh = cn.machnganh;
			this.tenchnganh = (cn.tenchnganh);
			this.mota = (cn.mota);
			this.trangthai = (cn.trangthai);
			this.maphutrach = cn.maphutrach;
		}
		public ChuyenNganh(int machnganh, string ten, int maphutrach ,string mota, string trangthai, int manganh)
		{
			this.machnganh = machnganh;
			this.manganh = manganh;
			this.tenchnganh = ten;
			this.mota = mota;
			this.trangthai = trangthai;
			this.maphutrach = maphutrach;
		}
		#endregion
	}
}
