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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "Developer")
            {
                getDataDevs();
            }
            else
            {
                getDataTrans();
            }

        }

        private void getDataDevs()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT Username, Role, ProfilePicPath FROM tblUser WHERE UserID = @UserID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                textBoxUserName.Text = nwReader["Username"].ToString();
                textBoxRole.Text = nwReader["Role"].ToString();
                Image1.ImageUrl = nwReader["ProfilePicPath"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
        }

        private void getDataTrans()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT Username, Role, ProfilePicPath FROM tblUser WHERE UserID = @UserID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                textBox1.Text = nwReader["Username"].ToString();
                textBox2.Text = nwReader["Role"].ToString();
                Image2.ImageUrl = nwReader["ProfilePicPath"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
        }

    }
}