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
		public void Max(List<SVDetai> list, out int maxht, out int maxdc, out int gvhd, out int gvpb)
		{
			if (list.Count == 0)
			{
				maxht = 10;
				maxdc = 10;
				gvhd = 10;
				gvpb = 10;
			}
			else
			{
				maxht = list[0].LopSV.Sinhvien.TenSV.Length;
				maxdc = list[0].Tuandt.Detai.Tendetai.Length;
				gvhd = list[0].GiangvienHD.TenGV.Length;
				gvpb = list[0].GiangvienPB.TenGV.Length;
				for (int i = 1; i < list.Count; ++i)
				{
					if (maxht < list[i].LopSV.Sinhvien.TenSV.Length)
						maxht = list[i].LopSV.Sinhvien.TenSV.Length;
					if (maxdc < list[i].Tuandt.Detai.Tendetai.Length)
						maxdc = list[i].Tuandt.Detai.Tendetai.Length;
					if (gvhd < list[i].GiangvienHD.TenGV.Length)
						gvhd = list[i].GiangvienHD.TenGV.Length;
					if (gvpb < list[i].GiangvienPB.TenGV.Length)
						gvpb = list[i].GiangvienPB.TenGV.Length;
				}
			}
		}
		public int Hien(List<SVDetai> list, int x, int y, string tieudedau, string tieudecuoi, int n)
		{
			int tsv, tendt, tengvhd, tengvpb;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(tieudedau);
			Console.WriteLine("------------------------------------------------------");
			y = y + 4;
			Max(list,out tsv,out tendt,out tengvhd,out tengvpb);
			Console.ForegroundColor = ConsoleColor.DarkBlue; Console.SetCursorPosition(x + 1, y); Console.Write("STT");
			Console.SetCursorPosition(x + 5, y); Console.Write("MÃ SINH VIÊN");
			Console.SetCursorPosition(x + 19, y); Console.Write("MÃ LỚP");
			Console.SetCursorPosition(x + 27, y); Console.Write("TÊN SINH VIÊN");
			Console.SetCursorPosition(x + 30+tsv, y); Console.Write("ĐỒ ÁN");
			Console.SetCursorPosition(x + 37+tsv, y); Console.Write("TÊN ĐỀ TÀI");
			Console.SetCursorPosition(x + 38+tsv+tendt, y); Console.Write("TÊN GVHD");
			Console.SetCursorPosition(x + 41 + tsv + tendt + tengvhd, y); Console.Write("TÊN GVPB");
			Console.SetCursorPosition(x + 43 + tsv + tendt + tengvpb+tengvhd, y); Console.Write("ĐIỂM BV");
			Console.SetCursorPosition(x + 52 + tsv + tendt + tengvpb + tengvhd, y); Console.Write("ĐIỂM GVHD");
			Console.SetCursorPosition(x + 63 + tsv + tendt + tengvpb + tengvhd, y); Console.Write("ĐIỂM GVPB");
			Console.SetCursorPosition(x + 74 + tsv + tendt + tengvpb + tengvhd, y); Console.Write("TỔNG ĐIỂM");
			Console.SetCursorPosition(x + 86 + tsv + tendt + tengvpb + tengvhd, y); Console.Write("XẾP LOẠI");
			Console.SetCursorPosition(x + 100 + tsv + tendt + tengvpb + tengvhd, y); Console.Write("ĐÁNH GIÁ");
			int d = 1;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				y = y + 1;
				Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(x + 1, y); Console.Write(d++);
				Console.SetCursorPosition(x + 5, y); Console.Write(list[i].LopSV.MaSV);
				Console.SetCursorPosition(x + 19, y); Console.Write(list[i].LopSV.Malop);
				Console.SetCursorPosition(x + 27, y); Console.Write(list[i].LopSV.Sinhvien.TenSV);
				Console.SetCursorPosition(x + 30 + tsv, y); Console.Write(list[i].Tuandt.Detai.Mada);
				Console.SetCursorPosition(x + 37 + tsv, y); Console.Write(list[i].Tuandt.Detai.Tendetai);
				Console.SetCursorPosition(x + 38 + tsv + tendt, y); Console.Write(list[i].GiangvienHD.TenGV);
				Console.SetCursorPosition(x + 41 + tsv + tendt + tengvhd, y); Console.Write(list[i].GiangvienPB.TenGV);
				Console.SetCursorPosition(x + 43 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(list[i].DiemBV);
				Console.SetCursorPosition(x + 52 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(list[i].DiemGVHD);
				Console.SetCursorPosition(x + 63 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(BL.Diemgvpb( list[i]));
				Console.SetCursorPosition(x + 74 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(BL.TongDiem( list[i]));
				Console.SetCursorPosition(x + 86 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(BL.xeploai( list[i]));
				Console.SetCursorPosition(x + 100 + tsv + tendt + tengvpb + tengvhd, y); Console.Write(BL.Danhgia( list[i]));
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
				int v = Hien(BL.GetAllData(), x, y, "                       DANH SÁCH ĐÃ NHẬP", "Enter để lưu, Nhấn ESC để thoát và lưu ,phím bất kỳ thoát nhưng không lưu!!! ", 5);
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
				while(true)
				{
					s.MaSV = Project_1.Utility.Congcu.Ma(70, 5, 0, 11, s.MaSV, 8, "Định dạng không hợp lệ, mã sinh viên phải gồm 8 chữ số !");
					if (BL.ExistSV(s.MaSV) && BL.ExistSV2(s.Madetai,s.MaSV))
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Mã sinh viên này chưa tồn tại hoặc đã hoàn thiện đồ án này !!!");
					}
					Console.SetCursorPosition(70, 5); Console.WriteLine("                   ");
				}
				while (true)
				{
					s.MaGVHD = Project_1.Utility.Congcu.Ma(27, 7, 0, 11, s.MaSV, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
					if (BL.ExistGV(s.MaGVHD))
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Mã giảng viên viên này chưa tồn tại !!!");
						Console.SetCursorPosition(27, 7); Console.WriteLine("                   ");
					}
				}
				while (true)
				{
					s.MaGVPB = Project_1.Utility.Congcu.Ma(27, 9, 0, 11, s.MaSV, 8, "Định dạng không hợp lệ, mã giảng viên phải gồm 8 chữ số !");
					if (BL.ExistGV(s.MaGVPB) && s.MaGVPB != s.MaGVHD)
						break;
					else
					{
						Console.SetCursorPosition(0, 9); Console.WriteLine("Mã giảng viên viên này chưa tồn tại hoặc đã trùng với mã GVHD !!!");
						Console.SetCursorPosition(27, 7); Console.WriteLine("                   ");
					}
				}
				while (true)
				{
					Console.SetCursorPosition(70, 7); s.DiemGVHD = double.Parse(Console.ReadLine());
					if (s.DiemGVHD >= .0 && s.DiemGVHD <= 10.0)
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

					}
					Console.SetCursorPosition(70,7); Console.WriteLine("                   ");

				}
				while (true)
				{
					Console.SetCursorPosition(70, 9); s.DiemBV = double.Parse(Console.ReadLine());
					if (s.DiemBV >= .0 && s.DiemBV<= 10.0)
						break;
					else
					{
						Console.SetCursorPosition(0, 11); Console.WriteLine("Điểm bảo vệ sai! điểm chỉ nằm trong khoảng từ 0-10");

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
				ISVDetaiBusiness Bl = new SVDetaiBusiness();
				Hien(Bl.GetAllData(), 0, 0, "                        DANH SÁCH ĐỀ TÀI SINH VIÊN ", "Nhập tuần cần xóa, thoát nhập 0!", 20);
				Console.WriteLine();
				Console.Write("Nhập mã đề tài muốn xóa : ");
				int ma = int.Parse("0" + Console.ReadLine());
				Console.Write("Nhập mã sinh viên muốn xóa : ");
				int ma1 = int.Parse("0" + Console.ReadLine());
				if (ma == 0 || ma1 == 0) return;
				else Bl.Delete(ma, ma1);
			} while (true);
		}
		public void Tim()
		{
			int detai = 0;
			int sv = 0;
			do
			{
				Console.Clear();
				ISVDetaiBusiness BL = new SVDetaiBusiness();
				List<SVDetai> list = BL.Tim(new SVDetai(detai,sv,0,0,0,0));
				Hien(list, 0, 0, "                 DANH SÁCH TUẦN ĐỀ TÀI                      ", "Nhấn Enter để thoát! Nhập tuần cần tìm : ", 30);
				detai = int.Parse(Console.ReadLine());
				detai = int.Parse(Console.ReadLine());
				if (detai == 0 && sv==0) return;
			} while (true);
		}

	}
}
