using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            if (!Page.IsPostBack)
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
                textBoxRole.Attributes.Add("readonly", "readonly");
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
                textBox2.Attributes.Add("readonly", "readonly");
            }
            nwReader.Close();
            sqlCon.Close();
        }

        protected void ButtonDevs_Click(object sender, EventArgs e)
        {

            int temp = CheckSameUserName(textBoxUserName.Text);
            if(temp == 0)
            {
                if (textBoxUserName.Text == "")
                {
                    lblErrorMessage.Text = "Please write choose a UserName before update";
                }
                else
                {
                    string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                    SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                    string query1 = "UPDATE tblUser SET Username = @Username WHERE UserID = @UserID";
                    sqlCon1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                    sqlCmd1.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    sqlCmd1.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon1.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            else
            {
                lblErrorMessage.Text = "This UserName aleready exists please choose something else";
            }
        }

        protected void ButtonTrans_Click(object sender, EventArgs e)
        {
            int temp = CheckSameUserName(textBoxUserName.Text);
            if (temp == 0)
            {
                if (textBox1.Text == "")
                {
                    lblErrorMessageTrans.Text = "Please write choose a UserName before update";
                }
                else
                {
                    string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                    SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                    string query1 = "UPDATE tblUser SET Username = @Username WHERE UserID = @UserID";
                    sqlCon1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                    sqlCmd1.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    sqlCmd1.Parameters.AddWithValue("@Username", textBox1.Text);
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon1.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            else
            {
                lblErrorMessageTrans.Text = "This UserName aleready exists please choose something else";
            }
        }


        int CheckSameUserName(string username)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT COUNT (*) FROM tblUser WHERE Username = @Username";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@Username", username);
                return (int)sqlCmd2.ExecuteScalar();

            }
        }

        string getPassword()
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlCon.Open();
                string query2 = "SELECT Password FROM tblUser WHERE UserID = @UserID";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                return sqlCmd2.ExecuteScalar().ToString();

            }
        }

        protected void ChangePasswordDevs_Click(object sender, EventArgs e)
        {
            string temp = getPassword();
            if(temp == textBoxOldPasswordDevs.Text)
            {
                if(textBoxNewPasswordDevs.Text == textBoxConfirmNewPasswordDevs.Text)
                {
                    string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                    SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                    string query1 = "UPDATE tblUser SET Password = @Password WHERE UserID = @UserID";
                    sqlCon1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                    sqlCmd1.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    sqlCmd1.Parameters.AddWithValue("@Password", textBoxNewPasswordDevs.Text);
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon1.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    lblErrorMessagePassDev.Text = "The new password doesnt match";
                }
            }
            else
            {
                lblErrorMessagePassDev.Text = "Old password is incorect";
            }
        }

        protected void ChangePasswordTrans_Click(object sender, EventArgs e)
        {
            string temp = getPassword();
            if (temp == textBoxOldPasswordTrans.Text)
            {
                if (textBoxNewPasswordTrans.Text == textBoxConfirmNewPasswordTrans.Text)
                {
                    string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                    SqlConnection sqlCon1 = new SqlConnection(connectionString1);
                    string query1 = "UPDATE tblUser SET Password = @Password WHERE UserID = @UserID";
                    sqlCon1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
                    sqlCmd1.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
                    sqlCmd1.Parameters.AddWithValue("@Password", textBoxNewPasswordTrans.Text);
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon1.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    lblErrorMessageTransPass.Text = "The new password doesnt match";
                }
            }
            else
            {
                lblErrorMessageTransPass.Text = "Old password is incorect";
            }
        }
    }
}