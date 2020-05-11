﻿using System;
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
                    string temp = getProjetFileType();
                    if (temp == "Xml")
                    {
                        ReadAndParcelXml(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                    }
                    else
                    {
                        ReadAndParceResX(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please select a file";
            }
        }

        private void ReadAndParcelXml(string path)
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

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.SelectNodes("/resources/string");

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    foreach (XmlNode item in nodes)
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("PhraseAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@PhraseID", Convert.ToInt32(hfPhraseID.Value == "" ? "0" : hfPhraseID.Value));
                        sqlCmd.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                        sqlCmd.Parameters.AddWithValue("@Phrase", item.InnerText);
                        sqlCmd.Parameters.AddWithValue("@TransLanguage", dr.Field<string>("TranslationLanguage"));
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }

        }

        private void ReadAndParceResX(string path)
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

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.SelectNodes("/root/data/value");

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    foreach (XmlNode item in nodes)
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("PhraseAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@PhraseID", Convert.ToInt32(hfPhraseID.Value == "" ? "0" : hfPhraseID.Value));
                        sqlCmd.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                        sqlCmd.Parameters.AddWithValue("@Phrase", item.InnerText);
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