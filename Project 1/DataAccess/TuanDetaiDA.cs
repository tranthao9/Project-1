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

    class TuanDetaiDA : ITuanDetaiDA
    {
        //Xác định đường dẫn của tệp dữ liệu TuanDetai.txt l 
        private string txtfile = "Data/Tuandetai.txt";
        //Lấy toàn bộ dữ liệu có trong file TuanDetai.txt đưa vào một danh sách 
        public List<TuanDetai> GetAllData()
        {
            List<TuanDetai> list = new List<TuanDetai>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new TuanDetai(int.Parse(a[1]), int.Parse(a[2]),a[3],double.Parse(a[4])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã tuan de tai của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Sttdoan()
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
        public void Insert(TuanDetai da)
        {
            int mada = Sttdoan() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(mada + "#" + da.Matuan + "#" + da.Madettai + "#" + da.Danhgia + "#" + da.Diem );
            fwrite.Close();
        }
        //Xóa một do an khi biết mã tuan de tai va ma tuan
        public void Delete(int mada,int mat)
        {
            List<TuanDetai> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int i = 0;
            foreach (TuanDetai da in list)
                
                if (da.Madettai != mada && da.Matuan!=mat)
                {
                    fwrite.WriteLine(i++ + "#" + da.Matuan + "#" + da.Madettai + "#" + da.Danhgia + "#" + da.Diem );
                }

            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<TuanDetai> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            int i = 0;
            foreach (TuanDetai da in List)
            {
               
                fw.WriteLine(i++ + "#" + da.Matuan + "#" + da.Madettai + "#" + da.Danhgia + "#" + da.Diem);

            }
            fw.Close();
        }
        public void Edit(int id,int ma, TuanDetai newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<TuanDetai> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].Madettai == id&& cn[i].Matuan==ma)
                {
                    cn[i] = newInfo;
                    break;
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
