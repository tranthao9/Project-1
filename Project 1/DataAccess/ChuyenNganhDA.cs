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
	class ChuyenNganhDA: IChuyenNganhDA
	{
		private string ftxt = "Data/ChuyenNganh.txt";
		//lay toan bo du lieu trong file ChuyenNganh.txt dua vao mot danh sach
		public List<ChuyenNganh> GetAllData()
		{
			List<ChuyenNganh> list = new List<ChuyenNganh>();
			StreamReader fr = File.OpenText(ftxt);
			string s = fr.ReadLine();
			while(s!=null)
			{
				if(s!=null)
				{
					s = Project_1.Utility.Congcu.CatXau(s);
					string[] a= s.Split('#');
					list.Add(new ChuyenNganh(int.Parse(a[1]), a[2],int.Parse(a[3]), a[4],a[5], int.Parse(a[6])));
				}
				s = fr.ReadLine();
			}
			fr.Close();
			return list;
		}
		// lay ma chuyen nganh cua ban ghi cuoi cung de danh ma tu dong
		public int STTchuyennganh()
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
		//Chèn một bản ghi Chuyennganh vào tệp
		public void Insert(ChuyenNganh cn)
		{
			int sttcn = STTchuyennganh() + 1;
			StreamWriter fwrite = File.AppendText(ftxt);
			fwrite.WriteLine(sttcn + "#" + cn.Machnganh + "#" + cn.Tenchnganh + "#" + cn.Maphutrach + "#" +cn.Mota+"#"+cn.Trangthai+"#"+cn.Manganh);
			fwrite.Close();
		}
		//xoa chuyen nganh theo ma
		public void Delete(int mach)
		{
			List < ChuyenNganh > list = GetAllData();
			StreamWriter fw = File.CreateText(ftxt);
			int i = 1;
			foreach (ChuyenNganh cn in list)
				if (cn.Machnganh != mach)
				{
					fw.WriteLine(i++ + "#" + cn.Machnganh + "#" + cn.Tenchnganh + "#" + cn.Maphutrach + "#" + cn.Mota + "#" + cn.Trangthai + "#" + cn.Manganh);
				}
			fw.Close();
		}
		//Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
		public void GhiLaiDanhsach(List<ChuyenNganh> List)
		{
			StreamWriter fw = new StreamWriter(ftxt, false);
			int t = 1;
			foreach (ChuyenNganh cn in List)
			{
				fw.WriteLine(t++ + "#" + cn.Machnganh + "#" + cn.Tenchnganh + "#" + cn.Maphutrach + "#" + cn.Mota + "#" + cn.Trangthai + "#" + cn.Manganh);

			}
			fw.Close();
		}
		public void Edit(int id, ChuyenNganh newInfo)
		{
			//Đọc toàn bộ tập lớn về
			List<ChuyenNganh> cn = GetAllData();
			//Sửa trên DS và ghi đè vào tệp
			for (int i = 0; i < cn.Count; i++)
			{
				if (cn[i].Machnganh == id)
				{
					cn[i] = newInfo;
					
					break;
				}
			}
			GhiLaiDanhsach(cn);
		}
	}
}
