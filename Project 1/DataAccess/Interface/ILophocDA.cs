using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
    public interface ILopHocDA
    {
        List<LopHoc> GetAllData();
        void Insert(LopHoc hs);
        void Delete(int malop);
        void Edit(int id, LopHoc newInfo);
    }
}
