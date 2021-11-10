using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class SinhVien
	{
		
		#region Các thành phần dữ liệu
		private int maSV;
		private string hotenSV;
		private DateTime namsinhSV;
		private string gioiTinh;
		private string diachi;
		private int sdt;
		private string email;
		#endregion

		#region Các thuộc tính
		public int MaSV
		{
			get { return maSV; }
			set
			{
					maSV = value;
			}
		}
		public string TenSV
		{
			
			get { return hotenSV; }
			set
			{
				if (value != "")
					hotenSV = value;
			}
		}
		public DateTime NamsinhSV
		{
			get { return namsinhSV; }
			set
			{
				if (value != null)
					namsinhSV = value;
			}
		}
		public string Gioitinh
		{
			get { return gioiTinh; }
			set
			{
				if (value.Replace(value[1], 'u').ToLower()== "nu" || value.ToLower()=="nam")
					gioiTinh = value;
			}
		}
		public string Email
		{
			get { return email; }
			set
			{
				if (value != "")
					email = value;
			}
		}
		public string Diachi
		{
			get { return diachi; }
			set
			{
				if (value != "")
					diachi = value;
			}
		}
		public int Sdt
		{
			get { return sdt; }
			set
			{
				if (value.ToString().Length == 9)
					sdt = value;
			}
		}
		#endregion

		#region Các phương thức
		public SinhVien() {
			
		}
		public SinhVien(SinhVien SV)
		{
			
			this.maSV = SV.maSV;
			this.hotenSV = SV.hotenSV;
			this.gioiTinh = SV.gioiTinh;
			this.diachi = SV.diachi;
			this.sdt = SV.sdt;
			this.email = SV.email;
			this.namsinhSV = SV.namsinhSV;
		}
		public SinhVien(int maSV, string Hoten, DateTime ngsing, string gioitinh, string diachi, int sdt, string email)
		{
			this.maSV = maSV;
			this.hotenSV = string.Copy(Hoten);
			this.namsinhSV = ngsing;
			this.gioiTinh = string.Copy(gioitinh);
			this.diachi = string.Copy(diachi);
			this.sdt = sdt;
			this.email = string.Copy(email);
		}
		#endregion
	}
}