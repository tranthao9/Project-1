using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface ISVDetaiDA
    {
        List<SVDetai> GetAllData();
        void Insert(SVDetai da);
        void Delete(int mada);
        void Edit(int id, int ma, SVDetai newInfo);
        void GhiLaiDanhsach(List<SVDetai> List);
    }
}
