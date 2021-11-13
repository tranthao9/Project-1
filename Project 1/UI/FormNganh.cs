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
	public class FormNganh
	{
		private INganhBusiness BL = new NganhBusiness();
		public void Max(List<Nganh> list, out int maxmt, out int maxtrangthai,out int maxt,out int ten)
		{
			if (list.Count == 0)
			{
				maxmt = 10;
				maxtrangthai = 10;
				maxt = 10;
				ten = 10;
			}
			else
			{
				maxmt = list[0].Mota.Length;
				maxtrangthai = list[0].Trangthai.Length;
				maxt = list[0].Tennganh.Length;
				ten = list[0].Giangvien.TenGV.Length;
				for (int i = 1; i < list.Count; i++)
				{
					if (maxmt < list[i].Mota.Length)
						maxmt = list[i].Mota.Length;
					if (maxtrangthai < list[i].Trangthai.Length)
						maxtrangthai = list[i].Trangthai.Length;
					if (maxt < list[i].Tennganh.Length)
						maxt = list[i].Tennganh.Length;
					if (ten < list[i].Giangvien.TenGV.Length)
						ten = list[i].Giangvien.TenGV.Length;
				}
			}
		}
		public int Hien(List<Nganh> list, int x, int y, string tieudecuoi, int n)
		{
			int maxmt; ;
			int maxtrangthai;
			int maxt,ten;
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐      DANH SÁCH NGÀNH      ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			Max(list, out maxmt, out maxtrangthai,out maxt,out ten);
			y = y + 4;
			Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 6, y); Console.Write("MÃ NGÀNH");
			Console.SetCursorPosition(x + 16, y); Console.Write("TÊN NGÀNH");
			Console.SetCursorPosition(x + 20 + maxt, y); Console.Write("TÊN TRƯỞNG NGÀNH");
			Console.SetCursorPosition(x + 30+maxt+ten, y); Console.Write("MÔ TẢ");
			Console.SetCursorPosition(x + 35+ten+maxt+maxmt, y); Console.Write("TRẠNG THÁI");
			Console.SetCursorPosition(x + 40+ten+maxt+maxmt+maxtrangthai, y); Console.Write("MÃ KHOA");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 6, y); Console.Write(list[i].Manganh);
				Console.SetCursorPosition(x + 16, y); Console.Write(list[i].Tennganh);
				Console.SetCursorPosition(x + 20 + maxt, y); Console.Write(list[i].Giangvien.MaGV);
				Console.SetCursorPosition(x + 30+ten + maxt, y); Console.Write(list[i].Mota);
				Console.SetCursorPosition(x + 35+ten + maxt + maxmt, y); Console.Write(list[i].Trangthai);
				Console.SetCursorPosition(x + 40+ten + maxt + maxmt + maxtrangthai, y); Console.Write(list[i].Makhoa);
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
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN NGÀNH---------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã ngành:                       Tên ngành :                             Mã trưởng ngành : ");
				Console.WriteLine();
				Console.WriteLine("Mô tả :");
				Console.WriteLine();
				Console.WriteLine("Trạng thái:");
				int x = 0, y = 15;
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				Nganh s = new Nganh();
				s.Manganh = Project_1.Utility.Congcu.Ma(10, 5, 0, 13, s.Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
				s.Tennganh = Project_1.Utility.Congcu.Ten(42, 5, 0, 13, s.Tennganh, "Nhập sai dữ liệu, tên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
				while(true)
				{
					
					s.Matruongnganh = Project_1.Utility.Congcu.Ma(85, 5, 0, 13, s.Matruongnganh, 8, "Nhập sai dữ liệu mã giảng viên gồm 8 chữ số và khác 0 vui lòng nhập lại ! ");
					if (BL.ExistGV(s.Matruongnganh))
						break;
					else
					{
						Console.SetCursorPosition(0, 13);Console.Write("Mã này chưa tồn tại !!! ");
						Console.SetCursorPosition(85, 5); Console.Write("                        ");
					}	
				}
				s.Mota = Project_1.Utility.Congcu.Ten(8, 7, 0, 13, s.Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Trangthai = Project_1.Utility.Congcu.Ten(15, 9, 0, 13, s.Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
				s.Makhoa = 100;
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
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ ngành cần xóa, thoát nhập 0!", 20);
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
			Console.WriteLine("\t\t\t\t\t\t\t\t║   1. Theo mã ngành           ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo tên ngành          ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║"); ;
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   3. Theo mã trưởng ngành    ║");
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã ngành            ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.Exist(i))
						{
							List<Nganh> list = BL.TimNganh(new Nganh(i, null, 0,null,null,0));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 2. Nhập tên ngành           ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); string a = Console.ReadLine();
						if (BL.ExistTEN(a))
						{
							List<Nganh> list = BL.TimNganh(new Nganh(0, a, 0,null,null,0));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Nhập mã trưởng ngành     ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistTN(i))
						{
							List<Nganh> list = BL.TimNganh(new Nganh(0, null, i,null,null,0));
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
		static void Bang(Nganh a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã ngành :             ║                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Tên ngành :            ║                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║   Mô tả :                ║                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Trạng thái :           ║                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║  Mã trưởng ngành :       ║                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║   Mã khoa :              ║                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("╚══════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 27); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.Manganh);
			Console.SetCursorPosition(80, 10); Console.Write(a.Tennganh);
			Console.SetCursorPosition(80, 13); Console.Write(a.Mota);
			Console.SetCursorPosition(80, 16); Console.Write(a.Trangthai);
			Console.SetCursorPosition(80, 19); Console.Write(a.Matruongnganh);
			Console.SetCursorPosition(80, 22); Console.Write(a.Makhoa);
		}
		public void Sua()
		{
			do
			{
				Console.Clear();
				Hien(BL.GetAllData(), 0, 3, "Nhập MÃ NGÀNH cần sửa, thoát nhập 0!", BL.GetAllData().Count);
				int ma = int.Parse(Console.ReadLine());
				if (ma == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].Manganh == ma)
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
							Console.WriteLine("\t\t║                                                  ║     1.Sửa mã ngành                  ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa tên ngành                 ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mô tả                     ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa trạng thái                ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     5.Sửa mã trưởng ngành           ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     7.Sửa tất cả thông tin ngành    ║                                             ║");
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
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Manganh, 3, "Nhập sai dữ liệu mã ngành gồm 3 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.Exist(tg))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã chuyên ngành đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Ngành đã sửa thành công !!!                          ");
											Nganh m = new Nganh(tg, BL.GetAllData()[i].Tennganh, BL.GetAllData()[i].Matruongnganh, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Makhoa);
											BL.Edit(ma, m);
											break;
										}
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									string ten = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tennganh, "Nhập sai dữ liệu, tên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
									Console.SetCursorPosition(50, 25); Console.WriteLine("Ngành đã sửa thành công !!!                             ");
									Nganh m2 = new Nganh(BL.GetAllData()[i].Manganh, ten, BL.GetAllData()[i].Matruongnganh, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Makhoa);
									BL.Edit(ma, m2);
									Console.ReadKey();
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									string mota = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
									Nganh m3 = new Nganh(BL.GetAllData()[i].Manganh, BL.GetAllData()[i].Tennganh, BL.GetAllData()[i].Matruongnganh, mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Makhoa);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Ngành đã sửa thành công !!!                                ");
									BL.Edit(ma, m3);
									Console.ReadKey();
									break;

								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									string trangthai = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
									Nganh m4 = new Nganh(BL.GetAllData()[i].Manganh, BL.GetAllData()[i].Tennganh, BL.GetAllData()[i].Matruongnganh, BL.GetAllData()[i].Mota, trangthai, BL.GetAllData()[i].Makhoa);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Ngành đã sửa thành công !!!                            ");
									BL.Edit(ma, m4);
									Console.ReadKey();
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									while (true)
									{
										int mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Matruongnganh, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
										if (BL.ExistGV(mpt))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Ngành đã sửa thành công !!!                          ");
											Nganh m5 = new Nganh(BL.GetAllData()[i].Manganh, BL.GetAllData()[i].Tennganh, mpt, BL.GetAllData()[i].Mota, BL.GetAllData()[i].Trangthai, BL.GetAllData()[i].Makhoa);
											BL.Edit(ma, m5);
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
										int tg = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].Manganh, 4, "Nhập sai dữ liệu mã ngành gồm 4 chữ số và khác 0 vui lòng nhập lại ! ");
										if (BL.Exist(tg))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã ngành đã tồn tại vui lòng nhập mã khác ");
											Console.SetCursorPosition(80, 7); Console.WriteLine("                          ");
										}
										else
										{
											string ten1 = Project_1.Utility.Congcu.Ten(80, 10, 50, 25, BL.GetAllData()[i].Tennganh, "Nhập sai dữ liệu, tên ngành phải khác rỗng vui lòng nhập lại dữ liệu !");
											string mota1 = Project_1.Utility.Congcu.Ten(80, 13, 50, 25, BL.GetAllData()[i].Mota, "Nhập sai dữ liệu, mô tả phải khác rỗng vui lòng nhập lại dữ liệu !");
											string trangthai1 = Project_1.Utility.Congcu.Ten(80, 16, 50, 25, BL.GetAllData()[i].Trangthai, "Nhập sai dữ liệu, trạng thái phải khác rỗng vui lòng nhập lại dữ liệu !");
											int mpt;
											while (true)
											{
												mpt = Project_1.Utility.Congcu.Ma(80, 19, 50, 25, BL.GetAllData()[i].Matruongnganh, 8, "Nhập sai dữ liệu, mã giảng viên gồm 8 chữ số !");
												if (BL.ExistGV(mpt))
												{
													break;
												}
												else
												{
													Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên không tồn tại vui lòng nhập mã khác  !!");
													Console.SetCursorPosition(80, 19); Console.WriteLine("                          ");
												}
											}
											Nganh sv6 = new Nganh(tg, ten1, mpt, mota1, trangthai1, BL.GetAllData()[i].Makhoa);
											Console.SetCursorPosition(50, 28); Console.SetCursorPosition(50, 28); Console.WriteLine("Ngành đã sửa thành công !!!                          ");
											BL.Edit(ma, sv6);
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
							Console.SetCursorPosition(10, BL.GetAllData().Count + 2); Console.WriteLine("Mã Chuyên ngành không tồn tại ");
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
				Console.Write("                                 ▐      QUẢN LÝ NGÀNH     ▌                                                   ");
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin ngành          ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị tất cả ngành         ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm ngành                ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin ngành           ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin ngành           ║                                             ║");
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
