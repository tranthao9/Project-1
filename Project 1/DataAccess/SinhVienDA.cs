using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Project_1.Entities;
using Project_1.DataAccess.Interface;
using Project_1.Business_Layer;
using Project_1.Business_Layer.Interface;


namespace Project_1.DataAccess
{
	class SinhVienDA : ISinhVienDA
	{
		private string filetxt = "Data/SinhVien.txt";
		//lay du lieu tu trong file sinhvien.txt
		public List<SinhVien> GetAllData()
		{
			List<SinhVien> list = new List<SinhVien>();
			StreamReader f = File.OpenText(filetxt);
			string s = f.ReadLine();
			while (s != null)
			{
				if (s != "")
				{
					s = Project_1.Utility.Congcu.CatXau(s);
					string[] a = s.Split('#');
					list.Add(new SinhVien(int.Parse(a[1]), a[2], DateTime.Parse(a[3]), a[4], a[5], int.Parse(a[6]), a[7]));
				}
				s = f.ReadLine();
			}
			f.Close();
			return list;
		}
		//lay ma hoc sinh cuoi cung de danh ma tu dong
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
		//chèn một bản ghi sinh viên vào tệp
		public void Insert(SinhVien sv)
		{
			int sttsv = Getma() + 1;
			StreamWriter fw = File.AppendText(filetxt);
			fw.WriteLine(sttsv + "#" +sv.MaSV+"#"+ sv.TenSV + "#" +"{0:d}", sv.NamsinhSV + "#" + sv.Gioitinh + "#" + sv.Diachi + "#" + sv.Sdt + "#" + sv.Email,true);
			fw.Close();
		}
		//xóa sinh viên theo mã
		public void Delete(int masv)
		{
			
			List<SinhVien> list = GetAllData();
			StreamWriter fw = File.CreateText(filetxt);
			int i = 0;
			foreach(SinhVien sv in list)
				if(sv.MaSV != masv)
				{
					fw.WriteLine(i++ + "#" + sv.MaSV + "#" + sv.TenSV + "#" + "{0:d}",(sv.NamsinhSV) + "#" + sv.Gioitinh + "#" + sv.Diachi + "#" + sv.Sdt + "#" + sv.Email);
				}
			fw.Close();
		}
		//Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
		public void GhiLaiDanhsach(List<SinhVien> List)
		{
			StreamWriter fw = new StreamWriter(filetxt, false);
			int i = 1;
			foreach (SinhVien sv in List)
			{
				fw.WriteLine(i++ + "#" + sv.MaSV + "#" + sv.TenSV + "#" + "{0:d}", (sv.NamsinhSV) + "#" + sv.Gioitinh + "#" + sv.Diachi + "#" + sv.Sdt + "#" + sv.Email);
				
			}
			fw.Close();
		}
		public void Edit(int id, SinhVien newInfo)
		{
			//Đọc toàn bộ tập lớn về
			List<SinhVien> sv = GetAllData();
			//Sửa trên DS và ghi đè vào tệp
			for(int i=0;i<sv.Count;i++)
			{
				if(sv[i].MaSV==id)
				{
					sv[i] = newInfo;
					break;
				}
			}
			GhiLaiDanhsach(sv);
		}
	}
}
