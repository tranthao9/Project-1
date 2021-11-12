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

    class SVDetaiDA : ISVDetaiDA
    {
        //Xác định đường dẫn của tệp dữ liệu DoAn.txt l 
        private string txtfile = "Data/DeTaiSinhVien.txt";
        //Lấy toàn bộ dữ liệu có trong file DoAn.txt đưa vào một danh sách 
        public List<SVDetai> GetAllData()
        {
            List<SVDetai> list = new List<SVDetai>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Project_1.Utility.Congcu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new SVDetai(int.Parse(a[1]),int.Parse (a[2]),int.Parse(a[3]), int.Parse(a[4]),double.Parse(a[5]),double.Parse(a[6])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã do an của bản ghi cuối cùng phục vụ cho đánh mã tự động
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
        //Chèn một bản ghi de tai sinh vien vào tệp
        public void Insert(SVDetai da)
        {
            int mada = Sttdoan() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(mada + "#" + da.Madetai + "#" + da.MaSV+"#"+ da.MaGVHD+ "#" + da.MaGVPB+ "#"  +da.DiemGVHD+"#"+da.DiemBV);
            fwrite.Close();
        }
        //Xóa một do an khi biết mã đề tài và mã sv
        public void Delete(int mada)
        {
            List<SVDetai> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            int i = 1;
            foreach (SVDetai da in list)
                if (da.Madetai != mada )
                {
                    fwrite.WriteLine(i++ + "#" + da.Madetai + "#" + da.MaSV + "#" + da.MaGVHD + "#" + da.MaGVPB + "#" + da.DiemGVHD + "#" + da.DiemBV);
                }

            fwrite.Close();
        }
        //Thuật toán phương thức sửa trên danh sách, ghi lại tệp.
        public void GhiLaiDanhsach(List<SVDetai> List)
        {
            StreamWriter fw = new StreamWriter(txtfile, false);
            int i = 1;
            foreach (SVDetai da in List)
            {
                fw.WriteLine(i++ + "#" + da.Madetai + "#" + da.MaSV + "#" + da.MaGVHD + "#" + da.MaGVPB + "#" + da.DiemGVHD + "#" + da.DiemBV);

            }
            fw.Close();
        }
        public void Edit(int id,int ma, SVDetai newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<SVDetai> cn = GetAllData();
            //Sửa trên DS và ghi đè vào tệp
            for (int i = 0; i < cn.Count; i++)
            {
                if (cn[i].MaSV == id&& cn[i].Madetai==ma)
                {
                    cn[i] = newInfo;
                    break;
                }
            }
            GhiLaiDanhsach(cn);
        }
    }
}
