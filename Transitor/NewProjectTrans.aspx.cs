using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace Transitor
{
    public partial class NewProjectTrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }

        }

        protected void btnSelectProjectType_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            CheckProjectsWithNoPhrases();

            if (ddlProjectType.SelectedValue == "New Project")
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string query = "SELECT ProjectID, ProjectName, ProjectOriginalLanguage, UploadDate FROM tblProjects WHERE TraslatorWorkingID IS NULL";
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                sqlCon.Close();

                if (dataTable != null && dataTable.Rows.Count >0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Now select a project from the list:";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is no project which needs translation. Please return later.";
                }
            }
            else
            {
                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT ProjectID, ProjectName, ProjectOriginalLanguage, UploadDate FROM tblProjects WHERE SubmitedForChecking = @SubmitedForChecking AND TraslatorWorkingID != @TraslatorWorkingID AND TraslatorChekingID IS NULL";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@SubmitedForChecking", "Yes");
                sqlCmd1.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable1 = new DataTable();
                dataAdapter1.Fill(dataTable1);
                GridView1.DataSource = dataTable1;
                GridView1.DataBind();
                sqlCon1.Close();

                if (dataTable1 != null && dataTable1.Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Now select a project from the list:";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is no project which needs cheking. Please return later.";
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];

                //Fetch value of Name.
                string projectName = row.Cells[0].Text;
                Session["projectname"] = projectName;
                Response.Redirect("StartProject.aspx");
            }
        }

        void CheckProjectsWithNoPhrases()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectID FROM tblProjects WHERE ProjectID NOT IN (SELECT ProjectID FROM tblPhrase)";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            using (SqlConnection sqlCon1 = new SqlConnection(connectionString))
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    string query1 = "DELETE FROM tblProjects WHERE ProjectID = @ProjectID";
                    sqlCon1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                    sqlCmd1.Parameters.AddWithValue("@ProjectID", dr.Field<int>("ProjectID"));
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon1.Close();
                }

            }
        }

    }
}