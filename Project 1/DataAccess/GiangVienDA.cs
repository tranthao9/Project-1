using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Project_1.Entities;
using Project_1.DataAccess.Interface;

namespace Project_1.DataAccess
{
	class GiangVienDA : IGiangVienDA
	{
		private string filetxt = "Data/GiangVien.txt";
		//lay du lieu tu trong file Giangvien.txt
		public List<GiangVien> GetAllData()
		{
			List<GiangVien> list = new List<GiangVien>();
			StreamReader f = File.OpenText(filetxt);
			string s = f.ReadLine();
			while (s != null)
			{
				if (s != "")
				{
					s = Project_1.Utility.Congcu.CatXau(s);
					string[] a = s.Split('#');
					list.Add(new GiangVien(int.Parse(a[1]), a[2], DateTime.Parse(a[3]), a[4], a[5], int.Parse(a[6]), a[7]));
				}
				s = f.ReadLine();
			}
			f.Close();
			return list;
		}
		//lay ma giang vien cuoi cung de danh ma tu dong
		public int Getma()
		{
			StreamReader fd = File.OpenText(filetxt);
			string s = fd.ReadLine();
			string tmp = "";
			while (s != null)
			{
				if (s != "")
					tmp = s;
				s = fd.ReadLine();
			}
			fd.Close();
			if (tmp == "") return 0;
			else
			{
				tmp = Project_1.Utility.Congcu.Chuanhoaxau(tmp);
				string[] a = tmp.Split('#');
				return int.Parse(a[0]);
			}
		}
		//chèn một bản ghi giang viên vào tệp
		public void Insert(GiangVien gv)
		{
			int sttsv = Getma() + 1;
			StreamWriter fw = File.AppendText(filetxt);
			fw.WriteLine(sttsv + "#" + gv.MaGV + "#" + gv.TenGV + "#"+"{0:d}", gv.Namsinh + "#" + gv.Gioitinh + "#" + gv.Diachi + "#" + gv.SDT + "#" + gv.Email);
			fw.Close();
		}
		//xóa sinh viên theo mã
		public void Delete(int magv)
		{

			List<GiangVien> list = GetAllData();
			StreamWriter fw = File.CreateText(filetxt);
			foreach (GiangVien gv in list)
				if (gv.MaGV != magv)
				{
					int sttsv = Getma() + 1;
					fw.Write(sttsv + "#" + gv.MaGV + "#" + gv.TenGV + "#" + gv.Namsinh + "#" + gv.Gioitinh + "#" + gv.Diachi + "#" + gv.SDT + "#" + gv.Email);
				}
			fw.Close();
		}
		//Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
		public void GhiLaiDanhsach(List<GiangVien> List)
		{
			StreamWriter fw = new StreamWriter(filetxt, false);
			int i = 0;
			foreach (GiangVien gv in List)
			{
				fw.WriteLine(i++ + "#" + gv.MaGV + "#" + gv.TenGV + "#" + gv.Namsinh + "#" + gv.Gioitinh + "#" + gv.Diachi + "#" + gv.SDT + "#" + gv.Email); ;

			}
			fw.Close();
		}
		public void Edit(int id, GiangVien newInfo)
		{
			//Đọc toàn bộ tập lớn về
			List<GiangVien> cn = GetAllData();
			//Sửa trên DS và ghi đè vào tệp
			for (int i = 0; i < cn.Count; i++)
			{
				if (cn[i].MaGV == id)
				{
					cn[i] = newInfo;
					break;
				}
			}
			GhiLaiDanhsach(cn);
		}
	}
}
