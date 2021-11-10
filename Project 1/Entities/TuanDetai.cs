﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Entities
{
	public class TuanDetai
	{

		#region Các thành phần dữ liệu
		private int madetai;
		private int matuan;
		private string danhgia;
		private double diem;
		private Detai detai;
		#endregion

		#region Các thuộc tính

		public int Madettai
		{
			get { return madetai; }
			set
			{
				if (value > 0)
					madetai = value;
			}

		}
		public int Matuan
		{
			get { return matuan; }
			set
			{
				if (value > 0)
					matuan = value;
			}
		}
		public Detai Detai
		{
			get { return detai; }
			set
			{
				if (value != null)
					detai = value;
			}
		}

		public string Danhgia
		{
			get { return danhgia; }
			set
			{
				if (value.ToLower() == "đạt" || value.ToLower() == "không đạt")
					danhgia = value;
			}
		}
		public double Diem
		{
			get { return diem; }
			set
			{
				if (value >= .0 && value <= 10.0)
					diem = value;
			}
		}
		#endregion

		#region Các phương thức 
		public TuanDetai() { }
		public TuanDetai(TuanDetai tuandt)
		{
			this.madetai = tuandt.madetai;
			this.matuan = tuandt.matuan;
			this.danhgia = tuandt.danhgia;
			this.diem = tuandt.diem;
			this.Detai = tuandt.Detai;
		}
		public TuanDetai(int matuan,int madetai,string danhgia,double diem)
		{
			this.matuan = matuan;
			this.madetai = madetai;
			this.danhgia = danhgia;
			this.diem = diem;
		}
		#endregion
	}
}

