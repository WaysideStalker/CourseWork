using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZhevakinArtemenkoRGR
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void DeytelStartPicture_Click(object sender, EventArgs e)
        {
            Hide();
            StartPage deytelStartPage = new StartPage();
            deytelStartPage.Show();
        }
    }
}
