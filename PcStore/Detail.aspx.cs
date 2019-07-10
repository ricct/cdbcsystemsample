using Cdbc.Data.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PcStore
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProductDetail();
        }

        private void GetProductDetail()
        {

            bool hasProduct = false;
            String productcode = Request.QueryString["productcode"];
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
            para.Value = productcode;
            cmd.Parameters.Add(para);

            DataSet dsProduct = new DataSet();
            CdbcDataAdapter myDa = new CdbcDataAdapter(cmd);
            try
            {
                myDa.Fill(dsProduct, "PRODUCT");
                if (dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsProduct.Tables[0].Rows[0];
                    lblProductName.Text = UtilCommon.NvlStr(dr["PRODUCT_NAME"]);
                    lblPrice.Text = UtilCommon.NvlStr(dr["CURRENCY_CODE"])+ UtilCommon.FormatNumber(dr["PRODUCT_PRICE"]);
                    lblDescription.Text = UtilCommon.NvlStr(dr["PRODUCT_SUMMARY"]);
                    lblReleaseDate.Text = UtilCommon.NvlStr(dr["RELEASE_DATE"]);
                    imageProduct.Src= @"./ShowImage?imagetype=product&code=" + UtilCommon.NvlStr(dr["PRODUCT_CODE"]);
                    hasProduct = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Please treat the exception here
            }

            if (!hasProduct)
            {
                Response.Redirect("./Default");
            }

        }
    }
}