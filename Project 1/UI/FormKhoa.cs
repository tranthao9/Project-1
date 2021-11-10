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
	public class FormKhoa
	{
		private IKhoaBusiness BL = new KhoaBusiness();
		public void Max(List<Khoa> list, out int maxmt, out int maxt,out int ten)
		{
			if (list.Count == 0)
			{
				maxmt = 10;
				maxt = 10;
				ten = 10;
			}
			else
			{
				maxmt = list[0].Mota.Length;
				maxt = list[0].Tenkhoa.Length;
				ten = list[0].Giangvien.TenGV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxt < list[i].Tenkhoa.Length)
						maxt = list[i].Tenkhoa.Length;
					if (ten < list[i].Giangvien.TenGV.Length)
						ten = list[i].Giangvien.TenGV.Length;
				}
			}
		}
		public int Hien(List<Khoa> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int maxmt;
			int maxt,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			Max(list, out maxmt, out maxt,out ten);
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ KHOA");
			Console.SetCursorPosition(x + 16, y); Console.Write("TÊN KHOA");
			Console.SetCursorPosition(x + 25 +maxt, y); Console.Write("TÊN TRƯỞNG KHOA");
			Console.SetCursorPosition(x + 35 + maxt+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x +40 + maxt +ten+ maxmt, y); Console.Write("TRẠNG THÁI");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Makhoa);
				Console.SetCursorPosition(x + 16, y); Console.Write(list[i].Tenkhoa);
				Console.SetCursorPosition(x + 25 + maxt, y); Console.Write(list[i].Giangvien.TenGV);
				 Console.SetCursorPosition(x + 35 +ten+maxt, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 40 +ten+ maxt + maxmt, y); Console.Write(list[i].Trangthai);
				if ((d+1) == n) break;
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
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN KHOA---------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã khoa:                       Tên khoa:                                       Mã trưởng khoa : ");
				Console.WriteLine();
				Console.WriteLine("Mô tả :");
				Console.WriteLine();
				Console.WriteLine("Trạng thái:");
				int x = 0, y = 13;
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				Khoa s = new Khoa();
				s.Makhoa = Project_1.Utility.Congcu.Ma(10, 5, 0, 13, s.Makhoa, 3, "Nhập sai dữ liệu mã khoa gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
				s.Tenkhoa = Project_1.Utility.Congcu.Ten(42, 5, 0, 13, s.Tenkhoa, "Nhập sai dữ liệu, tên khoa phải khác rỗng vui lòng nhập lại dữ liệu !");
				while(true)
				{
					s.Matruongkhoa = Project_1.Utility.Congcu.Ma(95, 5, 0, 13, s.Matruongkhoa, 8, "Nhập sai dữ liệu mã trưởng khoa gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistKTGV(s.Matruongkhoa))
						break;
					else
					{
						Console.SetCursorPosition(0,13);Console.Write("Mã trưởng khoa này không tồn tại ! vui lòng nhập lại đúng với mã giảng viên !!!");
						Console.SetCursorPosition(95, 5); Console.Write("                                 ");
					}
				}	
				s.Mota = Project_1.Utility.Congcu.Ten(8, 7, 0, 13, s.Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Trangthai = Project_1.Utility.Congcu.Ten(15, 9, 0, 13, s.Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
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

		static void Bang(Khoa a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã khoa :              ║                                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên khoa :             ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Mô tả :                ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Trạng thái :           ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║  Mã trưởng khoa :        ║                                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 27); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Makhoa);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tenkhoa);
			Console.SetCursorPosition(80, 13); Console.Write(a.Mota);
			Console.SetCursorPosition(80, 16); Console.Write(a.Trangthai);
			Console.SetCursorPosition(80, 19); Console.Write(a.Matruongkhoa);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 0, "                        DANH SÁCH NGÀNH ", "Nhập MÃ Khoa cần sửa, thoát nhập 0!", 20);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Makhoa == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã khoa                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên khoa                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mô tả                     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa trạng thái                ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa mã trưởng khoa            ║                                             ║");
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
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Makhoa, 3, "Nhập sai dữ liệu mã Khoa gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
										Console.SetCursorPosition(50, 25); Console.WriteLine("Khoa đã sửa thành công !!!                          ");
										Khoa m = new Khoa(tg, BL.GetAllData()[i].Tenkhoa, BL.GetAllData()[i].Matruongkhoa, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai);
										BL.Edit(ma, m);
										Console.ReadKey();
										break;
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string ten = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tenkhoa, "Nhập sai dữ liệu, tên Khoa phải khác rỗng vui lòng nhập lại dữ liệu !");
									Console.SetCursorPosition(50, 25); Console.WriteLine("Khoa đã sửa thành công !!!                             ");
									Khoa m2 = new Khoa(BL.GetAllData()[i].Makhoa, ten, BL.GetAllData()[i].Matruongkhoa, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai);
									BL.Edit(ma, m2);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string mota = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
									Khoa m3 = new Khoa(BL.GetAllData()[i].Makhoa, BL.GetAllData()[i].Tenkhoa, BL.GetAllData()[i].Matruongkhoa, mota, BL.GetAllData()[i].Trangthai);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Khoa đã sửa thành công !!!                                ");
									BL.Edit(ma, m3);
									Console.ReadKey();
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									string trangthai = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
									Khoa m4 = new Khoa(BL.GetAllData()[i].Makhoa, BL.GetAllData()[i].Tenkhoa, BL.GetAllData()[i].Matruongkhoa, BL.GetAllData()[i].Mota, trangthai);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Khoa đã sửa thành công !!!                            ");
									BL.Edit(ma, m4);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									while (true)
									{
										int mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Matruongkhoa, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
										if (BL.ExistKTGV(mpt))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Khoa đã sửa thành công !!!                          ");
											Khoa m5 = new Khoa(BL.GetAllData()[i].Makhoa, BL.GetAllData()[i].Tenkhoa, mpt, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai);
											BL.Edit(ma, m5);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
											Console.SetCursorPosition(80, 19); Console.WriteLine("                          ");
										}
									}
									break;
								case 6:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									while (true)
									{
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Makhoa, 4, "Nhập sai dữ liệu mã Khoa gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
										string ten1 = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tenkhoa, "Nhập sai dữ liệu, tên Khoa phải khác rỗng vui lòng nhập lại dữ liệu !");
										string mota1 = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
										string trangthai1 = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
										int mpt;
										while (true)
										{
											mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Matruongkhoa, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
											if (BL.ExistKTGV(mpt))
											{
												break;
											}
											else
											{
												Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
												Console.SetCursorPosition(80, 19); Console.WriteLine("                          ");
											}
										}
										Khoa sv6 = new Khoa(tg, ten1, mpt, mota1, trangthai1);
										Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("Khoa đã sửa thành công !!!                          ");
										BL.Edit(ma, sv6);
										Console.ReadKey();
										break;
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
							Console.SetCursorPosition(10, BL.GetAllData().Count + 2); Console.WriteLine("Mã khoa không tồn tại ");
					}
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
				Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐      QUẢN LÝ KHOA      ▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.Write("\t\t║                        ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                   ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                                                                                                      ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin khoa           ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin khoa       ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Sửa thông tin ngành           ║                                             ║");
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
						Sua();
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
