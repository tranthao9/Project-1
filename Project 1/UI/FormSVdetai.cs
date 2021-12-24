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
	public class FormSVdetai
	{
		private ISVDetaiBusiness BL= new SVDetaiBusiness();
		public void Max(List<SVDetai> list, out int maxht, out int gvhd, out int gvpb)
		{
			if (list.Count == 0)
			{
				maxht = 10;
				gvhd = 10;
				gvpb = 10;
			}
			else
			{
				maxht = list[0].LopSV.Sinhvien.TenSV.Length;
				gvhd = list[0].GiangvienHD.TenGV.Length;
				gvpb = list[0].GiangvienPB.TenGV.Length;
				for (int i = 1; i < list.Count; ++i)
				{
					if (maxht < list[i].LopSV.Sinhvien.TenSV.Length)
						maxht = list[i].LopSV.Sinhvien.TenSV.Length;
					if (gvhd < list[i].GiangvienHD.TenGV.Length)
						gvhd = list[i].GiangvienHD.TenGV.Length;
					if (gvpb < list[i].GiangvienPB.TenGV.Length)
						gvpb = list[i].GiangvienPB.TenGV.Length;
				}
			}
		}
		public int Hien(List<SVDetai> list, int x, int y, string tieudecuoi, int n)
		{
			int tsv, tengvhd, tengvpb;
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (Project_1.Utility.Congcu.getname(list[i].LopSV.Sinhvien.TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.getname(list[j].LopSV.Sinhvien.TenSV.ToLower())) < 0)
					{
						SVDetai tg = list[i];
						list[i] = list[j];
						list[j] = tg;
					}
					else if (Project_1.Utility.Congcu.getname(list[i].LopSV.Sinhvien.TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.getname(list[j].LopSV.Sinhvien.TenSV.ToLower())) == 0)
					{
						if (Project_1.Utility.Congcu.firstname(list[i].LopSV.Sinhvien.TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.firstname(list[j].LopSV.Sinhvien.TenSV.ToLower())) < 0)
						{
							SVDetai tg = list[i];
							list[i] = list[j];
							list[j] = tg;
						}
						else if(Project_1.Utility.Congcu.firstname(list[i].LopSV.Sinhvien.TenSV.ToLower()).CompareTo(Project_1.Utility.Congcu.firstname(list[j].LopSV.Sinhvien.TenSV.ToLower())) < 0)
						{
							if(list[i].Tuandt.Detai.Mada < list[j].Tuandt.Detai.Mada)
							{
								SVDetai tg = list[i];
								list[i] = list[j];
								list[j] = tg;
							}	
						}	
					}
				}
			}	
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐     DANH SÁCH SV ĐỀ TÀI   ▌                                                    ");
			Console.WriteLine("\t\t\t\t\t\t\t\t▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                    ");
			Console.ForegroundColor = ConsoleColor.Black;
			y = y + 4;
			Max(list,out tsv,out tengvhd,out tengvpb);
			Console.ForegroundColor = ConsoleColor.DarkBlue; Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 7, y); Console.Write("MÃ SV");
			Console.SetCursorPosition(x + 15, y); Console.Write("MÃ ĐỀ TÀI");
			Console.SetCursorPosition(x + 26, y); Console.Write("TÊN SINH VIÊN");
			Console.SetCursorPosition(x + 29+tsv, y); Console.Write("ĐỒ ÁN");
			Console.SetCursorPosition(x + 39+tsv, y); Console.Write("TÊN GVHD");
			Console.SetCursorPosition(x + 49 + tsv+ tengvhd, y); Console.Write("TÊN GVPB");
			Console.SetCursorPosition(x + 55 + tsv + tengvpb + tengvhd, y); Console.Write("ĐIỂM BV");
			Console.SetCursorPosition(x + 64 + tsv + tengvpb + tengvhd, y); Console.Write("ĐIỂM GVHD");
			Console.SetCursorPosition(x + 77 + tsv + tengvpb + tengvhd, y); Console.Write("ĐIỂM GVPB");
			Console.SetCursorPosition(x + 88 + tsv + tengvpb + tengvhd, y); Console.Write("TỔNG ĐIỂM");
			Console.SetCursorPosition(x + 100 + tsv + tengvpb + tengvhd, y); Console.Write("XẾP LOẠI");
			Console.SetCursorPosition(x + 115 + tsv + tengvpb + tengvhd, y); Console.Write("ĐÁNH GIÁ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 5, y); Console.Write(list[i].LopSV.MaSV);
				Console.SetCursorPosition(x + 15, y); Console.Write(list[i].Madetai);
				Console.SetCursorPosition(x + 25, y); Console.Write(list[i].LopSV.Sinhvien.TenSV);
				Console.SetCursorPosition(x + 29 + tsv, y); Console.Write(list[i].Tuandt.Detai.Mada);
				Console.SetCursorPosition(x + 39 + tsv , y); Console.Write(list[i].GiangvienHD.TenGV);
				Console.SetCursorPosition(x + 49 + tsv +tengvhd, y); Console.Write(list[i].GiangvienPB.TenGV);
				Console.SetCursorPosition(x + 55 + tsv + tengvpb + tengvhd, y); Console.Write(list[i].DiemBV);
				Console.SetCursorPosition(x + 64 + tsv  + tengvpb + tengvhd, y); Console.Write(list[i].DiemGVHD);
				Console.SetCursorPosition(x + 77 + tsv  + tengvpb + tengvhd, y); Console.Write(BL.Diemgvpb( list[i]));
				Console.SetCursorPosition(x + 88 + tsv  + tengvpb + tengvhd, y); Console.Write(BL.TongDiem( list[i]));
				Console.SetCursorPosition(x + 100 + tsv  + tengvpb + tengvhd, y); Console.Write(BL.xeploai( list[i]));
				Console.SetCursorPosition(x + 115 + tsv  + tengvpb + tengvhd, y); Console.Write(BL.Danhgia( list[i]));
				if ((d) == n + 1) break;
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.Write(tieudecuoi);
			return Console.CursorTop;
		}
		public void Nhap()
		{
			ITuanDetaiBusiness T = new TuanDetaiBusiness();
			Console.OutputEncoding = Encoding.Unicode;
			Console.InputEncoding = Encoding.Unicode;
			do
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("--------------------------------NHẬP THÔNG TIN ĐỀ TÀI SINH VIÊN--------------------------------");
				Console.WriteLine();
				Console.WriteLine("*************************************************************************************");
				Console.WriteLine();
				Console.WriteLine("Mã đề tài:                                          Mã sinh viên: ");
				Console.WriteLine();
				Console.WriteLine("Mã giáo viên hướng dẫn:                             Điểm GVHD : ");
				Console.WriteLine();
				Console.WriteLine("Mã giáo viên phản biện:                             Điểm bảo vệ : ");
				int x = 0, y = 11;
				int v = Hien(BL.GetAllData(), x, y, "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", BL.GetAllData().Count);
				SVDetai s = new SVDetai();
				while (true)
				{
					Console.SetCursorPosition(12, 5); s.Madetai = int.Parse(Console.ReadLine());
					if (BL.ExistDT(s.Madetai) && !(BL.ExistSV1(s.Madetai)))
					{
						break;
					}
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã đề tài chưa tồn tại hoặc đề tài này đã có người làm! vui lòng nhập lại !!!");

					}
					Console.SetCursorPosition(12, 5); Console.WriteLine("                   ");

				}
				while (true)
				{
					s.MaSV = Project_1.Utility.Congcu.Ma(70, 5, 0, 11, s.MaSV, 8, "Định dạng không hợp lệ, mã sinh viên phải gồm 8 chữ số !");
					if (BL.ExistSV(s.MaSV) && BL.ExistSV2(s.Madetai, s.MaSV))
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.Write("Mã sinh viên này chưa tồn tại hoặc đã hoàn thiện đồ án này !!! Vui lòng nhập mã sinh viên khác!");

					}

					Console.SetCursorPosition(70, 5); Console.WriteLine("                   ");
				}
				while (true)
				{
					s.MaGVHD = Project_1.Utility.Congcu.Ma(27, 7, 0, 11, s.MaGVHD, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !                                             ");
					if (BL.ExistGV(s.MaGVHD))
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Mã giảng viên viên này chưa tồn tại !!!                                                                          ");
						Console.SetCursorPosition(27, 7); Console.WriteLine("                   ");
					}
				}
				while (true)
				{
					s.MaGVPB = Project_1.Utility.Congcu.Ma(27, 9, 0, 11, s.MaGVPB, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !                                                           ");
					if (BL.ExistGV(s.MaGVPB) && s.MaGVPB != s.MaGVHD)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Mã giảng viên viên này chưa tồn tại hoặc đã trùng với mã GVHD !!!                                                                     ");
						Console.SetCursorPosition(27, 7); Console.WriteLine("                   ");
					}
				}
				while (true)
				{
					if (!T.ExistKT(s.Madetai) || !BL.ExistTDT(s.Madetai))
					{
						Console.SetCursorPosition(70, 7); s.DiemGVHD = 0; Console.WriteLine(s.DiemGVHD);
						break;
					}
					else
					{
						Console.SetCursorPosition(70, 7); s.DiemGVHD = double.Parse(Console.ReadLine());
						if (s.DiemGVHD >= .0 && s.DiemGVHD <= 10.0)
							break;
						else
						{
							Console.SetCursorPosition(0, 11); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10                                                                                   ");

						}
						Console.SetCursorPosition(70, 7); Console.WriteLine("                   ");
					}


				}
				while (true)
				{
					if (!T.ExistKT(s.Madetai))
					{
						Console.SetCursorPosition(70, 9); s.DiemBV = 0; Console.WriteLine(s.DiemBV);
						break;
					}
					Console.SetCursorPosition(70, 9); s.DiemBV = double.Parse(Console.ReadLine());
					if (s.DiemBV >= .0 && s.DiemBV <= 10.0)
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10                                                                       ");

					}
					Console.SetCursorPosition(70, 9); Console.WriteLine("                   ");

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
				Hien(BL.GetAllData(), 0,3, "Nhập mã đề tài cần xóa, thoát nhập 0!", BL.GetAllData().Count);
				int ma = int.Parse("0" + Console.ReadLine());
				if (ma == 0 ) return;
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
			Console.WriteLine("\t\t\t\t\t\t\t\t║   2. Theo mã sinh viên       ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   3. Theo mã GVHD            ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   4. Theo mã GVPB            ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   5. Theo mã đồ án           ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   6. Theo đánh giá           ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   7. Theo xếp loại           ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║══════════════════════════════║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║                              ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t║   0. Exit                    ║");
			Console.WriteLine("\t\t\t\t\t\t\t\t╚══════════════════════════════╝");
			Console.WriteLine();
			Console.WriteLine();
			Console.SetCursorPosition(65, 32); Console.Write("Nhập lựa chọn : "); int n = int.Parse(Console.ReadLine());
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
							foreach(var a in BL.GetAllData())
							{
								if (a.Lop() == i)
									list.Add(a);

							}	
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã sinh viên        ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int a = int.Parse(Console.ReadLine());
						if (BL.ExistKTSV(a))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0,a,0,0,0,0));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã GVHD             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int i = int.Parse(Console.ReadLine());
						if (BL.ExistKTGVHD(i))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0, 0, i,0,0, 0));
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
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║    Nhập mã GVPB             ║                                    ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(90, 2); Console.SetCursorPosition(80, 2); int s = int.Parse(Console.ReadLine());
						if (BL.ExistKTGVPB(s))
						{
							List<SVDetai> list = BL.Tim(new SVDetai(0, 0, 0, s,0,0));
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
				case 5:
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
							Hien(list, 0, 6, "Nhấn 0 để thoát! ", list.Count);
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
				case 6:
					do
					{
						Console.Clear();
						Console.SetCursorPosition(0, 0); Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════╗");
						Console.SetCursorPosition(0, 1); Console.WriteLine("\t\t\t\t\t\t║                             ║                                    ║");
						Console.SetCursorPosition(0, 2); Console.WriteLine("\t\t\t\t\t\t║ 1. Đạt                      ║  2. KHông đạt                      ║");
						Console.SetCursorPosition(0, 3); Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════╝");
						Console.SetCursorPosition(50, 5);Console.Write("Nhập lựa chọn : "); int c = int.Parse(Console.ReadLine());
						List<SVDetai> list = new List<SVDetai>();
						if (c==1)
						{
							
							foreach (var a in BL.GetAllData())
							{
								if (BL.Danhgia(a) == "Đạt")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
						}	
						else if(c==2)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.Danhgia(a) == "KHông đạt")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
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
				case 7:
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
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 2)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Giỏi")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 3)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Khá")
									list.Add(a);

							}
							Hien(list, 0,10, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 4)
						{
							
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "TB khá")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 5)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Trung bình")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
						}
						else if (c == 6)
						{
							foreach (var a in BL.GetAllData())
							{
								if (BL.xeploai(a) == "Yếu")
									list.Add(a);

							}
							Hien(list, 0, 10, "Nhấn 0 để thoát! ", list.Count);
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
		static void Bang(SVDetai a)
		{
			Console.Clear();
			Console.SetCursorPosition(50, 5); Console.Write("╔══════════════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(50, 6); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 7); Console.Write("║   Mã sinh viên :         ║                                                       ║");
			Console.SetCursorPosition(50, 8); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 9); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 10); Console.Write("║   Mã đề tài :            ║                                                       ║");
			Console.SetCursorPosition(50, 11); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 12); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 13); Console.Write("║  Mã GVHD :               ║                                                       ║");
			Console.SetCursorPosition(50, 14); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 15); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 16); Console.Write("║   Mã GVPB :              ║                                                       ║");
			Console.SetCursorPosition(50, 17); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 18); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 19); Console.Write("║   Điểm bảo vệ :          ║                                                       ║");
			Console.SetCursorPosition(50, 20); Console.Write("║══════════════════════════════════════════════════════════════════════════════════║");
			Console.SetCursorPosition(50, 21); Console.Write("║                          ║                                                       ║");
			Console.SetCursorPosition(50, 22); Console.Write("║   Điểm GVHD :            ║                                                       ║");
			Console.SetCursorPosition(50, 23); Console.Write("╚══════════════════════════════════════════════════════════════════════════════════╝");
			Console.SetCursorPosition(50, 25); Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
			Console.SetCursorPosition(80, 7); Console.Write(a.MaSV);
			Console.SetCursorPosition(80, 10); Console.Write(a.Madetai);
			Console.SetCursorPosition(80, 13); Console.Write(a.MaGVHD);
			Console.SetCursorPosition(80, 16); Console.Write(a.MaGVPB);
			Console.SetCursorPosition(80, 19); Console.Write(a.DiemBV);
			Console.SetCursorPosition(80, 22); Console.Write(a.DiemGVHD);
		}
		public void Sua()
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Black; ;
				Console.Clear();
				Hien(BL.GetAllData(), 0, 0, "Nhập MÃ sinh viên và mã đề tài cần sửa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã sinh viên : ");
				int ma = int.Parse(Console.ReadLine());
				Console.Write("Nhập mã đề tài  : "); int ma2 = int.Parse(Console.ReadLine());
				if (ma == 0 || ma2 == 0) return;
				else
				{
					int d = 0;
					for (int i = 0; i < BL.GetAllData().Count; i++)
					{
						if (BL.GetAllData()[i].MaSV == ma && BL.GetAllData()[i].Madetai == ma2)
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
							Console.WriteLine("\t\t║                                                  ║     2.Sửa mã đề tài                 ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa mã GVHD                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     4.Sửa mã GVPB                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     2.Sửa điểm BV                   ║                                             ║");
							Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
							Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
							Console.WriteLine("\t\t║                                                  ║     3.Sửa điểm GV                   ║                                             ║");
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
										int masv = Project_1.Utility.Congcu.Ma(80, 7, 50,25, BL.GetAllData()[i].MaSV, 8, "Định dạng không hợp lệ, mã sinh viên phải gồm 8 chữ số !");
										if (BL.ExistSV(masv) && BL.ExistSV2(BL.GetAllData()[i].Madetai, masv))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(BL.GetAllData()[i].Madetai,masv, BL.GetAllData()[i].MaGVHD, BL.GetAllData()[i].MaGVPB, BL.GetAllData()[i].DiemGVHD, BL.GetAllData()[i].DiemBV);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}											
												
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã sinh viên này chưa tồn tại hoặc đã hoàn thiện đồ án này !!!");
										}
										Console.SetCursorPosition(80,7); Console.WriteLine("                   ");
									}
									break;
								case 2:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80, 10); int madetai = int.Parse(Console.ReadLine());
										if (BL.ExistDT(madetai) && !(BL.ExistSV1(madetai)))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(madetai, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].MaGVHD, BL.GetAllData()[i].MaGVPB, BL.GetAllData()[i].DiemGVHD, BL.GetAllData()[i].DiemBV);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Mã đề tài chưa tồn tại hoặc đề tài này đã có người làm! vui lòng nhập lại !!!");

										}
										Console.SetCursorPosition(80,10); Console.WriteLine("                   ");

									}
									break;
								case 3:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									while (true)
									{
										int magvhd = Project_1.Utility.Congcu.Ma(80,13,50,25, BL.GetAllData()[i].MaGVHD, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
										if (BL.ExistGV(magvhd))
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].MaSV,magvhd, BL.GetAllData()[i].MaGVPB, BL.GetAllData()[i].DiemGVHD, BL.GetAllData()[i].DiemBV);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Mã giảng viên viên này chưa tồn tại !!!");
											Console.SetCursorPosition(80,13); Console.WriteLine("                   ");
										}
									}
									break;
								case 4:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									while (true)
									{
										int magvpb = Project_1.Utility.Congcu.Ma(80,16,50,25, BL.GetAllData()[i].MaGVPB, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
										if (BL.ExistGV(magvpb) && magvpb != BL.GetAllData()[i].MaGVHD)
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].MaGVHD, magvpb, BL.GetAllData()[i].DiemGVHD, BL.GetAllData()[i].DiemBV);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Mã giảng viên viên này chưa tồn tại hoặc đã trùng với mã GVHD !!!");
											Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");
										}
									}
									break;
								case 5:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80,19); double a = double.Parse(Console.ReadLine());
										if (a >= .0 && a <= 10.0)
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].MaGVHD, BL.GetAllData()[i].MaGVPB, BL.GetAllData()[i].DiemGVHD, a);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

										}
										Console.SetCursorPosition(80,19); Console.WriteLine("                   ");

									}
									break;
								case 6:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									while (true)
									{
										Console.SetCursorPosition(80,22); double b= double.Parse(Console.ReadLine());
										if (b >= .0 && b <= 10.0)
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                           ");
											SVDetai m = new SVDetai(BL.GetAllData()[i].Madetai, BL.GetAllData()[i].MaSV, BL.GetAllData()[i].MaGVHD, BL.GetAllData()[i].MaGVPB,b, BL.GetAllData()[i].DiemBV);
											BL.Edit(ma, ma2, m);
											Console.ReadKey();
											break;
										}	
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

										}
										Console.SetCursorPosition(80,22); Console.WriteLine("                   ");

									}
									break;
								case 7:
									Bang(BL.GetAllData()[i]);
									Console.SetCursorPosition(80, 7); Console.Write("                        ");
									Console.SetCursorPosition(80, 10); Console.Write("                        ");
									Console.SetCursorPosition(80, 13); Console.Write("                        ");
									Console.SetCursorPosition(80, 16); Console.Write("                        ");
									Console.SetCursorPosition(80, 19); Console.Write("                        ");
									Console.SetCursorPosition(80, 22); Console.Write("                        ");
									int sv,detai,hd,pb;
									double diem1,diem2;
									while (true)
									{
										sv = Project_1.Utility.Congcu.Ma(80, 7, 50, 25, BL.GetAllData()[i].MaSV, 8, "Định dạng không hợp lệ, mã sinh viên phải gồm 8 chữ số !");
										if (BL.ExistSV(sv) && BL.ExistSV2(BL.GetAllData()[i].Madetai, sv))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã sinh viên này chưa tồn tại hoặc đã hoàn thiện đồ án này !!!");
										}
										Console.SetCursorPosition(80, 7); Console.WriteLine("                   ");
									}
									while (true)
									{
										Console.SetCursorPosition(80, 10); detai = int.Parse(Console.ReadLine());
										if (BL.ExistDT(detai) && !(BL.ExistSV1(detai)))
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã đề tài chưa tồn tại hoặc đề tài này đã có người làm! vui lòng nhập lại !!!");
										}
										Console.SetCursorPosition(80, 10); Console.WriteLine("                   ");
									}
									while (true)
									{
										hd = Project_1.Utility.Congcu.Ma(80, 13, 50, 25, BL.GetAllData()[i].MaGVHD, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
										if (BL.ExistGV(hd))
										{
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên viên này chưa tồn tại !!!");
											Console.SetCursorPosition(80, 13); Console.WriteLine("                   ");
										}
									}
									while (true)
									{
										pb = Project_1.Utility.Congcu.Ma(80, 16, 50, 25, BL.GetAllData()[i].MaGVPB, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
										if (BL.ExistGV(pb) && pb != BL.GetAllData()[i].MaGVHD)
										{
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50, 25); Console.WriteLine("Mã giảng viên viên này chưa tồn tại hoặc đã trùng với mã GVHD !!!");
											Console.SetCursorPosition(80, 16); Console.WriteLine("                   ");
										}
									}
									while (true)
									{
										Console.SetCursorPosition(80,19); diem1 = double.Parse(Console.ReadLine());
										if (diem1 >= .0 && diem1 <= 10.0)
										{
											Console.ReadKey();
											break;
										}
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

										}
										Console.SetCursorPosition(80,19); Console.WriteLine("                   ");

									}
									while (true)
									{
										Console.SetCursorPosition(80,22); diem2 = double.Parse(Console.ReadLine());
										if (diem2 >= .0 && diem2 <= 10.0)
										{
											break;
										}
										else
										{
											Console.SetCursorPosition(50,25); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

										}
										Console.SetCursorPosition(80,22); Console.WriteLine("                   ");

									}
									SVDetai ta = new SVDetai(detai,sv,hd,pb,diem2,diem1);
									BL.Edit(ma, ma2, ta);
									Console.SetCursorPosition(50, 25); Console.WriteLine("Đã sửa thành công !!!                                                                          ");
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
				Console.Write("                             ▐      QUẢN LÝ SV ĐỀ TÀI      ▌                                                  ");
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
				Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin SV đề tài      ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm SV đề tài            ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin SV đề tài       ║                                             ║");
				Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
				Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
				Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin SV đề tài       ║                                             ║");
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
