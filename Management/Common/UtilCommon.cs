using Cdbc.Common.Data.Type;
using Cdbc.Data.Client;
using System;
using System.Configuration;
using System.Drawing;

namespace Management.Common
{
    public static class UtilCommon
    {

        public static string userId = "";
        public static string userPassword = "";
        public static CdbcConnection getConnection()
        {
            CdbcConnection con = new CdbcConnection();

            con.UserId = UtilCommon.userId;
            con.UserPassword = UtilCommon.userPassword;


            //You should encrypt the ApplicationId and ApplicationPsk to prevent leak.
            con.ApplicationId = ConfigurationManager.AppSettings["ApplicationId"];
            con.ApplicationPsk = ConfigurationManager.AppSettings["ApplicationPsk"];

            con.ConnectionString= ConfigurationManager.AppSettings["ConnectionString"];

            con.DatabaseProduct = DatabaseProductType.Oracle;
            con.Compress = false;
            con.Encrypt = false;
            return con;
        }

        public static String NvlStr(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return "";
            }
            else
            {
                return o.ToString();
            }
        }

        public static Image ByteArrayToImage(byte[] b)
        {
            if (b == null) return null;

            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

    }
}
