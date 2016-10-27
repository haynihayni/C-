using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Лаба_7__Windows_form_12__2
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// String with question and answer
        /// </summary>
        List<string> strMass;
        /// <summary>
        /// array with question + 4 answer and array with true answer
        /// </summary>
        string[] all_question_with_answer, only_question;
        /// <summary>
        /// need for count asks
        /// </summary>
        int number_of_current_question,
            count_true_answer;
        const string name_of_main_form = "Ponomaenko M.I. (CE-1 var15)";

        public Form2()
        {
            InitializeComponent();
            strMass = new List<string>();
            number_of_current_question = 0;// amoung of strong in file start from 0
            count_true_answer = 0;
            using (StreamReader sr = new StreamReader("test.txt", Encoding.GetEncoding(1251)))
            {
                while (!sr.EndOfStream)
                    strMass.Add(sr.ReadLine());
            }
            
            nextAsk();
        }

        /// <summary>
        /// Open next ask
        /// </summary>
        private void nextAsk()
        {
            if (number_of_current_question < strMass.Count)
            {
                all_question_with_answer = strMass[number_of_current_question].Split('#'); /// Divide all string on two substring: all question and a answer
                only_question = all_question_with_answer[0].Split('@');//Divide on question and four variant answer
                label1.Text = only_question[0];//Question
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton1.Text = only_question[1];//first answer
                radioButton2.Text = only_question[2];//second answer
                radioButton3.Text = only_question[3];
                radioButton4.Text = only_question[4];
            }
            else//when asks are ended, we hide this form and return to main form
            {
                MessageBox.Show("You have " + count_true_answer + " true answer", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MdiParent.Text = name_of_main_form;
                Close();
            }

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Text = "File №" + (Array.IndexOf((MdiParent.MdiChildren), this) + 1);
            MdiParent.Text = name_of_main_form + ") File №" + (Array.IndexOf((MdiParent.MdiChildren), this) + 1);
            MdiParent.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure, that you want to finish the test?", "End of programm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                MdiParent.Text = name_of_main_form;
                //if (MdiParent.MdiChildren[0] != null)
                //    MdiParent.MdiChildren[0].Activate();
                Close();
            }
        }


        /// <summary>
        ///When user press botton "Next" programm check trueing result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                if (all_question_with_answer[1] == radioButton1.Text)
                    ++count_true_answer;
            if (radioButton2.Checked == true)
                if (all_question_with_answer[1] == radioButton2.Text)
                    ++count_true_answer;
            if (radioButton3.Checked == true)
                if (all_question_with_answer[1] == radioButton3.Text)
                    ++count_true_answer;
            if (radioButton4.Checked == true)
                if (all_question_with_answer[1] == radioButton4.Text)
                    ++count_true_answer;
            ++number_of_current_question;
            nextAsk();
        }
    }
}
