using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class DoAn
	{
		#region Các thành phần dữ liệu
		private int mada;
		private string tenda;
		private int sotc;
		private string mota;
		#endregion

		#region Các thuộc tính
		
		public int Mada
		{
			get { return mada; }
			set
			{
					mada = value;
			}

		}
		public string Tenda
		{
			get { return tenda; }
			set
			{
					tenda = value;
			}
		}
		public int Sotc
		{
			get { return sotc; }
			set
			{
					sotc = value;
			}
		}
		public string Mota
		{
			get { return mota; }
			set
			{
					mota = value;
			}
		}
		#endregion

		#region Các phương thức 
		public DoAn() { }
		public DoAn(DoAn da)
		{
			this.mada = da.mada;
			this.tenda = da.tenda;
			this.sotc = da.sotc;
			this.mota = da.mota;
		}
		public DoAn(int mada, string tenda,int sotc,string mota)
		{
			this.mada = mada;
			this.tenda = tenda;
			this.sotc = sotc;
			this.mota = mota;
		}
		#endregion
	}
}

