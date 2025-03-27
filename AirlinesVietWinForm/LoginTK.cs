using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinesVietWinForm
{
    public partial class LoginTK : Form
    {
        public LoginTK()
        {
            InitializeComponent();
            comboBoxSoDienThoai.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void labelGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Một số thông tin cơ bản về ứng dụng!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginTK_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string phone = textBoxSoDienThoai.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở LoginMK và truyền số điện thoại sang
            LoginMK loginmk = new LoginMK(phone);
            this.Hide();
            loginmk.ShowDialog();
            //this.Close(); // Hiển thị lại nếu cần
        }
    }
}
