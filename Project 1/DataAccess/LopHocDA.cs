using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Project_1.Entities;
using Project_1.DataAccess.Interface;

namespace Project_1.DataAccess
{
    class LopHocDA : ILopHocDA
    {
        //Xác định đường dẫn của tệp dữ liệu HocSinh.txt l 
        private string txtfile = "Data/LopHoc.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<LopHoc> GetAllData()
        {
            List<LopHoc> list = new List<LopHoc>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new LopHoc(int.Parse(a[1]), a[2], int.Parse( a[3])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã học sinh của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Sttlh()
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
        //Chèn một bản ghi lop hoc vào tệp
        public void Insert(LopHoc lh)
        {
            int malh = Sttlh() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(malh + "#" + lh.Malop+"#"+ lh.Tenlop + "#" + lh.Mach);
            fwrite.Close();
        }
        //Xóa một học sinh khi biết mã
        public void Delete(int malop)
        {
            List<LopHoc> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (LopHoc lh in list)
                if (lh.Malop != malop)
				{
                    int malh = Sttlh() + 1;
                    fwrite.WriteLine(malh + "#" + lh.Malop + "#" + lh.Tenlop + "#" + lh.Mach);
                }
                    
            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<LopHoc> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            foreach (LopHoc lh in List)
            {
                int malh = Sttlh() + 1;
                fw.WriteLine(malh + "#" + lh.Malop + "#" + lh.Tenlop + "#" + lh.Mach);

            }
            fw.Close();
        }
        public void Edit(int id, LopHoc newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<LopHoc> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].Malop == id)
                {
                    cn[i] = new LopHoc(newInfo);
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
