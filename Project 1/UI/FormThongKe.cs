using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Business_Layer;
using Project_1.Business_Layer.Interface;
using Project_1.Entities;
using Project_1.Utility;

namespace Project_1.UI
{
	class FormThongKe
	{
		ISVDetaiBusiness BL = new SVDetaiBusiness();
		public void Menu()
		{
			Console.WriteLine("\t\t                                              ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌");
			Console.WriteLine("\t\t                                              ▐  CHỌN THÔNG TIN MUỐN THỐNG KÊ  ▌");
			Console.WriteLine("\t\t                                              ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
			Console.WriteLine("\t\t║                           ║     1.Theo Lớp                 ║              ║     6.Theo GVHD                ║                    ║");
			Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
			Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
			Console.WriteLine("\t\t║                           ║     2.Theo chuyên ngành        ║              ║     7.Theo GVPB                ║                    ║");
			Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
			Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
			Console.WriteLine("\t\t║                           ║     3.Theo ngành               ║              ║     8.Theo đồ án               ║                    ║");
			Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
			Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
			Console.WriteLine("\t\t║                           ║     4.Theo khoa                ║              ║     9.Theo đánh giá            ║                    ║");
			Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
			Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
			Console.WriteLine("\t\t║                           ║     5.Theo Sinh Viên           ║              ║     10.Theo xếp loại           ║                    ║");
			Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
			Console.WriteLine("\t\t║                                                  ╔════════════════════════════════╗                                             ║");
			Console.WriteLine("\t\t║                                                  ║     0.Exit                     ║                                             ║");
			Console.WriteLine("\t\t║                                                  ╚════════════════════════════════╝                                             ║");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t║                                                                                                                                 ║");
			Console.WriteLine("\t\t╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(65, 42); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
			FormSVdetai s = new FormSVdetai();
			switch (n)
			{
				case 1:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã lớp              ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistKTL(i))
						{
							List<SVDetai> list = new List<SVDetai>();
							foreach (var a in BL.GetAllData())
							{
								if (a.Lop() == i)
									list.Add(a);

							}
						    s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã chuyên ngành     ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistCN(i))
						{
							List<SVDetai> list = new List<SVDetai>();
							foreach (var a in BL.GetAllData())
							{
								if (a.LopSV.Lop.Mach == i)
									list.Add(a);

							}
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
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
				case 3:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã ngành            ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistN(i))
						{
							List<SVDetai> list = new List<SVDetai>();
							foreach (var a in BL.GetAllData())
							{
								if (a.LopSV.Lop.Cn.Manganh == i)
									list.Add(a);

							}
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
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
				case 4:
					s.Hien(BL.GetAllData(), 0, 6, "Nhấn 0 để thoát! ", BL.GetAllData().Count);
					break;
				case 5:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã sinh viên        ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int a = int.Parse(Console.ReadLine());
						if (BL.ExistKTSV(a))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0, a, 0, 0, 0, 0));
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
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
				case 6:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã GVHD             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistKTGVHD(i))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0, 0, i, 0, 0, 0));
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại mã gv này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (i == 0)
							break;
					} while (true);
					break;
				case 7:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã GVPB             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int k = int.Parse(Console.ReadLine());
						if (BL.ExistKTGVPB(k))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0, 0, 0, k, 0, 0));
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại mã gv này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (k == 0)
							break;
					} while (true);
					break;
				case 8:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║  Nhập mã đồ án              ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int l = int.Parse(Console.ReadLine());
						if (BL.ExistKTDA(l))
						{
							List<SVDetai> list = new List<SVDetai>();
							foreach (var a in BL.GetAllData())
							{
								if (a.Tuandt.Detai.Mada == l)
									list.Add(a);

							}
							s.Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 5); Console.WriteLine("KHông tồn tại học kỳ này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (l == 0)
							break;
					} while (true);
					break;
				case 9:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Đạt                      ║  2. KHông đạt                      ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(50, 5); Console.Write("Nhập lựa chọn : "); int c = int.Parse(Console.ReadLine());
						List<SVDetai> list = new List<SVDetai>();
						if (c == 1)
						{

							foreach (var a in BL.GetAllData())
							{
								if (BL.Danhgia(a) == "Đạt")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên đạt tiêu chí đánh giá ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 2)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.Danhgia(a) == "KHông đạt")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên không đạt tiêu chí đánh giá ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}

						else
						{
							Console.SetCursorPosition(60, 6); Console.WriteLine("KHông tồn tại học kỳ này ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (c == 0)
							break;
					} while (true);
					break;
				case 10:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                     ║                  ║                   ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Xuất sắc         ║  2. Giỏi         ║ 3. Khá            ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t║════════════════════════════════════════════════════════════║");
						Console.SetCursorPosition(0, 4); Console.WriteLine("\t\t\t\t\t\t║                     ║                  ║                   ║");
						Console.SetCursorPosition(0, 5); Console.WriteLine("\t\t\t\t\t\t║ 4.Trung bình khá    ║  5. Trung bình   ║   6. Yếu          ║");
						Console.SetCursorPosition(0, 6); Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(50, 7); Console.Write("Nhập lựa chọn : "); int c = int.Parse(Console.ReadLine());
						List<SVDetai> list = new List<SVDetai>();
						if (c == 1)
						{

							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Xuất Sắc")
									list.Add(a);
							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên xuất sắc ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 2)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Giỏi")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên giỏi ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 3)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Khá")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên khá ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 4)
						{

							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Trung bình khá")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên trung bình khá ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 5)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Trung bình")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên trung bình ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 6)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Yếu")
									list.Add(a);

							}
							Console.ForegroundColor = ConsoleColor.Blue; Console.SetCursorPosition(50, 10); Console.WriteLine("Có tổng số {0} sinh viên yếu ", list.Count);
							Console.ForegroundColor = ConsoleColor.Black; s.Hien(list, 0, 13, "Nhấn 0 để thoát! ", list.Count);
						}
						else
						{
							Console.SetCursorPosition(60, 9); Console.WriteLine("Lựa chọn không đúng ! Tiếp tục hoặc nhấn 0 để thoát ! ");
						}
						Console.ReadKey();
						if (c == 0)
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
	}
}
