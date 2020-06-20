using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
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
                                AddFileName(FileUpload1.FileName);
                            }
                            else
                            {
                                if (temp == ".resx")
                                {
                                    ShowInListBoxResx(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                                    AddFileName(FileUpload1.FileName);
                                }
                                else
                                {
                                    if (temp == ".csv")
                                    {
                                        ShowInListBoxCsv(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                                        AddFileName(FileUpload1.FileName);
                                    }
                                    else
                                    {
                                        if(temp == ".json")
                                        {
                                            ShowInListBoxJson(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                                            AddFileName(FileUpload1.FileName);
                                        }
                                    }
                                }
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
                    if (temp == ".resx")
                    {
                        ReadAndParceResX();
                        Session["projectid"] = "expired";
                        Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                    }
                    else
                    {
                        if (temp == ".csv")
                        {
                            ReadAndParceCsv();
                            Session["projectid"] = "expired";
                            Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                        }
                        else
                        {
                            if (temp == ".json")
                            {
                                ReadAndParceJson();
                                Session["projectid"] = "expired";
                                Response.Write("<script language='javascript'>window.alert('Upload Sucessful!');window.location='Home.aspx';</script>");
                            }
                        }
                    }
                }
            }
        }

        private void ShowInListBoxXml(string path)
        {
            try
            {
                LabelMsg1.Visible = true;
                LabelMsg2.Visible = true;
                ListBoxPhrases.Visible = true;
                btn_Confirm.Visible = true;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNodeList nodes = xmlDoc.SelectNodes("/resources/string");

                if (nodes.Count == 0)
                {
                    lblMessage.Text = "Could not read from the uploaded file! Please check if you'r file matches our template";
                    LabelMsg1.Visible = false;
                    LabelMsg2.Visible = false;
                    ListBoxPhrases.Visible = false;
                    btn_Confirm.Visible = false;
                }
                else
                {
                    foreach (XmlNode item in nodes)
                    {
                        ListBoxPhrases.Items.Add(item.InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Something is wrong with the uploaded the file";
                LabelMsg1.Visible = false;
                LabelMsg2.Visible = false;
                ListBoxPhrases.Visible = false;
                btn_Confirm.Visible = false;
            }

        }

        private void ShowInListBoxResx(string path)
        {
            try
            {
                LabelMsg1.Visible = true;
                LabelMsg2.Visible = true;
                ListBoxPhrases.Visible = true;
                btn_Confirm.Visible = true;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNodeList nodes = xmlDoc.SelectNodes("/root/data/value");

                if (nodes.Count == 0)
                {
                    lblMessage.Text = "Could not read from the uploaded file! Please check if you'r file matches our template";
                    LabelMsg1.Visible = false;
                    LabelMsg2.Visible = false;
                    ListBoxPhrases.Visible = false;
                    btn_Confirm.Visible = false;
                }
                else
                {
                    foreach (XmlNode item in nodes)
                    {
                        ListBoxPhrases.Items.Add(item.InnerText);
                    }
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Something is wrong with the uploaded the file";
                LabelMsg1.Visible = false;
                LabelMsg2.Visible = false;
                ListBoxPhrases.Visible = false;
                btn_Confirm.Visible = false;
            }
        }

        private void ShowInListBoxCsv(string path)
        {

            try
            {
                LabelMsg1.Visible = true;
                LabelMsg2.Visible = true;
                ListBoxPhrases.Visible = true;
                btn_Confirm.Visible = true;

                var csvRows = System.IO.File.ReadAllLines(path, Encoding.Default).ToList();

                if (csvRows.Count == 0)
                {

                    lblMessage.Text = "Could not read from the uploaded file! Please check if you'r file matches our template";
                    LabelMsg1.Visible = false;
                    LabelMsg2.Visible = false;
                    ListBoxPhrases.Visible = false;
                    btn_Confirm.Visible = false;
                }
                else
                {
                    foreach (var row in csvRows)
                    {
                        var columns = row.Split(',');
                        ListBoxPhrases.Items.Add(columns[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Something is wrong with the uploaded the file";
                LabelMsg1.Visible = false;
                LabelMsg2.Visible = false;
                ListBoxPhrases.Visible = false;
                btn_Confirm.Visible = false;
            }
        }

        private void ShowInListBoxJson(string path)
        {
            try
            {
                LabelMsg1.Visible = true;
                LabelMsg2.Visible = true;
                ListBoxPhrases.Visible = true;
                btn_Confirm.Visible = true;

                JObject jObject = ReadJSONData(path);
                if (jObject == null)
                {
                    lblMessage.Text = "Could not read from the uploaded file! Please check if you'r file matches our template";
                    LabelMsg1.Visible = false;
                    LabelMsg2.Visible = false;
                    ListBoxPhrases.Visible = false;
                    btn_Confirm.Visible = false;
                }
                else
                {
                    foreach (var item in jObject["phrases"])
                    {
                        ListBoxPhrases.Items.Add(item["string"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Something is wrong with the uploaded the file";
                LabelMsg1.Visible = false;
                LabelMsg2.Visible = false;
                ListBoxPhrases.Visible = false;
                btn_Confirm.Visible = false;
            }

        }

        public JObject ReadJSONData(string jsonFilename)
        {
            try
            {
                JObject jObject;
                using (StreamReader file = System.IO.File.OpenText(jsonFilename))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    jObject = (JObject)JToken.ReadFrom(reader);
                }
                return jObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred : " + ex.Message);
                return null;
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

        private void ReadAndParceCsv()
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

        private void ReadAndParceJson()
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

        void AddFileName(string name)
        {
            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "UPDATE tblProjects SET ProjectFileName = @ProjectFileName WHERE ProjectID = @ProjectID";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectFileName", name);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
            sqlCmd1.ExecuteNonQuery();
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