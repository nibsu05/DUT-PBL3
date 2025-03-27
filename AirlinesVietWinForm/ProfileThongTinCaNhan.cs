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
    public partial class ProfileThongTinCaNhan : Form
    {
        UserAccount useraccount = new UserAccount();
        public ProfileThongTinCaNhan(UserAccount useraccount)
        {
            InitializeComponent();
            this.useraccount = useraccount;
            string[] parts = useraccount.full_name.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            textBoxHo.Text = parts[0];
            textBoxTenDemVaTen.Text = string.Join(" ", parts.Skip(1));
            textBoxSoDienThoai.Text = useraccount.phone;
            textBoxNgaySinh.Text = useraccount.birthday;
        }

        private void radioButtonTaiKhoanCuaToi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTaiKhoanCuaToi.Checked == true)
            {
                Profile profile = new Profile(useraccount);
                profile.Show();
                this.Close();
            }
        }

        private void buttonTroLai_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu(useraccount);
            mainmenu.Show();
            this.Close();
        }
    }
}
