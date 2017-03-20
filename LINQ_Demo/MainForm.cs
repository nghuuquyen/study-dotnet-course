using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Demo
{
    public partial class MainForm : Form
    {
        // Cái này là tên của Class DataClassses trong file .dbml
        // Để tạo ra được cái file như thế này làm như sau.
        // 1- Từ Project chọn add new item.
        // 2- Search từ khóa 'LinQ'
        // 3- Chọn cái Add Class từ DB --> Tức là tạo Class từ DB
        // 4- Lúc này anh sẽ có cái file .dbml
        // 5- Nhấn mở file này ra anh sẽ thấy màn hình trắng trơn.
        // 6- Mở cái tab server Explorer (Cái Database) và kéo thả các Table vào
        // 7- Save lại, mở file Design ra --> Đọc cái tên trong đó ví dụ hiện tại em là DataClasses1DataContext
        // 8- New đối tượng và dùng như trước.
        DataClasses1DataContext db = new DataClasses1DataContext();
        public MainForm()
        {
            InitializeComponent();
            // Sử dụng var vì để thuận tiện cho việc sử lí kiểu trả về
            // Lúc này LinQ trả về có thể là List cũng có thể là một Object hoặc kiểu nguyên thủy
            // --> Sử dụng var để thuận tiện hơn.


            // ---- Kiểu viết theo phong cách Query ----
            var result_1 = from s in db.SVs select new { s.MSSV, s.Name, s.Lop.Ten_Lop };
            var result_2 = from s in db.SVs where s.Lop.ID_Lop.Equals(1) select new { s.MSSV, s.Name, s.Lop.Ten_Lop };

            // ---- Kiểu viết theo phong cách Lambda ----

            // Query hết bảng có sàn lọc dữ liệu
            var result_3 = db.SVs.Select(s => new { s.MSSV, s.Name, s.Lop.Ten_Lop });

            // Query theo điều kiện Where có sàn lọc dữ liệu (Select)
            var result_4 = db.SVs.Where(s => s.ID_Lop.Equals(1)).Select(s => new { s.Name, s.Lop.Ten_Lop });

            // Query bỏ qua 0 bảng ghi và lấy 2 bảng ghi kể tự vị trí thứ 1 trở đi.
            var result_5 = (from s in db.SVs select s).Skip(0).Take(2);

            // Query bỏ qua 5 bảng ghi và lấy 2 bảng ghi kể tự vị trí thứ 6 trở đi.
            // Tức là lấy từ Skip + 1 lên 
            // Bảng ghi đánh số từ số 1 <--
            var result_6 = (from s in db.SVs select s).Skip(5).Take(2);

            var result_7 = (from s in db.SVs select s).Skip(5).Take(2);

            // Bỏ 2 lấy 3 cái tiếp theo.
            var result_8 = db.SVs.Select(s => s).Skip(2).Take(3);

            // Cái Distinct là để lọc kết quả trả về nếu trùng thì chỉ lấy một.
            // Ở đây trong DB em có 2 dòng dữ liệu trùng 2 trường ở dưới --> Nên khi show ra 
            // chỉ có một cái thôi.
            // Nghĩa là nếu trùng 2 trường ( Name và Nien_Khoa) em chọn thì mới đưa ra một kết quả.
            // Còn nếu 1 trong 2 cái khác thì sẽ ghi ra luôn.
            var result_9 = db.SVs.Where(s => s.Name.Contains("Nguyen Huu Quyen"))
                                 .Select(s => new { s.Name, s.Nien_Khoa }).Distinct();

            //var result_10 = from sv in db.SVs
            //                join lop in db.Lops
            //                on sv.ID_Lop equals lop.ID_Lop
            //                group by sv.Name;

                            
            // Để các result_X vào để test.
            dataGridView1.DataSource = result_9;
        }
    }
}
