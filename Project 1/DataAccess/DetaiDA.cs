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
    class DetaiDA : IDetaiDA
    {
        //Xác định đường dẫn của tệp dữ liệu Detai.txt l 
        private string txtfile = "Data/DeTai.txt";
        //Lấy toàn bộ dữ liệu có trong file detai.txt đưa vào một danh sách 
        public List<Detai> GetAllData()
        {
            List<Detai> list = new List<Detai>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Detai(int.Parse(a[1]),(a[2]), (a[3]), int.Parse(a[4])));
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
        //Chèn một bản ghi vào tệp
        public void Insert(Detai t)
        {
            int matuan = Stt() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(matuan + "#" + t.Madetai + "#" + t.Tendetai + "#" + t.Mota+ "#" + t.Mada);
            fwrite.Close();
        }
        //Xóa một tuan khi biết mã 
        public void Delete(int ma)
        {
            List<Detai> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Detai t in list)
                if (t.Madetai != ma)
                {
                    int malh = Stt() + 1;
                    fwrite.WriteLine(malh + "#" + t.Madetai + "#" + t.Tendetai + "#" + t.Mota + "#" + t.Mada);
                }

            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<Detai> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            int malh = 1;
            foreach (Detai t in List)
            {
                fw.WriteLine(malh++ + "#" + t.Madetai + "#" + t.Tendetai + "#" + t.Mota + "#" + t.Mada);

            }
            fw.Close();
        }
        public void Edit(int id, Detai newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<Detai> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].Madetai == id)
                {
                    cn[i] = newInfo;
                    break;
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
