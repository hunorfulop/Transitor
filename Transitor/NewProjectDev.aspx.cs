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
using System.Collections;

namespace Transitor
{
    public partial class NewProjectDev : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList myArryList = new ArrayList();
            if (!IsPostBack)
            {
                Clear();
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text == "")
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
            else
            {
                int temp = CheckSameProjectName(txtProjectName.Text.Trim());
                if (temp != 0)
                {
                    lblErrorMessage.Text = "Please select another project name";
                }
                else
                {
                    int temp2 = CheckSelectedLanguage();
                    if(temp2 != 0)
                    {
                        using (SqlConnection sqlConProjects = new SqlConnection(connectionString))
                        {
                            sqlConProjects.Open();
                            SqlCommand sqlCmdProjects = new SqlCommand("ProjectAddOrEdit", sqlConProjects);
                            sqlCmdProjects.CommandType = CommandType.StoredProcedure;
                            sqlCmdProjects.Parameters.AddWithValue("@ProjectID", Convert.ToInt32(hfProjectID.Value == "" ? "0" : hfProjectID.Value));
                            sqlCmdProjects.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                            sqlCmdProjects.Parameters.AddWithValue("@ProjectName", txtProjectName.Text.Trim());
                            sqlCmdProjects.Parameters.AddWithValue("@ProjectFileType", ddlUploadedFileType.SelectedValue);
                            sqlCmdProjects.Parameters.AddWithValue("@ProjectOriginalLanguage", ddlOriginalLanguage.SelectedValue);
                            sqlCmdProjects.Parameters.AddWithValue("UploadDate", DateTime.Now.ToString("yyyy-MM-dd"));
                            sqlCmdProjects.Parameters.AddWithValue("IsSomeoneWorkingOnIt", "No");
                            sqlCmdProjects.Parameters.AddWithValue("SubmitedForChecking", "No");
                            sqlCmdProjects.Parameters.AddWithValue("IsItReady", "No");
                            sqlCmdProjects.ExecuteNonQuery();
                            sqlConProjects.Close();
                        }
                        getProjectID(txtProjectName.Text.Trim());
                        insertTransLang();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Please select at least one translation language";
                    }
                }
            }
        }

        void insertTransLang()
        {
            foreach (ListItem li in CheckBoxLisTransLanguages.Items)
            {
                if (li.Selected)
                {
                    using (SqlConnection sqlConTransLang = new SqlConnection(connectionString))
                    {
                        sqlConTransLang.Open();
                        SqlCommand sqlCmdTransLang = new SqlCommand("TranslationLanguagesAddOrEdit", sqlConTransLang);
                        sqlCmdTransLang.CommandType = CommandType.StoredProcedure;
                        sqlCmdTransLang.Parameters.AddWithValue("@TranslationLanguageID", Convert.ToInt32(hfTranslationLanguageID.Value == "" ? "0" : hfTranslationLanguageID.Value));
                        sqlCmdTransLang.Parameters.AddWithValue("@ProjectID", Session["ProjectID"].ToString());
                        sqlCmdTransLang.Parameters.AddWithValue("@TranslationLanguage", li.Text);
                        sqlCmdTransLang.ExecuteNonQuery();
                        sqlConTransLang.Close();
                    }
                }
            }
            Response.Redirect("FileReadAndUpload.aspx");
        }

        int CheckSameProjectName(String projectname)
        {
            using (SqlConnection sqlConSameProjectName = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlConSameProjectName.Open();
                string querySameProjectName = "SELECT COUNT (*) FROM tblProjects WHERE ProjectName = @ProjectName";
                SqlCommand sqlCmdSameProjectName = new SqlCommand(querySameProjectName, sqlConSameProjectName);
                sqlCmdSameProjectName.Parameters.AddWithValue("@ProjectName", projectname);
                return (int)sqlCmdSameProjectName.ExecuteScalar();

            }
        }

        int CheckSelectedLanguage()
        {
            int temp2 = 0;
            foreach (ListItem li in CheckBoxLisTransLanguages.Items)
            {
                if (li.Selected)
                {
                    temp2 = temp2 + 1;
                }
            }

            return temp2;
        }

   
        void getProjectID (string projectname)
        {
            using (SqlConnection sqlConPrjoctId = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlConPrjoctId.Open();
                string queryPrjoctId = "SELECT  ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
                SqlCommand sqlCmdPrjoctId = new SqlCommand(queryPrjoctId, sqlConPrjoctId);
                sqlCmdPrjoctId.Parameters.AddWithValue("@ProjectName", projectname);
                SqlDataReader nwReader = sqlCmdPrjoctId.ExecuteReader();
                while (nwReader.Read())
                {
                    string ProjectID = nwReader["ProjectID"].ToString();
                    Session["projectid"] = ProjectID;
                }
                nwReader.Close();
            }
        }

        void Clear()
        {
            txtProjectName.Text = "";
            hfProjectID.Value = "";
            lblSuccesMessage.Text = lblErrorMessage.Text = "";
        }

    }
}