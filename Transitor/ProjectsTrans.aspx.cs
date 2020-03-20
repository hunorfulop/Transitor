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
                string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string query = "SELECT ProjectID, ProjectName, ProjectOriginalLanguage, ProjectTranslationLanguage FROM tblProjects WHERE TraslatorWorkingID = @TraslatorWorkingID";
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                sqlCon.Close();
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
                Response.Redirect("Translation.aspx?test=" + projectName);
            }
        }
    }
}