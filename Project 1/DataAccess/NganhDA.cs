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
	class NganhDA : INganhDA
	{
		private string ftxt = "Data/Nganh.txt";
		//lay toan bo du lieu trong file ChuyenNganh.txt dua vao mot danh sach
		public List<Nganh> GetAllData()
		{
			List<Nganh> list = new List<Nganh>();
			StreamReader fr = File.OpenText(ftxt);
			string s = fr.ReadLine();
			while (s != null)
			{
				if (s != null)
				{
					s = Project_1.Utility.Congcu.CatXau(s);
					string[] a = s.Split('#');
					list.Add(new Nganh(int.Parse(a[1]), a[2],int.Parse( a[3]), a[4],a[5], int.Parse(a[6])));
				}
				s = fr.ReadLine();
			}
			fr.Close();
			return list;
		}
		// lay ma chuyen nganh cua ban ghi cuoi cung de danh ma tu dong
		public int STTNganh()
		{
			StreamReader fr = File.OpenText(ftxt);
			string s = fr.ReadLine();
			string tmp = "";
			while (s != null)
			{
				if (s != "") tmp = s;
				s = fr.ReadLine();
			}
			fr.Close();
			if (tmp == "") return 0;
			else
			{
				tmp = Project_1.Utility.Congcu.Chuanhoaxau(tmp);
				string[] a = tmp.Split('#');
				return int.Parse(a[0]);
			}
		}
		//Chèn một bản ghi nganh vào tệp
		public void Insert(Nganh n)
		{
			int sttcn = STTNganh() + 1;
			StreamWriter fwrite = File.AppendText(ftxt);
			fwrite.WriteLine(sttcn + "#" + n.Manganh + "#" + n.Tennganh + "#" + n.Matruongnganh + "#" + n.Mota + "#" + n.Trangthai + "#" + n.Makhoa);
			fwrite.Close();
		}
		//xoa  nganh theo ma
		public void Delete(int mach)
		{
			List<Nganh> list = GetAllData();
			StreamWriter fw = File.CreateText(ftxt);
			foreach (Nganh n in list)
				if (n.Manganh != mach)
				{
					int sttn = STTNganh() + 1;
					fw.WriteLine(sttn + "#" + n.Manganh + "#" + n.Tennganh + "#" + n.Matruongnganh + "#" + n.Mota + "#" + n.Trangthai+ "#" + n.Makhoa);
				}
			fw.Close();
		}
		//Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
		public void GhiLaiDanhsach(List<Nganh> List)
		{
			StreamWriter fw = new StreamWriter(ftxt, false);
			int i = 0;
			foreach (Nganh n in List)
			{
				fw.WriteLine(i++ + "#" + n.Manganh + "#" + n.Tennganh + "#" + n.Matruongnganh + "#" + n.Mota + "#" + n.Trangthai + "#" + n.Makhoa);

			}
			fw.Close();
		}
		public void Edit(int id, Nganh newInfo)
		{
			//Đọc toàn bộ tập lớn về
			List<Nganh> cn = GetAllData();
			//Sửa trên DS và ghi đè vào tệp
			for (int i = 0; i < cn.Count; i++)
			{
				if (cn[i].Manganh == id)
				{
					cn[i] = new Nganh(newInfo);
				}
			}
			GhiLaiDanhsach(cn);
		}

	}
}
