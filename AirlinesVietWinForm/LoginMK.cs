using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus_Tier;
using Model;

namespace AirlinesVietWinForm
{
    public partial class LoginMK : Form
    {
        private string phoneNumber; // Lưu số điện thoại được truyền vào từ LoginTK
        private BSUserAccount db = new BSUserAccount(); // Kết nối DB

        public LoginMK(string phone)
        {
            InitializeComponent();
            this.phoneNumber = phone;
        }
    
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string password = textBoxMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đăng nhập
            if (db.ValidateUser(phoneNumber, password))
            {
                // Lấy full_name từ DB
                UserAccount useraccount = db.Login(phoneNumber);

                MessageBox.Show("Đăng nhập thành công!\nXin chào, " + useraccount.full_name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở MainMenu và truyền full_name
                MainMenu mainMenu = new MainMenu(useraccount);
                mainMenu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai số điện thoại hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienMatKhau.Checked == true)
            {
                textBoxMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxMatKhau.UseSystemPasswordChar = true;
            }    
        }

        private void labelDangNhapBangTaiKhoanKhac_Click(object sender, EventArgs e)
        {
            LoginTK logintk = new LoginTK();
            logintk.Show();
            this.Close();
        }
    }

}
