using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace Transitor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();


                string query2 = "SELECT ROLE, USERID FROM tblUser WHERE username = @username AND password=@password ";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd2.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                SqlDataReader nwReader = sqlCmd2.ExecuteReader();
                while (nwReader.Read())
                {
                    string Role = nwReader["Role"].ToString();
                    string Userid = nwReader["UserID"].ToString();
                    Session["role"] = Role;
                    Session["userid"] = Userid;
                }
                nwReader.Close();

                string query = "SELECT COUNT(1) FROM tblUser WHERE username = @username AND password=@password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Response.Redirect("Home.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}