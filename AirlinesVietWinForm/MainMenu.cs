using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus_Tier;
using Model;

namespace AirlinesVietWinForm
{
    public partial class MainMenu : Form
    {
        UserAccount useraccount = new UserAccount();
        private BSAirport db = new BSAirport();
        public MainMenu(UserAccount useraccount)
        {
            InitializeComponent();
            comboBoxNgonNgu.SelectedIndex = 0;
            this.useraccount = useraccount;
            labelTenTK.Text = useraccount.full_name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Airport> airports = db.GetAllAirports();
            foreach (Airport airport in airports)
            {
                string str = string.Format(airport.city + " (" + airport.code + ")");
                comboBoxDiemKhoiHanh.Items.Add(str);
                comboBoxDiemDen.Items.Add(str);
                comboBoxDiemDenMotChieu.Items.Add(str);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTangHanhKhach_Click(object sender, EventArgs e)
        {
            string text = labelSoHanhKhach.Text;
            string[] parts = text.Split(' ');
            int n = int.Parse(parts[0]);
            n++;
            labelSoHanhKhach.Text = n.ToString() + " người";
        }

        private void buttonGiamHanhKhach_Click(object sender, EventArgs e)
        {
            string text = labelSoHanhKhach.Text;
            string[] parts = text.Split(' ');
            int n = int.Parse(parts[0]);
            if (n>1) n--;
            labelSoHanhKhach.Text = n.ToString() + " người";
        }

        private void radioButtonMotChieu_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDiemDenMotChieu.Visible = true;
            groupBoxDiemDenKhuHoi.Visible = false;
        }

        private void radioButtonKhuHoi_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDiemDenMotChieu.Visible = false;
            groupBoxDiemDenKhuHoi.Visible = true;
        }

        private void labelTenTK_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(useraccount);
            profile.Show();
            this.Close();

        }

        private void buttonTimChuyenBay_Click(object sender, EventArgs e)
        {
            try
            {
                string departure_place = comboBoxDiemKhoiHanh.Text;
                string arrival_place;
                if (radioButtonMotChieu.Checked == true)
                {
                    arrival_place = comboBoxDiemDenMotChieu.Text;
                }
                else
                {
                    arrival_place = comboBoxDiemDen.Text;
                }
                Regex regex = new Regex(@"\(([^)]+)\)");
                Match match = regex.Match(departure_place);
                string departure_code, arrival_code;
                if (match.Success)
                {
                    departure_code = match.Groups[1].Value;
                }
                else
                {
                    throw new Exception("Không tìm thấy điểm khởi hành!");
                }
                match = regex.Match(arrival_place);
                if (match.Success)
                {
                    arrival_code = match.Groups[1].Value;
                }
                else
                {
                    throw new Exception("Không tìm thấy điểm đến!");
                }
                string departure_date = dateTimePickerDiemKhoiHanh.Text.Trim();
                SelectFlight selectflight = new SelectFlight(useraccount, db.GetAirportByCode(departure_code), db.GetAirportByCode(arrival_code), departure_date);
                selectflight.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
