using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transitor
{
    public partial class StartProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            if (!this.IsPostBack)
            {
                getData();
            }
        }

        private void getData()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectOriginalLanguage, ProjectTranslationLanguage, UploadDate FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                textBoxProjectName.Text = Request.QueryString["test"];
                textBoxProjectOriginalLanguage.Text = nwReader["ProjectOriginalLanguage"].ToString();
                textBoxProjectTranslationLanguage.Text = nwReader["ProjectTranslationLanguage"].ToString();
                textBoxUploadDate.Text = nwReader["UploadDate"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
        }

        protected void btnStartProject_Click(object sender, EventArgs e)
        {
            if(Calendar1.SelectedDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                lblErrorMessage.Visible = true;
            }
            else
            {
                string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                string query1 = "UPDATE tblProjects SET TraslatorWorkingID = @TraslatorWorkingID, EstimatedFinishDate = @EstimatedFinishDate, IsSomeoneWorkingOnIt = @IsSomeoneWorkingOnIt WHERE ProjectName = @ProjectName";
                sqlCon1.Open();
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                sqlCmd1.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                sqlCmd1.Parameters.AddWithValue("@EstimatedFinishDate", Calendar1.SelectedDate.ToString());
                sqlCmd1.Parameters.AddWithValue("@ProjectName", Request.QueryString["test"]);
                sqlCmd1.Parameters.AddWithValue("@IsSomeoneWorkingOnIt", "Yes");
                sqlCmd1.ExecuteNonQuery();
                sqlCon1.Close();

            }
        }
    }
}