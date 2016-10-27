using System;
using System.Windows.Forms;

namespace Лаба_7__Windows_form_12__2
{
    public partial class Form1 : Form
    {
        int count;
        public int Count { get { return count; } set { count = value; } }

        public Form1()
        {
            InitializeComponent();
            count = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void beginTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 q = new Form2();
            q.MdiParent = this;
            windowsOfTestToolStripMenuItem.Enabled = true;
            q.Dock = DockStyle.Fill;
            q.Show();
        }
    }
}
