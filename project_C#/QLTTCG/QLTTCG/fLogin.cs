using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTTCG
{

    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void txbPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra kết quả chọn
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, thoát ứng dụng
                Application.Exit();
            }
            else
            {
                // Nếu người dùng chọn No, không làm gì cả
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                // Kiểm tra thông tin đăng nhập và chuyển sang form phù hợp
                string username = textBox1.Text;
                string password = txbPassWord.Text;

                if (username == "admin" && password == "123")
                {
                    fFarm tableManager = new fFarm();
                    tableManager.Show();
                    this.Hide();
                }
                else if (username == "nhanvien" && password == "234")
                {
                    fFarm employeeManager = new fFarm();
                    employeeManager.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               // this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}