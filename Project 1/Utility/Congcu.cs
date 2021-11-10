using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project_1.Utility
{
	public static class Congcu
	{
		public static string Chuanhoaxau(string xau)
		{
			string s = xau.Trim();
			while (s.IndexOf("  ") >= 0)
				s = s.Remove(s.IndexOf("  "), 1);
			string[] a = s.Split(' ');
			s = "";
			for (int i = 0; i < a.Length; i++)
				s = s + " " + char.ToUpper(a[i][0]) + a[i].Substring(1).ToLower();
			return s.Trim();
		}

		public static string CatXau(string xau)
		{
			string s = xau.Trim();
			while (s.IndexOf("  ") >= 0) s = s.Remove(s.IndexOf("  "), 1);
			return s;
		}
		public static string ChuanHoaXau(string xau, int max)
		{
			string s = CatXau(xau);
			while (s.Length < max) s = s + " ";
			return s;
		}
		public static string getname(string hoten)
		{
			string[] mt = hoten.Split(' ');
			return mt[mt.Length - 1];
		}
		public static string firstname(string hoten)
		{
			string s = hoten.Substring(0, hoten.LastIndexOf(' '));
			return s;
		}
		public static int Ma(int x, int y, int i, int j, int s,int ma,string m)
		{
			while (true)
			{
				Console.SetCursorPosition(x, y); s = int.Parse(Console.ReadLine());
				if (s != 0 && s.ToString().Length == ma)
					break;
				else
				{
					Console.SetCursorPosition(i, j); Console.WriteLine(m);

				}
				Console.SetCursorPosition(x, y); Console.WriteLine("                   ");

			}
			return s;
		}
		public static string Ten(int x, int y, int i, int j, string s,string note)
		{
			while (true)
			{
				Console.InputEncoding = Encoding.Unicode;
				Console.SetCursorPosition(x, y); s = Console.ReadLine();
				if (s != "")
				{
					break;
				}

				else
					Console.SetCursorPosition(i, j); Console.WriteLine(note);
				Console.SetCursorPosition(x, y); Console.WriteLine("                   ");
			}
			return s;
		}
		public static DateTime Namsinh(int x, int y, int i, int j, DateTime s)
		{
			while (true)
			{
				DateTime format;
				Console.SetCursorPosition(x, y); string a = Console.ReadLine();
				if ((bool)DateTime.TryParse(a, out format) == true)
				{
					s = DateTime.Parse(a);
					break;
				}
				else
				{
					Console.SetCursorPosition(i, j); Console.WriteLine("Định dạng ngày tháng sai vui lòng nhập yyyy/mm/dd !");
					Console.SetCursorPosition(x, y); Console.WriteLine("                   ");
				}

			}
			return s;
		}
		public static string Gioitinh(int x, int y, int i, int j, string s)
		{
			while (true)
			{

				Console.SetCursorPosition(x, y);
				s = Console.ReadLine().Trim().ToLower();
				if (s.Replace(s[1], 'u') == "nu")
				{
					s = "nữ";
					break;
				}
				else if (s == "nam")
					break;
				else
				{
					Console.SetCursorPosition(i, j); Console.WriteLine("Nhập sai dữ liệu chỉ là 'Nam' or 'Nữ' vui lòng nhập lại ! ");
					Console.SetCursorPosition(x, y); Console.WriteLine("                   ");
				}

			}
			return s;
		}
		static bool examkt(string a)
		{
			int dem = 0;
			int d = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] == '@')
					dem++;
				if (a[i] == '.')
					d++;
			}
			if (dem == 1 && d==1)
				return true;
			return false;
		}
		public static string Email(int x, int y, int i, int j, string em)
		{
			int d = 0;
			while(true)
			{

				string a, b, c;
				Console.SetCursorPosition(x, y); em = Console.ReadLine();
				int vt1 = em.IndexOf("@");
				int vt2 = em.IndexOf(".");
				if (vt1 > 0 && vt2 > 0 && vt1 < vt2)
				{
					a = em.Substring(0, vt1);
					b = em.Substring(vt1, vt2 - vt1);
					c = em.Substring(vt2 + 1);
					if (a == "" || b == "" || c == "")
					{
						Console.SetCursorPosition(i, j); Console.WriteLine("Nhập email sai định dạng vui lòng nhập lại !");
						Console.SetCursorPosition(x, y); Console.WriteLine("                             ");
					}

					else
					{
						if (!examkt(em))
						{
							Console.SetCursorPosition(i, j); Console.WriteLine("Nhập email sai định dạng vui lòng nhập lại !");
							Console.SetCursorPosition(x, y); Console.WriteLine("                              ");
						}
						else 
							d++;
					}
				}
				else
				{
					Console.SetCursorPosition(i, j); Console.WriteLine("Nhập email sai định dạng vui lòng nhập lại !");
					Console.SetCursorPosition(x, y); Console.WriteLine("                                ");
				}
				if (d != 0)
					break;
			}
			return em;
		}
		public static bool Exam(string un, string pw)
		{
			if (un == "CTDLvGT" && pw == "Cuahang")
				return true;
			else
				return false;
		}
		//public void SapXepTheoTen()
		//{
		//	List<SinhVien> list = GetAllData();
		//	for (int i = 0; i < list.Count - 1; i++)
		//	{
		//		for (int j = i + 1; j < list.Count; j++)
		//		{
		//			if (Project_1.Utility.Congcu.getname(list[i].TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.getname(list[j].TenSV.ToLower())) > 0)
		//			{
		//				SinhVien tg = list[i];
		//				list[i] = list[j];
		//				list[j] = tg;
		//			}
		//			else if (Project_1.Utility.Congcu.getname(list[i].TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.getname(list[j].TenSV.ToLower())) == 0)
		//			{
		//				if (Project_1.Utility.Congcu.firstname(list[i].TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.firstname(list[j].TenSV.ToLower())) > 0)
		//				{
		//					SinhVien tg = list[i];
		//					list[i] = list[j];
		//					list[j] = tg;
		//				}
		//			}
		//		}
		//	}

		//}
	}
}
