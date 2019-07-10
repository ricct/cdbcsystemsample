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
    public partial class ShowImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string imageType = Page.Request.QueryString.Get("imagetype");
            string code = Page.Request.QueryString.Get("code");

            if (String.IsNullOrEmpty(imageType) || String.IsNullOrEmpty(code))
            {
                Response.End();
                return;
            }
          
            string cmdQuery = "";
            if (imageType == "product")
            {
                cmdQuery = " SELECT P.PRODUCT_IMAGE "
                + "  FROM PRODUCTS P "
                + " WHERE P.PRODUCT_CODE=:PRODUCT_CODE";
            }

            Response.ContentType = "image";
            Response.Flush();

            if (!String.IsNullOrEmpty(cmdQuery))
            {
                CdbcConnection con = UtilCommon.getConnection();

                CdbcCommand cmd = new CdbcCommand(cmdQuery);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                CdbcParameter para = new CdbcParameter(":PRODUCT_CODE", Cdbc.Common.Data.Type.CdbcOracleDbType.Varchar2);
                para.Value = code;
                cmd.Parameters.Add(para);

                CdbcDataAdapter dataAdapter = new CdbcDataAdapter(cmd);
                DataSet dsProduct = new DataSet();

                try
                {
                    dataAdapter.Fill(dsProduct, "PRODUCTS");
                    if (dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsProduct.Tables[0].Rows[0];

                        byte[] bImage = (byte[])(dr["PRODUCT_IMAGE"]);
                        Response.OutputStream.Write(bImage, 0, bImage.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Please treat the exception here
                }
            }

            Response.End();
        }
    }
}