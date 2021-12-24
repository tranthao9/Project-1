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
			int k = 0;
			bool kt;
			mn.GiaoDien();
			{
				while (true)
				{
					k++;
					kt = mn.Dangnhap();
					if (kt == true || k == 3)
						break;
				}
				if(kt==false)
				{
					Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition(75, 9); Console.WriteLine("ĐĂNG NHẬP THẤT BẠI ");
					Console.ReadKey();
					return;
				}
				while(true)
				{
					mn.MenuQL();
					int c = int.Parse(Console.ReadLine());
					switch (c)
					{
						case 1:

							FormSinhVien a = new FormSinhVien();
							a.Menu();
							break;
						case 2:
							Console.Clear();
							FormGiangVien b = new FormGiangVien();
							b.Menu();
							break;
						case 3:
							Console.Clear();
							FormLopHoc d = new FormLopHoc();
							d.Menu();
							break;
						case 4:
							Console.Clear();
							FormChuyenNganh e = new FormChuyenNganh();
							e.Menu();
							break;
						case 5:
							Console.Clear();
							FormNganh f = new FormNganh();
							f.Menu();
							break;
						case 6:
							Console.Clear();
							FormKhoa g = new FormKhoa();
							g.Menu();
							break;
						case 7:
							Console.Clear();
							FormLopSinhVien h = new FormLopSinhVien();
							h.Menu();
							break;
						case 8:
							Console.Clear();
							FormDoAn j = new FormDoAn();
							j.Menu();
							break;
						case 9:
							Console.Clear();
							Formdetai p = new Formdetai();
							p.Menu();
							break;
						case 10:
							Console.Clear();
							FormTuanDeTai l = new FormTuanDeTai();
							l.Menu();
							break;
						case 11:
							Console.Clear();
							FormSVdetai m = new FormSVdetai();
							m.Menu();
							break;
						case 12:
							Console.Clear();
							FormThongKe v = new FormThongKe();
							v.Menu();
							break;
						case 0:
							return;
						default:
							Console.WriteLine("Nhập sai cú pháp");
							break;
					}
				}
			}
		}
	}
}
