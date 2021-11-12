
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
		private IDetaiBusiness BL = new DetaiBusiness();
		static void Max(List<Detai> list, out int maxht)
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
		public int Hien(List<Detai> list, int x, int y, string tieudecuoi, int n)
		{
			int max;
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐     DANH SÁCH ĐỀ TÀI      ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
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
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				Detai s = new Detai();
				while (true)
				{
					Console.SetCursorPosition(12, 5); s.Mada = int.Parse(Console.ReadLine());
					if (s.Mada > 0 & BL.ExistKT(s.Mada))
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã đồ án phải lớn hơn 0! hoặc mã đồ án không tồn tại ");

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
				Hien(BL.GetAllData(), 0, 3, "Nhập mã đề tài cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0 ) return;
				else BL.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			int detai = 0;
			do
			{
				Console.Clear();
				List<Detai> list = BL.Tim(new Detai(detai,null,null,0));
				Hien(list, 0, 0, "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}

		static void Bang(Detai a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã đề tài:             ║                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên đề tài :           ║                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Mã đồ án :             ║                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Mô tả :                ║                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("╚══════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 20); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Madetai);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tendetai);
			Console.SetCursorPosition(80, 13); Console.Write(a.Mada);
			Console.SetCursorPosition(80, 16); Console.Write(a.Mota);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 0, "Nhập MÃ đề tài cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Madetai == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã đề tài                 ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên đề tài                ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mã đồ án                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa mô tả                     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa tất cả thông tin đề tài   ║                                             ║");
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
										Console.SetCursorPosition(80, 7); int Madetai = int.Parse(Console.ReadLine());
										if (Madetai >= 1 && !BL.Exist(Madetai))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                         ");
											Detai m1 = new Detai(Madetai, BL.GetAllData()[i].Tendetai, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Mada);
											BL.Edit(ma, m1);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng mã đề tài sai, Mã đề tài phải lớn hơn 0 hoặc mã đề tài đã tồn tại!");

										}
										Console.SetCursorPosition(80, 7); Console.WriteLine("                   ");

									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string Tendetai = Project_1.Utility.Congcu.Ten(80,10,50,20, BL.GetAllData()[i].Tendetai, "Tên đề tài không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                               ");
									Detai m = new Detai(BL.GetAllData()[i].Madetai, Tendetai, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Mada);
									BL.Edit(ma, m);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 13); int Mada = int.Parse(Console.ReadLine());
										if (Mada > 0 & BL.ExistKT(Mada))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                              ");
											Detai m3 = new Detai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].Tendetai, BL.GetAllData()[i].Mota,Mada);
											BL.Edit(ma, m3);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Mã đồ án phải lớn hơn 0! hoặc mã đồ án chưa tồn tại ");

										}
										Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
									}
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									string Mota = Project_1.Utility.Congcu.Ten(180,16,50,20, BL.GetAllData()[i].Mota, "Mô tả không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                          ");
									Detai m2 = new Detai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].Tendetai,Mota, BL.GetAllData()[i].Mada);
									BL.Edit(ma, m2);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									int ma2, da;
									string mt, ten;
									while (true)
									{
										Console.SetCursorPosition(80, 7); ma2 = int.Parse(Console.ReadLine());
										if (ma2 >= 1 && !BL.Exist(ma2))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng mã đề tài sai, Mã đề tài phải lớn hơn 0 hoặc mã đề tài đã tồn tại!");

										}
										Console.SetCursorPosition(80, 7); Console.WriteLine("                   ");

									}
									ten = Project_1.Utility.Congcu.Ten(80, 10, 50, 20, BL.GetAllData()[i].Tendetai, "Tên đề tài không được khác rỗng");
									while (true)
									{
										Console.SetCursorPosition(80,13); da = int.Parse(Console.ReadLine());
										if (da > 0& BL.ExistKT(da))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Mã đồ án phải lớn hơn 0! hoặc mã đồ án chưa tồn tại ");

										}
										Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
									}
									mt = Project_1.Utility.Congcu.Ten(80,16,50,20, BL.GetAllData()[i].Mota, "Mô tả không được khác rỗng");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                   ");
									Detai m4 = new Detai(ma2, ten,  mt,da);
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
					if (d == 0)
						Console.SetCursorPosition(10, BL.GetAllData().Count + 2); Console.WriteLine("Mã đề tài không tồn tại ");
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
				Console.Write("                                 ▐     QUẢN LÝ ĐỀ TÀI     ▌                                                      ");
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin đề tài         ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị tất cả đề tài        ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm đề tài               ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin đề tài          ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin đề tài          ║                                             ║");
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
