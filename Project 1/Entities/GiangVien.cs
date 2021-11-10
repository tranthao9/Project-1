using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class GiangVien
	{
		#region Các thành phần dữ liệu
		private int maGV;
		private string hotenGV;
		private DateTime ngaysinhGV;
		private string gioiTinh;
		private string diachi;
		private int sdt;
		private string email;
		#endregion

		#region Các thuộc tính
		public int MaGV
		{
			get { return maGV; }
			set
			{
					maGV = value;
			}
		}
		public int SDT
		{
			get { return sdt; }
			set
			{
					sdt = value;
			}
		}
		public DateTime Namsinh
		{
			get { return ngaysinhGV; }
			set
			{
					ngaysinhGV = value;
			}
		}
		public string TenGV
		{
			get { return hotenGV; }
			set
			{
					hotenGV = value;
			}
		}
		public string Gioitinh
		{
			get { return gioiTinh; }
			set
			{
					gioiTinh = value;
			}
		}
		public string Diachi
		{
			get { return diachi; }
			set
			{
					diachi = value;
			}
		}
		public string Email
		{
			get { return email; }
			set
			{
					email = value;
			}
		}
		#endregion

		#region Các phương thức
		public GiangVien() { }
		public GiangVien(GiangVien GV)
		{
			this.maGV = GV.maGV;
			this.hotenGV = GV.hotenGV;
			this.gioiTinh = string.Copy(GV.gioiTinh);
			this.diachi = string.Copy(GV.diachi);
			this.sdt = GV.sdt;
			this.email = string.Copy(GV.email);
			this.ngaysinhGV = GV.ngaysinhGV;
		}
		public GiangVien(int maGV,string Hoten,DateTime ngsing, string gioitinh,string diachi, int sdt, string email)
		{
			this.maGV = maGV;
			this.hotenGV = Hoten;
			this.ngaysinhGV = ngsing;
			this.gioiTinh = gioitinh;
			this.diachi = diachi;
			this.sdt = sdt;
			this.email = email;
		}
		#endregion
	}
}
