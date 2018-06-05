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
    public partial class ChooseThemeTypicalMistakes : Form
    {
        private StartPage a;
        public ChooseThemeTypicalMistakes()
        {
            a = new StartPage();
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Hide();
            a.OpenTypicalMistakes(0);
        }
    }
}
