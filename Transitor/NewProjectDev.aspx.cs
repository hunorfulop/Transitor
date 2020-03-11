using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.IO;

namespace Transitor
{
    public partial class NewProjectDev : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                //Second Commit
                //*******
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text == "")
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
            else
            {
                int temp = CheckSameProjectName(txtProjectName.Text.Trim());
                if (temp == 0)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ProjectAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ProjectID", Convert.ToInt32(hfProjectID.Value == "" ? "0" : hfProjectID.Value));
                        sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                        sqlCmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@ProjectFileType", ddlUploadedFileType.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@ProjectOriginalLanguage", ddlOriginalLanguage.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@ProjectTranslationLanguage", ddlTranslationLanguage.SelectedValue);
                        sqlCmd.ExecuteNonQuery();
                    }
                    GoToUpload(txtProjectName.Text.Trim());
                }
                else
                {
                    lblErrorMessage.Text = "Please select another project name";
                }
            }
        }

        int CheckSameProjectName(String projectname)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblProjects WHERE ProjectName = @ProjectName";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectName", projectname);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        private void GoToUpload (string projectname)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT  ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@ProjectName", projectname);
                SqlDataReader nwReader = sqlCmd2.ExecuteReader();
                while (nwReader.Read())
                {
                    string ProjectID = nwReader["ProjectID"].ToString();
                    Session["projectid"] = ProjectID;
                }
                nwReader.Close();
            }
            Response.Redirect("FileReadAndUpload.aspx");
        }

        void Clear()
        {
            txtProjectName.Text = "";
            hfProjectID.Value = "";
            lblSuccesMessage.Text = lblErrorMessage.Text = "";
        }
    }
}