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
    public partial class TransProgresDevs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectID1;
            if (!this.IsPostBack)
            {
                projectID1 = getId();
                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "SELECT Phrase, TranslatedPhrase FROM tblPhrase WHERE ProjectID = @ProjectID";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID1);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd1);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ListViewPhrasesDev.DataSource = dataTable;
                ListViewPhrasesDev.DataBind();
                sqlCon1
                    .Close();
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

        }
    }
}