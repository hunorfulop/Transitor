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
    public partial class ProjectsDev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.getListView();
            }
        }

        private void getListView()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT  ProjectName, ProjectFileType, ProjectOriginalLanguage, ProjectTranslationLanguage, IsSomeoneWorkingOnIt, IsItReady FROM tblProjects WHERE UserOwnerID = @UserOwnerID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserOwnerID", Session["userid"].ToString());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            ListViewProjectsDev.DataSource = dataTable;
            ListViewProjectsDev.DataBind();
            sqlCon.Close();

        }
    }
}