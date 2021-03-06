﻿using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
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
                

                if(Session["role"].ToString() == "Developer")
                {
                    lblDevs.Text = "Welcome " + Session["role"] + "!";

                    int notnumberdev;
                    notnumberdev = CountNotificationNumberDev();
                    LabelNotNumber.Text = notnumberdev.ToString() + " new comments";

                    FillGridWiew1();
                    FillGridWiew2();

                    ResXResourceSet resxSet = new ResXResourceSet(Server.MapPath("~/StringResources/Resource.resx"));
                    ResLabel1.Text = resxSet.GetString("String1");
                    ResLabel2.Text = resxSet.GetString("String2");
                    ResLabel3.Text = resxSet.GetString("String3");
                    ResLabel4.Text = resxSet.GetString("String4");
                    ResLabel5.Text = resxSet.GetString("String5");
                    ResLabel6.Text = resxSet.GetString("String6");
                    ResLabel7.Text = resxSet.GetString("String7");
                    ResLabel8.Text = resxSet.GetString("String6");
                    ResLabel9.Text = resxSet.GetString("String11");
                    ResLabel10.Text = resxSet.GetString("String6");
                    ResLabel11.Text = resxSet.GetString("String12");
                    ResLabel12.Text = resxSet.GetString("String6");

                    if (GridView1.Rows.Count == 0)
                    {
                        Labelhiden1.Visible = true;
                    }

                    if (GridView2.Rows.Count == 0)
                    {
                        Labelhiden2.Visible = true;
                    }


                }
                else
                {
                    lblTrans.Text = "Welcome " + Session["role"] + "!";

                    int notnumbertran;
                    notnumbertran = CountNotificationNumberTrans();
                    LabeNotNumberTrans.Text = notnumbertran.ToString() + " new comments";

                    FillGridWiew3();
                    FillGridWiew4();

                    ResXResourceSet resxSet = new ResXResourceSet(Server.MapPath("~/StringResources/Resource.resx"));
                    ResLabelTrans1.Text = resxSet.GetString("String8");
                    ResLabelTrans2.Text = resxSet.GetString("String9");
                    ResLabelTrans3.Text = resxSet.GetString("String10");


                    if (GridView3.Rows.Count == 0)
                    {
                        Labelhiden3.Visible = true;
                    }

                    if (GridView4.Rows.Count == 0)
                    {
                        Labelhiden4.Visible = true;
                    }
                }
            }
        }

        int CountNotificationNumberDev()
        {
            using (SqlConnection sqlConSameProjectName = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlConSameProjectName.Open();
                string querySameProjectName = "SELECT COUNT (*) FROM tblComents WHERE UserID=@UserID AND ComentStatus=@ComentStatus AND MsgForDev = @MsgForDev";
                SqlCommand sqlCmdSameProjectName = new SqlCommand(querySameProjectName, sqlConSameProjectName);
                sqlCmdSameProjectName.Parameters.AddWithValue("@UserID", Session["userid"]);
                sqlCmdSameProjectName.Parameters.AddWithValue("@ComentStatus", "UnRead");
                sqlCmdSameProjectName.Parameters.AddWithValue("@MsgForDev", "New Comment");
                return (int)sqlCmdSameProjectName.ExecuteScalar();

            }

        }

        int CountNotificationNumberTrans()
        {
            using (SqlConnection sqlConSameProjectName = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {
                sqlConSameProjectName.Open();
                string querySameProjectName = "SELECT COUNT (*) FROM tblComents WHERE MsgForTrans = @MsgForTrans AND ComentStatus=@ComentStatus AND ProjectName IN (SELECT ProjectName FROM tblProjects WHERE TraslatorWorkingID = @TraslatorWorkingID AND SubmitedForChecking = @SubmitedForChecking)";
                SqlCommand sqlCmdSameProjectName = new SqlCommand(querySameProjectName, sqlConSameProjectName);
                sqlCmdSameProjectName.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
                sqlCmdSameProjectName.Parameters.AddWithValue("@ComentStatus", "UnRead");
                sqlCmdSameProjectName.Parameters.AddWithValue("@MsgForTrans", "New Coment");
                sqlCmdSameProjectName.Parameters.AddWithValue("@SubmitedForChecking", "No");
                return (int)sqlCmdSameProjectName.ExecuteScalar();

            }

        }

        void FillGridWiew1()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT DISTINCT ProjectName, Phrase, TranslationLanguage FROM tblComents WHERE UserID=@UserID AND ComentStatus=@ComentStatus AND MsgForDev=@MsgForDev";
            sqlCon.Open(); 
             SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"]);
            sqlCmd.Parameters.AddWithValue("@ComentStatus", "UnRead");
            sqlCmd.Parameters.AddWithValue("@MsgForDev", "New Comment");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            sqlCon.Close();
        }

        void FillGridWiew2()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT DISTINCT ProjectName, Phrase, TranslationLanguage FROM tblComents WHERE UserID=@UserID AND MsgForDev=@MsgForDev";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"]);
            sqlCmd.Parameters.AddWithValue("@ComentStatus", "UnRead");
            sqlCmd.Parameters.AddWithValue("@MsgForDev", "");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView2.DataSource = dataTable;
            GridView2.DataBind();
            sqlCon.Close();
        }

        void FillGridWiew3()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT DISTINCT ProjectName, Phrase, TranslationLanguage FROM tblComents WHERE MsgForTrans = @MsgForTrans AND ComentStatus=@ComentStatus AND ProjectName IN (SELECT ProjectName FROM tblProjects WHERE TraslatorWorkingID = @TraslatorWorkingID AND SubmitedForChecking = @SubmitedForChecking)";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ComentStatus", "UnRead");
            sqlCmd.Parameters.AddWithValue("@MsgForTrans", "New Coment");
            sqlCmd.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
            sqlCmd.Parameters.AddWithValue("@SubmitedForChecking", "No");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView3.DataSource = dataTable;
            GridView3.DataBind();
            sqlCon.Close();
        }

        void FillGridWiew4()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT DISTINCT ProjectName, Phrase, TranslationLanguage FROM tblComents WHERE MsgForTrans = @MsgForTrans AND ProjectName IN (SELECT ProjectName FROM tblProjects WHERE TraslatorWorkingID = @TraslatorWorkingID AND SubmitedForChecking = @SubmitedForChecking)";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@TraslatorWorkingID", Session["userid"].ToString());
            sqlCmd.Parameters.AddWithValue("@MsgForTrans", "");
            sqlCmd.Parameters.AddWithValue("@SubmitedForChecking", "No");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            GridView4.DataSource = dataTable;
            GridView4.DataBind();
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView2.Rows[rowIndex];

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


        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView3.Rows[rowIndex];

                //Fetch value of Name.
                string projectName = row.Cells[0].Text;
                string phrase = row.Cells[1].Text;
                string language = row.Cells[2].Text;
                Session["dir"] = "com";
                Session["notprojdev"] = projectName;
                Session["notphrasedev"] = phrase;
                Session["notlangdev"] = language;
                Response.Redirect("Translation.aspx");
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView4.Rows[rowIndex];

                //Fetch value of Name.
                string projectName = row.Cells[0].Text;
                string phrase = row.Cells[1].Text;
                string language = row.Cells[2].Text;
                Session["dir"] = "com";
                Session["notprojdev"] = projectName;
                Session["notphrasedev"] = phrase;
                Session["notlangdev"] = language;
                Response.Redirect("Translation.aspx");
            }
        }

        protected void PopupClose_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            Labelhiden1.Visible = false;
            Labelhiden2.Visible = false;

        }

        protected void PopupClose2_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();
            Labelhiden3.Visible = false;
            Labelhiden4.Visible = false;
        }
    }
}