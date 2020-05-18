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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                if (Session["role"] == null)
                    Response.Redirect("Login.aspx");

                lblDevs.Text = "Welcome " + Session["role"] + "!";
                lblTrans.Text = "Welcome " + Session["role"] + "!";

                int notnumber;
                notnumber = CountNotificationNumberDev();
                LabelNotNumber.Text = notnumber.ToString() + " new notifications";

                FillGridWiew();
            }

        }

        int CountNotificationNumberDev()
        {
            using (SqlConnection sqlConSameProjectName = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlConSameProjectName.Open();
                string querySameProjectName = "SELECT COUNT (*) FROM tblComents WHERE UserID=@UserID AND ComentStatus=@ComentStatus";
                SqlCommand sqlCmdSameProjectName = new SqlCommand(querySameProjectName, sqlConSameProjectName);
                sqlCmdSameProjectName.Parameters.AddWithValue("@UserID", Session["userid"]);
                sqlCmdSameProjectName.Parameters.AddWithValue("@ComentStatus", "UnRead");
                return (int)sqlCmdSameProjectName.ExecuteScalar();

            }

        }

        void FillGridWiew()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT DISTINCT ProjectName, Phrase, TranslationLanguage FROM tblComents WHERE UserID=@UserID AND ComentStatus=@ComentStatus";
            sqlCon.Open(); 
             SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"]);
            sqlCmd.Parameters.AddWithValue("@ComentStatus", "UnRead");
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
                string phrase = row.Cells[1].Text;
                string language = row.Cells[2].Text;
                Session["notprojdev"] = projectName;
                Session["notphrasedev"] = phrase;
                Session["notlangdev"] = language;
                Response.Redirect("DevComents.aspx");
            }
        }

        protected void PopupClose_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
    }
}