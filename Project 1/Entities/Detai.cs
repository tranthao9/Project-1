using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class Detai
	{

		#region Các thành phần dữ liệu
		private int mada;
		private int madetai;
		private string tendetai;
		private string mota;
		private DoAn da;
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
		public string Tendetai
		{
			get { return tendetai; }
			set
			{
				if (value != "")
					tendetai = value;
			}
		}
		public int Madetai
		{
			get { return madetai; }
			set
			{
				if (value >= 1)
					madetai = value;
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
		public DoAn Da
		{
			get { return da; }
			set
			{
				if (value != null)
					da = value;
			}
		}
		#endregion

		#region Các phương thức 
		public Detai() { }
		public Detai(Detai da)
		{
			this.mada = da.mada;
			this.tendetai = (da.tendetai);
			this.madetai = da.madetai;
			this.mota = da.mota;
			this.Da = da.Da;
		}
		public Detai(int madetai, string tendt, string mota,int mada)
		{
			this.mada = mada;
			this.tendetai = tendt;
			this.madetai = madetai;
			this.mota = mota;
		}
		#endregion
	}
}

