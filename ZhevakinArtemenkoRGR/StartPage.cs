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
    public partial class StartPage : Form
    {
        public static List<Form1> existForms = new List<Form1>() { null, null, null, null, null };
        public static List<DeitelTypicalMistakes> ListOfForms = new List<DeitelTypicalMistakes>() {null, null, null, null, null};
        public StartPage()
        {
            InitializeComponent();
            FormsToUSe.FillMistakesForDeitel();
        }
        
        public  void bunifuThinButton21_Click(object sender, EventArgs e)
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

            Hide();
        }
        public void CreateNewForm(int indexFormToCreate)
        {
            existForms[indexFormToCreate] = new Form1(FormsToUSe.ListsList[indexFormToCreate][0],
                FormsToUSe.ListsList[indexFormToCreate][1]);
            FormsToUSe._indexOfCurrent = indexFormToCreate;
            if (indexFormToCreate == 0)
                existForms[indexFormToCreate].HideButtonToPrevious();
            if (indexFormToCreate == existForms.Count - 1)
                existForms[indexFormToCreate].HideButtonToNext();
            Hide();
            existForms[indexFormToCreate].Show();
        }


        public void OpenTypicalMistakes(int indexFormToOpen)
        {
            if (ListOfForms[FormsToUSe._TypicalMistakesIndex] != null)
                ListOfForms[FormsToUSe._TypicalMistakesIndex].Hide();
            if (ListOfForms[indexFormToOpen] != null)
            {
                FormsToUSe._TypicalMistakesIndex = indexFormToOpen;
                ListOfForms[FormsToUSe._TypicalMistakesIndex].Show();
            }
            else
            {
                CreateNewTypicalMistakes(indexFormToOpen);
            }
        }
        public void CreateNewTypicalMistakes(int indexFormToCreate)
        {
            ListOfForms.Insert(indexFormToCreate, new DeitelTypicalMistakes());
            FormsToUSe._TypicalMistakesIndex = indexFormToCreate;
            ListOfForms[indexFormToCreate].richTextBox1.Text = FormsToUSe.TypicalMistakesDeitel[indexFormToCreate];
            FormsToUSe._TypicalMistakesIndex = indexFormToCreate;
            Hide();
            ListOfForms[indexFormToCreate].Show();
        }
    }
}
