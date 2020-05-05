using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Transitor
{
    public partial class FileReadAndUpload : System.Web.UI.Page
    {

        string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (File.Exists(Server.MapPath("~/Uploads/" + FileUpload1.FileName)))
                {
                    lblMessage.Text = "Please rename your file and try agin";
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                    lblMessage.Text = FileUpload1.FileName;
                    ReadAndParcelXml(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                    Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                }
            }
            else
            {
                lblMessage.Text = "Please select a file";
            }
        }

        private void ReadAndParcelXml(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.SelectNodes("/resources/string");

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (XmlNode item in nodes)
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("PhraseAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@PhraseID", Convert.ToInt32(hfPhraseID.Value == "" ? "0" : hfPhraseID.Value));
                    sqlCmd.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                    sqlCmd.Parameters.AddWithValue("@Phrase", item.InnerText);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }

        }
    }
}