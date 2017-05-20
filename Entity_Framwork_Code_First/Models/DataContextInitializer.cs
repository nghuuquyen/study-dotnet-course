using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    class DataContextInitializer: CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {

            context.Lops.Add(new Lop()
            {
                id = 1,
                ten = "14TCLC2"
            });

            context.SinhViens.Add(new SinhVien()
            {
                id = 1,
                hoten = "Nguyen Huu Quyen",
                email = "nghuuquyen@gmail.com",
                lopId = 1
            });

            context.MonHocs.Add(new MonHoc()
            {
                id = 1,
                name = ".NET",                
            });

            context.SVMonHocs.Add(new SinhVienMonHoc()
            {
                monHocId = 1 ,
                sinhVienId = 1
            });

            context.SVDiaChis.Add(new SinhVienDiaChi()
            {
                id = 1,
                diachi1 = "Dia Chi 1",
                diachi2 = "Dia Chi 2",
                thanhPho = "Da Nang"
            });
         
            base.Seed(context);
        }
    }
}
