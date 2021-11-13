
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
	public class FormLopSinhVien
	{
		private ILopSinhVienBusiness BL = new LopSinhVienBusiness();
		public void Max(List<LopSinhVien> list, out int maxht)
		{
			if (list.Count == 0)
			{
				maxht = 10;
			}
			else
			{
				maxht = list[0].Sinhvien.TenSV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxht < list[i].Sinhvien.TenSV.Length)
						maxht = list[i].Sinhvien.TenSV.Length;
				}
			}
		}
		public int Hien(List<LopSinhVien> list, int x, int y, string tieudecuoi, int n)
		{
			int max;
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐  DANH SÁCH LỚP SINH VIÊN  ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			y = y + 4;
			Max(list, out max);
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ SINH VIÊN");
			Console.SetCursorPosition(x + 25, y); Console.Write("MÃ LỚP");
			Console.SetCursorPosition(x + 40, y); Console.Write("TÊN SINH VIÊN");
			Console.SetCursorPosition(x + 45+max, y); Console.Write("NĂM HỌC");
			Console.SetCursorPosition(x + 60+max, y); Console.Write("HỌC KỲ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].MaSV);
				Console.SetCursorPosition(x + 25, y); Console.Write(list[i].Malop);
				Console.SetCursorPosition(x + 40, y); Console.Write(list[i].Sinhvien.TenSV);
				Console.SetCursorPosition(x + 45+max, y); Console.Write(list[i].Namhoc);
				Console.SetCursorPosition(x + 60+max, y); Console.Write(list[i].Hocky);
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
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN LỚP SINH VIÊN--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã lớp:                                Mã sinh viên: ");
				Console.WriteLine();
				Console.WriteLine("Năm Học :                              Học kỳ : ");
				int x = 0, y = 11;
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				LopSinhVien s = new LopSinhVien();
				while(true)
				{
					s.Malop = Project_1.Utility.Congcu.Ma(12, 5, 0, 9, s.Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
					if (BL.ExistL(s.Malop))
						break;
					else
					{
						Console.SetCursorPosition(0, 9);Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
						Console.SetCursorPosition(12, 5);Console.Write("                    ");
					}	
				}	
				while(true)
				{
					s.MaSV = Project_1.Utility.Congcu.Ma(55, 5, 0, 9, s.MaSV, 8, "Định dạng sai, Mã sinh viên phải gốm 8 chữ số !");
					if (BL.ExistSV(s.MaSV))
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.Write("Mã sinh viên không tồn tại ! vui lòng nhập lại !!! ");
						Console.SetCursorPosition(55, 5); Console.Write("                    ");
					}	
					
				}
				s.Namhoc = Project_1.Utility.Congcu.Ma(12, 7, 0, 9, s.Namhoc, 4, "Định dạng sai, năm học phải lớn 0 và gồm 4 chữ số !");
				while (true)
				{
					Console.SetCursorPosition(50,7); s.Hocky = int.Parse(Console.ReadLine());
					if (s.Hocky>0)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

					}
					Console.SetCursorPosition(50, 7); Console.WriteLine("                   ");

				}
				Console.SetCursorPosition(80, v);
				ConsoleKeyInfo kt = Console.ReadKey();
				if (kt.Key == ConsoleKey.Escape)
				{
					BL.Insert(s);
					break;
				}
				else if (kt.Key == ConsoleKey.Enter)
				{
					BL.Insert(s);
					
				}
				else
					break;
			} while (true);
		}
		public void Xoa()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0,3, "Nhập tuần cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã lớp muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã sinh viên muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1==0) return;
				else BL.Delete(ma,ma1);
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
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo mã sinh viên       ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   3. Theo năm học            ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   4. Theo học kỳ             ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   0. Exit                    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t╚══════════════════════════════╝");
			Console.WriteLine();
			Console.WriteLine();
			Console.SetCursorPosition(65, 25); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
			switch (n)
			{
				case 1:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã lớp              ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistKTL(i))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(i, 0,0, 0));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 2. Nhập mã sinh viên        ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int a =int.Parse( Console.ReadLine());
						if (BL.ExistKTSV(a))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, a,0, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại mã sinh viên này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (a == 0)
							break;
					} while (true);
					break;
				case 3:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 3. Nhập năm học             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistKTNH(i))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, 0, i,0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại năm học này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (i == 0)
							break;
					} while (true);
					break;
				case 4:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 4. Nhập học kỳ              ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int s = int.Parse(Console.ReadLine());
						if (BL.ExistKTHK(s))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, 0,0, s));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại học kỳ này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (s == 0)
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
		static void Bang(LopSinhVien a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã sinh viên :         ║                                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Mã lớp :               ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║  Năm học :               ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Học kỳ :               ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 20); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.MaSV);
			Console.SetCursorPosition(80, 10); Console.Write(a.Malop);
			Console.SetCursorPosition(80, 13); Console.Write(a.Namhoc);
			Console.SetCursorPosition(80, 16); Console.Write(a.Hocky);
		}
		public void Sua()
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Black; ;
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ đề tài và mã tuần cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã sinh viên : ");
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].MaSV == ma )
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã sinh viên              ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa mã lớp                    ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa năm học                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa học kỳ                    ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa tất cả thông tin          ║                                             ║");
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
										int masv = Project_1.Utility.Congcu.Ma(80,7,50,20, BL.GetAllData()[i].MaSV, 8, "Định dạng sai, Mã sinh viên phải gốm 8 chữ số !");
										if (BL.ExistSV(masv))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m = new LopSinhVien(BL.GetAllData()[i].Malop, masv, BL.GetAllData()[i].Namhoc, BL.GetAllData()[i].Hocky);
											BL.Edit(ma, m);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.Write("Mã sinh viên không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 7); Console.Write("                    ");
										}
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									while (true)
									{
										int  Malop = Project_1.Utility.Congcu.Ma(80,10,50,20, BL.GetAllData()[i].Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
										if (BL.ExistL(Malop))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m1 = new LopSinhVien(Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhoc, BL.GetAllData()[i].Hocky);
											BL.Edit(ma, m1);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50, 20); Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 10); Console.Write("                    ");
										}
									}
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									 int Namhoc = Project_1.Utility.Congcu.Ma(80,13,50,20, BL.GetAllData()[i].Namhoc, 4, "Định dạng sai, năm học phải lớn 0 và gồm 4 chữ số !");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
									LopSinhVien m2 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV,Namhoc, BL.GetAllData()[i].Hocky);
									BL.Edit(ma, m2);
									Console.ReadKey();
									break;
								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 16); int Hocky = int.Parse(Console.ReadLine());
										if (Hocky > 0)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m3 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhoc,Hocky);
											BL.Edit(ma, m3);
											Console.ReadKey();
											break;
										}											
												
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									int sv,lop,namhoc,hocky;
									while (true)
									{
										sv = Project_1.Utility.Congcu.Ma(80, 7, 50, 20, BL.GetAllData()[i].MaSV, 8, "Định dạng sai, Mã sinh viên phải gốm 8 chữ số !");
										if (BL.ExistSV(sv))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.Write("Mã sinh viên không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 7); Console.Write("                    ");
										}
									}
									while (true)
									{
										lop = Project_1.Utility.Congcu.Ma(80, 10, 50, 20, BL.GetAllData()[i].Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
										if (BL.ExistL(lop))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 10); Console.Write("                    ");
										}
									}
									namhoc = Project_1.Utility.Congcu.Ma(80, 13, 50, 20, BL.GetAllData()[i].Namhoc, 4, "Định dạng sai, năm học phải lớn 0 và gồm 4 chữ số !");
									while (true)
									{
										Console.SetCursorPosition(80, 16); hocky = int.Parse(Console.ReadLine());
										if (hocky > 0)
											break;
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									LopSinhVien ta = new LopSinhVien(lop,sv,namhoc,hocky);
									BL.Edit(ma,  ta);
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
						Console.SetCursorPosition(5, BL.GetAllData().Count + 8); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Mã không tồn tại ");
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
				Console.Write("                             ▐    QUẢN LÝ LỚP SINH VIÊN    ▌                                                  ");
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin lớp sinh viên  ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm lớp sinh viên        ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin lớp sinh viên   ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin lớp sinh viên   ║                                             ║");
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
