using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class LopHoc
	{
		#region Các thành phần dữ liệu
		private int malop;
		private string tenlop;
		private int mach;
		private ChuyenNganh cn;
		#endregion

		#region Các thuộc tính
		public ChuyenNganh Cn
		{
			get { return cn; }
			set
			{
				if (value != null)
					cn = value;
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
		public int Mach
		{
			get { return mach; }
			set
			{
				if (value >= 1 && value.ToString().Length == 4)
					mach = value;
			}
		}
		public string Tenlop
		{
			get { return tenlop; }
			set
			{
				if (value != "")
					tenlop = value;
			}
		}
		#endregion


		#region Các phương thức
		public LopHoc() { }
		public LopHoc(LopHoc lh)
		{
			this.malop = lh.malop;
			this.tenlop = string.Copy(lh.tenlop);
			this.mach = lh.mach;
		}
		public LopHoc(int ma, string ten,int mach)
		{
			this.malop = ma;
			this.tenlop = ten;
			this.mach = mach;
		}
		#endregion
	}
}
