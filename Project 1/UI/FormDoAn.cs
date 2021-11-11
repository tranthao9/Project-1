
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
		private IDoAnBusiness BL = new DoAnBusiness();
		public int Hien(List<DoAn> list, int x, int y, string tieudecuoi, int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐     DANH SÁCH ĐỒ ÁN       ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
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
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
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
				Hien(BL.GetAllData(), 0, 3, "Nhập đồ án cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else BL.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			int detai = 0;
			do
			{
				Console.Clear();
				List<DoAn> list = BL.Tim(new DoAn(detai, null,0, null));
				Hien(list, 0, 3, "Nhấn Enter để thoát! Nhập đồ án cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}
		static void Bang(DoAn a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã đồ án:              ║                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên đồ án :            ║                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Số tín chỉ :           ║                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Mô tả :                ║                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("╚══════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 20); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Mada);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tenda);
			Console.SetCursorPosition(80, 13); Console.Write(a.Sotc);
			Console.SetCursorPosition(80, 16); Console.Write(a.Mota);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0,3, "Nhập MÃ đồ án cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Mada== ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã đồ án                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên đồ án                 ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa số tín chỉ                ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa mô tả                     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa tất cả thông tin đò án    ║                                             ║");
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
										Console.SetCursorPosition(80, 7); int Mada = int.Parse(Console.ReadLine());
										if (Mada > 0)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                        ");
											DoAn m1 = new DoAn(Mada, BL.GetAllData()[i].Tenda, BL.GetAllData()[i].Sotc, BL.GetAllData()[i].Mota);
											BL.Edit(ma, m1);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Mã đồ án phải lớn hơn 0!");

										}
										Console.SetCursorPosition(80, 7); Console.WriteLine("                   ");

									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string Tenda = Project_1.Utility.Congcu.Ten(44, 5, 0, 9, BL.GetAllData()[i].Tenda, "Tên đề tài không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                  ");
									DoAn m = new DoAn(BL.GetAllData()[i].Mada, Tenda, BL.GetAllData()[i].Sotc, BL.GetAllData()[i].Mota);
									BL.Edit(ma, m);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 13); int Sotc = int.Parse(Console.ReadLine());
										if (Sotc >= 1)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Chuyên ngành đã sửa thành công !!!                          ");
											DoAn m2 = new DoAn(BL.GetAllData()[i].Mada, BL.GetAllData()[i].Tenda, Sotc, BL.GetAllData()[i].Mota);
											BL.Edit(ma, m2);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Số tín chỉ phải lớn hơn 0!");

										}
										Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
									}
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									string Mota = Project_1.Utility.Congcu.Ten(44, 7, 0, 9, BL.GetAllData()[i].Mota, "Mô tả không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                              ");
									DoAn m3 = new DoAn(BL.GetAllData()[i].Mada, BL.GetAllData()[i].Tenda, BL.GetAllData()[i].Sotc, Mota);
									BL.Edit(ma, m3);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									int ma2, tc;
									string mt, ten;
									while (true)
									{
										Console.SetCursorPosition(80, 7); ma2 = int.Parse(Console.ReadLine());
										if (ma2 > 0)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Mã đồ án phải lớn hơn 0!");

										}
										Console.SetCursorPosition(80, 7); Console.WriteLine("                   ");

									}
									ten = Project_1.Utility.Congcu.Ten(44, 5, 0, 9, BL.GetAllData()[i].Tenda, "Tên đề tài không được khác rỗng");
									while (true)
									{
										Console.SetCursorPosition(80, 13); tc = int.Parse(Console.ReadLine());
										if (tc >= 1)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Số tín chỉ phải lớn hơn 0!");

										}
										Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
									}
									mt = Project_1.Utility.Congcu.Ten(44, 7, 0, 9, BL.GetAllData()[i].Mota, "Mô tả không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                          ");
									DoAn m4 = new DoAn(ma2,ten,tc, mt);
									BL.Edit(ma, m4);
									Console.ReadKey();
									break;

								case 0:
									return;
								default:
									Console.WriteLine("Sai cú pháp!");
									break;
							}
						}
					}
					if(d==0)
						Console.SetCursorPosition(10, BL.GetAllData().Count + 2); Console.WriteLine("Mã đồ án không tồn tại ");
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
				Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐     QUẢN LÝ ĐỒ ÁN      ▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin đồ án          ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị tất cả đồ án         ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm đồ án                ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin đồ án           ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin đồ án           ║                                             ║");
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
						Hien(BL.GetAllData(), 0, 11, "", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
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
