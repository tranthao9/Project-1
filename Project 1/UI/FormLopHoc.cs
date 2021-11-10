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
	public class FormLopHoc
	{
		private ILopHocBusiness A = new LopHocBusiness();
		public int Hien(List<LopHoc> list , int x,int y,string tieudedau,string tieudecuoi,int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Console.SetCursorPosition(x + 1, y);Console.Write("STT");
			Console.SetCursorPosition(x + 10, y);Console.Write("MÃ LỚP");
			Console.SetCursorPosition(x + 25, y);Console.Write("TÊN LỚP");
			Console.SetCursorPosition(x + 40, y); Console.Write("MÃ CHUYÊN NGÀNH");
			int d = 0;
			for(int i=list.Count-1;i>=0;i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x+1, y);Console.Write(d++);
				Console.SetCursorPosition(x+10, y);Console.Write(list[i].Malop);
				Console.SetCursorPosition(x + 25, y);Console.Write(list[i].Tenlop);
				Console.SetCursorPosition(x + 40, y); Console.Write(list[i].Mach);

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
				ILopHocBusiness BL = new LopHocBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN LỚP HỌC---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã Lớp:                            Tên Lớp:                             ");
				Console.WriteLine();
				Console.WriteLine("Mã Chuyên Ngành : ");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				LopHoc s = new LopHoc();
				while(true)
				{
					s.Malop = Project_1.Utility.Congcu.Ma(10, 5, 0, 9, s.Malop, 6, "Nhập sai dữ liệu mã lớp gồm 6 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.Exist(s.Malop))
					{
						Console.SetCursorPosition(0, 9); Console.Write("Mã lớp đã tồn tại vui lòng nhập lại ! ");
						Console.SetCursorPosition(10, 5); Console.Write("                    ");
					}
					else
						break;
				}	
				
				s.Tenlop = Project_1.Utility.Congcu.Ten(44, 5, 0, 9, s.Tenlop, "Nhập sai dữ liệu, tên lớp phải khác rỗng vui lòng nhập lại dữ liệu !");
				while(true)
				{
					s.Mach = Project_1.Utility.Congcu.Ma(18, 7, 0, 9, s.Mach, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistCN(s.Mach))
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.Write("Mã chuyen ngành chưa tồn tại vui lòng nhập lại ! ");
						Console.SetCursorPosition(18, 7); Console.Write("                    ");
					}	
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
				ILopHocBusiness Bl = new LopHocBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH LỚP HỌC ", "Nhập MÃ Lớp cần xóa, thoát nhập 0!", 20);
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
				ILopHocBusiness BL = new LopHocBusiness();
				List<LopHoc> list = BL.TimLopHoc(new LopHoc(0,ten,0));
				Hien(list, 0, 0, "                 DANH SÁCH LỚP HỌC                       ", "Nhấn Enter để thoát! Nhập tên lớp cần tìm : ", 30);
				ten=Console.ReadLine();
				if (ten == "") return;
			} while (true);
		}

	}
}
