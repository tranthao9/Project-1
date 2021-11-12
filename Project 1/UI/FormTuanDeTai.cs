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
		private ITuanDetaiBusiness BL = new TuanDetaiBusiness();
		public int Hien(List<TuanDetai> list, int x, int y, string tieudecuoi, int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐  DANH SÁCH LỚP SINH VIÊN  ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
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
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
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
				Hien(BL.GetAllData(), 0, 3, "Nhập tuần cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã đề tài muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã tuần muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1==0) return;
				else BL.Delete(ma,ma1);
			} while (true);
		}
		public void Tim()
		{
			int detai=0;
			do
			{
				Console.Clear();
				List<TuanDetai> list = BL.Tim(new TuanDetai(0,detai,null,0));
				Hien(list, 0, 3, "Nhấn Enter để thoát! Nhập tuần cần tìm : ", BL.GetAllData().Count);
				detai = int.Parse(Console.ReadLine());
				if (detai == 0) return;
			} while (true);
		}
		static void Bang(TuanDetai a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã đề tài :            ║                                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Mã tuần :              ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║  Đánh giá :              ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Điểm :                 ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 20); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Madettai);
			Console.SetCursorPosition(80, 10); Console.Write(a.Matuan);
			Console.SetCursorPosition(80, 13); Console.Write(a.Danhgia);
			Console.SetCursorPosition(80, 16); Console.Write(a.Diem);
		}
		public void Sua()
		{
			while (true) 
			{
				Console.ForegroundColor = ConsoleColor.Black; ;
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ đề tài và mã tuần cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã đề tài : ");
				int ma = int.Parse(Console.ReadLine());
				Console.Write("Nhập mã tuần  : ");int ma2 = int.Parse(Console.ReadLine());
				if (ma == 0 || ma2==0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Madettai == ma && BL.GetAllData()[i].Matuan == ma2)
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
							Console.Write("                             ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("║");
							Console.Write("\t\t║                        ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("                             ▐  CHỌN THÔNG TIN MUỐN SỬA  ▌                                                    ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("║");
							Console.Write("\t\t║                        ");
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Write("                             ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
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
							Console.WriteLine("\t\t║                                                  ║     2.Sửa mã tuần                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa đánh giá                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa điểm                      ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa tất cả thông tin khoa     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     0.Exit                          ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
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
										Console.SetCursorPosition(80, 7); int madetai = int.Parse(Console.ReadLine());
										if (!(BL.ExistKT(madetai)) && madetai > 0)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											TuanDetai m = new TuanDetai( BL.GetAllData()[i].Matuan, madetai, BL.GetAllData()[i].Danhgia, BL.GetAllData()[i].Diem);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Sai định dạng, mã đề tài phải lớn hơn 0! hoặc mã đề tài đã có điền đầy đủ các tuần !");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                     ");
										}

									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 10); int matuan = int.Parse(Console.ReadLine());
										if (!(BL.Exist(matuan, BL.GetAllData()[i].Madettai)) && matuan >= 1 && matuan <= 15)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                          ");
											TuanDetai m = new TuanDetai(matuan, BL.GetAllData()[i].Madettai, BL.GetAllData()[i].Danhgia, BL.GetAllData()[i].Diem);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng tuần sai, tuần nằm trong khoảng từ 1 đến 15 hoặc tuần đã tồn tại !");
											Console.SetCursorPosition(80, 10); Console.WriteLine("                   ");
										}
									}
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									while (true)
									{
										Console.OutputEncoding = Encoding.UTF8;
										Console.InputEncoding = Encoding.Unicode;
										Console.SetCursorPosition(80, 13); string Danhgia = (Console.ReadLine().ToLower());
										if (Danhgia == "đạt" || Danhgia == "không đạt")
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                           ");
											TuanDetai m = new TuanDetai(BL.GetAllData()[i].Matuan, BL.GetAllData()[i].Madettai,  Danhgia, BL.GetAllData()[i].Diem);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đánh giá chỉ đạt hoặc không đạt !");
											Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
										}
									}
									break;
								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 16); double Diem = double.Parse(Console.ReadLine());
										if (Diem >= .0 && Diem <= 10.0)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                           ");
											TuanDetai m = new TuanDetai(BL.GetAllData()[i].Matuan, BL.GetAllData()[i].Madettai,  BL.GetAllData()[i].Danhgia, Diem);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Điểm 1 sai! điểm chỉ nằm trong khoảng từ 0-10");
											Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");
										}
									}
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									int madetai1, matuan1;
									string danhgia;
									double diem;
									while (true)
									{
										Console.SetCursorPosition(80, 7); madetai1 = int.Parse(Console.ReadLine());
										if (!(BL.ExistKT(madetai1)) && madetai1 > 0)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Sai định dạng, mã đề tài phải lớn hơn 0! hoặc mã đề tài đã có điền đầy đủ các tuần !           ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                     ");
										}
									}
									while (true)
									{
										Console.SetCursorPosition(80, 10); matuan1 = int.Parse(Console.ReadLine());
										if (!(BL.Exist(matuan1, madetai1)) && matuan1 >= 1 && matuan1 <= 15)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng tuần sai, tuần nằm trong khoảng từ 1 đến 15 hoặc tuần đã tồn tại !          ");
											Console.SetCursorPosition(80, 10); Console.WriteLine("                   ");
										}
									}
									while (true)
									{
										Console.OutputEncoding = Encoding.UTF8;
										Console.InputEncoding = Encoding.Unicode;
										Console.SetCursorPosition(80, 13); danhgia = (Console.ReadLine().ToLower());
										if (danhgia == "đạt" || danhgia == "không đạt")
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đánh giá chỉ đạt hoặc không đạt !                                                   ");
											Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
										}
									}
									while (true)
									{
										Console.SetCursorPosition(80, 16); diem = double.Parse(Console.ReadLine());
										if (diem >= .0 && diem <= 10.0)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Điểm 1 sai! điểm chỉ nằm trong khoảng từ 0-10                                       ");
											Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");
										}
									}
									TuanDetai ta = new TuanDetai(matuan1, madetai1,  danhgia, diem);
									BL.Edit(ma, ma2, ta);
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                                          ");
									Console.ReadKey();
									break;
								case 0:
									return;
								default:
									Console.SetCursorPosition(50, 20); Console.WriteLine("Sai cú pháp!");
									break;
							}
						}
					}
					if (d == 0)
						Console.SetCursorPosition(5, BL.GetAllData().Count + 10); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Mã không tồn tại ");
				}
			} 
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
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("                             ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                  ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("                             ▐      QUẢN LÝ TUẦN ĐỀ TÀI    ▌                                                  ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("                             ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                  ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin tuần đề tài    ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm tuần đề tài          ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin tuần đề tài     ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin tuần đề tài     ║                                             ║");
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
