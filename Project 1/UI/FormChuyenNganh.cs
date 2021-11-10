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
	public class FormChuyenNganh
	{
		private IChuyenNganhBusiness A = new ChuyenNganhBusiness();
		public void Max(List<ChuyenNganh> list, out int maxmt, out int maxtrangthai,out int maxten)
		{
			if (list.Count == 0)
			{
				maxmt = 10;
				maxtrangthai = 10;
				maxten = 10;
			}
			else
			{
				maxmt = list[0].Mota.Length;
				maxtrangthai = list[0].Tenchnganh.Length;
				maxten = list[0].Giangvien.TenGV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxtrangthai < list[i].Tenchnganh.Length)
						maxtrangthai = list[i].Tenchnganh.Length;
					if (maxten < list[0].Giangvien.TenGV.Length)
						maxten = list[0].Giangvien.TenGV.Length;
				}
			}
		}
		public int Hien(List<ChuyenNganh> list , int x,int y,string tieudedau,string tieudecuoi,int n)
		{
			int t, mota,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Max(list,out mota,out t, out ten);
			Console.SetCursorPosition(x + 1, y);Console.Write("STT");
			Console.SetCursorPosition(x + 6, y);Console.Write("MÃ CHUYÊN NGÀNH");
			Console.SetCursorPosition(x + 24, y);Console.Write("TÊN CHUYÊN NGÀNH");
			Console.SetCursorPosition(x + 29+t, y); Console.Write("TÊN PHỤ TRÁCH");
			Console.SetCursorPosition(x + 34+t+ten, y); Console.Write("MÃ NGÀNH");
			Console.SetCursorPosition(x + 50+t+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x + 55+ten+t+mota, y); Console.Write("TRẠNG THÁI");
			int d = 0;
			for(int i=list.Count-1;i>=0;i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x+1, y);Console.Write(d++);
				Console.SetCursorPosition(x+10, y);Console.Write(list[i].Machnganh);
				Console.SetCursorPosition(x + 24, y);Console.Write(list[i].Tenchnganh);
				Console.SetCursorPosition(x + 29 + t, y);Console.Write(list[i].Giangvien.TenGV);
				Console.SetCursorPosition(x + 34+ten+t, y); Console.Write(list[i].Manganh);
				Console.SetCursorPosition(x + 50+ten+t, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 55 + t+ten + mota, y); Console.Write(list[i].Trangthai);
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
				IChuyenNganhBusiness BL = new ChuyenNganhBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN CHUYÊN NGÀNH---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã chuyên ngành:                                 Tên chuyên ngành :                             ");
				Console.WriteLine();
				Console.WriteLine("Mô tả :");
				Console.WriteLine();
				Console.WriteLine("Trạng thái:                                   Mã người phụ trách  : ");
				Console.WriteLine();
				Console.WriteLine("Mã ngành :");
				int x = 0, y = 15;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				ChuyenNganh s = new ChuyenNganh();
				while (true)
				{
					s.Machnganh = Project_1.Utility.Congcu.Ma(18, 5, 0, 11, s.Machnganh, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistKTCN(s.Machnganh))
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã chuyên ngành đã tồn tại vui lòng nhập mã khác ");
						Console.SetCursorPosition(18, 5); Console.WriteLine("                          ");
					}
					else
						break;

				}
				s.Tenchnganh= Project_1.Utility.Congcu.Ten(70, 5, 0, 13, s.Tenchnganh, "Nhập sai dữ liệu, tên chuyên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Mota = Project_1.Utility.Congcu.Ten(8, 7, 0, 13, s.Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !" );
				s.Trangthai = Project_1.Utility.Congcu.Ten(15, 9, 0, 13, s.Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
				
				while(true)
				{
					s.Maphutrach = Project_1.Utility.Congcu.Ma(70, 9, 0, 13, s.Maphutrach, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
					if (BL.ExistKTGV(s.Maphutrach))
						break;
					else
					{
						Console.SetCursorPosition(0, 13); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
						Console.SetCursorPosition(70, 9); Console.WriteLine("                          ");
					}
				}	
				while (true)
				{
					s.Manganh = Project_1.Utility.Congcu.Ma(10, 11, 0, 13, s.Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistKTN(s.Manganh))
						break;
					else
					{
						Console.SetCursorPosition(0, 13); Console.WriteLine("Mã ngành không tồn tại vui lòng nhập mã khác  !!");
						Console.SetCursorPosition(10, 11); Console.WriteLine("                          ");
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
				IChuyenNganhBusiness Bl = new ChuyenNganhBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH CHUYÊN NGÀNH ", "Nhập MÃ Chuyên ngành cần xóa, thoát nhập 0!", 20);
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
				IChuyenNganhBusiness BL = new ChuyenNganhBusiness();
				List<ChuyenNganh> list = BL.TimChuyenNganh(new ChuyenNganh(0,ten,0,null,null,0));
				Hien(list, 0, 0, "                 DANH SÁCH CHUYÊN NGÀNH                       ", "Nhấn Enter để thoát! Nhập tên chuyên ngành cần tìm : ", 30);
				ten=Console.ReadLine();
				if (ten == "") return;
			} while (true);
		}

	}
}
