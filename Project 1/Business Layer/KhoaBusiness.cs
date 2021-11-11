using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;
using Project_1.DataAccess.Interface;
using Project_1.DataAccess;
using Project_1.Business_Layer.Interface;

namespace Project_1.Business_Layer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IKhoaBusiness
    public class KhoaBusiness : IKhoaBusiness
    {
        private IKhoaDA khDA = new KhoaDA();
        private IGiangVienDA gvDA = new GiangVienDA();
        private INganhDA nDA = new NganhDA();
        //Thực thi các yêu cầu
        public List<Khoa> GetAllData()
        {
            List<Khoa> listkh = khDA.GetAllData();
            foreach(Khoa a in listkh)
			{
                foreach (var b in gvDA.GetAllData())
				{
                    if(a.Matruongkhoa==b.MaGV)
                        a.Giangvien=new GiangVien (b);
				}
			}                
            return listkh;
        }
         //kiểm tra một mã giảng viên xem đã tồn tại hay chưa
        public bool ExistKTGV(int ma)
        {
            List<GiangVien> list = gvDA.GetAllData();
            if (list.Find(m => m.MaGV == ma) != null)
                return true;
            return false;
        }
        public void Insert(Khoa kh)
        {
            if (kh.Tenkhoa != "" && kh.Mota != null && kh.Trangthai != null)
            {
                kh.Tenkhoa= Project_1.Utility.Congcu.Chuanhoaxau(kh.Tenkhoa);
                kh.Mota = Project_1.Utility.Congcu.Chuanhoaxau(kh.Mota);
                kh.Trangthai = Project_1.Utility.Congcu.Chuanhoaxau(kh.Trangthai);
                khDA.Insert(kh);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public void Edit(int id, Khoa newInfo)
        {
            khDA.Edit(id, newInfo);
            if(id != newInfo.Makhoa)
			{
                List<Nganh> a = nDA.GetAllData();
                foreach(var s in a)
				{
                    if(s.Makhoa ==id)
					{
                        s.Makhoa = newInfo.Makhoa;
					}                        
				}
                nDA.GhiLaiDanhsach(a);
			}                
        }
    }
}
