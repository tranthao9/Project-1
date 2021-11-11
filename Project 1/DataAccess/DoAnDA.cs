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
    class DoAnDA : IDoAnDA
    {
        //Xác định đường dẫn của tệp dữ liệu DoAn.txt l 
        private string txtfile = "Data/DoAn.txt";
        //Lấy toàn bộ dữ liệu có trong file DoAn.txt đưa vào một danh sách 
        public List<DoAn> GetAllData()
        {
            List<DoAn> list = new List<DoAn>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new DoAn(int.Parse(a[1]),(a[2]), int.Parse(a[3]), (a[4])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Stt()
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
        public void Insert(DoAn t)
        {
            int ma = Stt() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(ma + "#" + t.Mada + "#" + t.Tenda + "#" + t.Sotc + "#" + t.Mota);
            fwrite.Close();
        }
        //Xóa một tuan khi biết mã
        public void Delete(int ma)
        {
            List<DoAn> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int i = 1;
            foreach (DoAn t in list)
                if (t.Mada != ma)
                {
                    fwrite.WriteLine(i++ + "#" + t.Mada + "#" + t.Tenda + "#" + t.Sotc+ "#" + t.Mota);
                }

            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<DoAn> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            int i = 1;
            foreach (DoAn t in List)
            {
                fw.WriteLine(i++ + "#" + t.Mada + "#" + t.Tenda + "#" + t.Sotc + "#" + t.Mota);

            }
            fw.Close();
        }
        public void Edit(int id, DoAn newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<DoAn> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].Mada == id)
                {
                    cn[i] = newInfo;  
                    break;
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
