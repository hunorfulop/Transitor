using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Windows.Forms;
using System.IO;

namespace Transitor
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
            else
            {
                int temp = CheckSameUserName(txtUserName.Text.Trim());
                if (temp == 0)
                {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                            sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);
                            sqlCmd.Parameters.AddWithValue("@ProfilePicPath", Hidden1.Value);
                            sqlCmd.ExecuteNonQuery();
                            lblSuccesMessage.Text = "Register Succesfull";
                            Response.Redirect("Login.aspx");
                        }
                }
                else
                {
                    lblErrorMessage.Text = "Username aleaready exists";
                }
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

        void Clear()
        {
            txtUserName.Text = txtPassword.Text = "";
            hfUserID.Value = "";
            lblSuccesMessage.Text = lblErrorMessage.Text = "";
        }

        protected void btnBrowsePicture_Click(object sender, EventArgs e)
        {
            
            if (FileUpload1.HasFile)
            {
                if (File.Exists(Server.MapPath("~/ProfilePics/" + FileUpload1.FileName)))
                {
                    lblErrorMessage.Text = "Please rename your file and try agin";
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/ProfilePics/" + FileUpload1.FileName));
                    Hidden1.Value = "~/ProfilePics/" + FileUpload1.FileName;
                    Image1.ImageUrl = Hidden1.Value;
                }
            }

        }

    }
}