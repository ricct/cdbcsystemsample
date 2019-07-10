using Cdbc.Common.Data.Type;
using Cdbc.Data.Client;
using System;
using System.Drawing;
using System.Globalization;
using System.Web.Configuration;

public static class UtilCommon
{
    public static String NvlStr(object value)
    {
        if (value == null || value == DBNull.Value)
        {
            return "";
        }
        else
        {
            return value.ToString();
        }
    }


    public static String FormatNumber(object value)
    {
        if (value == null || value == DBNull.Value)
        {
            return "";
        }
        else
        {
            return ((long)value).ToString("0,0", CultureInfo.InvariantCulture);
        }
    }


    public static CdbcConnection getConnection()
    {

        
        CdbcConnection con = new CdbcConnection();
        con.UserId = WebConfigurationManager.AppSettings["UserId"];
        con.UserPassword = WebConfigurationManager.AppSettings["UserPassword"];
        con.ApplicationId = WebConfigurationManager.AppSettings["ApplicationId"];
        con.ApplicationPsk = WebConfigurationManager.AppSettings["ApplicationPsk"];
        con.ConnectionString = WebConfigurationManager.AppSettings["ConnectionString"];

        con.DatabaseProduct = DatabaseProductType.Oracle;
        con.Compress = false;
        con.Encrypt = false;

        return con;
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
