
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;
using Project_1.Business_Layer;
using Project_1.Business_Layer.Interface;
using System.Globalization;

namespace Project_1.UI
{
	public class FormLopSinhVien
	{
		private ILopSinhVienBusiness A = new LopSinhVienBusiness();
		public void Max(List<LopSinhVien> list, out int maxht)
		{
			if (list.Count == 0)
			{
				maxht = 10;
			}
			else
			{
				maxht = list[0].Sinhvien.TenSV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxht < list[i].Sinhvien.TenSV.Length)
						maxht = list[i].Sinhvien.TenSV.Length;
				}
			}
		}
		public int Hien(List<LopSinhVien> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int max;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Max(list, out max);
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ SINH VIÊN");
			Console.SetCursorPosition(x + 25, y); Console.Write("MÃ LỚP");
			Console.SetCursorPosition(x + 40, y); Console.Write("TÊN SINH VIÊN");
			Console.SetCursorPosition(x + 45+max, y); Console.Write("NĂM HỌC");
			Console.SetCursorPosition(x + 60+max, y); Console.Write("HỌC KỲ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].MaSV);
				Console.SetCursorPosition(x + 25, y); Console.Write(list[i].Malop);
				Console.SetCursorPosition(x + 40, y); Console.Write(list[i].Sinhvien.TenSV);
				Console.SetCursorPosition(x + 45+max, y); Console.Write(list[i].Namhoc);
				Console.SetCursorPosition(x + 60+max, y); Console.Write(list[i].Hocky);
				if ((d) == n+1) break;
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.Write(tieudecuoi);
			return Console.CursorTop;
		}
		public void Nhap()
		{
			Console.OutputEncoding = Encoding.Unicode;
			Console.InputEncoding = Encoding.Unicode;
			do
			{
				ILopSinhVienBusiness BL = new LopSinhVienBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN LỚP SINH VIÊN--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã lớp:                                Mã sinh viên: ");
				Console.WriteLine();
				Console.WriteLine("Năm Học :                              Học kỳ : ");
				int x = 0, y = 11;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				LopSinhVien s = new LopSinhVien();
				while(true)
				{
					s.Malop = Project_1.Utility.Congcu.Ma(12, 5, 0, 9, s.Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
					if (BL.ExistL(s.Malop))
						break;
					else
					{
						Console.SetCursorPosition(0, 9);Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
						Console.SetCursorPosition(12, 5);Console.Write("                    ");
					}	
				}	
				while(true)
				{
					s.MaSV = Project_1.Utility.Congcu.Ma(55, 5, 0, 9, s.MaSV, 8, "Định dạng sai, Mã lớp phải gốm 8 chữ số !");
					if (BL.ExistSV(s.MaSV))
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.Write("Mã sinh viên không tồn tại ! vui lòng nhập lại !!! ");
						Console.SetCursorPosition(55, 5); Console.Write("                    ");
					}	
					
				}
				s.Namhoc = Project_1.Utility.Congcu.Ma(12, 7, 0, 9, s.Namhoc, 4, "Định dạng sai, năm học phải lớn 0 và gồm 4 chữ số !");
				while (true)
				{
					Console.SetCursorPosition(50,7); s.Hocky = int.Parse(Console.ReadLine());
					if (s.Hocky>0)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

					}
					Console.SetCursorPosition(50, 7); Console.WriteLine("                   ");

				}
				Console.SetCursorPosition(80, v);
				ConsoleKeyInfo kt = Console.ReadKey();
				if (kt.Key == ConsoleKey.Escape)
				{
					BL.Insert(s);
					break;
				}
				else if (kt.Key == ConsoleKey.Enter)
				{
					BL.Insert(s);
					
				}
				else
					break;
			} while (true);
		}
		public void Xoa()
		{
			do
			{
				Console.Clear();
				ILopSinhVienBusiness Bl = new LopSinhVienBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH LỚP SINH VIÊN ", "Nhập tuần cần xóa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã lớp muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã sinh viên muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1==0) return;
				else Bl.Delete(ma,ma1);
			} while (true);
		}
		public void Tim()
		{
			int lop = 0;
			do
			{
				Console.Clear();
				ILopSinhVienBusiness BL = new LopSinhVienBusiness();
				List<LopSinhVien> list = BL.Tim(new LopSinhVien(lop,0,0,0));
				Hien(list, 0, 0, "                 DANH SÁCH TUẦN ĐỀ TÀI                      ", "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				lop = int.Parse(Console.ReadLine());
				if (lop == 0) return;
			} while (true);
		}
		//public void Menu()
		//{
		//	ILopSinhVienBusiness BL = new LopSinhVienBusiness();
		//	Console.Clear();
		//	int check = 0;
		//	while (check == 0)
		//	{
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine();
		//		Console.WriteLine();
		//		Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                      ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.Write("                                 ▐  QUẢN LÝ SINH VIÊN  ▌                                                      ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                      ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin sinh viên      ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin sinh viên  ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm sinh viên            ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin sinh viên       ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin sinh viên       ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     0.Exit                          ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

		//		Console.Write("Mời bạn chọn chức năng: ");
		//		int mode = int.Parse(Console.ReadLine());
		//		switch (mode)
		//		{
		//			case 1:
		//				Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
		//				Nhap(); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 2:
		//				Hien(BL.GetAllData(), 0, 11, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 3:
		//				Console.Clear();
		//				Hien(BL.GetAllData(), 0, 11, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); 
		//				Console.Write("Nhập Mã PB cần tìm kiếm: ");
		//				string id1 = Console.ReadLine();
		//				Find(id1); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;

		//			case 4:
		//				Console.Clear();
		//				Hien(BL.GetAllData(), 0, 11, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục");
		//				Console.WriteLine("Sửa thông tin phòng ban");
		//				Console.Write("Nhập Mã PB cần sửa: ");
		//				string id2 = Console.ReadLine();
		//				Update(id2); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 5:
		//				Console.Clear();
		//				Hien(BL.GetAllData(), 0, 11, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục");
		//				Console.Write("Nhập Mã PB cần xóa: ");
		//				string id3 = Console.ReadLine();
		//				Delete(id3); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 0:
		//				check = 1;
		//				break;
		//			default:
		//				Console.WriteLine("Sai cú pháp!");
		//				break;
		//		}

		//	}
		//}
	}
}
