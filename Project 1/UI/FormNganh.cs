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
	public class FormNganh
	{
		private INganhBusiness A = new NganhBusiness();
		public void Max(List<Nganh> list, out int maxmt, out int maxtrangthai,out int maxt,out int ten)
		{
			if (list.Count == 0)
			{
				maxmt = 10;
				maxtrangthai = 10;
				maxt = 10;
				ten = 10;
			}
			else
			{
				maxmt = list[0].Mota.Length;
				maxtrangthai = list[0].Trangthai.Length;
				maxt = list[0].Tennganh.Length;
				ten = list[0].Giangvien.TenGV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxtrangthai < list[i].Trangthai.Length)
						maxtrangthai = list[i].Trangthai.Length;
					if (maxt < list[i].Tennganh.Length)
						maxt = list[i].Tennganh.Length;
					if (ten < list[i].Giangvien.TenGV.Length)
						ten = list[i].Giangvien.TenGV.Length;
				}
			}
		}
		public int Hien(List<Nganh> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int maxmt; ;
			int maxtrangthai;
			int maxt,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			Max(list, out maxmt, out maxtrangthai,out maxt,out ten);
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ NGÀNH");
			Console.SetCursorPosition(x + 16, y); Console.Write("TÊN NGÀNH");
			Console.SetCursorPosition(x + 20 + maxt, y); Console.Write("TÊN TRƯỞNG NGÀNH");
			Console.SetCursorPosition(x + 30+maxt+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x + 35+ten+maxt+maxmt, y); Console.Write("TRẠNG THÁI");
			Console.SetCursorPosition(x + 40+ten+maxt+maxmt+maxtrangthai, y); Console.Write("MÃ KHOA");
			int d = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Manganh);
				Console.SetCursorPosition(x + 16, y); Console.Write(list[i].Tennganh);
				Console.SetCursorPosition(x + 20 + maxt, y); Console.Write(list[i].Giangvien.MaGV);
				Console.SetCursorPosition(x + 30+ten + maxt, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 35+ten + maxt + maxmt, y); Console.Write(list[i].Trangthai);
				Console.SetCursorPosition(x + 40+ten + maxt + maxmt + maxtrangthai, y); Console.Write(list[i].Makhoa);
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
				INganhBusiness BL = new NganhBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN NGÀNH---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã ngành:                       Tên ngành :                             Mã trưởng ngành : ");
				Console.WriteLine();
				Console.WriteLine("Mô tả :");
				Console.WriteLine();
				Console.WriteLine("Trạng thái:");
				int x = 0, y = 15;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				Nganh s = new Nganh();
				s.Manganh = Project_1.Utility.Congcu.Ma(10, 5, 0, 13, s.Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
				s.Tennganh = Project_1.Utility.Congcu.Ten(42, 5, 0, 13, s.Tennganh, "Nhập sai dữ liệu, tên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
				while(true)
				{
					
					s.Matruongnganh = Project_1.Utility.Congcu.Ma(85, 5, 0, 13, s.Matruongnganh, 8, "Nhập sai dữ liệu mã giảng viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistGV(s.Matruongnganh))
						break;
					else
					{
						Console.SetCursorPosition(0, 13);Console.Write("Mã này chưa tồn tại !!! ");
						Console.SetCursorPosition(85, 5); Console.Write("                        ");
					}	
				}
				s.Mota = Project_1.Utility.Congcu.Ten(8, 7, 0, 13, s.Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Trangthai = Project_1.Utility.Congcu.Ten(15, 9, 0, 13, s.Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Makhoa = 100;
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
				INganhBusiness Bl = new NganhBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH NGÀNH ", "Nhập mã ngành cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else Bl.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			string ten = "";
			do
			{
				Console.Clear();
				INganhBusiness BL = new NganhBusiness();
				List<Nganh> list = BL.TimNganh(new Nganh(0, ten,0, null, null, 0));
				Hien(list, 0, 0, "                 DANH SÁCH NGÀNH                       ", "Nhấn Enter để thoát! Nhập tên ngành cần tìm : ", 30);
				ten = Console.ReadLine();
				if (ten == "") return;
			} while (true);
		}

	}
}
