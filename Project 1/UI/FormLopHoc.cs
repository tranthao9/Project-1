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
		private ILopHocBusiness BL = new LopHocBusiness();
		public int Hien(List<LopHoc> list , int x,int y,string tieudecuoi,int n)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐     DANH SÁCH LỚP HỌC     ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
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
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
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
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ Lớp cần xóa, thoát nhập 0!", BL.GetAllData().Count);
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
			Console.WriteLine("\t\t\t\t\t\t\t\t║   1. Theo mã lớp             ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo tên lớp            ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   3. Theo mã chuyên ngành    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   0. Exit                    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t╚══════════════════════════════╝");
			Console.WriteLine();
			Console.WriteLine();
			Console.SetCursorPosition(65, 22); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
			switch (n)
			{
				case 1:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã đồ án            ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.Exist(i))
						{
							List<LopHoc> list = BL.TimLopHoc(new LopHoc(i, null, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại mã này ! Tiếp tục hoặc nhấn 0 để thoát ! ");

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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 2. Nhập tên đồ án           ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); string a = Console.ReadLine();
						if (BL.ExistTEN(a))
						{
							List<LopHoc> list = BL.TimLopHoc(new LopHoc(0, a, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại tên này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (a == null)
							break;
					} while (true);
					break;
				case 3:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã chuyên ngành     ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistXCN(i))
						{
							List<LopHoc> list = BL.TimLopHoc(new LopHoc(0, null, i));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại mã chuyên ngành này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
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
		static void Bang(LopHoc a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã lớp :               ║                                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên lớp :             ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║  Mã chuyên ngành :       ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 17); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Malop);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tenlop);
			Console.SetCursorPosition(80, 13); Console.Write(a.Mach);
		}
		public void Sua()
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Black; ;
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ lớp cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Malop == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã lớp                    ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên lớp                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mã chuyen ngành           ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa tất cả thông tin          ║                                             ║");
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
										 int Malop = Project_1.Utility.Congcu.Ma(80,7,50,17, BL.GetAllData()[i].Malop, 6, "Nhập sai dữ liệu mã lớp gồm 6 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.Exist(Malop))
										{
											Console.SetCursorPosition(50,17); Console.Write("Mã lớp đã tồn tại vui lòng nhập lại ! ");
											Console.SetCursorPosition(80, 7); Console.Write("                    ");
										}
										else
										{
											Console.SetCursorPosition(50, 17); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopHoc m2 = new LopHoc(Malop,BL.GetAllData()[i].Tenlop, BL.GetAllData()[i].Mach);
											BL.Edit(ma, m2);
											Console.ReadKey();
											break;
										}	
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string Tenlop = Project_1.Utility.Congcu.Ten(80, 10, 50, 17, BL.GetAllData()[i].Tenlop, "Nhập sai dữ liệu, tên lớp phải khác rỗng vui lòng nhập lại dữ liệu !");
									Console.SetCursorPosition(50, 17); Console.WriteLine("Đã sửa thành công !!!                                                       ");
									LopHoc m = new LopHoc(BL.GetAllData()[i].Malop, Tenlop, BL.GetAllData()[i].Mach);
									BL.Edit(ma, m);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									while (true)
									{
										int Mach = Project_1.Utility.Congcu.Ma(80, 13, 50, 17, BL.GetAllData()[i].Mach, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.ExistCN(Mach))
										{
											Console.SetCursorPosition(50, 17); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopHoc m1 = new LopHoc(BL.GetAllData()[i].Malop, BL.GetAllData()[i].Tenlop, Mach);
											BL.Edit(ma, m1);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 17); Console.Write("Mã chuyen ngành chưa tồn tại vui lòng nhập lại ! ");
											Console.SetCursorPosition(80, 13); Console.Write("                    ");
										}
									}
									break;
								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									int lop,cn;
									string ten;
									while (true)
									{
										lop = Project_1.Utility.Congcu.Ma(80, 7, 50, 17, BL.GetAllData()[i].Malop, 6, "Nhập sai dữ liệu mã lớp gồm 6 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.Exist(lop))
										{
											Console.SetCursorPosition(50, 17); Console.Write("Mã lớp đã tồn tại vui lòng nhập lại ! ");
											Console.SetCursorPosition(80, 7); Console.Write("                    ");
										}
										else
										{
											break;
										}
									}
									ten = Project_1.Utility.Congcu.Ten(80, 10, 50, 17, BL.GetAllData()[i].Tenlop, "Nhập sai dữ liệu, tên lớp phải khác rỗng vui lòng nhập lại dữ liệu !");
									while (true)
									{
										cn = Project_1.Utility.Congcu.Ma(80, 13, 50, 17, BL.GetAllData()[i].Mach, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.ExistCN(cn))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 17); Console.Write("Mã chuyen ngành chưa tồn tại vui lòng nhập lại ! ");
											Console.SetCursorPosition(80, 13); Console.Write("                    ");
										}
									}
									LopHoc ta = new LopHoc(lop,ten,cn);
									BL.Edit(ma, ta);
									Console.SetCursorPosition(50, 17); Console.WriteLine("Đã sửa thành công !!!                                                                          ");
									Console.ReadKey();
									break;
								case 0:
									return;
								default:
									Console.SetCursorPosition(50, 17); Console.WriteLine("Sai cú pháp!");
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
				Console.Write("                             ▐      QUẢN LÝ LỚP HỌC        ▌                                                  ");
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin lớp            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin lớp        ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm lớp                  ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin lớp             ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin lớp             ║                                             ║");
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
