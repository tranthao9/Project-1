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
			//FormKhoa a = new FormKhoa();
			//FormSinhVien a = new FormSinhVien();
			//FormGiangVien a = new FormGiangVien();
			//a.Menu();
			//FormChuyenNganh a = new FormChuyenNganh();
			//Formdetai a = new Formdetai();
			//FormTuanDeTai a = new FormTuanDeTai();
			FormSVdetai a = new FormSVdetai();
			//FormLopHoc a = new FormLopHoc();
			//FormNganh a = new FormNganh();
			//FormLopSinhVien a = new FormLopSinhVien();
			//FormDoAn a = new FormDoAn();
			a.Nhap();
			

			//FormMenu a = new FormMenu();
			//a.GiaoDien();
			//do
			//{
			//	for(int i=0;i<50;i++)
			//	{
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Black; Console.WriteLine("7rần 7hị 7hả0❤---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(5);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(10);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(15);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(20);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(25);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(35);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(40);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("ℱαt✘ƴαทջɦℴ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(45);
			//		Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("αtƴαջ︵---------TRẦN THỊ THẢO---«-(¯`v´¯)-« TẠO TÊN ĐẸP »-(¯`v´¯)-»-----------------------"); Thread.Sleep(50);

			//	}

			//	ConsoleKeyInfo kt = Console.ReadKey();
			//	if (kt.Key == ConsoleKey.Escape)
			//	{
			//		break;
			//	}


			//} while (true);

			//Console.WriteLine("♥◦•●●•◦   ");
			Console.ReadKey();

		}
	}
}
