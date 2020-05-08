using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transitor
{
    public partial class Checking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string projectID1;
                projectID1 = getId();

                string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon2 = new SqlConnection(connectionString2);
                string query2 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(sqlCmd2);
                DataTable dataTable2 = new DataTable();
                dataAdapter2.Fill(dataTable2);
                ddlLanguage.DataSource = dataTable2;
                ddlLanguage.DataValueField = "TranslationLanguage";
                ddlLanguage.DataTextField = "TranslationLanguage";
                ddlLanguage.DataBind();
            }
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

        protected void btnSelectLanguage_Click(object sender, EventArgs e)
        {
            string projectID2;
            projectID2 = getId();


            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT Phrase, TransLanguage, TranslatedPhrase FROM tblPhrase WHERE TransLanguage = @TransLanguage AND ProjectID = @ProjectID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@TransLanguage", ddlLanguage.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID2);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            sqlCon.Close();

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "SELECT Phrase FROM tblPhrase WHERE ProjectID = @ProjectID AND TransLanguage = @TransLanguage";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
            sqlCmd1.Parameters.AddWithValue("@TransLanguage", ddlLanguage.SelectedValue);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlCmd1);
            DataTable dataTable1 = new DataTable();
            dataAdapter1.Fill(dataTable1);
            ddlPhrases.DataSource = dataTable1;
            ddlPhrases.DataValueField = "Phrase";
            ddlPhrases.DataTextField = "Phrase";
            ddlPhrases.DataBind();

            Label2.Visible = true;
            ddlPhrases.Visible = true;
            btnSelectPhrase.Visible = true;
            TextAreaTranslatedPhrase.Visible = true;
            btnFinishTrans.Visible = true;
            Label3.Visible = true;
            btnCorrect.Visible = true;
        }

        protected void btnSelectPhrase_Click(object sender, EventArgs e)
        {
            string projectID3;
            projectID3 = getId();


            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase AND TransLanguage = @TransLanguage";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID3);
            sqlCmd.Parameters.AddWithValue("@Phrase", ddlPhrases.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@TransLanguage", ddlLanguage.SelectedValue);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                string temp = nwReader["TranslatedPhrase"].ToString();
                if (temp != null)
                {
                    TextAreaTranslatedPhrase.InnerHtml = temp;
                }
            }
            nwReader.Close();
            sqlCon.Close();
        }

        protected void btnCorrect_Click(object sender, EventArgs e)
        {
            string projectID4;
            projectID4 = getId();

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "UPDATE tblPhrase SET TranslatedPhrase = @TranslatedPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase AND TransLanguage = @TransLanguage";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@TranslatedPhrase", TextAreaTranslatedPhrase.InnerHtml);
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID4);
            sqlCmd1.Parameters.AddWithValue("@Phrase", ddlPhrases.SelectedValue);
            sqlCmd1.Parameters.AddWithValue("@TransLanguage", ddlLanguage.SelectedValue);
            sqlCmd1.ExecuteNonQuery();

            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT Phrase, TransLanguage, TranslatedPhrase FROM tblPhrase WHERE TransLanguage = @TransLanguage AND ProjectID = @ProjectID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@TransLanguage", ddlLanguage.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID4);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            sqlCon.Close();
        }

        protected void btnFinishTrans_Click(object sender, EventArgs e)
        {
            string projectID5;
            projectID5 = getId();

            string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon2 = new SqlConnection(connectionString2);
            string query2 = "UPDATE tblProjects SET IsItReady = @IsItReady WHERE ProjectID = @ProjectID";
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
            sqlCmd2.Parameters.AddWithValue("@IsItReady", "Yes");
            sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID5);
            sqlCmd2.ExecuteNonQuery();

            Response.Write("<script language='javascript'>window.alert('Project is finished sucessfuly!');window.location='Home.aspx';</script>");
        }
    }
}