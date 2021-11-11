using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Entities;

namespace Project_1.DataAccess.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface ITuanDetaiDA
    {
        List<TuanDetai> GetAllData();
        void Insert(TuanDetai da);
        void Delete(int mada,int mt);
        void Edit(int id, int ma, TuanDetai newInfo);
        void GhiLaiDanhsach(List<TuanDetai> List);
    }
}
