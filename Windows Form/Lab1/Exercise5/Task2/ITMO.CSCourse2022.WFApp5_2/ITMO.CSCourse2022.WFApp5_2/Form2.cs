using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.CSCourse2022.WFApp5_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newChild = new Form1();
            newChild.MdiParent = this;
            newChild.Show();
        }
    }
}
