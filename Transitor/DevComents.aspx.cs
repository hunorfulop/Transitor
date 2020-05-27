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
    public partial class DevComents : System.Web.UI.Page
    {

        SqlCommand SqlCommandGL = new SqlCommand();
        SqlConnection SqlConnectionGL = new SqlConnection();
        SqlDataAdapter SqlDataAdapterGL = new SqlDataAdapter();
        DataSet dataSetGL = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                show();
                updatestatus();
            }
        }

        protected void show()
        {
            LabelNoComent.Visible = false;

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection SqlConnectionGL = new SqlConnection(connectionString1);
            SqlConnectionGL.Open();

            string projectID5;
            projectID5 = getId();

            string projectname;
            projectname = getProjectName();

            LabelName.Text = "Comments on the phrase " + Session["notphrasedev"].ToString() + ", in the " + Session["notlangdev"].ToString() + " language, from the " + projectname + " project:";

            SqlCommandGL.CommandText = "SELECT * FROM tblComents WHERE Phrase = @Phrase AND TranslationLanguage = @TranslationLanguage AND ProjectID=@ProjectID ORDER BY ComentDate DESC";
            SqlCommandGL.Parameters.AddWithValue("@Phrase", Session["notphrasedev"].ToString());
            SqlCommandGL.Parameters.AddWithValue("@TranslationLanguage", Session["notlangdev"].ToString());
            SqlCommandGL.Parameters.AddWithValue("@ProjectID", projectID5);
            SqlCommandGL.Connection = SqlConnectionGL;
            SqlDataAdapterGL.SelectCommand = SqlCommandGL;
            SqlDataAdapterGL.Fill(dataSetGL, "Coment");
            RepeaterComents.DataSource = dataSetGL;
            RepeaterComents.DataBind();

            if (dataSetGL.Tables[0].Rows.Count == 0)
            {
                LabelNoComent.Visible = true;
            }
        }

        void updatestatus()
        {
            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            string query1 = "UPDATE tblComents SET ComentStatus = @ComentStatus, MsgForDev = @MsgForDev WHERE MsgForDev = @MsgForDevs AND ProjectName = @ProjectName AND Phrase = @Phrase AND TranslationLanguage = @TranslationLanguage";
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon1);
            sqlCmd1.Parameters.AddWithValue("@ComentStatus", "Read");
            sqlCmd1.Parameters.AddWithValue("@MsgForDevs", "New Comment");
            sqlCmd1.Parameters.AddWithValue("@ProjectName", Session["notprojdev"].ToString());
            sqlCmd1.Parameters.AddWithValue("@Phrase", Session["notphrasedev"].ToString());
            sqlCmd1.Parameters.AddWithValue("@TranslationLanguage", Session["notlangdev"].ToString());
            sqlCmd1.Parameters.AddWithValue("@MsgForDev", "");
            sqlCmd1.ExecuteNonQuery();
            sqlCon1.Close();
        }


        protected void btnSendComent_Click(object sender, EventArgs e)
        {
            string projectID5;
            projectID5 = getId();

            string projectname;
            projectname = getProjectName();

            string userId;
            userId = getUserId();

            string comentowner;
            comentowner = getComentOwner();

            string connectionString1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon1 = new SqlConnection(connectionString1);
            sqlCon1.Open();
            SqlCommand sqlCmd1 = new SqlCommand("CommentAddOrEdit", sqlCon1);
            sqlCmd1.CommandType = CommandType.StoredProcedure;
            sqlCmd1.Parameters.AddWithValue("@ComentID", Convert.ToInt32(hfComentId.Value == "" ? "0" : hfComentId.Value));
            sqlCmd1.Parameters.AddWithValue("@ProjectID", projectID5);
            sqlCmd1.Parameters.AddWithValue("@UserID", userId);
            sqlCmd1.Parameters.AddWithValue("@ComentOwnerID", Session["userid"].ToString());
            sqlCmd1.Parameters.AddWithValue("@ComentOwner", comentowner);
            sqlCmd1.Parameters.AddWithValue("@ProjectName", projectname);
            sqlCmd1.Parameters.AddWithValue("@Phrase", Session["notphrasedev"].ToString());
            sqlCmd1.Parameters.AddWithValue("@TranslationLanguage", Session["notlangdev"].ToString());
            sqlCmd1.Parameters.AddWithValue("@Coment", TextareaComent.InnerHtml);
            sqlCmd1.Parameters.AddWithValue("@ComentStatus", "UnRead");
            sqlCmd1.Parameters.AddWithValue("@ComentDate", DateTime.Now);
            sqlCmd1.Parameters.AddWithValue("@MsgForDev", "");
            sqlCmd1.Parameters.AddWithValue("@MsgForTrans", "New Coment");
            sqlCmd1.ExecuteNonQuery();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        string getId()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectID FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Session["notprojdev"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectID"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getProjectName()
        {
            string projectID1;
            projectID1 = getId();

            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT ProjectName FROM tblProjects WHERE ProjectID = @ProjectID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectID", projectID1);
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["ProjectName"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getUserId()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT UserID FROM tblProjects WHERE ProjectName = @ProjectName";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@ProjectName", Session["notprojdev"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["UserID"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }

        string getComentOwner()
        {
            string temp = "";
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            string query = "SELECT Username FROM tblUser WHERE UserID = @UserID";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
            SqlDataReader nwReader = sqlCmd.ExecuteReader();
            while (nwReader.Read())
            {
                temp = nwReader["Username"].ToString();
            }
            nwReader.Close();
            sqlCon.Close();
            return temp;
        }
    }
}