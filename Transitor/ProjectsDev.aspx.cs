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
using System.IO;

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
            CheckProjectsWithNoPhrases();

            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT  ProjectName, ProjectFileType, ProjectOriginalLanguage, IsSomeoneWorkingOnIt, IsItReady FROM tblProjects WHERE UserID = @UserID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
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
                LabelEmptyMessage.Visible = true;
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
                Response.Redirect("TransProgresDevs.aspx?test=" + projectName);
            }
            else
            {
                if(e.CommandName == "Delete")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[rowIndex];
                    string projectName = row.Cells[0].Text;
                    DeleteProject(projectName);
                    Response.Redirect(Request.Url.AbsoluteUri);

                }
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

        string getId(string name)
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", name);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectID"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getFileName(string name)
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectFileName FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", name);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectFileName"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        void DeleteProject(string name)
        {
            string id;
            id = getId(name);

            string filename;
            filename = getFileName(name);

            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "DELETE FROM tblComents WHERE ProjectID = @ProjectID;";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectID", id);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon2 = new SqlConnection(connectionString2);
            string query2 = "DELETE FROM tblPhrase WHERE ProjectID = @ProjectID;";
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
            sqlCmd2.Parameters.AddWithValue("@ProjectID", id);
            sqlCmd2.ExecuteNonQuery();
            sqlCon2.Close();

            string connectionString3 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon3 = new SqlConnection(connectionString3);
            string query3 = "DELETE FROM tblProjects WHERE ProjectID = @ProjectID;";
            sqlCon3.Open();
            SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon3);
            sqlCmd3.Parameters.AddWithValue("@ProjectID", id);
            sqlCmd3.ExecuteNonQuery();
            sqlCon3.Close();

            string connectionString4 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon4 = new SqlConnection(connectionString4);
            string query4 = "DELETE FROM tblTranslationLanguages WHERE ProjectID = @ProjectID;";
            sqlCon4.Open();
            SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon4);
            sqlCmd4.Parameters.AddWithValue("@ProjectID", id);
            sqlCmd4.ExecuteNonQuery();
            sqlCon4.Close();

            string Directory = Server.MapPath("~/Uploads/");
            string fileName = filename;
            string path = Directory + fileName;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }


    }
}