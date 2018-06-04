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
    public partial class MackonahellStartPage : Form
    {
        public static List<Form1> existForms = new List<Form1>() { null, null, null, null, null, null };
        public MackonahellStartPage()
        {
            InitializeComponent();
            FormsToUSe.UseMackonahell();
        }
        public void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        public void Theme2_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }

        public void Theme3_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        public void Theme4_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        public void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }


        public void OpenForm(int indexFormToOpen)
        {
            if (existForms[FormsToUSe._indexOfCurrent] != null)
                existForms[FormsToUSe._indexOfCurrent].Hide();
            if (existForms[indexFormToOpen] != null)
            {
                FormsToUSe._indexOfCurrent = indexFormToOpen;
                existForms[FormsToUSe._indexOfCurrent].Show();
            }
            else
            {
                CreateNewForm(indexFormToOpen);
            }
        }
        public void CreateNewForm(int indexFormToCreate)
        {
            existForms.Insert(indexFormToCreate, new Form1(FormsToUSe.ListsList[indexFormToCreate][0], FormsToUSe.ListsList[indexFormToCreate][1]));
            FormsToUSe._indexOfCurrent = indexFormToCreate;
            if (indexFormToCreate == 0)
                existForms[indexFormToCreate].HideButtonToPrevious();
            if (indexFormToCreate == existForms.Count - 1)
                existForms[indexFormToCreate].HideButtonToNext();
            Hide();
            existForms[indexFormToCreate].Show();
        }

        private void Theme6_Click(object sender, EventArgs e)
        {
            OpenForm(5);
        }
    }
}
