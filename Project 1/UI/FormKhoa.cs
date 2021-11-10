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
	public class FormKhoa
	{
		private IKhoaBusiness A = new KhoaBusiness();
		public void Max(List<Khoa> list, out int maxmt, out int maxt,out int ten)
		{
			if (list.Count == 0)
			{
				maxmt = 10;
				maxt = 10;
				ten = 10;
			}
			else
			{
				maxmt = list[0].Mota.Length;
				maxt = list[0].Tenkhoa.Length;
				ten = list[0].Giangvien.TenGV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxt < list[i].Tenkhoa.Length)
						maxt = list[i].Tenkhoa.Length;
					if (ten < list[i].Giangvien.TenGV.Length)
						ten = list[i].Giangvien.TenGV.Length;
				}
			}
		}
		public int Hien(List<Khoa> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int maxmt;
			int maxt,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			Max(list, out maxmt, out maxt,out ten);
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ KHOA");
			Console.SetCursorPosition(x + 16, y); Console.Write("TÊN KHOA");
			Console.SetCursorPosition(x + 25 +maxt, y); Console.Write("TÊN TRƯỞNG KHOA");
			Console.SetCursorPosition(x + 35 + maxt+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x +40 + maxt +ten+ maxmt, y); Console.Write("TRẠNG THÁI");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Makhoa);
				Console.SetCursorPosition(x + 16, y); Console.Write(list[i].Tenkhoa);
				Console.SetCursorPosition(x + 25 + maxt, y); Console.Write(list[i].Giangvien.TenGV);
				 Console.SetCursorPosition(x + 35 +ten+maxt, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 40 +ten+ maxt + maxmt, y); Console.Write(list[i].Trangthai);
				if ((d+1) == n) break;
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
				IKhoaBusiness BL = new KhoaBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN KHOA---------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã khoa:                       Tên khoa:                                       Mã trưởng khoa : ");
				Console.WriteLine();
				Console.WriteLine("Mô tả :");
				Console.WriteLine();
				Console.WriteLine("Trạng thái:");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				Khoa s = new Khoa();
				s.Makhoa = Project_1.Utility.Congcu.Ma(10, 5, 0, 13, s.Makhoa, 3, "Nhập sai dữ liệu mã khoa gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
				s.Tenkhoa = Project_1.Utility.Congcu.Ten(42, 5, 0, 13, s.Tenkhoa, "Nhập sai dữ liệu, tên khoa phải khác rỗng vui lòng nhập lại dữ liệu !");
				while(true)
				{
					s.Matruongkhoa = Project_1.Utility.Congcu.Ma(95, 5, 0, 13, s.Matruongkhoa, 8, "Nhập sai dữ liệu mã trưởng khoa gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistKTGV(s.Matruongkhoa))
						break;
					else
					{
						Console.SetCursorPosition(0,13);Console.Write("Mã trưởng khoa này không tồn tại ! vui lòng nhập lại đúng với mã giảng viên !!!");
						Console.SetCursorPosition(95, 5); Console.Write("                                 ");
					}
				}	
				s.Mota = Project_1.Utility.Congcu.Ten(8, 7, 0, 13, s.Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Trangthai = Project_1.Utility.Congcu.Ten(15, 9, 0, 13, s.Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
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
	}
}
