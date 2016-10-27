using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Лаба_8__Графік
{
    public partial class Form1 : Form
    {
        float x1, x2, a;
        Form3 form;

        public Form1()
        {
            InitializeComponent();
            x1 =(float) Convert.ToDouble(textBox_for_x1.Text);
            x2 = (float)Convert.ToDouble(textBox_for_x2.Text);
            a = (float)Convert.ToDouble(textBox_for_a.Text);
        }

        private void textBox_for_x1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_for_x1.Text == "")
            {
                errorProvider1.SetError(textBox_for_x1, "");
                return;
            }
            if (!float.TryParse((textBox_for_x1.Text), out x1))
            {
                errorProvider1.SetError(textBox_for_x1, "You entered not number");
                return;
            }
            if (x2 < x1)
            {
                errorProvider1.SetError(textBox_for_x1, "x1 can not be higher than x2");
                return;
            }
            errorProvider1.SetError(textBox_for_x1, "");
        }

        private void button_for_draw_function_Click(object sender, EventArgs e)
        {
            if (!(
                errorProvider1.GetError(textBox_for_x1) == "") ||
                errorProvider1.GetError(textBox_for_x2) == "" ||
                errorProvider1.GetError(textBox_for_a) == ""
                )
            {
                form = new Form3(x1, x2, a);
                form.Show();
            }
            else
                MessageBox.Show("You must entered correct your mistakes", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void textBox_for_x2_Validating(object sender, CancelEventArgs e)
        {
            if(textBox_for_x2.Text == "")
            {
                errorProvider1.SetError(textBox_for_x2, "Fiels is empty");
                return;
            }
            if (!float.TryParse((textBox_for_x2.Text), out x2))
            {
                errorProvider1.SetError(textBox_for_x2, "You entered not number");
                return;
            }
            if (x2 < x1)
            {
                errorProvider1.SetError(textBox_for_x2, "x2 can not be less than x1");
                return;
            }
            errorProvider1.SetError(textBox_for_x2, "");
        }
        private void textBox_for_a_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_for_a.Text == "")
            {
                errorProvider1.SetError(textBox_for_a, "Fiels is empty");
                return;
            }
            if (!float.TryParse((textBox_for_a.Text), out a))
            {
                errorProvider1.SetError(textBox_for_x2, "You entered not number");
                return;
            }
            errorProvider1.SetError(textBox_for_x2, "");
        }
    }
}
