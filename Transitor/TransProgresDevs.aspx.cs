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
using System.Xml.Linq;

namespace Transitor
{
    public partial class TransProgresDevs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectID1;
            if (!this.IsPostBack)
            {

                projectID1 = getId();
                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID1);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ddlTransLanguage.DataSource = dataTable;
                ddlTransLanguage.DataValueField = "TranslationLanguage";
                ddlTransLanguage.DataTextField = "TranslationLanguage";
                ddlTransLanguage.DataBind();
            }
        }

        protected void btnTransLanguage_Click(object sender, EventArgs e)
        {
            string projectID2, Percentage;
            int AllWord, TransWord;

            projectID2 = getId();
            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT Phrase, TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID AND TransLanguage = @TransLanguage";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
            sqlCmd1.Parameters.AddWithValue("@TransLanguage", ddlTransLanguage.SelectedValue);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            ListViewPhrasesDev.DataSource = dataTable;
            ListViewPhrasesDev.DataBind();
            sqlCon1.Close();

            AllWord = countEveryWordSelectedLang(projectID2);
            TransWord = countEveryTransWordSelectedLang(projectID2);
            Percentage = getPercentage(AllWord, TransWord);

            LabelSelectedLanguagePercentage.Text = "The project is at " + Percentage + "% translated at the selected language";

            AllWord = countEveryWord(projectID2);
            TransWord = countEveryTransWord(projectID2);
            Percentage = getPercentage(AllWord, TransWord);

            LabelPercentage.Text = "The project is at " + Percentage + "% translated in total";

            string isitready;
            isitready = getIsItReady();
            if (isitready == "No")
            {
                LabelIsItChecked.Text = "The project hasn`t been checked by another translator!";
            }
            else
            {
                LabelIsItChecked.Text = "The project is ready to download";
                btnDownload.Visible = true;
            }

        }

        string getPercentage(int allword, int transword)
        {
            int percentage;
            percentage = (transword * 100) / allword;
            return percentage.ToString();
        }

        string getId()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectID"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getFileName()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectFileName FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectFileName"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        int countEveryWord(String projectID1)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblPhrase WHERE ProjectID = @ProjectID";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        int countEveryTransWord(String projectID1)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblPhrase WHERE ProjectID = @ProjectID AND TranslatedPhrase IS NOT NULL";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        int countEveryWordSelectedLang(String projectID1)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblPhrase WHERE ProjectID = @ProjectID AND TransLanguage = @TransLanguage";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                sqlCmd2.Parameters.AddWithValue("@TransLanguage", ddlTransLanguage.SelectedValue);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        int countEveryTransWordSelectedLang(String projectID1)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblPhrase WHERE ProjectID = @ProjectID AND TransLanguage = @TransLanguage AND TranslatedPhrase IS NOT NULL";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                sqlCmd2.Parameters.AddWithValue("@TransLanguage", ddlTransLanguage.SelectedValue);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        string getIsItReady()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT IsItReady FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["IsItReady"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

            string filetype = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectFileType FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                filetype = nwReader["ProjectFileType"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();

            if (filetype == ".xml")
            {
                string filename1 = getFileName();
                CreateDownloadableXml(filename1);
                string Filpath = Server.MapPath("~/Uploads/" + filename1);
                DownLoad(Filpath);

            }
            else
            {
                string filename1 = getFileName();
                CreateDownloadableResx(filename1);
                string Filpath = Server.MapPath("~/Uploads/" + filename1);
                DownLoad(Filpath);
            }

        }

        void CreateDownloadableXml(string filename)
        {
            string projectID2;
            projectID2 = getId();

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            string file = MapPath("~/Uploads/" + filename);
            XDocument doc = XDocument.Load(file);

            foreach (DataRow dr in dataTable.Rows)
            {
                XElement ele = new XElement("TranslatedString", dr.Field<string>("TranslatedPhrase"));
                doc.Root.Add(ele);
                doc.Save(file);
            }
        }

       void CreateDownloadableResx(string filename)
        {
            string projectID2;
            projectID2 = getId();

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            string file = MapPath("~/Uploads/" + filename);
            XDocument doc = XDocument.Load(file);

            foreach (DataRow dr in dataTable.Rows)
            {
                XElement ele = new XElement("data", new XElement("TranslatedValue", dr.Field<string>("TranslatedPhrase")));
                doc.Root.Add(ele);
                doc.Save(file);
            }
        }

        public void DownLoad(string FName)
        {
            string filePath = FName;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }

    }
}
