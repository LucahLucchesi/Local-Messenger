using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMessenger
{
    public partial class Test : Form
    {
        int testNum = 0;

        public Test()
        {
            InitializeComponent();
        }

        private void updateHeader()
        {
            this.Text = "Dynamic Numbers: " + testNum.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ++testNum;
            updateHeader();
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            --testNum;
            updateHeader();
        }
    }
}
