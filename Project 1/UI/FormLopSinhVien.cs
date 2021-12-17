
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
			Console.SetCursorPosition(x + 45+max, y); Console.Write("NĂM HỌC BẮT ĐẦU");
			Console.SetCursorPosition(x + 70+max, y); Console.Write("HỌC KỲ BẮT ĐẦU");
			Console.SetCursorPosition(x + 90 + max, y); Console.Write("NĂM HỌC KẾT THÚC");
			Console.SetCursorPosition(x + 110 + max, y); Console.Write("HỌC KỲ KẾT THÚC");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].MaSV);
				Console.SetCursorPosition(x + 25, y); Console.Write(list[i].Malop);
				Console.SetCursorPosition(x + 40, y); Console.Write(list[i].Sinhvien.TenSV);
				Console.SetCursorPosition(x + 45+max, y); Console.Write(list[i].Namhocbdau);
				Console.SetCursorPosition(x + 70+max, y); Console.Write(list[i].Hockybdau);
				if(list[i].Active==1)
				{
					Console.SetCursorPosition(x + 90 + max, y); Console.Write(list[i].Namhockthuc);
					Console.SetCursorPosition(x + 110 + max, y); Console.Write(list[i].Hockykthuc);
				}	
				else
				{
					Console.SetCursorPosition(x + 90 + max, y); Console.Write("null");
					Console.SetCursorPosition(x + 110 + max, y); Console.Write("0");
				}	
				
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
				Hien(BL.GetAllData(), 0, 3, "Thoát nhập 0 , Nhập mã sinh viên ", BL.GetAllData().Count);
				int ma = int.Parse(Console.ReadLine());
				Console.WriteLine();
				int t;
				while (true)
				{
					Console.Write("Nhập mã lớp của sinh viên : "); t = int.Parse(Console.ReadLine());
					if (BL.ExistKTL(t))
					{
						break;
					}
					else
					{
						Console.WriteLine("Không tồn tại mã này !");
					}
				}
				if (BL.ExistKTSVL(ma, t))
				{
					Console.Clear();
					Console.WriteLine("--------------------------------CHỌN THÔNG TIN SINH VIÊN--------------------------------");
					Console.WriteLine();
					Console.WriteLine("*************************************************************************************");
					Console.WriteLine();
					Console.WriteLine("\t\t\t\t\t\t\t\t1.Sinh viên chuyển lớp");
					Console.WriteLine("\t\t\t\t\t\t\t\t2.Sinh viên lên lớp");
					Console.WriteLine("\t\t\t\t\t\t\t\t3.Sinh viên bảo lưu");
					Console.WriteLine("\t\t\t\t\t\t\t\t4.Sinh viên kết thúc");
					Console.WriteLine("\t\t\t\t\t\t\t\t0.exit");
					Console.WriteLine();
					Console.Write("\t\t\t\t\t\t\t\tChọn tình trạng sinh viên : "); int a = int.Parse(Console.ReadLine());

					switch (a)
					{
						
						case 1:

							foreach (var z in BL.GetAllData())
							{
								if (z.MaSV == ma && z.Malop == t)
								{
									Console.Write("Nhập lớp muốn chuyển : "); int k = int.Parse(Console.ReadLine());
									if (BL.ExistL(k) && k!=t)
									{
										LopSinhVien s = new LopSinhVien();
										s.MaSV = z.MaSV;
										s.Malop = k;
										Console.Write("Nhập kỳ học bắt đầu chuyển : ");int g = int.Parse(Console.ReadLine());
										z.Hockykthuc = g;
										s.Hockybdau = g;
										if ( (g%2) ==0)
										{
											s.Hockykthuc = g;
											s.Namhocbdau = z.Namhockthuc;
											s.Hockykthuc = s.Hockybdau;
										}
										else
										{
											s.Hockykthuc = g + 1;
											string[] c = z.Namhockthuc.Split('-');
											s.Namhocbdau = (int.Parse(c[0]) + 1).ToString() + '-' + (int.Parse(c[1]) + 1).ToString();
											s.Hockykthuc = s.Hockybdau + 1;
										}
										s.Namhockthuc = s.Namhocbdau;
										s.Active = 0;
										z.Active = 1;
										BL.Edit(ma, t, z);
										BL.Insert(s);
									}
									else
									{
										Console.WriteLine("Mã lớp không tồn tại hoặc trùng lớp ban đầu !");
									}	
								}

							}
							break;
						
						case 2:
							foreach (var z in BL.GetAllData())
							{
								if (z.MaSV == ma && z.Malop == t)
								{
									z.Hockykthuc = z.Hockykthuc + 2;
									string[] c = z.Namhockthuc.Split('-');
									z.Namhockthuc = (int.Parse(c[0]) + 1).ToString() + '-' + (int.Parse(c[1]) + 1).ToString();
									BL.Edit(ma, t, z);
								}
							}
							break;
						case 3:
							foreach (var z in BL.GetAllData())
							{
								if (z.MaSV == ma && z.Malop == t)
								{
									z.Active = 1;
									BL.Edit(ma, t, z);
								}
							}
							break;
						case 4:
							foreach (var z in BL.GetAllData())
							{
								if (z.MaSV == ma && z.Malop == t)
								{
									z.Active = 1;
									BL.Edit(ma, t, z);
								}
							}
							break;
						case 0:
							return;
						default:
							Console.WriteLine("Nhập sai cú pháp : ");
							break;
					}
				}
				else
				{
					Console.WriteLine("Không tồn tại mã này !");
					Console.ReadKey();
				}	
					
			} while (true);
		}
		public void Xoa()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập lớp sinh viên cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã lớp muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã sinh viên muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1 == 0) return;
				else
				{
					if(BL.ExistKTSVL(ma,ma1))
					{
						BL.Delete(ma, ma1);
					}	
					else
					{
						Console.WriteLine("Không tồn tại mã này !");
					}	
				} 
					
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
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(i, 0, null, 0,null,0,0));
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
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int a = int.Parse(Console.ReadLine());
						if (BL.ExistKTSV(a))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, a, null, 0, null, 0, 0));
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
						string g;
						while (true)
						{
							char[] p = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
							Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2);  g = (Console.ReadLine());
							string[] a = g.Split('-');
							if (!(g.Contains('-')))
							{
								Console.SetCursorPosition(50, 5); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
								Console.SetCursorPosition(90, 2); Console.Write("                               ");
							}
							else
							{
								int d2 = 0;
								for (int i = 0; i < a.Length; i++)
								{
									int d1 = 0;
									for (int j = 0; j < a[i].Length; j++)
									{
										char z = a[i][j];
										foreach (char k in p)
										{
											if (z == k)
												d1++;
										}
									}
									if (d1 == 4 && a[i].Length == 4)
									{
										if ((int.Parse(a[i]) > 0))
											d2++;
									}

								}
								if (d2 == 2 && a.Length == 2 && int.Parse(a[1]) - int.Parse(a[0]) == 1)
									break;
								else
								{
									Console.SetCursorPosition(0, 13); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
									Console.SetCursorPosition(65, 11); Console.Write("                               ");
								}
							}

						}
						if (BL.ExistKTNH(g))
						{
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, 0, g, 0, null, 0, 0));
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại năm học này ! Tiếp tục hoặc nhấn Enter để thoát ! ");
						}
						Console.ReadKey();
						if (g == null)
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
							List<LopSinhVien> list = BL.Tim(new LopSinhVien(0, 0, null, s,null,0,0));
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
			Console.SetCursorPosition(50, 5);  Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6);  Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7);  Console.Write("║   Mã sinh viên :         ║                                                       ║");
			Console.SetCursorPosition(50, 8);  Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9);  Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Mã lớp :               ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║  Năm học bắt đầu :       ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Học kỳ bắt đầu :       ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║   Mã lớp :               ║                                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║  Năm học bắt đầu :       ║                                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 25); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.MaSV);
			Console.SetCursorPosition(80, 10); Console.Write(a.Malop);
			Console.SetCursorPosition(80, 13); Console.Write(a.Namhocbdau);
			Console.SetCursorPosition(80, 16); Console.Write(a.Hockybdau);
			Console.SetCursorPosition(80, 19); Console.Write(a.Namhocbdau);
			Console.SetCursorPosition(80, 22); Console.Write(a.Hockybdau);
		}
		public void Sua()
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Black; ;
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập mã sinh viên và mã lớp cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã sinh viên : ");
				int ma = int.Parse(Console.ReadLine());
				Console.Write("Nhập mã lớp : ");
				int m1 = int.Parse(Console.ReadLine());
				if (ma == 0 || m1 ==0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].MaSV == ma&&BL.GetAllData()[i].Malop==m1)
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
										int masv = Project_1.Utility.Congcu.Ma(80, 7, 50, 20, BL.GetAllData()[i].MaSV, 8, "Định dạng sai, Mã sinh viên phải gốm 8 chữ số !");
										if (BL.ExistSV(masv))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m = new LopSinhVien(BL.GetAllData()[i].Malop, masv, BL.GetAllData()[i].Namhocbdau, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
											BL.Edit(ma, m1,m);
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
										int Malop = Project_1.Utility.Congcu.Ma(80, 10, 50, 20, BL.GetAllData()[i].Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
										if (BL.ExistL(Malop))
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien mm1 = new LopSinhVien(Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhocbdau, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
											BL.Edit(ma, m1,mm1);
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
									Namhocbd = Project_1.Utility.Congcu.Ma(80, 13, 50, 20, BL.GetAllData()[i].Namhocbdau, 4, "Định dạng sai, năm học phải lớn 0 và gồm 4 chữ số !");
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
									LopSinhVien m2 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, Namhoc, BL.GetAllData()[i].Hocky);
									BL.Edit(ma,m1, m2);
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
											LopSinhVien m3 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhoc, Hocky);
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
									int sv, lop, namhoc, hocky;
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
									LopSinhVien ta = new LopSinhVien(lop, sv, namhoc, hocky);
									BL.Edit(ma, ta);
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
		//public void Menu()
		//{
		//	Console.Clear();
		//	int check = 0;
		//	while (check == 0)
		//	{
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine();
		//		Console.WriteLine();
		//		Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Green;
		//		Console.Write("                             ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                  ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Green;
		//		Console.Write("                             ▐    QUẢN LÝ LỚP SINH VIÊN    ▌                                                  ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.Write("\t\t║                        ");
		//		Console.ForegroundColor = ConsoleColor.Green;
		//		Console.Write("                             ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                  ");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin lớp sinh viên  ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin            ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm lớp sinh viên        ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin lớp sinh viên   ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin lớp sinh viên   ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
		//		Console.WriteLine("\t\t║                                                  ║     0.Exit                          ║                                             ║");
		//		Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
		//		Console.ForegroundColor = ConsoleColor.Black;
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t║                                                                                                                                      ║");
		//		Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

		//		Console.Write("Mời bạn chọn chức năng: ");
		//		int mode = int.Parse(Console.ReadLine());
		//		switch (mode)
		//		{
		//			case 1:
		//				Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
		//				Nhap(); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 2:
		//				Console.Clear();
		//				Hien(BL.GetAllData(), 0, 3, " ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
		//				break;
		//			case 3:
		//				Console.Clear();
		//				Tim();
		//				break;
		//			case 4:
		//				Console.Clear();
		//				Sua();
		//				break;
		//			case 5:
		//				Console.Clear();
		//				Xoa();
		//				break;
		//			case 0:
		//				check = 1;
		//				break;
		//			default:
		//				Console.WriteLine("Sai cú pháp!");
		//				break;
		//		}

		//	}

		//}
	}
}
