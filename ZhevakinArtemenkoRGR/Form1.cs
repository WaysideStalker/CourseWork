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
  
        private  string[] _correctAnswersForTest;
        private readonly int trueFalseVariantsPanelHight;
        List<RichTextBox> RichTextBoxList = new List<RichTextBox>();
        private string[][] _textCorrectIncorrectCodeStrings = new string[10][];
        private string[][] _testQuestionAndAnsverStrings = new string[5][];

        public Form1(string[] text, string[] test)
        {
            InitializeComponent();
            _indexOfCurrentTest = 0;
            DelimitedTextStringTo2Array(text);
            DelimitedTestStringTo2Array(test);
            //_answersForTest = answers;
            //_correctAnswersForTest = correctAnswers;
            //richTextBox2.Text = test;

            _varianToUSeCheckBoxs = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4 };
            //for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
            //  _varianToUSeCheckBoxs[i].Text = answers[i];




            panel2.Visible = false;
            fastColoredTextBox1.ReadOnly = true;
            fastColoredTextBox2.ReadOnly = true;
        }
        private void DelimitedTestStringTo2Array(string[] test)
        {
            for (int i = 0; i < test.Length; i++)
            {
                _testQuestionAndAnsverStrings[i] = test[i].Split('$');
            }
            richTextBox2.Text = _testQuestionAndAnsverStrings[_indexOfCurrentTest][0];
        }
        private void DelimitedTextStringTo2Array(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                _textCorrectIncorrectCodeStrings[i] = text[i].Split('$');
            }

            for (int i = 0; i < _textCorrectIncorrectCodeStrings.Length; i++)
            {
                RichTextBoxList[i].Text = _textCorrectIncorrectCodeStrings[i][0];
            }
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
                FormsToUSe.ListsList[indexFormToCreate][1]));
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
            richTextBox2.Text = _testQuestionAndAnsverStrings[_indexOfCurrentTest][0];
            string[] ansvers = _testQuestionAndAnsverStrings[_indexOfCurrentTest][1].Split('\n');
            _indexOfCurrentTest++;
            for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
                _varianToUSeCheckBoxs[i].Text = ansvers[i];
        }

        private void exitTrueFalseButton_Click(object sender, EventArgs e)
        {
            trueFalseVariantsPanel.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                RichTextBoxList.Add(new RichTextBox()
                {
                    ReadOnly = true,
                    Size = new Size(800, 50),
                    Location = new Point(10, (panel7.Controls.Count) * 50)
                });
                panel7.Controls.Add(RichTextBoxList[i]);
            }
            RichTextBoxList[0].MouseClick += richTextBoxListItem0_MouseClick;
            RichTextBoxList[1].MouseClick += richTextBoxListItem1_MouseClick;
            RichTextBoxList[2].MouseClick += richTextBoxListItem2_MouseClick;
            RichTextBoxList[3].MouseClick += richTextBoxListItem3_MouseClick;
            RichTextBoxList[4].MouseClick += richTextBoxListItem4_MouseClick;
            RichTextBoxList[5].MouseClick += richTextBoxListItem5_MouseClick;
            RichTextBoxList[6].MouseClick += richTextBoxListItem6_MouseClick;
            RichTextBoxList[7].MouseClick += richTextBoxListItem7_MouseClick;
            RichTextBoxList[8].MouseClick += richTextBoxListItem8_MouseClick;
            RichTextBoxList[9].MouseClick += richTextBoxListItem9_MouseClick;
        }

        private void richTextBoxListItems_AddText(int numberForm)
        {
            fastColoredTextBox1.Text = _textCorrectIncorrectCodeStrings[numberForm][1];
            fastColoredTextBox2.Text = _textCorrectIncorrectCodeStrings[numberForm][2];
        }

        private void richTextBoxListItem0_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(0);
        }
        private void richTextBoxListItem1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(1);
        }
        private void richTextBoxListItem2_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(2);
        }
        private void richTextBoxListItem3_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(3);
        }
        private void richTextBoxListItem4_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(4);
        }
        private void richTextBoxListItem5_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(5);
        }
        private void richTextBoxListItem6_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(6);
        }
        private void richTextBoxListItem7_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(7);
        }
        private void richTextBoxListItem8_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(8);

        }
        private void richTextBoxListItem9_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBoxListItems_AddText(9);
        }
    }
}