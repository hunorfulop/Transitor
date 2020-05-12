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
            if (Session["projectid"].ToString() == "expired")
            {
                Response.Write("<script language='javascript'>window.alert('This session has expired! If you want to start a new project please visit the New Project menu');window.location='Home.aspx';</script>");
            }
            else
            {

                lblMessage.Text = "";

                if (FileUpload1.HasFile)
                {
                    if (File.Exists(Server.MapPath("~/Uploads/" + FileUpload1.FileName)))
                    {
                        lblMessage.Text = "Please rename your file and try agin";
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));

                        string temp = getProjetFileType();
                        FileInfo fi = new FileInfo(FileUpload1.FileName);
                        string ext = fi.Extension;

                        if (temp == ext)
                        {
                            if (temp == ".xml")
                            {
                                ShowInListBoxXml(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                            }
                            else
                            {
                                ShowInListBoxResx(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Please upload a file which has the correct extension: " + temp;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Please select a file";
                }
            }
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Session["projectid"].ToString() == "expired")
            {
                Response.Write("<script language='javascript'>window.alert('This session has expired! If you want to start a new project please visit the New Project menu');window.location='Home.aspx';</script>");
            }
            else
            {

                string temp = getProjetFileType();
                if (temp == ".xml")
                {
                    ReadAndParcelXml();
                    Session["projectid"] = "expired";
                    Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                }
                else
                {
                    ReadAndParceResX();
                    Session["projectid"] = "expired";
                    Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                }
            }
        }

        private void ShowInListBoxXml(string path)
        {
            LabelMsg1.Visible = true;
            LabelMsg2.Visible = true;
            ListBoxPhrases.Visible = true;
            btn_Confirm.Visible = true;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.SelectNodes("/resources/string");

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (XmlNode item in nodes)
                {
                    ListBoxPhrases.Items.Add(item.InnerText);
                }
            }
        }

        private void ShowInListBoxResx(string path)
        {
            ListBoxPhrases.Visible = true;
            btn_Confirm.Visible = true;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.SelectNodes("/root/data/value");

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (XmlNode item in nodes)
                {
                    ListBoxPhrases.Items.Add(item.InnerText);
                }
            }
        }


        private void ReadAndParcelXml()
        {
            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    for (int loop = 0; loop < ListBoxPhrases.Items.Count; loop++)
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("PhraseAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@PhraseID", Convert.ToInt32(hfPhraseID.Value == "" ? "0" : hfPhraseID.Value));
                        sqlCmd.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                        sqlCmd.Parameters.AddWithValue("@Phrase", ListBoxPhrases.Items[loop].ToString());
                        sqlCmd.Parameters.AddWithValue("@TransLanguage", dr.Field<string>("TranslationLanguage"));
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
        }

        private void ReadAndParceResX()
        {
            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    for (int loop = 0; loop < ListBoxPhrases.Items.Count; loop++)
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("PhraseAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@PhraseID", Convert.ToInt32(hfPhraseID.Value == "" ? "0" : hfPhraseID.Value));
                        sqlCmd.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                        sqlCmd.Parameters.AddWithValue("@Phrase", ListBoxPhrases.Items[loop].ToString());
                        sqlCmd.Parameters.AddWithValue("@TransLanguage", dr.Field<string>("TranslationLanguage"));
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }

        }

        string getProjetFileType()
        {
            using (SqlConnection sqlConPrjoctId = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                string projectfiletype = "";
                sqlConPrjoctId.Open();
                string queryPrjoctId = "SELECT ProjectFileType FROM tblProjects WHERE ProjectID = @ProjectID";
                SqlCommand sqlCmdPrjoctId = new SqlCommand(queryPrjoctId, sqlConPrjoctId);
                sqlCmdPrjoctId.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                SqlDataReader nwReader = sqlCmdPrjoctId.ExecuteReader();
                while (nwReader.Read())
                {
                    projectfiletype = nwReader["ProjectFileType"].ToString();
                }
                return projectfiletype; 
            }
        }

    }
}