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
		private ISinhVienBusiness A = new SinhVienBusiness();
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
		public int Hien(List<SinhVien> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int maxht;
			int maxdc;
			Console.WriteLine();
			Max(list, out maxht, out maxdc);
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MASV");
			Console.SetCursorPosition(x + 16, y); Console.Write("HỌ TÊN");
			Console.SetCursorPosition(x + 20 + maxht, y); Console.Write("NĂM SINH");
			Console.SetCursorPosition(x + 32 + maxht, y); Console.Write("GIỚI TÍNH");
			Console.SetCursorPosition(x + 46 + maxht, y); Console.Write("QUÊ QUÁN");
			Console.SetCursorPosition(x + 50 + maxht + maxdc, y); Console.Write("SĐT");
			Console.SetCursorPosition(x + 54 + maxdc + maxht + 10, y); Console.Write("Email");
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
				if ((d) == n + 1) break;
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
				ISinhVienBusiness BL = new SinhVienBusiness();
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN SINH VIÊN---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã Sinh Viên:                                Họ Tên:                                  Năm sinh:");
				Console.WriteLine();
				Console.WriteLine("Giới tính:                                   Địa chỉ:");
				Console.WriteLine();
				Console.WriteLine("SDT:                                         Email:");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
				SinhVien s = new SinhVien();
				while (true)
				{
					s.MaSV = Project_1.Utility.Congcu.Ma(14, 5, 0, 11, s.MaSV, 8, "Nhập sai dữ liệu mã sinh viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.Exist(s.MaSV))
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập mã khác ");
						Console.SetCursorPosition(14, 5); Console.WriteLine("                          ");
					}
					else
						break;

				}
				s.TenSV = Project_1.Utility.Congcu.Ten(54, 5, 0, 11, s.TenSV, "Tên sinh viên không được bỏ trống !");
				s.NamsinhSV = Project_1.Utility.Congcu.Namsinh(97, 5, 0, 11, s.NamsinhSV);
				s.Gioitinh = Project_1.Utility.Congcu.Gioitinh(12, 7, 0, 11, s.Gioitinh);
				s.Diachi = Project_1.Utility.Congcu.Ten(54, 7, 0, 11, s.Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Sdt = Project_1.Utility.Congcu.Ma(6, 9, 0, 11, s.Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
				s.Email = Project_1.Utility.Congcu.Email(54, 9, 0, 11, s.Email);
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
				ISinhVienBusiness Bl = new SinhVienBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH SINH VIÊN ", "Nhập MÃ SV cần xóa, thoát nhập 0!", 20);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0) return;
				else Bl.Delete(ma);
			} while (true);
		}
		public void Tim()
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.InputEncoding = Encoding.Unicode;
			string hoten = "";
			do
			{
				Console.Clear();
				ISinhVienBusiness BL = new SinhVienBusiness();
				List<SinhVien> list = BL.TimSinhVien(new SinhVien(0, hoten, new DateTime(), "", "", 0, ""));
				Hien(list, 0, 0, "                 DANH SÁCH SINH VIÊN                       ", "Nhấn ENTER để thoát! Nhập họ và tên cần tìm : ", 30);
				hoten = Console.ReadLine();
				if (hoten == "") return;
			} while (true);
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
				ISinhVienBusiness Bl = new SinhVienBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH SINH VIÊN ", "Nhập MÃ SV cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse( Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d=0;
					for(int i=0;i<Bl.GetAllData().Count;i++)
					{
						if (Bl.GetAllData()[i].MaSV == ma)
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
									Bang(Bl.GetAllData()[i]);
									while (true)
									{
										Console.SetCursorPosition(80, 7); Console.Write("                        ");
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, Bl.GetAllData()[i].MaSV, 8, "Nhập sai dữ liệu mã sinh viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										SinhVien m = new SinhVien(tg, Bl.GetAllData()[i].TenSV, Bl.GetAllData()[i].NamsinhSV, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].Sdt, Bl.GetAllData()[i].Email);
										if (Bl.Exist(tg))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                          ");
											Bl.Edit(ma, m);
											Console.ReadKey();
											break;
										}
									}
									break;
								case 2:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string a = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, Bl.GetAllData()[i].TenSV, "Tên sinh viên không được bỏ trống !");

									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                             ");
									SinhVien sv = new SinhVien(Bl.GetAllData()[i].MaSV,a, Bl.GetAllData()[i].NamsinhSV, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].Sdt, Bl.GetAllData()[i].Email);
									Bl.Edit(ma,sv);
									Console.ReadKey();
									break;
								case 3:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string c = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, Bl.GetAllData()[i].Gioitinh);
									SinhVien sv1 = new SinhVien(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i].TenSV, Bl.GetAllData()[i].NamsinhSV, c, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].Sdt, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                ");
									Bl.Edit(Bl.GetAllData()[i].MaSV,sv1);
									Console.ReadKey();
									break;

								case 4:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									DateTime dt = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, Bl.GetAllData()[i].NamsinhSV);
									SinhVien sv2 = new SinhVien(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i].TenSV, dt, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].Sdt, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                            ");
									Bl.Edit(Bl.GetAllData()[i].MaSV,sv2);
									Console.ReadKey();
									break;
								case 5:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80,19); Console.Write("                        ");
									string dc = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, Bl.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
									SinhVien sv3 = new SinhVien(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i].TenSV, Bl.GetAllData()[i].NamsinhSV, Bl.GetAllData()[i].Gioitinh,dc, Bl.GetAllData()[i].Sdt, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                 ");
									Bl.Edit(Bl.GetAllData()[i].MaSV,sv3);
									Console.ReadKey();
									break;
								case 6:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									int Sdt = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, Bl.GetAllData()[i].Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
									SinhVien sv4 = new SinhVien(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i].TenSV, Bl.GetAllData()[i].NamsinhSV, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Sdt, Bl.GetAllData()[i].Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                   ");
									Bl.Edit(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i]);
									Console.ReadKey();
									break;
								case 7:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 25); Console.Write("                        ");
									string Email = Project_1.Utility.Congcu.Email(80, 25, 20, 28, Bl.GetAllData()[i].Email);
									SinhVien sv5 = new SinhVien(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i].TenSV, Bl.GetAllData()[i].NamsinhSV, Bl.GetAllData()[i].Gioitinh, Bl.GetAllData()[i].Diachi, Bl.GetAllData()[i].Sdt,Email);
									Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                                   ");
									Bl.Edit(Bl.GetAllData()[i].MaSV, Bl.GetAllData()[i]);
									Console.ReadKey();
									break;
								case 8:
									Bang(Bl.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80,10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									Console.SetCursorPosition(80, 25); Console.Write("                        ");
									while (true)
									{
										int ma1 = Project_1.Utility.Congcu.Ma(80, 7, 50, 28, Bl.GetAllData()[i].MaSV, 8, "Nhập sai dữ liệu mã sinh viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
										if (Bl.Exist(ma1))
										{
											Console.SetCursorPosition(50, 28); Console.WriteLine("Mã sinh viên đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											string tV = Project_1.Utility.Congcu.Ten(80, 10, 50, 28, Bl.GetAllData()[i].TenSV, "Tên sinh viên không được bỏ trống !");
											string gt = Project_1.Utility.Congcu.Gioitinh(80, 13, 50, 28, Bl.GetAllData()[i].Gioitinh);
											DateTime ns = Project_1.Utility.Congcu.Namsinh(80, 16, 50, 28, Bl.GetAllData()[i].NamsinhSV);
											string dc1 = Project_1.Utility.Congcu.Ten(80, 19, 50, 28, Bl.GetAllData()[i].Diachi, "Nhập sai dữ liệu, quê quán phải khác rỗng vui lòng nhập lại dữ liệu !");
											int sdt2 = Project_1.Utility.Congcu.Ma(80, 22, 50, 28, Bl.GetAllData()[i].Sdt, 9, "Nhập số điện thoại sai định dạng vui lòng nhập lại !");
											string e= Project_1.Utility.Congcu.Email(80, 25, 20, 28, Bl.GetAllData()[i].Email);
											SinhVien sv6 = new SinhVien(ma1, tV, ns, gt, dc1, sdt2, e);
											Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("Sinh Viên đã sửa thành công !!!                          ");
											Bl.Edit(ma,sv6);
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
							Console.SetCursorPosition(10,Bl.GetAllData().Count+2); Console.WriteLine("Mã sinh viên không tồn tại ");
					}
				} 
			} while (true) ;
		}
		public void Menu()
		{
			ISinhVienBusiness BL = new SinhVienBusiness();
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
						Hien(BL.GetAllData(), 0, 11, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count); Console.WriteLine("Nhấn phím bất kì để tiếp tục"); Console.ReadLine(); Console.Clear();
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
