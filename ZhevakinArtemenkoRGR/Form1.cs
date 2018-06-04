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

        private string[] _correctAnswersForTest;
        private readonly int trueFalseVariantsPanelHight;
        List<RichTextBox> RichTextBoxList = new List<RichTextBox>();
        private string[][] _textCorrectIncorrectCodeStrings;
        private string[][] _testQuestionAndAnsverStrings;

        public Form1(List<string> text, List<string> test)
        {
            _textCorrectIncorrectCodeStrings = new string[text.Count][];
            _testQuestionAndAnsverStrings = new string[test.Count][];
            InitializeComponent();
            InizializeRichTextBoxComponents(text.Count);
            _indexOfCurrentTest = 0;
            DelimitedTextStringTo2Array(text);
            DelimitedTestStringTo2Array(test);
            //_answersForTest = answers;
            //_correctAnswersForTest = correctAnswers;
            //richTextBox2.Text = test;
            _varianToUSeCheckBoxs = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4 };
            //for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
            //  _varianToUSeCheckBoxs[i].Text = answers[i];
            NextTest();



            panel2.Visible = false;
            fastColoredTextBox1.ReadOnly = true;
            fastColoredTextBox2.ReadOnly = true;
        }
        private void DelimitedTestStringTo2Array(List<string> test)
        {
            for (int i = 0; i < test.Count; i++)
            {
                _testQuestionAndAnsverStrings[i] = test[i].Split('$');
            }
            textForTestFastColoredTextBox.Text = _testQuestionAndAnsverStrings[_indexOfCurrentTest][0];
        }
        private void DelimitedTextStringTo2Array(List<string> text)
        {
            for (int i = 0; i < text.Count; i++)
            {
                _textCorrectIncorrectCodeStrings[i] = text[i].Split('$');
            }

            for (int i = 0; i < RichTextBoxList.Count; i++)
            {
                RichTextBoxList[i].Text = _textCorrectIncorrectCodeStrings[i][0];////
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

        public void panel4_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterInPanelWithChechBox(panel3, checkBox1);
        }

        public void panel5_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterInPanelWithChechBox(panel4, checkBox2);
        }

        public void panel6_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterInPanelWithChechBox(panel5, checkBox3);
        }

        public void panel7_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterInPanelWithChechBox(panel6, checkBox4);
        }

        public void MouseLeaveInPanelWithChechBox(Panel usingPanel, CheckBox usingCheckBox)
        {
            usingPanel.BackColor = Color.Silver;
            usingCheckBox.BackColor = Color.Transparent;
            usingCheckBox.ForeColor = Color.Black;
        }

        public void panel4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveInPanelWithChechBox(panel3, checkBox1);
        }

        public void panel5_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveInPanelWithChechBox(panel4, checkBox2);
        }

        public void panel6_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveInPanelWithChechBox(panel5, checkBox3);
        }

        public void panel7_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveInPanelWithChechBox(panel6, checkBox4);
        }

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

        public void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            OpenForm(FormsToUSe._indexOfCurrent + 1);
        }

        public void HideButtonToPrevious()
        {
            MoveToPreviousThemeForm.Visible = false;
        }

        public void HideButtonToNext()
        {
            NextThemeFormFromTest.Visible = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }

        private void MoveToPreviousThemeForm_Click(object sender, EventArgs e)
        {
            OpenForm(FormsToUSe._indexOfCurrent - 1);
        }

        private void NextThemeFormFromTheme_Click(object sender, EventArgs e)
        {

            OpenForm(FormsToUSe._indexOfCurrent + 1);
        }

        public void OpenForm(int indexFormToOpen)
        {
            if (indexFormToOpen != FormsToUSe._indexOfCurrent)
            {
                int indexOfPastTheme = FormsToUSe._indexOfCurrent;
                if (StartPage.existForms[indexFormToOpen] != null)
                {
                    FormsToUSe._indexOfCurrent = indexFormToOpen;
                    StartPage.existForms[FormsToUSe._indexOfCurrent].Show();
                }
                else
                {
                    CreateNewForm(indexFormToOpen);
                }
                if (StartPage.existForms[indexOfPastTheme] != null)
                    StartPage.existForms[indexOfPastTheme].Hide();
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
                    if (i.Text.Replace("\n", "") == _testQuestionAndAnsverStrings[_indexOfCurrentTest][2].Replace("\n", ""))
                    {
                        ErorInputLabel.Visible = false;
                        i.Checked = false;
                        _indexOfCurrentTest++;
                        NextTest();
                        break;
                    }
                    ErorInputLabel.Visible = true;
                }
            }
        }

        private void NextTest()
        {
            if (_indexOfCurrentTest < _testQuestionAndAnsverStrings.Length)
            {
                textForTestFastColoredTextBox.Text = _testQuestionAndAnsverStrings[_indexOfCurrentTest][0];
                string[] ansvers = _testQuestionAndAnsverStrings[_indexOfCurrentTest][1].Split('\n');
                for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
                    _varianToUSeCheckBoxs[i].Text = ansvers[i + 1];
            }
            else
            {
                textForTestFastColoredTextBox.Text = "The test is over";
                AnsverOnTest_ThinButton.Visible = false;
                for (int i = 0; i < _varianToUSeCheckBoxs.Count; i++)
                {
                    _varianToUSeCheckBoxs[i].Text = "";
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = false;
                }
            }
        }

        private void exitTrueFalseButton_Click(object sender, EventArgs e)
        {
            trueFalseVariantsPanel.Visible = false;
            label3.Visible = true;
        }
        private void InizializeRichTextBoxComponents(int numberToInizializate)
        {
            MouseEventHandler[] richTextBoxListItemsActions = GetRichTextBoxListItemsActions();
            for (int i = 0; i < numberToInizializate; i++)
            {
                RichTextBoxList.Add(new RichTextBox()
                {
                    ReadOnly = true,
                    Size = new Size(900, 100),
                    Location = new Point(10, (panel7.Controls.Count) * 100)
                });
                panel7.Controls.Add(RichTextBoxList[i]);
                RichTextBoxList[i].MouseClick += richTextBoxListItemsActions[i];
            }

        }
        private MouseEventHandler[] GetRichTextBoxListItemsActions()
        {
            MouseEventHandler[] actionsToReturn = new MouseEventHandler[10];
            actionsToReturn[0] += richTextBoxListItem0_MouseClick;
            actionsToReturn[1] += richTextBoxListItem1_MouseClick;
            actionsToReturn[2] += richTextBoxListItem2_MouseClick;
            actionsToReturn[3] += richTextBoxListItem3_MouseClick;
            actionsToReturn[4] += richTextBoxListItem4_MouseClick;
            actionsToReturn[5] += richTextBoxListItem5_MouseClick;
            actionsToReturn[6] += richTextBoxListItem6_MouseClick;
            actionsToReturn[7] += richTextBoxListItem7_MouseClick;
            actionsToReturn[8] += richTextBoxListItem8_MouseClick;
            actionsToReturn[9] += richTextBoxListItem9_MouseClick;
            return actionsToReturn;
        }
        private void richTextBoxListItems_AddText(int numberForm)
        {
            fastColoredTextBox1.Text = _textCorrectIncorrectCodeStrings[numberForm][1];
            fastColoredTextBox2.Text = _textCorrectIncorrectCodeStrings[numberForm][2];
            label3.Visible = false;
            trueFalseVariantsPanel.Visible = true;

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

        private void ToStartPage_Click(object sender, EventArgs e)
        {
            MainPage exitFromDeytell = new MainPage();
            exitFromDeytell.Show();
            Hide();
        }
    }
}