using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwingWWTKinect
{
    public partial class LightsForm : Form
    {
        public LightsForm()
        {
            InitializeComponent();
        }

        private void LightsForm_Load(object sender, EventArgs e)
        {
            LightTimeoutTime.Text = Properties.Settings.Default.AutoLightsTimeout.ToString();
            UserName.Text = Properties.Settings.Default.LoginUsername;
            Password.Text = Properties.Settings.Default.LoginPassword;
            LightsOnUrl.Text = Properties.Settings.Default.LightOnUrl;
            LightsOffUrl.Text = Properties.Settings.Default.LightOffUrl;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Password.PasswordChar = (char)0;
            }
            else
            {
                Password.PasswordChar = '*';
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            bool good = false;
            int timeout = 0;


            if (int.TryParse(LightTimeoutTime.Text, out timeout))
            {
                Properties.Settings.Default.AutoLightsTimeout = timeout;
            }
            else
            {
                LightTimeoutTime.BackColor = Color.Red; 
            }

            Properties.Settings.Default.LoginUsername = UserName.Text;
            Properties.Settings.Default.LoginPassword = Password.Text;
            Properties.Settings.Default.LightOnUrl = LightsOnUrl.Text;
            Properties.Settings.Default.LightOffUrl = LightsOffUrl.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
