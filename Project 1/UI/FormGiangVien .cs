using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;
using Project_1.Business_Layer;
using Project_1.Business_Layer.Interface;

namespace Project_1.UI
{
	public class FormGiangVien
	{
		private IGiangVienBusiness A = new GiangVienBusiness();
		static void Max(List<GiangVien> list,out int maxht,out int maxdc)
		{
			if(list.Count==0)
			{
				maxht = 10;
				maxdc = 10;
			}
			else
			{
				maxht = list[0].TenGV.Length;
				maxdc = list[0].Diachi.Length;
				for(int i=1;i<list.Count;i++)
				{
					if (maxht < list[i].TenGV.Length)
						maxht = list[i].TenGV.Length;
					if (maxdc < list[i].Diachi.Length)
						maxdc = list[i].Diachi.Length;
				}
			}
		}
		public int Hien(List<GiangVien> list , int x,int y,string tieudecuoi,int n)
		{

			int maxht;
			int maxdc;
			Console.WriteLine();
			Max(list, out maxht, out maxdc);
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐    DANH SÁCH GIẢNG VIÊN   ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			y = y + 4;
			Console.SetCursorPosition(x + 1, y);Console.Write("STT");
			Console.SetCursorPosition(x + 6, y);Console.Write("MÃGV");
			Console.SetCursorPosition(x + 20, y);Console.Write("HỌ TÊN");
			Console.SetCursorPosition(x + 25+ maxht, y);Console.Write("NĂM SINH");
			Console.SetCursorPosition(x + 40 + maxht, y);Console.Write("GIỚI TÍNH");
			Console.SetCursorPosition(x + 55 + maxht , y);Console.Write("QUÊ QUÁN");
			Console.SetCursorPosition(x + 60 + maxht + maxdc, y);Console.Write("SĐT");
			Console.SetCursorPosition(x + 75 + maxdc + maxht + 10, y);Console.Write("Email");
			int d = 0;
			for(int i=list.Count-1;i>=0;i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x+1, y);Console.Write(d++);
				Console.SetCursorPosition(x+6, y);Console.Write(list[i].MaGV);
				Console.SetCursorPosition(x + 20, y);Console.Write(list[i].TenGV);
				Console.SetCursorPosition(x + 25 + maxht, y); Console.Write("{0:d}", list[i].Namsinh);
				Console.SetCursorPosition(x + 40 + maxht, y); Console.Write(list[i].Gioitinh);
				Console.SetCursorPosition(x + 55 + maxht, y); Console.Write(list[i].Diachi);
				Console.SetCursorPosition(x + 60 + maxht + maxdc, y); Console.Write(list[i].SDT);
				Console.SetCursorPosition(x + 75 + maxdc + maxht + 10, y); Console.Write(list[i].Email);
				if ((d) == n) break;
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.Write(tieudecuoi);
			return Console.CursorTop;
		}
		public void Nhap()
		{
			do
			{
				IGiangVienBusiness BL = new GiangVienBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN GIẢNG VIÊN---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã Giảng Viên:                      Họ Tên:                                  Năm sinh:");
				Console.WriteLine();
				Console.WriteLine("Giới tính:                         Địa chỉ:");
				Console.WriteLine();
				Console.WriteLine("SDT:                               Email:");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				GiangVien s = new GiangVien();
				s.MaGV = Project_1.Utility.Congcu.Ma(14, 5, 0, 11, s.MaGV,8, "Nhập sai dữ liệu mã giảng viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
				s.TenGV = Project_1.Utility.Congcu.Ten(44, 5, 0, 11, s.TenGV,"Nhập sai định dạng tên giảng viên phải khác rỗng vui lòng nhập lại!");
				s.Namsinh = Project_1.Utility.Congcu.Namsinh(87, 5, 0, 11, s.Namsinh);
				s.Gioitinh = Project_1.Utility.Congcu.Gioitinh(12, 7, 0, 11, s.Gioitinh);
				s.Diachi = Project_1.Utility.Congcu.Ten(44, 7, 0, 11, s.Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.SDT = Project_1.Utility.Congcu.Ma(6, 9, 0, 11, s.SDT,9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
				s.Email = Project_1.Utility.Congcu.Email(44, 9, 0, 11, s.Email);
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
				IGiangVienBusiness Bl = new GiangVienBusiness();
				Hien(Bl.GetAllData(), 0, 0, "Nhập MÃ GV cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else Bl.Delete(ma);
			} while (true);
		}

		static void Bang(GiangVien a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã Giảng Viên :        ║                                       ║");
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
			Console.SetCursorPosition(80, 7); Console.Write(a.MaGV);
			Console.SetCursorPosition(80, 10); Console.Write(a.TenGV);
			Console.SetCursorPosition(80, 13); Console.Write(a.Gioitinh);
			Console.SetCursorPosition(80, 16); Console.Write("{0:d}", a.Namsinh);
			Console.SetCursorPosition(80, 19); Console.Write(a.Diachi);
			Console.SetCursorPosition(80, 22); Console.Write("0" + a.SDT);
			Console.SetCursorPosition(80, 25); Console.Write(a.Email);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				IGiangVienBusiness Bl = new GiangVienBusiness();
				Hien(Bl.GetAllData(), 0, 0, "Nhập MÃ GV cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < Bl.GetAllData().Count; i++)
					{
						if (Bl.GetAllData()[i].MaGV == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã giảng viên             ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên giảng viên            ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa giới tính giảng viên      ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa năm sinh giảng  viên      ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa quê quán giảng viên       ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     6.Sửa số điện thoại giảng viên  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa email giảng viên          ║                                             ║");
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
									Bang(Bl.GetAllData()[i]);
									while (true)
									{
										Console.SetCursorPosition(80, 7); Console.Write("                           ");
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, Bl.GetAllData()[i].MaGV, 8, "Nhập sai dữ liệu mã Giảng viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										GiangVien m = new GiangVien(tg, Bl.GetAllData()[i].TenGV, Bl.GetAllData()[i].Namsinh, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].SDT, Bl.GetAllData()[i].Email);
										if (Bl.Exist(tg))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã Giảng viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("GIảng Viên đã sửa thành công !!!                          ");
											Bl.Edit(ma, m);
											Console.ReadKey();
											break;
										}
									}
									break;
								case 2:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                           ");
									string a = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, Bl.GetAllData()[i].TenGV, "Tên GIảng viên không được bỏ trống !");

									Console.SetCursorPosition(50, 28); Console.WriteLine("Giảng Viên đã sửa thành công !!!                             ");
									GiangVien sv = new GiangVien(Bl.GetAllData()[i].MaGV, a, Bl.GetAllData()[i].Namsinh, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].SDT, Bl.GetAllData()[i].Email);
									Bl.Edit(ma, sv);
									Console.ReadKey();
									break;
								case 3:
									Bang(Bl.GetAllData()[i]); 
									Console.SetCursorPosition(80, 13); Console.Write("                           ");
									string c = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, Bl.GetAllData()[i].Gioitinh);
									GiangVien sv1 = new GiangVien(Bl.GetAllData()[i].MaGV, Bl.GetAllData()[i].TenGV, Bl.GetAllData()[i].Namsinh, c, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].SDT, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Giảng Viên đã sửa thành công !!!                                ");
									Bl.Edit(Bl.GetAllData()[i].MaGV, sv1);
									Console.ReadKey();
									break;

								case 4:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                           ");
									DateTime dt = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, Bl.GetAllData()[i].Namsinh);
									GiangVien sv2 = new GiangVien(Bl.GetAllData()[i].MaGV, Bl.GetAllData()[i].TenGV, dt, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].SDT, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Giảng Viên đã sửa thành công !!!                            ");
									Bl.Edit(Bl.GetAllData()[i].MaGV, sv2);
									Console.ReadKey();
									break;
								case 5:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 19); Console.Write("                           ");
									string dc = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, Bl.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
									GiangVien sv3 = new GiangVien(Bl.GetAllData()[i].MaGV, Bl.GetAllData()[i].TenGV, Bl.GetAllData()[i].Namsinh, Bl.GetAllData()[i].Gioitinh, dc, Bl.GetAllData()[i].SDT, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("GIảng Viên đã sửa thành công !!!                                 ");
									Bl.Edit(Bl.GetAllData()[i].MaGV, sv3);
									Console.ReadKey();
									break;
								case 6:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80,22); Console.Write("                           ");
									int Sdt = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, Bl.GetAllData()[i].SDT, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
									GiangVien sv4 = new GiangVien(Bl.GetAllData()[i].MaGV, Bl.GetAllData()[i].TenGV, Bl.GetAllData()[i].Namsinh, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Sdt, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Giảng Viên đã sửa thành công !!!                                   ");
									Bl.Edit(Bl.GetAllData()[i].MaGV,sv4);
									Console.ReadKey();
									break;
								case 7:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 25); Console.Write("                           ");
									string Email = Project_1.Utility.Congcu.Email(80, 25, 20, 28, Bl.GetAllData()[i].Email);
									GiangVien sv5 = new GiangVien(Bl.GetAllData()[i].MaGV, Bl.GetAllData()[i].TenGV, Bl.GetAllData()[i].Namsinh, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].SDT, Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Giảng Viên đã sửa thành công !!!                                   ");
									Bl.Edit(Bl.GetAllData()[i].MaGV,sv5);
									Console.ReadKey();
									break;
								case 8:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                           ");
									Console.SetCursorPosition(80, 10); Console.Write("                           ");
									Console.SetCursorPosition(80, 13); Console.Write("                           ");
									Console.SetCursorPosition(80,16); Console.Write("                           ");
									Console.SetCursorPosition(80, 19); Console.Write("                           ");
									Console.SetCursorPosition(80, 22); Console.Write("                           ");
									Console.SetCursorPosition(80, 25); Console.Write("                           ");
									while (true)
									{
										int ma1 = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, Bl.GetAllData()[i].MaGV, 8, "Nhập sai dữ liệu mã giảng viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										if (Bl.Exist(ma1))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã giảng viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											string tV = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, Bl.GetAllData()[i].TenGV, "Tên giảng viên không được bỏ trống !");
											string gt = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, Bl.GetAllData()[i].Gioitinh);
											DateTime ns = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, Bl.GetAllData()[i].Namsinh);
											string dc1 = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, Bl.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
											int sdt2 = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, Bl.GetAllData()[i].SDT, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
											string e = Project_1.Utility.Congcu.Email(80, 25, 20, 28, Bl.GetAllData()[i].Email);
											GiangVien sv6 = new GiangVien(ma1, tV, ns, gt, dc1, sdt2, e);
											Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("GIảng Viên đã sửa thành công !!!                          ");
											Bl.Edit(ma, sv6);
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
							Console.SetCursorPosition(10, Bl.GetAllData().Count + 2); Console.WriteLine("Mã giảng viên không tồn tại ");
					}
				}
			} while (true);
		}
		public void Menu()
		{
			IGiangVienBusiness BL = new GiangVienBusiness();
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin giảng viên     ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin giảng viên ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm giảng viên           ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin giảng viên      ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin giảng viên      ║                                             ║");
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
						Hien(BL.GetAllData(), 0, 11, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
						break;
					case 3:
						Console.Clear();
						//
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
