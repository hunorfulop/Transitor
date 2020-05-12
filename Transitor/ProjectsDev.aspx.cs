﻿using System;
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