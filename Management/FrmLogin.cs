using Cdbc.Data.Client;
using Management.Common;
using System;
using System.Windows.Forms;

namespace Management
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            UtilCommon.userId = txtUserId.Text;
            UtilCommon.userPassword = txtPassword.Text;
            CdbcConnection con = UtilCommon.getConnection();
            
            try
            {
                con.ConnectToServiceWhileOpen = true;
                con.Open();

                this.Hide();

                FrmProductList frmProductList = new FrmProductList();
                frmProductList.ShowDialog();
                frmProductList.Dispose();

                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
                  ;
            }
        }

        private void LblLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
        }
    }
}
