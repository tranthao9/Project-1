
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
	public class FormDoAn
	{
		private IDoAnBusiness A = new DoAnBusiness();
		public int Hien(List<DoAn> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ ĐỒ ÁN");
			Console.SetCursorPosition(x + 20, y); Console.Write("TÊN ĐỒ ÁN");
			Console.SetCursorPosition(x + 35, y); Console.Write("SỐ TC");
			Console.SetCursorPosition(x + 50, y); Console.Write("MÔ TẢ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Mada);
				Console.SetCursorPosition(x + 20, y); Console.Write(list[i].Tenda);
				Console.SetCursorPosition(x + 35, y); Console.Write(list[i].Sotc);
				Console.SetCursorPosition(x + 50, y); Console.Write(list[i].Mota);
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
				IDoAnBusiness BL = new DoAnBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN ĐỒ ÁN--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã đồ án:                       Tên đồ án:                             ");
				Console.WriteLine();
				Console.WriteLine("Số TC                            Mô tả :");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				DoAn s = new DoAn();
				while (true)
				{
					Console.SetCursorPosition(12, 5); s.Mada = int.Parse(Console.ReadLine());
					if (s.Mada > 0)
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã đồ án phải lớn hơn 0!");

					}
					Console.SetCursorPosition(12, 5); Console.WriteLine("                   ");

				}
				s.Tenda = Project_1.Utility.Congcu.Ten(44, 5, 0, 9, s.Tenda, "Tên đề tài không được khác rỗng");
				while (true)
				{
					Console.SetCursorPosition(8,7); s.Sotc = int.Parse(Console.ReadLine());
					if (s.Sotc >= 1)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Số tín chỉ phải lớn hơn 0!");

					}
					Console.SetCursorPosition(8,7); Console.WriteLine("                   ");
				}
				s.Mota = Project_1.Utility.Congcu.Ten(44,7, 0, 9, s.Mota, "Mô tả không được khác rỗng");
				Console.SetCursorPosition(80, v);
				ConsoleKeyInfo kt = Console.ReadKey();
				if (kt.Key == ConsoleKey.Escape)
				{
					BL.Insert(s);
					break;
				}
				else if (kt.Key == ConsoleKey.Enter)
					BL.Insert(s);
				else
					break;
			} while (true);
		}
		public void Xoa()
		{
			do
			{
				Console.Clear();
				IDoAnBusiness Bl = new DoAnBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH ĐỒ ÁN ", "Nhập tuần cần xóa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã đồ án muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else Bl.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			int detai = 0;
			do
			{
				Console.Clear();
				IDoAnBusiness BL = new DoAnBusiness();
				List<DoAn> list = BL.Tim(new DoAn(detai, null,0, null));
				Hien(list, 0, 0, "                 DANH SÁCH ĐỒ ÁN                      ", "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}

	}
}
