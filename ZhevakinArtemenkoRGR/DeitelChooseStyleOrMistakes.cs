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
    public partial class DeitelChooseStyleOrMistakes : Form
    {
        public DeitelChooseStyleOrMistakes()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            ChooseThemeTypicalMistakes Choose = new ChooseThemeTypicalMistakes();
            Choose.Show();
            Hide();
        }
    }
}
