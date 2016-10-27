using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_7__Windows_form_12__2
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }
        
        private void Help_Load(object sender, EventArgs e)
        {
            label1.Width=Width-20;
            label1.Text = "If you press \"Begin test\" student will has some question. If you press \"Get result\" you can find out how many question is true. If you press \"Exit\" proggram will end";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
