
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
					Console.SetCursorPosition(x + 90 + max, y); Console.Write("NULL");
					Console.SetCursorPosition(x + 110 + max, y); Console.Write("NULL");
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
									if (BL.ExistL(k) && k!=t )
									{
										LopSinhVien s = new LopSinhVien();
										s.MaSV = z.MaSV;
										s.Malop = k;
										int g;
										while(true)
										{
											Console.Write("Nhập kỳ học bắt đầu chuyển : ");  g = int.Parse(Console.ReadLine());
											if (g >= z.Hockybdau)
												break;
											else
												Console.WriteLine("Học kỳ phải lớn hơn hoặc bằng học kỳ bắt đầu ! ");
										}	
										
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
											if(g==z.Hockybdau)
											{
												s.Namhocbdau = z.Namhockthuc;
											}
											else
											{
												string[] c = z.Namhockthuc.Split('-');
												s.Namhocbdau = (int.Parse(c[0]) + 1).ToString() + '-' + (int.Parse(c[1]) + 1).ToString();
											}	
											s.Hockykthuc = g + 1;
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
			Console.SetCursorPosition(50, 13); Console.Write("║  Năm học bắt đầu :       ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Học kỳ bắt đầu :       ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║   Năm học kết thúc :     ║                                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║  Học kỳ kết thúc :       ║                                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 24); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 25); Console.Write("║  Active :                ║                                                       ║");
			Console.SetCursorPosition(50, 26); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 28); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.MaSV);
			Console.SetCursorPosition(80, 10); Console.Write(a.Malop);
			Console.SetCursorPosition(80, 13); Console.Write(a.Namhocbdau);
			Console.SetCursorPosition(80, 16); Console.Write(a.Hockybdau);
			if(a.Active==1)
			{
				Console.SetCursorPosition(80, 19); Console.Write(a.Namhockthuc);
				Console.SetCursorPosition(80, 22); Console.Write(a.Hockykthuc);
			}	
			else
			{
				Console.SetCursorPosition(80, 19); Console.Write("NULL");
				Console.SetCursorPosition(80, 22); Console.Write("NULL");
			}
			Console.SetCursorPosition(80, 25); Console.Write(a.Active);
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
				if (ma == 0 || m1 == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].MaSV == ma && BL.GetAllData()[i].Malop == m1)
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
							Console.WriteLine("\t\t║                                                  ║     3.Sửa năm học bắt đầu           ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa học kỳ bắt đầu            ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa trạng thái học            ║                                             ║");
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
										int masv = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, BL.GetAllData()[i].MaSV, 8, "Định dạng sai, Mã sinh viên phải gốm 8 chữ số !");
										if (BL.ExistSV(masv))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m = new LopSinhVien(BL.GetAllData()[i].Malop, masv, BL.GetAllData()[i].Namhocbdau, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
											BL.Edit(ma, m1, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.Write("Mã sinh viên không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 7); Console.Write("                    ");
										}
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									while (true)
									{
										int Malop = Project_1.Utility.Congcu.Ma(80, 10, 50, 28, BL.GetAllData()[i].Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
										if (BL.ExistL(Malop))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien mm1 = new LopSinhVien(Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhocbdau, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
											BL.Edit(ma, m1, mm1);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
											Console.SetCursorPosition(80, 10); Console.Write("                    ");
										}
									}
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string g;
									while (true)
									{
										char[] p = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
										Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); g = (Console.ReadLine());
										string[] a = g.Split('-');
										if (!(g.Contains('-')))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
											Console.SetCursorPosition(90, 2); Console.Write("                               ");
										}
										else
										{
											int d2 = 0;
											for (int l = 0; l < a.Length; i++)
											{
												int d1 = 0;
												for (int j = 0; j < a[i].Length; j++)
												{
													char z = a[l][j];
													foreach (char k in p)
													{
														if (z == k)
															d1++;
													}
												}
												if (d1 == 4 && a[l].Length == 4)
												{
													if ((int.Parse(a[l]) > 0))
														d2++;
												}

											}
											if (d2 == 2 && a.Length == 2 && int.Parse(a[1]) - int.Parse(a[0]) == 1)
												break;
											else
											{
												Console.SetCursorPosition(0, 28); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
												Console.SetCursorPosition(65, 11); Console.Write("                               ");
											}
										}

									}
									Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
									LopSinhVien m2 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, g, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
									BL.Edit(ma, m1, m2);
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
											Console.SetCursorPosition(50, 28); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m3 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhocbdau, Hocky, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
											BL.Edit(ma,m1, m3);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 16); int  ac1= int.Parse(Console.ReadLine());
										if (ac1 == 0 || ac1==1)
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Đã sửa thành công !!!                                                       ");
											LopSinhVien m3 = new LopSinhVien(BL.GetAllData()[i].Malop, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].Namhocbdau, BL.GetAllData()[i].Hockybdau, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, ac1);
											BL.Edit(ma, m1, m3);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng sai, Active chỉ là 0 hoặc 1 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									break;
								case 6:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 25); Console.Write("                        ");
									int sv, lop, hocky,ac;
									string namhoc;
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
									while (true)
									{
										char[] p = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
										Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); namhoc = (Console.ReadLine());
										string[] a = namhoc.Split('-');
										if (!(namhoc.Contains('-')))
										{
											Console.SetCursorPosition(50, 5); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
											Console.SetCursorPosition(90, 2); Console.Write("                               ");
										}
										else
										{
											int d2 = 0;
											for (int l = 0; l < a.Length; i++)
											{
												int d1 = 0;
												for (int j = 0; j < a[i].Length; j++)
												{
													char z = a[l][j];
													foreach (char k in p)
													{
														if (z == k)
															d1++;
													}
												}
												if (d1 == 4 && a[l].Length == 4)
												{
													if ((int.Parse(a[l]) > 0))
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
									while (true)
									{
										Console.SetCursorPosition(80, 16);hocky = int.Parse(Console.ReadLine());
										if (hocky > 0)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng sai, học kỳ phải lớn 0 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									while (true)
									{
										Console.SetCursorPosition(80, 16);  ac = int.Parse(Console.ReadLine());
										if (ac == 0 || ac == 1)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 20); Console.WriteLine("Định dạng sai, Active chỉ là 0 hoặc 1 !");

										}
										Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");

									}
									LopSinhVien ta = new LopSinhVien(lop, sv, namhoc, hocky, BL.GetAllData()[i].Namhockthuc, BL.GetAllData()[i].Hockykthuc, BL.GetAllData()[i].Active);
									BL.Edit(ma,m1, ta);
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập tình trạng của sinh viên ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin            ║                                             ║");
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
