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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        public Form1(string text, string test, string[] answers)
        {
            InitializeComponent();
            richTextBox1.Text = text;
            richTextBox2.Text = test;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox2.BorderStyle = BorderStyle.None;
            panel2.Visible = false;

        }

        public void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }
        public void MouseEnterInPanelWithChechBox(Panel usingPanel, CheckBox usingCheckBox)
        {
            usingPanel.BackColor = Color.Black;
            usingCheckBox.BackColor = Color.Black;
            usingCheckBox.ForeColor = Color.White;
        }
        public void panel4_MouseEnter(object sender, EventArgs e) => MouseEnterInPanelWithChechBox(panel3, checkBox1);
        public void panel5_MouseEnter(object sender, EventArgs e) => MouseEnterInPanelWithChechBox(panel4, checkBox2);
        public void panel6_MouseEnter(object sender, EventArgs e) => MouseEnterInPanelWithChechBox(panel5, checkBox3);
        public void panel7_MouseEnter(object sender, EventArgs e) => MouseEnterInPanelWithChechBox(panel6, checkBox4);
        public void MouseLeaveInPanelWithChechBox(Panel usingPanel, CheckBox usingCheckBox)
        {
            usingPanel.BackColor = Color.Silver;
            usingCheckBox.BackColor = Color.Transparent;
            usingCheckBox.ForeColor = Color.Black;
        }
        public void panel4_MouseLeave(object sender, EventArgs e) => MouseLeaveInPanelWithChechBox(panel3, checkBox1);
        public void panel5_MouseLeave(object sender, EventArgs e) => MouseLeaveInPanelWithChechBox(panel4, checkBox2);
        public void panel6_MouseLeave(object sender, EventArgs e) => MouseLeaveInPanelWithChechBox(panel5, checkBox3);
        public void panel7_MouseLeave(object sender, EventArgs e) => MouseLeaveInPanelWithChechBox(panel6, checkBox4);

        public void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        public void checkBox4_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox4.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox1.Checked = false;
        }

        public void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = true;
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox4.Checked = false;
        }

        public void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        public void bunifuThinButton23_Click(object sender, EventArgs e) => OpenForm(FormsToUSe._indexOfCurrent + 1);


        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void HideButtonToPrevious() => MoveToPreviousThemeForm.Visible = false;
        public void HideButtonToNext() => NextThemeFormFromTest.Visible = false;
        private void metroButton1_Click(object sender, EventArgs e) => OpenForm(0);
        private void metroButton2_Click(object sender, EventArgs e) => OpenForm(1);
        private void metroButton3_Click(object sender, EventArgs e) => OpenForm(2);
        private void metroButton4_Click(object sender, EventArgs e) => OpenForm(3);
        private void metroButton5_Click(object sender, EventArgs e) => OpenForm(4);

        public void OpenForm(int indexFormToOpen)
        {
            if (indexFormToOpen != FormsToUSe._indexOfCurrent)
            {
                if (StartPage.existForms[FormsToUSe._indexOfCurrent] != null)
                    StartPage.existForms[FormsToUSe._indexOfCurrent].Hide();
                if (StartPage.existForms[indexFormToOpen] != null)
                {
                    FormsToUSe._indexOfCurrent = indexFormToOpen;
                    StartPage.existForms[FormsToUSe._indexOfCurrent].Show();
                }
                else
                {
                    CreateNewForm(indexFormToOpen);
                }
            }
        }
        public void CreateNewForm(int indexFormToCreate)
        {
            StartPage.existForms.Insert(indexFormToCreate, new Form1(FormsToUSe.ListsList[indexFormToCreate][0], FormsToUSe.ListsList[indexFormToCreate][1], FormsToUSe.ListsList[indexFormToCreate][2].Split('\n')));
            FormsToUSe._indexOfCurrent = indexFormToCreate;
            if (indexFormToCreate == 0)
                StartPage.existForms[indexFormToCreate].HideButtonToPrevious();
            if (indexFormToCreate == StartPage.existForms.Count - 1)
                StartPage.existForms[indexFormToCreate].HideButtonToNext();

            StartPage.existForms[indexFormToCreate].Show();
        }

        private void MoveToPreviousThemeForm_Click(object sender, EventArgs e) => OpenForm(FormsToUSe._indexOfCurrent - 1);


        private void FromTestToThemeButton_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void NextThemeFormFromTheme_Click(object sender, EventArgs e) => OpenForm(FormsToUSe._indexOfCurrent + 1);
    }
}
