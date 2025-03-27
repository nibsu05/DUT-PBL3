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
    public partial class SelectFlight : Form
    {
        UserAccount useraccount = new UserAccount();
        public SelectFlight(UserAccount useraccount, Airport departure_airport, Airport arrival_airport, string date)
        {
            this.useraccount = useraccount;
            InitializeComponent();
            labelCodeAirport1.Text = departure_airport.code;
            labelCodeAirport2.Text = arrival_airport.code;
            labelCityAirport1.Text = departure_airport.city;
            labelCityAirport2.Text = arrival_airport.city;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void buttonTroLai_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu(useraccount);
            mainmenu.Show();
            this.Close();
        }
    }
}
