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
	public class FormSinhVien
	{
		private ISinhVienBusiness BL = new SinhVienBusiness();
		private ILopSinhVienBusiness BLL = new LopSinhVienBusiness();
		private ILopHocBusiness BLLL = new LopHocBusiness();
		public void Max(List<SinhVien> list, out int maxht, out int maxdc)
		{
			if (list.Count == 0)
			{
				maxht = 10;
				maxdc = 10;
			}
			else
			{
				maxht = list[0].TenSV.Length;
				maxdc = list[0].Diachi.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxht < list[i].TenSV.Length)
						maxht = list[i].TenSV.Length;
					if (maxdc < list[i].Diachi.Length)
						maxdc = list[i].Diachi.Length;
				}
			}
		}
		public int Hien(List<SinhVien> list, int x, int y, string tieudecuoi, int n)
		{
			int maxht;
			int maxdc;
			Console.WriteLine();
			Max(list, out maxht, out maxdc);
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐     DANH SÁCH SINH VIÊN   ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MASV");
			Console.SetCursorPosition(x + 16, y); Console.Write("HỌ TÊN");
			Console.SetCursorPosition(x + 20 + maxht, y); Console.Write("NĂM SINH");
			Console.SetCursorPosition(x + 32 + maxht, y); Console.Write("GIỚI TÍNH");
			Console.SetCursorPosition(x + 46 + maxht, y); Console.Write("QUÊ QUÁN");
			Console.SetCursorPosition(x + 50 + maxht + maxdc, y); Console.Write("SĐT");
			Console.SetCursorPosition(x + 54 + maxdc + maxht + 10, y); Console.Write("Email");
			Console.SetCursorPosition(x + 54 + maxdc + maxht + 10 + 30, y); Console.Write("LỚP");
			Console.SetCursorPosition(x + 64 + maxdc + maxht + 10+30, y); Console.Write("NĂM HỌC BẮT ĐẦU");
			Console.SetCursorPosition(x + 70 + maxdc + maxht + 10 + 30+15, y); Console.Write("HỌC KỲ BẮT ĐẦU");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].MaSV);
				Console.SetCursorPosition(x + 16, y); Console.Write(list[i].TenSV);
				Console.SetCursorPosition(x + 20 + maxht, y); Console.Write("{0:d}", list[i].NamsinhSV);
				Console.SetCursorPosition(x + 32 + maxht, y); Console.Write(list[i].Gioitinh);
				Console.SetCursorPosition(x + 46 + maxht, y); Console.Write(list[i].Diachi);
				Console.SetCursorPosition(x + 50 + maxht + maxdc, y); Console.Write(list[i].Sdt);
				Console.SetCursorPosition(x + 54 + maxdc + maxht + 10, y); Console.Write(list[i].Email);
				int a=-1;
				for(int j= BLL.GetAllData().Count-1; j>=0;--j)
				{
					if (BLL.GetAllData()[j].MaSV == list[i].MaSV)
					{
						a = j;
						break;
					}	
				}
				Console.SetCursorPosition(x + 54 + maxdc + maxht + 10 + 30, y); Console.Write(BLL.GetAllData()[a].Malop);
				Console.SetCursorPosition(x + 64 + maxdc + maxht + 10 + 30, y); Console.Write(BLL.GetAllData()[a].Namhocbdau);
				Console.SetCursorPosition(x + 70 + maxdc + maxht + 10 + 30 + 15, y); Console.Write(BLL.GetAllData()[a].Hockybdau);
				
				if ((d) == n + 1) break;
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.Write(tieudecuoi);
			return Console.CursorTop;
		}
		public void Nhap()
		{
			Console.InputEncoding = Encoding.Unicode;
			do
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN SINH VIÊN---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã Chuyên Ngành:                             Họ Tên:                                  Năm sinh:");
				Console.WriteLine();
				Console.WriteLine("Giới tính:                                   Địa chỉ:");
				Console.WriteLine();
				Console.WriteLine("SDT:                                         Email:");
				Console.WriteLine();
				Console.WriteLine("Lớp :                    Kỳ học :                     Năm học bắt đầu : ");
				int x = 0, y = 15;
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				SinhVien s = new SinhVien();
				LopHoc cn = new LopHoc();
				while (true)
				{
					cn.Mach = Project_1.Utility.Congcu.Ma(18, 5, 0, 13, cn.Mach, 4, "Nhập sai dữ liệu mã chuyên ngành gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BLLL.ExistCN(cn.Mach))
					{
						if (BL.GetMa(cn.Mach)==0)
							s.MaSV = int.Parse(cn.Mach + "0001");
						else
							s.MaSV = BL.GetMa(cn.Mach)+1;
						break;
					}	
					else
					{
						Console.SetCursorPosition(0, 13); Console.Write("Mã chuyen ngành chưa tồn tại vui lòng nhập lại ! ");
						Console.SetCursorPosition(18, 5); Console.Write("                    ");
					}
				}
				s.TenSV = Project_1.Utility.Congcu.Ten(54, 5, 0, 13, s.TenSV, "Tên sinh viên không được bỏ trống !");
				s.NamsinhSV = Project_1.Utility.Congcu.Namsinh(97, 5, 0, 13, s.NamsinhSV);
				s.Gioitinh = Project_1.Utility.Congcu.Gioitinh(12, 7, 0, 13, s.Gioitinh);
				s.Diachi = Project_1.Utility.Congcu.Ten(54, 7, 0, 13, s.Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Sdt = Project_1.Utility.Congcu.Ma(6, 9, 0, 13, s.Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
				s.Email = Project_1.Utility.Congcu.Email(54, 9, 0, 13, s.Email);
				LopSinhVien lsv = new LopSinhVien();
				while (true)
				{
					lsv.Malop = Project_1.Utility.Congcu.Ma(8, 11, 0, 13, lsv.Malop, 6, "Định dạng sai, Mã lớp phải gốm 6 chữ số !");
					if (BLL.ExistL(lsv.Malop))
						break;
					else
					{
						Console.SetCursorPosition(0, 13); Console.Write("Mã lớp không tồn tại ! vui lòng nhập lại !!! ");
						Console.SetCursorPosition(8, 11); Console.Write("                 ");
					}
				}
				while(true)
				{
					Console.SetCursorPosition(35, 11); lsv.Hockybdau = int.Parse(Console.ReadLine());
					if (lsv.Hockybdau >= 1)
						break;
					else
					{
						Console.SetCursorPosition(0, 13); Console.Write("kỳ học không hợp lý");
						Console.SetCursorPosition(35, 11); Console.Write("              ");
					}	
				}	
				while (true)
				{
					char[] p = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
					Console.SetCursorPosition(75,11); lsv.Namhocbdau = Console.ReadLine();
					string[] a = lsv.Namhocbdau.Split('-');
					if (!(lsv.Namhocbdau.Contains('-')))
					{

						Console.SetCursorPosition(0, 13); Console.WriteLine("Định dạng sai,vui lòng nhập lại ! VD: 2008-2009 ");
						Console.SetCursorPosition(75,11); Console.Write("                               ");
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
							Console.SetCursorPosition(65,11); Console.Write("                               ");
						}
					}

				}

				lsv.MaSV = s.MaSV;
				if ((lsv.Hockybdau % 2) == 0)
				{
					lsv.Hockykthuc = lsv.Hockybdau;
				}
				else
				{
					lsv.Hockykthuc = lsv.Hockybdau + 1;
				}
				lsv.Namhockthuc = lsv.Namhocbdau;
				lsv.Active = 0;
				Console.SetCursorPosition(80, v);
				ConsoleKeyInfo kt = Console.ReadKey();
				if (kt.Key == ConsoleKey.Escape)
				{
					BL.Insert(s);
					BLL.Insert(lsv);
					break;
				}
				else if (kt.Key == ConsoleKey.Enter)
				{
					BL.Insert(s);
					BLL.Insert(lsv);
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
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ SV cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else BL.Delete(ma);
			} while (true);
		}
		public void XoaL()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập lớp sinh viên cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				Console.WriteLine();
				Console.Write("Nhập mã lớp muốn xóa : ");
				int ma = int.Parse(Console.ReadLine());
				Console.Write("Nhập mã sinh viên muốn xóa : ");
				int ma1 = int.Parse(Console.ReadLine());
				if (ma == 0 || ma1 == 0) return;
				else
				{
					if (BLL.ExistKTSVL(ma1, ma))
					{
						BLL.Delete(ma1, ma);
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
			Console.WriteLine("\t\t\t\t\t\t\t\t║   1. Theo mã sinh viên       ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo tên sinh viên      ║");
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
			Console.SetCursorPosition(65, 22); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
			switch (n)
			{
				case 1:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã sinh viên        ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.Exist(i))
						{
							List<SinhVien> list = BL.TimSinhVien(new SinhVien(i, null, new DateTime(), null, null, 0, null));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 2. Nhập tên sinh viên       ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); string a = Console.ReadLine();
						if (BL.ExistTEN(a))
						{
							List<SinhVien> list = BL.TimSinhVien(new SinhVien(0, a, new DateTime(), null, null, 0, null));
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
					string g;
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 3. Nhập năm học             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(80, 2); Console.SetCursorPosition(80, 2);  g = (Console.ReadLine());
						if (BLL.ExistKTNH(g))
						{
							List<SinhVien> list = BLL.Tim(new LopSinhVien(0, 0, g, 0, null, 0, 0));
							Hien(list, 0, 6, "Nhấn Enter để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(50, 5); Console.WriteLine("KHông tồn tại năm học này ! Tiếp tục hoặc nhấn Enter để thoát ! ");
						}
						Console.ReadKey();
						
					} while(g==null);
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
						if (BLL.ExistKTHK(s))
						{
							List<SinhVien> list = BLL.Tim(new LopSinhVien(0, 0, null, s, null, 0, 0));
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
		static void Bang(SinhVien a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã Sinh Viên :         ║                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Họ Tên :               ║                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Giới tính :            ║                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Năm sinh :             ║                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║   Quê quán               ║                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║   Số Điện Thoại          ║                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 24); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 25); Console.Write("║   Email                  ║                                       ║");
			Console.SetCursorPosition(50, 26); Console.Write("╚══════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 27); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.MaSV);
			Console.SetCursorPosition(80, 10); Console.Write(a.TenSV);
			Console.SetCursorPosition(80, 13); Console.Write(a.Gioitinh);
			Console.SetCursorPosition(80, 16); Console.Write("{0:d}", a.NamsinhSV);
			Console.SetCursorPosition(80, 19); Console.Write(a.Diachi);
			Console.SetCursorPosition(80, 22); Console.Write("0" + a.Sdt);
			Console.SetCursorPosition(80, 25); Console.Write(a.Email);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ SV cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				int ma = int.Parse( Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d=0;
					for(int i=0;i<BL.GetAllData().Count;i++)
					{
						if (BL.GetAllData()[i].MaSV == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã sinh viên              ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên sinh viên             ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa giới tính sinh viên       ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa năm sinh sinh  viên       ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa quê quán sinh viên        ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     6.Sửa số điện thoại sinh viên   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa email sinh viên           ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     8.Sửa tất cả thông tin sinh viên║                                             ║");
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
									while (true)
									{
										Console.SetCursorPosition(80, 7); Console.Write("                        ");
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, BL.GetAllData()[i].MaSV, 8, "Nhập sai dữ liệu mã sinh viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										SinhVien m = new SinhVien(tg, BL.GetAllData()[i].TenSV, BL.GetAllData()[i].NamsinhSV, BL.GetAllData()[i].Gioitinh, BL.GetAllData()[i].Diachi, BL.GetAllData()[i].Sdt, BL.GetAllData()[i].Email);
										if (BL.Exist(tg))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                          ");
											BL.Edit(ma, m);
											Console.ReadKey();
											break;
										}
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string a = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, BL.GetAllData()[i].TenSV, "Tên sinh viên không được bỏ trống !");

									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                             ");
									SinhVien sv = new SinhVien(BL.GetAllData()[i].MaSV,a, BL.GetAllData()[i].NamsinhSV, BL.GetAllData()[i].Gioitinh, BL.GetAllData()[i].Diachi, BL.GetAllData()[i].Sdt, BL.GetAllData()[i].Email);
									BL.Edit(ma,sv);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string c = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, BL.GetAllData()[i].Gioitinh);
									SinhVien sv1 = new SinhVien(BL.GetAllData()[i].MaSV, BL.GetAllData()[i].TenSV, BL.GetAllData()[i].NamsinhSV, c, BL.GetAllData()[i].Diachi, BL.GetAllData()[i].Sdt, BL.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                ");
									BL.Edit(BL.GetAllData()[i].MaSV,sv1);
									Console.ReadKey();
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									DateTime dt = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, BL.GetAllData()[i].NamsinhSV);
									SinhVien sv2 = new SinhVien(BL.GetAllData()[i].MaSV, BL.GetAllData()[i].TenSV, dt, BL.GetAllData()[i].Gioitinh, BL.GetAllData()[i].Diachi, BL.GetAllData()[i].Sdt, BL.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                            ");
									BL.Edit(BL.GetAllData()[i].MaSV,sv2);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80,19); Console.Write("                        ");
									string dc = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, BL.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
									SinhVien sv3 = new SinhVien(BL.GetAllData()[i].MaSV, BL.GetAllData()[i].TenSV, BL.GetAllData()[i].NamsinhSV, BL.GetAllData()[i].Gioitinh,dc, BL.GetAllData()[i].Sdt, BL.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                 ");
									BL.Edit(BL.GetAllData()[i].MaSV,sv3);
									Console.ReadKey();
									break;
								case 6:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									int Sdt = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, BL.GetAllData()[i].Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
									SinhVien sv4 = new SinhVien(BL.GetAllData()[i].MaSV, BL.GetAllData()[i].TenSV, BL.GetAllData()[i].NamsinhSV, BL.GetAllData()[i].Gioitinh, BL.GetAllData()[i].Diachi, Sdt, BL.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                   ");
									BL.Edit(BL.GetAllData()[i].MaSV, BL.GetAllData()[i]);
									Console.ReadKey();
									break;
								case 7:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 25); Console.Write("                        ");
									string Email = Project_1.Utility.Congcu.Email(80, 25, 20, 28, BL.GetAllData()[i].Email);
									SinhVien sv5 = new SinhVien(BL.GetAllData()[i].MaSV, BL.GetAllData()[i].TenSV, BL.GetAllData()[i].NamsinhSV, BL.GetAllData()[i].Gioitinh, BL.GetAllData()[i].Diachi, BL.GetAllData()[i].Sdt,Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                   ");
									BL.Edit(BL.GetAllData()[i].MaSV, BL.GetAllData()[i]);
									Console.ReadKey();
									break;
								case 8:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80,10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									Console.SetCursorPosition(80, 25); Console.Write("                        ");
									while (true)
									{
										int ma1 = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, BL.GetAllData()[i].MaSV, 8, "Nhập sai dữ liệu mã sinh viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.Exist(ma1))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											string tV = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, BL.GetAllData()[i].TenSV, "Tên sinh viên không được bỏ trống !");
											string gt = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, BL.GetAllData()[i].Gioitinh);
											DateTime ns = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, BL.GetAllData()[i].NamsinhSV);
											string dc1 = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, BL.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
											int sdt2 = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, BL.GetAllData()[i].Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
											string e= Project_1.Utility.Congcu.Email(80, 25, 20, 28, BL.GetAllData()[i].Email);
											SinhVien sv6 = new SinhVien(ma1, tV, ns, gt, dc1, sdt2, e);
											Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                          ");
											BL.Edit(ma,sv6);
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
					}
					if(d==0)
						Console.SetCursorPosition(5, BL.GetAllData().Count + 8); Console.WriteLine("Mã sinh viên không tồn tại ");
				} 
			} while (true) ;
		}
		public void Menu()
		{
			ISinhVienBusiness BL = new SinhVienBusiness();
			Console.Clear();
			int check = 0;
			while (check==0)
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
				Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐  QUẢN LÝ SINH VIÊN  ▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                      ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin sinh viên      ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin sinh viên  ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm sinh viên            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin sinh viên       ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin sinh viên       ║                                             ║");
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
						Console.Write(" BẠN MUỐN SỬA THÔNG TIN CÁ NHÂN (T) HAY THÔNG TIN LỚP HỌC (H) "); char x = char.Parse(Console.ReadLine());
						switch (x.ToString().ToUpper())
						{
							case "T":
								Sua();
								break;
							case "H":
								FormLopSinhVien s = new FormLopSinhVien();
								s.Sua();
								break;
							default:
								break;
						}
						break;
					case 5:
						Console.Clear();
						Console.Write(" BẠN MUỐN XÓA THEO LỚP(L) HAY XÓA TẤT CẢ THÔNG TIN(A) "); char z = char.Parse(Console.ReadLine());
						switch(z.ToString().ToUpper())
						{
							case "A":
								Xoa();
								break;
							case "L":
								XoaL();
								break;
							default:
								break;
						}
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
