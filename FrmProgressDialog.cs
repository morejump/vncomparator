using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VnSentencesConparator
{
    public partial class FrmProgressDialog : MetroFramework.Forms.MetroForm
    {
        public FrmProgressDialog()
        {
            InitializeComponent();
        }

        public string Message
        {
            set { lbMsg.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar.Value = value; }
        }

        public void toogleImg()
        {
            picLoading.Visible = true;
            progressBar.Hide();
        }

        private void frmProgressDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
