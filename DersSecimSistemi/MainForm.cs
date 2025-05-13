using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    public partial class MainForm : Form
    {
        string loginID;
        string fullName;
        public MainForm(string loginID, string fullName)
        {
            InitializeComponent();
            this.loginID = loginID;
            this.fullName = fullName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelStudentInfo.Text = $"{loginID} - {fullName}";
        }

    }
}
