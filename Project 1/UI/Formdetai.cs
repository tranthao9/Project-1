
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
	public class Formdetai
	{
		private IDetaiBusiness A = new DetaiBusiness();
		public void Max(List<Detai> list, out int maxht)
		{
			if (list.Count == 0)
			{
				maxht = 10;
			}
			else
			{
				maxht = list[0].Tendetai.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxht < list[i].Tendetai.Length)
						maxht = list[i].Tendetai.Length;
				}
			}
		}
		public int Hien(List<Detai> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int max;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Max(list,out max);
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ ĐỒ ÁN");
			Console.SetCursorPosition(x + 20, y); Console.Write("MÃ ĐỀ TÀI");
			Console.SetCursorPosition(x + 35, y); Console.Write("TÊN ĐỀ TÀI");
			Console.SetCursorPosition(x + 50+max, y); Console.Write("MÔ TẢ");
			int d = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Mada);
				Console.SetCursorPosition(x + 20, y); Console.Write(list[i].Madetai);
				Console.SetCursorPosition(x + 35, y); Console.Write(list[i].Tendetai);
				Console.SetCursorPosition(x + 50+max, y); Console.Write(list[i].Mota);
				if ((d) == n) break;
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
				IDetaiBusiness BL = new DetaiBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN ĐỀ TÀI--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã đồ án:                                 Mã đề tài:                             ");
				Console.WriteLine();
				Console.WriteLine("Tên đề tài:");
				Console.WriteLine();
				Console.WriteLine("Mô tả : ");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				Detai s = new Detai();
				while (true)
				{
					Console.SetCursorPosition(12, 5); s.Mada = int.Parse(Console.ReadLine());
					if (s.Mada > 0 )
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã đồ án phải lớn hơn 0! ");

					}
					Console.SetCursorPosition(12, 5); Console.WriteLine("                   ");

				}
				while (true)
				{
					Console.SetCursorPosition(54, 5); s.Madetai = int.Parse(Console.ReadLine());
					if (s.Madetai >= 1 && !BL.Exist(s.Madetai))
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Định dạng mã đề tài sai, Mã đề tài phải lớn hơn 0 hoặc mã đề tài đã tồn tại!");

					}
					Console.SetCursorPosition(54, 5); Console.WriteLine("                   ");

				}
				s.Tendetai = Project_1.Utility.Congcu.Ten(12, 7, 0, 11, s.Tendetai, "Tên đề tài không được khác rỗng");
				
				s.Mota = Project_1.Utility.Congcu.Ten(10, 9, 0, 11, s.Mota, "Mô tả không được khác rỗng");
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
				IDetaiBusiness Bl = new DetaiBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH ĐỀ TÀI ", "Nhập tuần cần xóa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã đề tài muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0 ) return;
				else Bl.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			int detai = 0;
			do
			{
				Console.Clear();
				IDetaiBusiness BL = new DetaiBusiness();
				List<Detai> list = BL.Tim(new Detai(detai,null,null,0));
				Hien(list, 0, 0, "                 DANH SÁCH TUẦN ĐỀ TÀI                      ", "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}

	}
}
