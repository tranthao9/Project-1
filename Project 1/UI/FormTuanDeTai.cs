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
	public class FormTuanDeTai
	{
		private ITuanDetaiBusiness A = new TuanDetaiBusiness();
		public int Hien(List<TuanDetai> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ ĐỀ TÀI");
			Console.SetCursorPosition(x + 20, y); Console.Write("TUẦN");
			Console.SetCursorPosition(x + 30, y); Console.Write("ĐÁNH GIÁ");
			Console.SetCursorPosition(x + 50 , y); Console.Write("ĐIỂM ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Madettai);
				Console.SetCursorPosition(x + 20, y); Console.Write(list[i].Matuan);
				Console.SetCursorPosition(x + 30, y); Console.Write(list[i].Danhgia);
				Console.SetCursorPosition(x + 50, y); Console.Write(list[i].Diem);
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
				ITuanDetaiBusiness BL = new TuanDetaiBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN TUẦN ĐỀ TÀI--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã đề tài:                       Tuần:                             ");
				Console.WriteLine();
				Console.WriteLine("Đánh giá:                       Điểm :  ");
				int x = 0, y = 11;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				TuanDetai s = new TuanDetai();
				while (true)
				{
					Console.SetCursorPosition(12, 5); s.Madettai = int.Parse(Console.ReadLine());
					if (!(BL.ExistKT(s.Madettai)) && s.Madettai > 0)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Sai định dạng, mã đề tài phải lớn hơn 0! hoặc mã đề tài đã có điền đầy đủ các tuần !");

					}
					Console.SetCursorPosition(12, 5); Console.WriteLine("                   ");

				}
				while (true)
				{
					Console.SetCursorPosition(40, 5); s.Matuan = int.Parse(Console.ReadLine());
					if (!(BL.Exist(s.Matuan, s.Madettai))&&s.Matuan >= 1 && s.Matuan <=15 )
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Định dạng tuần sai, tuần nằm trong khoảng từ 1 đến 15 hoặc tuần đã tồn tại !");

					}
					Console.SetCursorPosition(40,5); Console.WriteLine("                   ");

				}
				while (true)
				{
					Console.OutputEncoding = Encoding.UTF8;
					Console.InputEncoding = Encoding.Unicode;
					Console.SetCursorPosition(10,7); s.Danhgia = (Console.ReadLine().ToLower());
					if (s.Danhgia == "đạt" ||s.Danhgia == "không đạt")
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Đánh giá chỉ đạt hoặc không đạt !");

					}
					Console.SetCursorPosition(10,7); Console.WriteLine("                   ");

				}
				while (true)
				{
					Console.SetCursorPosition(42, 7); s.Diem = double.Parse(Console.ReadLine());
					if (s.Diem >= .0 &&s.Diem <= 10.0)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Điểm 1 sai! điểm chỉ nằm trong khoảng từ 0-10");

					}
					Console.SetCursorPosition(42, 7); Console.WriteLine("                   ");

				}
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
				ITuanDetaiBusiness Bl = new TuanDetaiBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH TUẦN ĐỀ TÀI ", "Nhập tuần cần xóa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã đề tài muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã tuần muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1==0) return;
				else Bl.Delete(ma,ma1);
			} while (true);
		}
		public void Tim()
		{
			int detai=0;
			do
			{
				Console.Clear();
				ITuanDetaiBusiness BL = new TuanDetaiBusiness();
				List<TuanDetai> list = BL.Tim(new TuanDetai(0,detai,null,0));
				Hien(list, 0, 0, "                 DANH SÁCH TUẦN ĐỀ TÀI                      ", "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}

	}
}
