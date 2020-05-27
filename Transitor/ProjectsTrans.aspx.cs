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
    public partial class ProjectsTrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["dir"] = "no";
            }
        }

        protected void btnSelectProjectType_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (ddlProjectType.SelectedValue == "Translation Projects")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;

                string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string query = "SELECT ProjectID, ProjectName, ProjectOriginalLanguage, EstimatedFinishDate FROM tblProjects WHERE TraslatorWorkingID = @TraslatorWorkingID AND SubmitedForChecking = @SubmitedForChecking";
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@SubmitedForChecking", "No");
                sqlCmd.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                sqlCon.Close();

                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "You have no translation projects at the moment. Please start one from the NewProject menu.";
                }
            }
            else
            {
                GridView1.Visible = false;
                GridView2.Visible = true;

                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT ProjectID, ProjectName, ProjectOriginalLanguage, EstimatedFinishDate FROM tblProjects WHERE SubmitedForChecking = @SubmitedForChecking AND TraslatorChekingID = @TraslatorChekingID AND IsItReady = @IsItReady";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@SubmitedForChecking", "Yes");
                sqlCmd1.Parameters.AddWithValue("@IsItReady", "No");
                sqlCmd1.Parameters.AddWithValue("@TraslatorChekingID", Session["userid"].ToString());
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable1 = new DataTable();
                dataAdapter1.Fill(dataTable1);
                GridView2.DataSource = dataTable1;
                GridView2.DataBind();
                sqlCon1.Close();

                if (dataTable1 != null && dataTable1.Rows.Count > 0)
                {

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "You have no checking projects at the moment. Please start one from the NewProject menu.";
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
                Response.Redirect("Translation.aspx");
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView2.Rows[rowIndex];

                //Fetch value of Name.
                string projectName = row.Cells[0].Text;
                Response.Redirect("Checking.aspx?test=" + projectName);
            }
        }

    }
}