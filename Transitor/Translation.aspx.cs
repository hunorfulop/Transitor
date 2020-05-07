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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectID1, transLang;
            if (!this.IsPostBack)
            {
                projectID1 = getId();
                transLang = getTransLang();

                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT Phrase FROM tblPhrase WHERE ProjectID = @ProjectID AND TransLanguage = @TransLanguage";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID1);
                sqlCmd1.Parameters.AddWithValue("@TransLanguage", transLang);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DropDownListPhrases.DataSource = dataTable;
                DropDownListPhrases.DataValueField = "Phrase";
                DropDownListPhrases.DataTextField = "Phrase";
                DropDownListPhrases.DataBind();

                string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon2 = new SqlConnection(connectionString2);
                string query2 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(sqlCmd2);
                DataTable dataTable2 = new DataTable();
                dataAdapter2.Fill(dataTable2);
                DropDownListTransLanguages.DataSource = dataTable2;
                DropDownListTransLanguages.DataValueField = "TranslationLanguage";
                DropDownListTransLanguages.DataTextField = "TranslationLanguage";
                DropDownListTransLanguages.DataBind();

                int tempEveryWord = countEveryWord(projectID1);
                lblEveryPhraseNumber.Text = tempEveryWord.ToString();

                int tempTransWord = countEveryTransWord(projectID1);
                lblEveryTransNumber.Text = tempTransWord.ToString();
                sqlCon1.Close();
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
                sqlCmd2.Parameters.AddWithValue("@TransLanguage", LabelTransLang.Text);
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
                sqlCmd2.Parameters.AddWithValue("@TransLanguage", DropDownListTransLanguages.SelectedValue);
                return (int)sqlCmd2.ExecuteScalar();

            }
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

        string getTransLang()
        {
            string projectID2;
            projectID2 = getId();
            string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon2 = new SqlConnection(connectionString2);
            string query2 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
            sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID2);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd2);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable.Rows[0][0].ToString();
        }

        protected void btnSelectPhrase_Click(object sender, EventArgs e)
        {
            string projectID3;
            projectID3 = getId();

            lblErrorMessage.Visible = false;
            TextareaPhrase.InnerHtml = DropDownListPhrases.SelectedValue;
            LabelTransLang.Text = DropDownListTransLanguages.SelectedValue;

            int temp3 = countEveryWordSelectedLang(projectID3);
            int temp2 = countEveryTransWordSelectedLang(projectID3);

            lblSelectedLangPhraseNumber.Text = temp3.ToString();
            lblSelectedLangTransNumber.Text = temp2.ToString();

            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase AND TransLanguage = @TransLanguage";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID3);
            sqlCmd.Parameters.AddWithValue("@Phrase", TextareaPhrase.InnerHtml);
            sqlCmd.Parameters.AddWithValue("@TransLanguage", LabelTransLang.Text);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
               string temp = nwReader["TranslatedPhrase"].ToString();
               if(temp != null)
                {
                    TextareaTranslate.InnerHtml = temp;
                }
            }
            nwReader.Close();
            sqlCon.Close();
        }

        protected void btnTranlate_Click(object sender, EventArgs e)
        {
            if(TextareaPhrase.InnerHtml == "")
            {
                lblErrorMessage.Text = "Please select a phrase which you want to translate";
                lblErrorMessage.Visible = true;
            }
            else if (TextareaTranslate.InnerHtml == "")
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please translate the phrase!";
            }
            else
            {
                string projectID2;
                projectID2 = getId();

                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "UPDATE tblPhrase SET TranslatedPhrase = @TranslatedPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase AND TransLanguage = @TransLanguage";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@TranslatedPhrase", TextareaTranslate.InnerHtml);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
                sqlCmd1.Parameters.AddWithValue("@Phrase", TextareaPhrase.InnerHtml);
                sqlCmd1.Parameters.AddWithValue("@TransLanguage", LabelTransLang.Text);
                sqlCmd1.ExecuteNonQuery();

                lblErrorMessage.Visible = false;
                TextareaPhrase.InnerHtml = "";
                TextareaTranslate.InnerHtml = "";
                LabelTransLang.Text = "";

                int tempTransWord = countEveryTransWord(projectID2);
                lblEveryTransNumber.Text = tempTransWord.ToString();

                int tempSelectedTransWord = countEveryTransWordSelectedLang(projectID2);
                lblSelectedLangTransNumber.Text = tempSelectedTransWord.ToString();

                sqlCon1.Close();
            }
        }

        protected void btnFinishTranslation_Click(object sender, EventArgs e)
        {
            if(lblEveryTransNumber.Text == lblEveryPhraseNumber.Text)
            {
                string projectID4;
                projectID4 = getId();

                string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon2 = new SqlConnection(connectionString2);
                string query2 = "UPDATE tblProjects SET SubmitedForChecking = @SubmitedForChecking WHERE ProjectID = @ProjectID";
                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
                sqlCmd2.Parameters.AddWithValue("@SubmitedForChecking", "Yes");
                sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID4);
                sqlCmd2.ExecuteNonQuery();

                Response.Write("<script language='javascript'>window.alert('Project submited for checking sucessfuly!');window.location='Home.aspx';</script>");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please translate every pharese in every language before finalization";
            }
        }
    }
}