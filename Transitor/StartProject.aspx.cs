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
            string query = "SELECT ProjectOriginalLanguage, UploadDate FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Session["projectname"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                textBoxProjectName.Text = Session["projectname"].ToString();
                textBoxProjectOriginalLanguage.Text = nwReader["ProjectOriginalLanguage"].ToString();
                textBoxUploadDate.Text = nwReader["UploadDate"].ToString();
                textBoxProjectName.Attributes.Add("readonly", "readonly");
                textBoxProjectOriginalLanguage.Attributes.Add("readonly", "readonly");
                textBoxUploadDate.Attributes.Add("readonly", "readonly");

            }
            nwReader.Close();
            sqlCon.Close();

            string projectID1; 
            projectID1 = getId();
            string connectionString2 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon2 = new SqlConnection(connectionString2);
            string query2 = "SELECT TranslationLanguage FROM tblTranslationLanguages WHERE ProjectID = @ProjectID";
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon2);
            sqlCmd2.Parameters.AddWithValue("@ProjectID", projectID1);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd2);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach(DataRow dr in dataTable.Rows)
            {
                ListBoxTransLanguage.Items.Add(dr["TranslationLanguage"].ToString());
            }

        }

        protected void btnStartProject_Click(object sender, EventArgs e)
        {
            if (Session["projectname"].ToString() == "expired")
            {
                Response.Write("<script language='javascript'>window.alert('This session has expired!');window.location='Home.aspx';</script>");
            }
            else
            {

                string projtype;
                projtype = getProjType();

                if (Calendar1.SelectedDate.ToString() == "1/1/0001 12:00:00 AM")
                {
                    lblErrorMessage.Visible = true;
                }
                else
                {
                    if (projtype == "No")
                    {
                        string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                        SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                        string query1 = "UPDATE tblProjects SET TraslatorWorkingID = @TraslatorWorkingID, EstimatedFinishDate = @EstimatedFinishDate, IsSomeoneWorkingOnIt = @IsSomeoneWorkingOnIt WHERE ProjectName = @ProjectName";
                        sqlCon1.Open();
                        SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                        sqlCmd1.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                        sqlCmd1.Parameters.AddWithValue("@EstimatedFinishDate", Calendar1.SelectedDate.ToString());
                        sqlCmd1.Parameters.AddWithValue("@ProjectName", Session["projectname"].ToString());
                        sqlCmd1.Parameters.AddWithValue("@IsSomeoneWorkingOnIt", "Yes");
                        sqlCmd1.ExecuteNonQuery();
                        sqlCon1.Close();
                        Session["projectname"] = "expired";
                        Response.Write("<script language='javascript'>window.alert('Project started sucessfuly!');window.location='Home.aspx';</script>");
                    }
                    else
                    {
                        string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                        SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                        string query1 = "UPDATE tblProjects SET TraslatorChekingID = @TraslatorChekingID, EstimatedFinishDate = @EstimatedFinishDate, IsSomeoneWorkingOnIt = @IsSomeoneWorkingOnIt WHERE ProjectName = @ProjectName";
                        sqlCon1.Open();
                        SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                        sqlCmd1.Parameters.AddWithValue("@TraslatorChekingID", Session["userid"].ToString());
                        sqlCmd1.Parameters.AddWithValue("@EstimatedFinishDate", Calendar1.SelectedDate.ToString());
                        sqlCmd1.Parameters.AddWithValue("@ProjectName", Session["projectname"].ToString());
                        sqlCmd1.Parameters.AddWithValue("@IsSomeoneWorkingOnIt", "Yes");
                        sqlCmd1.ExecuteNonQuery();
                        sqlCon1.Close();
                        Session["projectname"] = "expired";
                        Response.Write("<script language='javascript'>window.alert('Project started sucessfuly!');window.location='Home.aspx';</script>");
                    }
                }
            }
        }

        string getId()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Session["projectname"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectID"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getProjType()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT SubmitedForChecking FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Session["projectname"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["SubmitedForChecking"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }
    }
}