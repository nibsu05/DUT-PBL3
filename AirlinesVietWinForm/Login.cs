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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void labelGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình khách hàng thân thiết của Vietjet mang đến niềm vui bằng cách làm phong phú mỗi thành viên với cơ hội kiếm điểm và đổi thưởng không giới hạn tại Việt Nam và trên toàn thế giới. Thành viên có thể dễ dàng kiếm SkyPoint trên mỗi 10.000 VND chi tiêu với Vietjet, nhanh chóng thăng hạng thành viên và tận hưởng các quyền lợi ưu tiên tại sân bay cùng nhiều ưu đãi hấp dẫn khác.\r\n\r\n Xem hướng dẫn đăng ký Tại đây. ");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
