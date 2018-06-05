using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZhevakinArtemenkoRGR
{
    public partial class MainPage : Form
    {
        private StartPage kostil;
        private MackonahellStartPage mackonahell ;
        private StartPage deytelStartPage;
        private DeitelChooseStyleOrMistakes chooseStyle;
        public MainPage()
        {
            InitializeComponent();
            mackonahell = new MackonahellStartPage();
            deytelStartPage = new StartPage();
            
        }

        private void DeytelStartPicture_Click(object sender, EventArgs e)
        {
            FormsToUSe.UseDaytell();
            deytelStartPage.Show();
            Hide();            
        }



        private void MackonellStartPicture_Click_1(object sender, EventArgs e)
        {
            FormsToUSe.UseMackonahell();
            mackonahell.Show();
                Hide();
               
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DeitelChooseStyleOrMistakes chooseStyle = new DeitelChooseStyleOrMistakes();
            chooseStyle.Show();
            Hide();
        }
    }
}
