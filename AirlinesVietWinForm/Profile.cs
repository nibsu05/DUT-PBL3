using Model;
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
    public partial class Profile : Form
    {
        UserAccount useraccount = new UserAccount();
        public Profile(UserAccount useraccount)
        {
            InitializeComponent();
            this.useraccount = useraccount;
            textBoxMaSoThanhVien.Text = useraccount.user_id.ToString();
            textBoxHangThe.Text = useraccount.member_rank.ToString();
            textBoxPhone.Text = useraccount.phone.ToString();
            textBoxEmail.Text = useraccount.email.ToString();
            textBoxMatKhau.Text = useraccount.password.ToString();
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

        private void buttonTroLai_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu(useraccount);
            mainmenu.Show();
            this.Close();
        }

        private void radioButtonThongTinCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonThongTinCaNhan.Checked == true)
            {
                ProfileThongTinCaNhan profilethongtincanhan = new ProfileThongTinCaNhan(useraccount);
                profilethongtincanhan.Show();
                this.Close();
            }
        }

        private void buttonDangXuat_Click(object sender, EventArgs e)
        {
            LoginTK logintk = new LoginTK();
            logintk.Show();
            this.Close();
        }
    }
}
