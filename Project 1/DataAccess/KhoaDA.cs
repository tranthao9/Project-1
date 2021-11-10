using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Project_1.DataAccess.Interface;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
	class KhoaDA : IKhoaDA
	{
		private string ftxt = "Data/Khoa.txt";
		//lay toan bo du lieu trong file Khoa.txt dua vao mot danh sach
		public List<Khoa> GetAllData()
		{
			List<Khoa> list = new List<Khoa>();
			StreamReader fr = File.OpenText(ftxt);
			string s = fr.ReadLine();
			while (s != null)
			{
				if (s != null)
				{
					s = Project_1.Utility.Congcu.CatXau(s);
					string[] a = s.Split('#');
					list.Add(new Khoa(int.Parse(a[1]), a[2],int.Parse( a[3]), a[4],a[5]));
				}
				s = fr.ReadLine();
			}
			fr.Close();
			return list;
		}
		// lay ma khoa cua ban ghi cuoi cung de danh ma tu dong
		public int STTkhoa()
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
		//Chèn một bản ghi khoa vào tệp
		public void Insert(Khoa k)
		{
			int sttk = STTkhoa() + 1;
			StreamWriter fwrite = File.AppendText(ftxt);
			fwrite.WriteLine(sttk + "#" + k.Makhoa + "#" + k.Tenkhoa + "#" + k.Matruongkhoa + "#" + k.Mota + "#" + k.Trangthai );
			fwrite.Close();
		}
		//xoa  khoa theo ma
		public void Delete(int mak)
		{
			List<Khoa> list = GetAllData();
			StreamWriter fw = File.CreateText(ftxt);
			foreach (Khoa n in list)
				if (n.Makhoa != mak)
				{
					int sttk = STTkhoa() + 1;
					fw.Write(sttk + "#" + n.Makhoa + "#" + n.Tenkhoa + "#" + n.Matruongkhoa + "#" + n.Mota + "#" + n.Trangthai );
				}
			fw.Close();
		}
		//Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
		public void GhiLaiDanhsach(List<Khoa> List)
		{
			StreamWriter fw = new StreamWriter(ftxt, false);
			foreach (Khoa n in List)
			{
				int sttk = STTkhoa() + 1;
				fw.Write(sttk + "#" + n.Makhoa + "#" + n.Tenkhoa + "#" + n.Matruongkhoa + "#" + n.Mota + "#" + n.Trangthai);

			}
			fw.Close();
		}
		public void Edit(int id, Khoa newInfo)
		{
			//Đọc toàn bộ tập lớn về
			List<Khoa> cn = GetAllData();
			//Sửa trên DS và ghi đè vào tệp
			for (int i = 0; i < cn.Count; i++)
			{
				if (cn[i].Makhoa == id)
				{
					cn[i] = new Khoa(newInfo);
				}
			}
			GhiLaiDanhsach(cn);
		}
	}
}
