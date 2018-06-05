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
using MetroFramework.Controls;


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
        MainPage exitToMainPage = new MainPage();

        public Form1(List<string> text, List<string> test)
        {
            InitializeComponent();
            addЬMackonahellComponents();
            _textCorrectIncorrectCodeStrings = new string[text.Count][];
            _testQuestionAndAnsverStrings = new string[test.Count][];
            InizializeRichTextBoxComponents(text.Count);
            _indexOfCurrentTest = 0;
            DelimitedTextStringTo2Array(text);
            DelimitedTestStringTo2Array(test);
            _varianToUSeCheckBoxs = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4 };
            NextTest();
            panel2.Visible = false;
            fastColoredTextBox1.ReadOnly = true;
            fastColoredTextBox2.ReadOnly = true;


        }

        private void addЬMackonahellComponents()
        {

            if (FormsToUSe.ListsList.Count == FormsToUSe.MackonahellListsList.Count )
            {
                int distanceBetweenMetroButtons = metroButton5.Location.Y-metroButton4.Location.Y;              
                metroButton7.Location = new Point(metroButton7.Location.X, metroButton7.Location.Y + distanceBetweenMetroButtons);
                MetroButton toSixTheMetroButton = new MetroButton()
                {
                    Text="6) Показчики",
                    Location=new Point(metroButton5.Location.X, metroButton5.Location.Y+distanceBetweenMetroButtons),
                    Visible=true ,
                    Size = metroButton5.Size 
                };
                this.Controls.Add(toSixTheMetroButton);
                toSixTheMetroButton.MouseClick += ToSixTheMetroButton_MouseClick;
                metroButton1.Text = "1) Змінні";
                metroButton2.Text = "2) Числові типи даних";
                metroButton3.Text = "3) Рядки й масиви символів";
                metroButton4.Text = "4) Масиви";
                metroButton5.Text = "5) Структури";
            }
        }

        private void ToSixTheMetroButton_MouseClick(object sender, MouseEventArgs e)
        {
            OpenForm(5);
            MackonahellStartPage.existForms[5].NextThemeFormFromTheme.Visible = false;
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
            usingCheckBox.ForeColor = Color.GhostWhite;
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
            usingPanel.BackColor = Color.GhostWhite;
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
            NextThemeFormFromTheme.Visible = false;
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

        public void NextThemeFormFromTheme_Click(object sender, EventArgs e)
        {

            OpenForm(FormsToUSe._indexOfCurrent + 1);

        }

        public void OpenForm(int indexFormToOpen)
        {
      
            if (indexFormToOpen != FormsToUSe._indexOfCurrent)
            {
                List<Form1> existForms = FormsToUSe.ListsList.Count == FormsToUSe.MackonahellListsList.Count                   
                    ? MackonahellStartPage.existForms
                    : StartPage.existForms;
                int indexOfPastTheme = FormsToUSe._indexOfCurrent;
                if (existForms[indexFormToOpen] != null)
                {

                    FormsToUSe._indexOfCurrent = indexFormToOpen;
                    existForms[FormsToUSe._indexOfCurrent].Show();
                }
                else
                {
                    CreateNewForm(indexFormToOpen, existForms);
                }
                if (existForms[indexOfPastTheme] != null)
                    existForms[indexOfPastTheme].Hide();
            }
        }

        public void CreateNewForm(int indexFormToCreate, List<Form1> existForms)
        {
           existForms[indexFormToCreate]= new Form1(FormsToUSe.ListsList[indexFormToCreate][0],
                FormsToUSe.ListsList[indexFormToCreate][1]);
            FormsToUSe._indexOfCurrent = indexFormToCreate;
            if (indexFormToCreate == 0)
                existForms[indexFormToCreate].HideButtonToPrevious();
            if (indexFormToCreate == existForms.Count - 1)
                existForms[indexFormToCreate].HideButtonToNext();
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
            for (int i = 0; i < numberToInizializate; i++)
            {
                RichTextBoxList.Add(new RichTextBox()
                {
                    ReadOnly = true,
                    AutoSize = true,
                    Size = new Size(950, 100),
                    Location = new Point(10, (panel7.Controls.Count) * 100),
                    Tag = i,
                    Font = new Font("Times New Roman", 14)
                });
                panel7.Controls.Add(RichTextBoxList[i]);
                RichTextBoxList[i].MouseClick += a;
            }

        }
        private void a(object sender, MouseEventArgs e)
        {
            var index = ((RichTextBox)sender).Tag;
            richTextBoxListItems_AddText((int)index);
        }
        private void richTextBoxListItems_AddText(int numberForm)
        {
            fastColoredTextBox1.Text = _textCorrectIncorrectCodeStrings[numberForm][1];
            fastColoredTextBox2.Text = _textCorrectIncorrectCodeStrings[numberForm][2];
            label3.Visible = false;
            trueFalseVariantsPanel.Visible = true;

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Hide();
            exitToMainPage.Show();
            Hide();

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_MouseEnter(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.Black;
        }

        private void metroButton6_MouseLeave(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.Black;
        }
    }
}