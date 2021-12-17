using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;
using System.IO;
using Project_1.DataAccess.Interface;

namespace Project_1.DataAccess
{
    class LopSinhVienDA : ILopSinhVienDA
    {
        //Xác định đường dẫn của tệp dữ liệu LopSinhVien.txt l 
        private string txtfile = "Data/LopSinhVien.txt";
        //Lấy toàn bộ dữ liệu có trong file LopSinhVien.txt đưa vào một danh sách 
        public List<LopSinhVien> GetAllData()
        {
            List<LopSinhVien> list = new List<LopSinhVien>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new LopSinhVien(int.Parse(a[1]), int.Parse(a[2]), (a[3]),int.Parse(a[4]),a[5],int.Parse(a[6]),int.Parse(a[7])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã lop sinh vien của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Sttlsv()
        {
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            string tmp = "";
            while (s != null)
            {
                if (s != "") tmp = s;
                s = fread.ReadLine();
            }
            fread.Close();
            if (tmp == "") return 0;
            else
            {
                tmp = Project_1.Utility.Congcu.Chuanhoaxau(tmp);
                string[] a = tmp.Split('#');
                return int.Parse(a[0]);
            }
        }
        //Chèn một bản ghi lop sinh vien vào tệp
        public void Insert(LopSinhVien lsv)
        {
            int malsv = Sttlsv() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(malsv + "#" + lsv.Malop + "#" + lsv.MaSV + "#" + lsv.Namhocbdau + "#" + lsv.Hockybdau + "#" + lsv.Namhockthuc + "#" + lsv.Hockykthuc + "#" + lsv.Active);
            fwrite.Close();
        }
        //Xóa một lop sinh vien khi biết mã lop
        public void DeleteLop(int malop)
        {
            List<LopSinhVien> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int i = 1;
            foreach (LopSinhVien lsv in list)
                if (lsv.Malop != malop)
                {
                    fwrite.WriteLine(i++ + "#" + lsv.Malop + "#" + lsv.MaSV + "#" + lsv.Namhocbdau + "#" + lsv.Hockybdau + "#" + lsv.Namhockthuc + "#" + lsv.Hockykthuc + "#" + lsv.Active);
                }
            fwrite.Close();
        }
        //Xóa một lop sinh vien khi biết mã sinh viên
        public void DeleteSV(int ma)
        {
            List<LopSinhVien> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int malh = 1;
            foreach (LopSinhVien lsv in list)
                if (lsv.MaSV != ma)
                {
                    fwrite.WriteLine(malh++ + "#" + lsv.Malop + "#" + lsv.MaSV + "#" + lsv.Namhocbdau + "#" + lsv.Hockybdau + "#" + lsv.Namhockthuc + "#" + lsv.Hockykthuc + "#" + lsv.Active);
                }
            fwrite.Close();
        }
        //Xóa một lop sinh vien khi biết mã sinh vien và mã lớp
        public void DeleteLSV(int masv,int malop)
        {
            List<LopSinhVien> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int malh = 1;
            foreach (LopSinhVien lsv in list)
                if (lsv.MaSV != masv && lsv.Malop != malop)
                {
                    fwrite.WriteLine(malh++ + "#" + lsv.Malop + "#" + lsv.MaSV + "#" + lsv.Namhocbdau + "#" + lsv.Hockybdau + "#" + lsv.Namhockthuc + "#" + lsv.Hockykthuc + "#" + lsv.Active);
                }
            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<LopSinhVien> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            int i =1;
            foreach (LopSinhVien lsv in List)
            {
                fw.WriteLine(i++ + "#" + lsv.Malop + "#" + lsv.MaSV + "#" + lsv.Namhocbdau + "#" + lsv.Hockybdau + "#" + lsv.Namhockthuc + "#" + lsv.Hockykthuc + "#" + lsv.Active);
            }
            fw.Close();
        }
        public void Edit(int id,int lop, LopSinhVien newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<LopSinhVien> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].MaSV==id && cn[i].Malop==lop)
                {
                    cn[i] = newInfo;
                    break;
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
