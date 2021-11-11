using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Project_1.Utility;
using Project_1.UI;
using Project_1.Entities;


namespace Project_1
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.OutputEncoding = Encoding.UTF8;
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			Console.SetCursorPosition(Console.CursorTop, Console.CursorLeft);
			Console.SetWindowPosition(Console.CursorLeft, Console.CursorTop);
			FormMenu mn = new FormMenu();
			mn.GiaoDien();
			{
				mn.Dangnhap();
				mn.MenuQL();
				int c = int.Parse(Console.ReadLine());
				switch(c)
				{
					case 1:
						FormSinhVien a = new FormSinhVien();
						a.Menu();
						break;
					case 2:
						FormGiangVien b= new FormGiangVien();
						b.Menu();
						break;
					case 3:
						FormLopHoc d = new FormLopHoc();
						d.Menu();
						break;
					case 4:
						FormChuyenNganh e = new FormChuyenNganh();
						e.Menu();
						break;
					case 5:
						FormNganh f = new FormNganh();
						f.Menu();
						break;
					case 6:
						FormKhoa g = new FormKhoa();
						g.Menu();
						break;
					case 7:
						FormLopSinhVien h = new FormLopSinhVien();
						h.Menu();
						break;
					case 8:
						FormDoAn j = new FormDoAn();
						j.Menu();
						break;
					case 9:
						Formdetai k = new Formdetai();
						k.Menu();
						break;
					case 10:
						FormTuanDeTai l = new FormTuanDeTai();
						l.Menu();
						break;
					case 11:
						FormSVdetai m = new FormSVdetai();
						m.Menu();
						break;
					case 12:
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Nhập sai cú pháp");
						return;
				}
			}
			Console.ReadKey();

		}
	}
}
