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
		private IChuyenNganhBusiness BL = new ChuyenNganhBusiness();
		static void Max(List<ChuyenNganh> list, out int maxmt, out int maxtrangthai,out int maxten)
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
				if (list[0].Maphutrach==0)
					maxten = 10;
				else
					maxten = list[0].Giangvien.TenGV.Length;

				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxtrangthai < list[i].Tenchnganh.Length)
						maxtrangthai = list[i].Tenchnganh.Length;
					if (list[i].Maphutrach == 0)
						maxten = maxten + 1;
					if (list[i].Maphutrach != 0)
					{
						if (maxten < list[i].Giangvien.TenGV.Length)
							maxten = list[i].Giangvien.TenGV.Length;
					}
				}
			}
		}
		public int Hien(List<ChuyenNganh> list , int x,int y,string tieudecuoi,int n)
		{
			int t, mota,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐  DANH SÁCH CHUYÊN NGÀNH   ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			y = y + 4;
			Max(list,out mota,out t, out ten);
			Console.SetCursorPosition(x + 1, y);Console.Write("STT");
			Console.SetCursorPosition(x + 6, y);Console.Write("MÃ CHUYÊN NGÀNH");
			Console.SetCursorPosition(x + 24, y);Console.Write("TÊN CHUYÊN NGÀNH");
			Console.SetCursorPosition(x + 29+t, y); Console.Write("TÊN PHỤ TRÁCH");
			Console.SetCursorPosition(x + 34+t+ten, y); Console.Write("MÃ NGÀNH");
			Console.SetCursorPosition(x + 50+t+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x + 55+ten+t+mota, y); Console.Write("TRẠNG THÁI");
			int d = 1;
			for(int i=list.Count-1;i>=0;i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x+1, y);Console.Write(d++);
				Console.SetCursorPosition(x+10, y);Console.Write(list[i].Machnganh);
				Console.SetCursorPosition(x + 24, y);Console.Write(list[i].Tenchnganh);
				if (list[i].Maphutrach != 0)
				{ Console.SetCursorPosition(x + 29 + t, y); Console.Write(list[i].Giangvien.TenGV); }
				if (list[i].Maphutrach == 0)
				{ Console.SetCursorPosition(x + 29 + t, y); Console.Write("null"); }
				
				Console.SetCursorPosition(x + 34+ten+t, y); Console.Write(list[i].Manganh);
				Console.SetCursorPosition(x + 50+ten+t, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 55 + t+ten + mota, y); Console.Write(list[i].Trangthai);
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
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
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
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ Chuyên ngành cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else BL.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐  CHỌN THÔNG TIN MUỐN TÌM KIẾM  ▌");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌");
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("\t\t\t\t\t\t\t\t╔══════════════════════════════╗");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   1. Theo mã chuyên ngành    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo tên chuyên ngành   ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   3. Theo mã ngành           ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   0. Exit                    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t╚══════════════════════════════╝");
			Console.WriteLine();
			Console.WriteLine();
			Console.SetCursorPosition(65, 22); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
			switch(n)
			{
				case 1:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0,0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0,1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0,2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã chuyên ngành     ║                                    ║");
						Console.SetCursorPosition(0,3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90,2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if(BL.ExistKTCN(i))
						{
							List<ChuyenNganh> list = BL.TimChuyenNganh(new ChuyenNganh(i, null, 0, null, null, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}	
						else
						{
							Console.SetCursorPosition(70, 5);Console.WriteLine("Mã này không tồn tại ! Tiếp tục hoặc nhấn 0 để thoát ");
						}
						Console.ReadKey();
						if (i == 0)
							break;
					} while (true);
					break;
				case 2:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập tên chuyên ngành    ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); string a= Console.ReadLine();
						if (BL.ExistKTTen(a))
						{
							List<ChuyenNganh> list = BL.TimChuyenNganh(new ChuyenNganh(0, a, 0, null, null, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(70, 5); Console.WriteLine("Tên này không tồn tại ! Tiếp tục hoặc nhấn 0 để thoát ");
						}
						Console.ReadKey();
						if (a==null)
							break;
					} while (true);
					break;
				case 3:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã ngành            ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistXN(i))
						{
							List<ChuyenNganh> list = BL.TimChuyenNganh(new ChuyenNganh(0, null, 0, null, null, i));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(70, 5); Console.WriteLine("Tên này không tồn tại ! Tiếp tục hoặc nhấn 0 để thoát ");
						}
						Console.ReadKey();
						if (i == 0)
							break;
					} while (true);
					break;
				case 0:
					break;
				default:
					Console.WriteLine("Nhập sai cú pháp !");
					break;
			}
		}
		static void Bang(ChuyenNganh a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã chuyên ngành :      ║                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên chuyên ngành :     ║                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Mô tả :                ║                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Trạng thái :           ║                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║  Mã người phụ trách :    ║                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║   Mã ngành :             ║                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("╚══════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 27); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Machnganh);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tenchnganh);
			Console.SetCursorPosition(80, 13); Console.Write(a.Mota);
			Console.SetCursorPosition(80, 16); Console.Write(a.Trangthai);
			Console.SetCursorPosition(80, 19); Console.Write(a.Maphutrach);
			Console.SetCursorPosition(80, 22); Console.Write(a.Manganh);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ CN cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Machnganh == ma)
						{
							d++;
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.White;
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("\t\t║                        ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("║");
							Console.Write("\t\t║                        ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("                                 ▐  CHỌN THÔNG TIN MUỐN SỬA  ▌                                                ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("║");
							Console.Write("\t\t║                        ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã chuyên ngành           ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên chuyên ngành          ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mô tả                     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa trạng thái                ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa mã người phụ trách        ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     6.Sửa mã ngành                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa tất cả thông tin CN       ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     0.Exit                          ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t║                                                                                                                                      ║");
							Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

							Console.Write("Mời bạn chọn chức năng: ");
							int mode = int.Parse(Console.ReadLine());
							switch (mode)
							{
								case 1:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									while (true)
									{
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Machnganh, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.ExistKTCN(tg))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã chuyên ngành đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                          ");
											ChuyenNganh m = new ChuyenNganh(tg, BL.GetAllData()[i].Tenchnganh, BL.GetAllData()[i].Maphutrach, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Manganh);
											BL.Edit(ma, m);
											break;
										}
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string ten = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tenchnganh, "Nhập sai dữ liệu, tên chuyên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
									Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                             ");
									ChuyenNganh m2 = new ChuyenNganh(BL.GetAllData()[i].Machnganh, ten, BL.GetAllData()[i].Maphutrach, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Manganh);
									BL.Edit(ma, m2);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string mota = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
									ChuyenNganh m3 = new ChuyenNganh(BL.GetAllData()[i].Machnganh, BL.GetAllData()[i].Tenchnganh, BL.GetAllData()[i].Maphutrach, mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Manganh);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                                ");
									BL.Edit(ma, m3);
									Console.ReadKey();
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									string trangthai = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
									ChuyenNganh m4 = new ChuyenNganh(BL.GetAllData()[i].Machnganh, BL.GetAllData()[i].Tenchnganh, BL.GetAllData()[i].Maphutrach, BL.GetAllData()[i].Mota,trangthai, BL.GetAllData()[i].Manganh);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                            ");
									BL.Edit(ma, m4);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									while (true)
									{
										int mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Maphutrach, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
										if (BL.ExistKTGV(mpt))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                          ");
											ChuyenNganh m5 = new ChuyenNganh(BL.GetAllData()[i].Machnganh, BL.GetAllData()[i].Tenchnganh,mpt, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Manganh);
											BL.Edit(ma, m5);
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
											Console.SetCursorPosition(80, 19); Console.WriteLine("                          ");
										}
									}
									break;
								case 6:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									while (true)
									{
										int mn = Project_1.Utility.Congcu.Ma(80, 22, 50, 25, BL.GetAllData()[i].Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.ExistKTN(mn))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                          ");
											ChuyenNganh m5 = new ChuyenNganh(BL.GetAllData()[i].Machnganh, BL.GetAllData()[i].Tenchnganh, BL.GetAllData()[i].Maphutrach, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, mn);
											BL.Edit(ma, m5);
											break;
										}		
										else
										{
											Console.SetCursorPosition(80, 22); Console.WriteLine("Mã ngành không tồn tại vui lòng nhập mã khác  !!");
											Console.SetCursorPosition(50, 25); Console.WriteLine("                          ");
										}
									}
									break;
								case 7:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									while (true)
									{
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Machnganh, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.ExistKTCN(tg))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã chuyên ngành đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											string ten1 = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tenchnganh, "Nhập sai dữ liệu, tên chuyên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
											string mota1 = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
											string trangthai1 = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
											int mpt;
											while (true)
											{
												mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Maphutrach, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
												if (BL.ExistKTGV(mpt))
												{
													break;
												}
												else
												{
													Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
													Console.SetCursorPosition(80, 19); Console.WriteLine("                          ");
												}
											}
											int mn;
											while (true)
											{
												mn = Project_1.Utility.Congcu.Ma(80, 22, 50, 25, BL.GetAllData()[i].Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
												if (BL.ExistKTN(mn))
												{
													break;
												}
												else
												{
													Console.SetCursorPosition(80, 22); Console.WriteLine("Mã ngành không tồn tại vui lòng nhập mã khác  !!");
													Console.SetCursorPosition(50, 25); Console.WriteLine("                          ");
												}
											}
											ChuyenNganh sv6 = new ChuyenNganh(tg,ten1,mpt,mota1,trangthai1,mn);
											Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                          ");
											BL.Edit(ma, sv6);
											Console.ReadKey();
											break;
										}
									}
									break;

								case 0:
									return;
								default:
									Console.WriteLine("Sai cú pháp!");
									break;
							}
						}
						else
							Console.SetCursorPosition(10, BL.GetAllData().Count + 2); Console.WriteLine("Mã Chuyên ngành không tồn tại ");
					}
				}
			} while (true);
		}
		public void Menu()
		{
			Console.Clear();
			int check = 0;
			while (check == 0)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐  QUẢN LÝ CHUYÊN NGÀNH  ▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin chuyên ngành   ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị tất cả chuyên ngành  ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm chuyên ngành         ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin chuyên ngành    ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin chuyên ngành    ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     0.Exit                          ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

				Console.Write("Mời bạn chọn chức năng: ");
				int mode = int.Parse(Console.ReadLine());
				switch (mode)
				{
					case 1:
						Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
						Nhap(); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
						break;
					case 2:
						Console.Clear();
						Hien(BL.GetAllData(), 0, 3, " ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
						break;
					case 3:
						Console.Clear();
						Tim();
						break;

					case 4:
						Console.Clear();
						Sua();
						break;
					case 5:
						Console.Clear();
						Xoa();
						break;
					case 0:
						check = 1;
						break;
					default:
						Console.WriteLine("Sai cú pháp!");
						break;
				}

			}

		}
	}
}
