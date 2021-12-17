using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project_1.UI
{
	public class FormMenu
	{

        public void GiaoDien()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Ứng dụng quản lý đồ án sinh viên khoa CNTT";
            //Console.CursorVisible = fa; //con trỏ có thể chia sẻ
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                            TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN                                           ║");
            Console.WriteLine("\t\t║                                                    KHOA CÔNG NGHỆ THÔNG TIN                                                   ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                    ♥♥♥♥♥♥♥♥   ♥♥♥♥♥♥♥♥♥     ♥♥♥♥♥♥♥   ♥♥♥♥♥♥♥♥♥♥  ♥♥♥♥♥♥♥♥   ♥♥♥♥♥♥♥♥  ♥♥♥♥♥♥♥♥♥♥        ▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥    ♥♥  ♥♥♥    ♥♥♥   ♥♥♥   ♥♥♥       ♥♥♥    ♥♥♥       ♥♥♥           ♥♥♥          ▀▀▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥    ♥♥♥ ♥♥♥    ♥♥♥  ♥♥♥     ♥♥♥      ♥♥♥    ♥♥♥       ♥♥♥           ♥♥♥            ▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥♥♥♥♥♥♥  ♥♥♥♥♥♥♥♥♥   ♥♥♥     ♥♥♥      ♥♥♥    ♥♥♥♥♥♥♥♥♥ ♥♥♥           ♥♥♥            ▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥        ♥♥♥    ♥♥♥  ♥♥♥     ♥♥♥      ♥♥♥    ♥♥♥       ♥♥♥           ♥♥♥            ▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥        ♥♥♥     ♥♥♥  ♥♥♥   ♥♥♥      ♥♥♥     ♥♥♥       ♥♥♥           ♥♥♥            ▀▀▀                  ║");
            Console.WriteLine("\t\t║                    ♥♥♥        ♥♥♥      ♥♥♥  ♥♥♥♥♥♥♥   ♥♥♥♥♥♥      ♥♥♥♥♥♥♥♥   ♥♥♥♥♥♥♥♥     ♥♥♥          ▀▀▀▀▀▀▀                ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                        ╔═══════════════════════════════════════════════════════════════════════════════╗                      ║");
            Console.WriteLine("\t\t║                        ║   CHÀO MỪNG BẠN ĐẾN VỚI ỨNG DỤNG QUẢN LÝ ĐỒ ÁN SINH VIÊN KHOA CNTT            ║                      ║");
            Console.WriteLine("\t\t║                        ╚═══════════════════════════════════════════════════════════════════════════════╝                      ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                              Giáo Viên Hướng dẫn: CHU THỊ MINH HUỆ                                            ║");
            Console.WriteLine("\t\t║                                              Sinh Viên thực hiện: TRẦN THỊ THẢO                                               ║");
            Console.WriteLine("\t\t║                                              Lớp                : 125202                                                      ║");
            Console.WriteLine("\t\t║                                              Mã sinh viên       : 12520041                                                    ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                        Hưng Yên 2021                                                          ║");
            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine("\t\t                                              Nhấn đúp phím bất kì để vào menu chính!!!");
            Console.ReadKey();
        }
        public void MenuQL()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Ứng dụng quản lý đồ án sinh viên khoa CNTT";
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                     ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐   MENU QUẢN LÝ  ▌                                                     ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                     ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.WriteLine("\t\t║                                                                                                                                 ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     1.Quản Lý Sinh Viên        ║              ║     7.Xét duyệt Sinh Viên      ║                    ║");
            Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     2.Quản lý Giảng Viên       ║              ║     8.Quản Lý Đồ Án            ║                    ║");
            Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     3.Quản Lý Lớp Học          ║              ║     9.Quản Lý Đề Tài           ║                    ║");
            Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     4.Quản Lý Chuyên Ngành     ║              ║     10.Quản lý Tuần Đề Tài     ║                    ║");
            Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     5.Quản Lý Ngành            ║              ║     11.Quản Lý Đề Tài Sinh Viên║                    ║");
            Console.WriteLine("\t\t║                           ╚════════════════════════════════╝              ╚════════════════════════════════╝                    ║");
            Console.WriteLine("\t\t║                           ╔════════════════════════════════╗              ╔════════════════════════════════╗                    ║");
            Console.WriteLine("\t\t║                           ║     6.Quản lý Khoa             ║              ║     12.Thống kê                ║                    ║");
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
        }
        //ham dang nhap mat khau va tai khoan admin
        public void Dangnhap()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Đăng nhập";
            int left = 79, top = 2;
            string strShow = "♥◦•●●•◦ XIN MỜI BẠN ĐĂNG NHẬP CHƯƠNG TRÌNH ◦•●●•◦♥";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 11); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(50, 12); Console.WriteLine("║                                                                       ║");
            Console.SetCursorPosition(50, 13); Console.WriteLine("║  TÀI KHOẢN :                                                          ║");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.SetCursorPosition(70, 13); Console.Write("Magiangvien@utehy.vn");
            Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition(50, 14); Console.WriteLine("║═══════════════════════════════════════════════════════════════════════║");
            Console.SetCursorPosition(50, 15); Console.WriteLine("║  MẬT KHẨU  :                                                          ║");
            Console.SetCursorPosition(50, 16); Console.WriteLine("║                                                                       ║");
            Console.SetCursorPosition(50, 17); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(60, 6); Console.WriteLine("                                                       ");
                Console.SetCursorPosition(50, 15); Console.SetCursorPosition(left, top);
                left--;
                if (left == 0)
                    left = 79;
                int nChar = (80 - left) < strShow.Length ? (79 - left) : strShow.Length;
                Console.SetCursorPosition(60, 6); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(strShow.Substring(0, nChar));

                Thread.Sleep(100);

            }
            Console.SetCursorPosition(60, 6); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("♥◦•●●•◦ XIN MỜI BẠN ĐĂNG NHẬP CHƯƠNG TRÌNH ◦•●●•◦♥");
            Console.SetCursorPosition(70, 13); Console.Write("                                       ");
            Console.SetCursorPosition(70, 13); string tk = Console.ReadLine();
            Console.SetCursorPosition(70, 15); string mk = Console.ReadLine();
            if (mk.Length > 0)
            {
                for (int i = 0; i < mk.Length; i++)
                {
                    Console.SetCursorPosition(70 + i, 15); Console.Write("*");
                }
            }
            Console.ReadKey();
        }
    }
}
