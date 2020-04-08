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
            string projectID1;
            if (!this.IsPostBack)
            {
                projectID1 = getId();
                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT Phrase FROM tblPhrase WHERE ProjectID = @ProjectID";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID1);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DropDownList1.DataSource = dataTable;
                DropDownList1.DataValueField = "Phrase";
                DropDownList1.DataTextField = "Phrase";
                DropDownList1.DataBind();

                int temp = countEveryWord(projectID1);
                int temp2 = countEveryTransWord(projectID1);

                lblEveryPhraseNumber.Text = temp.ToString();
                lblTransNumber.Text = temp2.ToString();

                sqlCon1.Close();
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

        protected void btnSelectPhrase_Click(object sender, EventArgs e)
        {
            string projectID3;
            projectID3 = getId();

            lblErrorMessage.Visible = false;
            TextareaPhrase.InnerHtml = DropDownList1.SelectedValue;

            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID3);
            sqlCmd.Parameters.AddWithValue("@Phrase", TextareaPhrase.InnerHtml);
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
                string query1 = "UPDATE tblPhrase SET TranslatedPhrase = @TranslatedPhrase WHERE ProjectID = @ProjectID AND Phrase = @Phrase";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@TranslatedPhrase", TextareaTranslate.InnerHtml);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID2);
                sqlCmd1.Parameters.AddWithValue("@Phrase", TextareaPhrase.InnerHtml);
                sqlCmd1.ExecuteNonQuery();

                lblErrorMessage.Visible = false;
                TextareaPhrase.InnerHtml = "";
                TextareaTranslate.InnerHtml = "";

                int temp2 = countEveryTransWord(projectID2);
                lblTransNumber.Text = temp2.ToString();

                sqlCon1.Close();
            }
        }

        protected void btnFinishTranslation_Click(object sender, EventArgs e)
        {
            if(lblTransNumber.Text == lblEveryPhraseNumber.Text)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Translation done";
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please translate every pharese before finalization";
            }
        }
    }
}