using Cdbc.Data.Client;
using System;
using System.Web.UI;
using System.Data;

namespace PcStore
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProductList();
        }

        private void GetProductList()
        {
            CdbcConnection con = UtilCommon.getConnection();

            string cmdQuery = "SELECT P.PRODUCT_CODE "
                + "     , P.PRODUCT_NAME "
                + "     , P.PRODUCT_PRICE "
                + "     , P.CURRENCY_CODE "
                + "     , P.PRODUCT_SUMMARY "
                + "     , P.CATEGORY_CODE "
                + "     , C.CATEGORY_NAME "
                + "  FROM PRODUCTS P "
                + " INNER JOIN CATEGORIES C "
                + "    ON P.CATEGORY_CODE = C.CATEGORY_CODE "
                + " ORDER BY P.PRODUCT_CODE  ";

            // Create the OracleCommand
            CdbcCommand cmd = new CdbcCommand(cmdQuery);

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            CdbcDataAdapter dataAdapter = new CdbcDataAdapter(cmd);
            DataSet dsProduct = new DataSet();

            try
            {
                dataAdapter.Fill(dsProduct, "PRODUCTS");

                ListView1.DataSource = dsProduct;
                ListView1.DataMember = "PRODUCTS";

                ListView1.DataBind();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Please treat the exception here
                lblError.Text = "Error:" + ex.Message;
                lblInfo.Visible = true;
                lblError.Visible = true;
            }
        }

        protected string FormatNumber(object number)
        {
            return UtilCommon.FormatNumber(number);
        }

    }
}