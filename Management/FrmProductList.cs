using Cdbc.Common.Data.Type;
using Cdbc.Data.Client;
using Management.Common;
using Management.Datasets;
using System;
using System.Data;
using System.Windows.Forms;

namespace Management
{
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }


        private DataSetProducts dsCategories=new DataSetProducts() ;
        private DataSetProducts dsCurrencies = new DataSetProducts();

        private DataSetProducts dsCategoriesCurrencies = new DataSetProducts();

        private void getCategoryCurrencyList()
        {
            CdbcConnection con = UtilCommon.getConnection();


            CdbcDataAdapter dataAdapter = new CdbcDataAdapter();
            //CATEGORIES
            string cmdQuery = "SELECT C.CATEGORY_CODE "
                           + "     , C.CATEGORY_NAME "
                           + "  FROM CATEGORIES C "
                           + " ORDER BY C.CATEGORY_CODE";
            CdbcCommand cmd = new CdbcCommand(cmdQuery,con);
            dataAdapter.AddMultiSelectCommand(cmd, dsCategoriesCurrencies.CATEGORIES.TableName);

            //CURRENCIES
            cmdQuery = "SELECT C.CURRENCY_CODE "
                            + "     , C.CURRENCY_SYMBOL "
                            + "  FROM CURRENCIES C "
                            + " ORDER BY C.CURRENCY_CODE";
            cmd = new CdbcCommand(cmdQuery, con);
            dataAdapter.AddMultiSelectCommand(cmd, dsCategoriesCurrencies.CURRENCIES.TableName);


            try
            {
                dsCategoriesCurrencies = new DataSetProducts();
                int[] fillResult = dataAdapter.MultiFill(dsCategoriesCurrencies);


 
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error)
                        ;
            }
        }

        private void getCategoryList()
        {

            CdbcConnection con = UtilCommon.getConnection();

            string cmdQuery = "SELECT C.CATEGORY_CODE "
                            + "     , C.CATEGORY_NAME "
                            + "  FROM CATEGORIES C "
                            + " ORDER BY C.CATEGORY_CODE";

            CdbcCommand cmd = new CdbcCommand(cmdQuery);

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            CdbcDataAdapter dataAdapter = new CdbcDataAdapter(cmd);

            try
            {
                dataAdapter.Fill(dsCategories, dsCategories.CATEGORIES.TableName);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error)
                        ;
            }
        }


        private void getCurrencyList()
        {

            CdbcConnection con = UtilCommon.getConnection();

            string cmdQuery = "SELECT C.CURRENCY_CODE "
                            + "     , C.CURRENCY_SYMBOL "
                            + "  FROM CURRENCIES C "
                            + " ORDER BY C.CURRENCY_CODE";

            CdbcCommand cmd = new CdbcCommand(cmdQuery);

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            CdbcDataAdapter dataAdapter = new CdbcDataAdapter(cmd);

            try
            {
                dataAdapter.Fill(dsCurrencies, dsCurrencies.CURRENCIES.TableName);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error)
                        ;
            }
        }

        private void GetProductList()
        {

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            CdbcConnection con = UtilCommon.getConnection();

            string cmdQuery = "SELECT P.PRODUCT_CODE "
                            + "     , P.PRODUCT_NAME "
                            + "     , P.PRODUCT_PRICE "
                            + "     , P.CURRENCY_CODE "
                            + "     , P.PRODUCT_SUMMARY "
                            + "     , P.CATEGORY_CODE "
                            + "     , CA.CATEGORY_NAME "
                            + "  FROM PRODUCTS P "
                            + " INNER JOIN CATEGORIES CA "
                            + "    ON P.CATEGORY_CODE = CA.CATEGORY_CODE "
                            + " ORDER BY P.PRODUCT_CODE  ";

            // Create the OracleCommand
            CdbcCommand cmd = new CdbcCommand(cmdQuery);

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            
            dataSetProducts1.PRODUCTS.Clear();
            CdbcDataAdapter dataAdapter = new CdbcDataAdapter(cmd);

            try
            {
                dataAdapter.Fill(dataSetProducts1, dataSetProducts1.PRODUCTS.TableName);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                         ;
            }
            cmd.Dispose();

            sw.Stop();
            this.Text = $"{sw.ElapsedMilliseconds} ms";

        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            gvProdList.RowTemplate.Height = 30;
            GetProductList();
            Application.DoEvents();
            //getCategoryList();
            //getCurrencyList();

            getCategoryCurrencyList();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProduct frmProduct = new FrmProduct();
            frmProduct.isNew = true;
            frmProduct.dsCategoriesCurrencies = (DataSetProducts)this.dsCategoriesCurrencies.Copy();
            frmProduct.ShowDialog();
            if (frmProduct.dataSaved)
            {
                GetProductList();
            }
            frmProduct.Dispose();
            this.Show();
        }

        private void GvProdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colBtnEdit.Index)
            {
                
                DataGridViewRow row = this. gvProdList.Rows[e.RowIndex];
                FrmProduct frmProduct = new FrmProduct();
                frmProduct.isNew = false;
                frmProduct.dsCategoriesCurrencies = (DataSetProducts)this.dsCategoriesCurrencies.Copy();
                frmProduct.ProductCode = row.Cells[colProductCode.Index].Value.ToString();
                this.Hide();
                frmProduct.ShowDialog();
                if (frmProduct.dataSaved)
                {
                    GetProductList();
                }
                frmProduct.Dispose();
                this.Show();
            }
            else if (e.ColumnIndex == colBtnDelete.Index)
            {


                DialogResult result = MessageBox.Show("Are you sure to delete？",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                DataGridViewRow row = this.gvProdList.Rows[e.RowIndex];
                String productcode = row.Cells[colProductCode.Index].Value.ToString();

                String cmdQuery = @"DELETE FROM PRODUCTS WHERE PRODUCT_CODE=:PRODUCT_CODE";

                CdbcConnection con = UtilCommon.getConnection();
                CdbcCommand cmd = new CdbcCommand(cmdQuery, con);

                CdbcParameter para = new CdbcParameter(":PRODUCT_CODE", CdbcOracleDbType.Varchar2);
                para.Value = productcode;
                cmd.Parameters.Add(para);
                try
                {
                    cmd.ExecuteNonQuery();
                    GetProductList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                     ;
                }

            }
        }

        private void LblLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
        }
    }
}
