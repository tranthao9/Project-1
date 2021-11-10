using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
    public interface ILopSinhVienDA
    {
        List<LopSinhVien> GetAllData();
        void Insert(LopSinhVien lsv);
        void DeleteLop(int mal);
        void DeleteLSV(int masv,int malop);
        void DeleteSV(int masv);
        void Edit(int id,int ma, LopSinhVien newInfo);
    }
}
