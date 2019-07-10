using Cdbc.Data.Client;
using Management.Common;
using Management.Datasets;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Management
{
    public partial class FrmProduct : Form
    {

        static ImageConverter imgconv = new ImageConverter();

        private bool _isNew;
        public bool dataSaved;
        public DataSetProducts dsCategoriesCurrencies;


        public bool isNew
        {
            set
            {
                _isNew = value;
                txtProductCode.Enabled = _isNew;
            }
            get
            {
                return _isNew;
            }
        }


        public String ProductCode
        {
            set
            {
                txtProductCode.Text = value;
            }
            get
            {
                return txtProductCode.Text;
            }
        }

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = dsCategoriesCurrencies.CATEGORIES;
            cbCategory.DisplayMember = dsCategoriesCurrencies.CATEGORIES.CATEGORY_NAMEColumn.ColumnName;
            cbCategory.ValueMember = dsCategoriesCurrencies.CATEGORIES.CATEGORY_CODEColumn.ColumnName;

            cbCurrency.DataSource = dsCategoriesCurrencies.CURRENCIES;
            cbCurrency.DisplayMember = dsCategoriesCurrencies.CURRENCIES.CURRENCY_CODEColumn.ColumnName;
            cbCurrency.ValueMember = dsCategoriesCurrencies.CURRENCIES.CURRENCY_CODEColumn.ColumnName;

            GetData();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                dataSaved = true;
                Close();
            }
        }


        private void GetData()
        {

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (!isNew)
            {
                CdbcConnection con = UtilCommon.getConnection();

                string cmdQuery = "SELECT P.PRODUCT_CODE "
                 + "     , P.PRODUCT_NAME "
                 + "     , P.PRODUCT_PRICE "
                 + "     , P.CURRENCY_CODE "
                 + "     , P.PRODUCT_SUMMARY "
                 + "     , P.CATEGORY_CODE "
                 + "     , P.PRODUCT_IMAGE "
                 + "     , P.RELEASE_DATE "
                 + "  FROM PRODUCTS P "
                 + " WHERE P.PRODUCT_CODE = :PRODUCT_CODE ";

                CdbcCommand cmd = new CdbcCommand(cmdQuery);

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                CdbcParameter para = new CdbcParameter(":PRODUCT_CODE", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
                para.Value = ProductCode;
                cmd.Parameters.Add(para);

                DataSetProducts dsProduct = new DataSetProducts();
                CdbcDataAdapter myDa = new CdbcDataAdapter(cmd);
                try
                {
                    myDa.Fill(dsProduct, dsProduct.PRODUCTS.TableName);
                    if (dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                    {
                        DataSetProducts.PRODUCTSRow dr = (DataSetProducts.PRODUCTSRow)dsProduct.PRODUCTS.Rows[0];
                        txtProductName.Text = UtilCommon.NvlStr(dr. PRODUCT_NAME);
                        txtPrice.Text = UtilCommon.NvlStr(dr.PRODUCT_PRICE);
                        cbCurrency.SelectedValue = UtilCommon.NvlStr(dr.CURRENCY_CODE);
                        txtSummary.Text = UtilCommon.NvlStr(dr.PRODUCT_SUMMARY);
                        cbCategory.SelectedValue = UtilCommon.NvlStr(dr.CATEGORY_CODE);
                        dtReleaseDate.Value = dr.RELEASE_DATE;
                        pictureBox1.Image = UtilCommon.ByteArrayToImage(dr.PRODUCT_IMAGE);
                    }
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
            sw.Stop();
            this.Text = $"{sw.ElapsedMilliseconds} ms";
        }

        private bool SaveData()
        {
            CdbcConnection con = UtilCommon.getConnection();
            string cmdQuery;

            if (isNew)
            {
                cmdQuery = @"INSERT INTO PRODUCTS("
                                 + "    PRODUCT_NAME"
                                 + "  , PRODUCT_PRICE"
                                 + "  , CURRENCY_CODE"
                                 + "  , PRODUCT_SUMMARY"
                                 + "  , CATEGORY_CODE"
                                 + "  , PRODUCT_IMAGE"
                                 + "  , RELEASE_DATE"
                                 + "  , PRODUCT_CODE"
                                 + " ) "
                                 + "VALUES ("
                                 + "    :PRODUCT_NAME"
                                 + "  , :PRODUCT_PRICE"
                                 + "  , :CURRENCY_CODE"
                                 + "  , :PRODUCT_SUMMARY"
                                 + "  , :CATEGORY_CODE"
                                 + "  , :PRODUCT_IMAGE"
                                 + "  , :RELEASE_DATE"
                                 + "  , :PRODUCT_CODE"
                                 + ")";

            }
            else
            {
                cmdQuery = @"UPDATE PRODUCTS "
                              + " SET PRODUCT_NAME    = :PRODUCT_NAME"
                              + "  ,  PRODUCT_PRICE   = :PRODUCT_PRICE"
                              + "  ,  CURRENCY_CODE   = :CURRENCY_CODE"
                              + "  ,  PRODUCT_SUMMARY = :PRODUCT_SUMMARY"
                              + "  ,  CATEGORY_CODE   = :CATEGORY_CODE"
                              + "  ,  PRODUCT_IMAGE   = :PRODUCT_IMAGE"
                              + "  ,  RELEASE_DATE    = :RELEASE_DATE"
                              + " WHERE PRODUCT_CODE  = :PRODUCT_CODE";
            }

            // Create the OracleCommand
            CdbcCommand cmd = new CdbcCommand(cmdQuery, con);

            CdbcParameter para = new CdbcParameter(":PRODUCT_NAME", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            para.Value = txtProductName.Text;
            cmd.Parameters.Add(para);

            para = new CdbcParameter(":PRODUCT_PRICE", Cdbc.Common.Data.Type.CdbcOracleDbType.Decimal);
            int iPrice;
            if (Int32.TryParse(txtPrice.Text, out iPrice)){
                para.Value = iPrice;
            }
            else
            {
                MessageBox.Show("Invalid price.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
                 ;
                return false;
            }
            cmd.Parameters.Add(para);

            para = new CdbcParameter(":CURRENCY_CODE", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            para.Value =  cbCurrency.SelectedValue;
            cmd.Parameters.Add(para);

            para = new CdbcParameter(":PRODUCT_SUMMARY", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            para.Value = txtSummary.Text;
            cmd.Parameters.Add(para);


            para = new CdbcParameter(":CATEGORY_CODE", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            para.Value = cbCategory.SelectedValue;
            cmd.Parameters.Add(para);


            para = new CdbcParameter(":PRODUCT_IMAGE", Cdbc.Common.Data.Type.CdbcOracleDbType.Blob);
            para.Value = UtilCommon.ImageToByteArray(pictureBox1.Image);
            cmd.Parameters.Add(para);

            para = new CdbcParameter(":RELEASE_DATE", Cdbc.Common.Data.Type.CdbcOracleDbType.Date);
            para.Value = new DateTime(dtReleaseDate.Value.Year, dtReleaseDate.Value.Month, dtReleaseDate.Value.Day);
            cmd.Parameters.Add(para);

            para = new CdbcParameter(":PRODUCT_CODE", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            para.Value = ProductCode;
            cmd.Parameters.Add(para);

            //if (!isNew)
            //{
            //    para = new CdbcParameter(":ISBN2", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
            //    para.Value = txtISBN.Text;
            //    cmd.Parameters.Add(para);
            //}


            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
                 ;
                return false;
            }

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
