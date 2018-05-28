using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZhevakinArtemenkoRGR
{
    public partial class Form1 : Form
    {
        private readonly List<CheckBox> _varianToUSeCheckBoxs;
        private int _indexOfCurrentTest;
        private readonly string[] _answersForTest;
        private readonly string[] _correctAnswersForTest;
        private readonly int coloredTextBoxHight;
        private readonly int trueFalseVariantsPanelHight;

        public Form1(string text, string test, string[] answers, string[] correctAnswers)
        {
            InitializeComponent();
            _indexOfCurrentTest = 0;
            _answersForTest = answers;
            _correctAnswersForTest = correctAnswers;
            richTextBox1.Text = text;
            richTextBox2.Text = test;

            _varianToUSeCheckBoxs = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4 };
            for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
                _varianToUSeCheckBoxs[i].Text = answers[i];

            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox2.BorderStyle = BorderStyle.None;


            panel2.Visible = false;
            fastColoredTextBox1.ReadOnly = true;
            fastColoredTextBox2.ReadOnly = true;
            coloredTextBoxHight = fastColoredTextBox1.Size.Height;
            trueFalseVariantsPanelHight = trueFalseVariantsPanel.Size.Height;
        }

        public void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void FromTestToThemeButton_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
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

        public void HideButtonToPrevious() => MoveToPreviousThemeForm.Visible = false;
        public void HideButtonToNext() => NextThemeFormFromTest.Visible = false;
        private void metroButton1_Click(object sender, EventArgs e) => OpenForm(0);
        private void metroButton2_Click(object sender, EventArgs e) => OpenForm(1);
        private void metroButton3_Click(object sender, EventArgs e) => OpenForm(2);
        private void metroButton4_Click(object sender, EventArgs e) => OpenForm(3);
        private void metroButton5_Click(object sender, EventArgs e) => OpenForm(4);

        private void MoveToPreviousThemeForm_Click(object sender, EventArgs e) =>
            OpenForm(FormsToUSe._indexOfCurrent - 1);

        private void NextThemeFormFromTheme_Click(object sender, EventArgs e) =>
            OpenForm(FormsToUSe._indexOfCurrent + 1);

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
            StartPage.existForms.Insert(indexFormToCreate, new Form1(FormsToUSe.ListsList[indexFormToCreate][0],
                FormsToUSe.ListsList[indexFormToCreate][1], FormsToUSe.ListsList[indexFormToCreate][2].Split('\n'),
                FormsToUSe.ListsList[indexFormToCreate][3].Split('\n')));
            FormsToUSe._indexOfCurrent = indexFormToCreate;
            if (indexFormToCreate == 0)
                StartPage.existForms[indexFormToCreate].HideButtonToPrevious();
            if (indexFormToCreate == StartPage.existForms.Count - 1)
                StartPage.existForms[indexFormToCreate].HideButtonToNext();

            StartPage.existForms[indexFormToCreate].Show();
        }

        private void AnsverOnTest_ThinButton_Click(object sender, EventArgs e)
        {
            foreach (var i in _varianToUSeCheckBoxs)
            {
                if (i.Checked)
                {
                    if (i.Text == _correctAnswersForTest[_indexOfCurrentTest])
                    {
                        ErorInputLabel.Visible = false;
                        i.Checked = false;
                        NextTest();
                        break;
                    }

                    ErorInputLabel.Visible = true;
                }
            }
        }

        private void NextTest()
        {
            _indexOfCurrentTest++;
            for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
                _varianToUSeCheckBoxs[i].Text = _answersForTest[i + _indexOfCurrentTest * 4];
        }

        private void exitTrueFalseButton_Click(object sender, EventArgs e)
        {
            trueFalseVariantsPanel.Visible = false;
        }
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            showTrueFalsePanelAtRigthPlace(58, 0, "int hourDataTimeNow", "inc a");
        }
        private void showTrueFalsePanelAtRigthPlace(int xCoordinate, int yCoordinate, string correctCodeExemple, string incorrectCodeExample)
        {
            trueFalseVariantsPanel.Visible = true;
            trueFalseVariantsPanel.Location = new Point(170 + xCoordinate,0);
            int amountCorrect = new Regex("\n").Matches(correctCodeExemple + "\n").Count;
            int amountIncorrect = new Regex("\n").Matches(incorrectCodeExample + "\n").Count;
            trueFalseVariantsPanel.Size = new Size(trueFalseVariantsPanel.Size.Width,
                trueFalseVariantsPanelHight - coloredTextBoxHight + (amountIncorrect> amountCorrect ? amountIncorrect : amountCorrect ) * 15 + 2);
            fastColoredTextBox1.Text = correctCodeExemple;
            fastColoredTextBox2.Text = incorrectCodeExample;
        }

        private void richTextBox3_MouseClick(object sender, MouseEventArgs e)
        {

            showTrueFalsePanelAtRigthPlace(57, 0, "int fullDataTime\n123", "inc a");
        }

        private void richTextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            showTrueFalsePanelAtRigthPlace(58, 0, "int dataTimeNowHours", "inc a");

        }

        private void richTextBox5_MouseClick(object sender, MouseEventArgs e)
        {
            showTrueFalsePanelAtRigthPlace(58, 0, "int dataTimeNowHours", "inc a");
        }
    }
}