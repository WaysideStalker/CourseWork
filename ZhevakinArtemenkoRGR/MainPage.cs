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
            StartPage deytelStartPage = new StartPage();
            deytelStartPage.Show();
            Hide();
            
        }

        private void MackonellStartPicture_Click(object sender, EventArgs e)
        {
            MackonahellStartPage mackonahell = new MackonahellStartPage();
            mackonahell.Show();
            Hide();
        }
    }
}
