using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transitor
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
                Response.Redirect("Login.aspx");
            lblDevs.Text = "Welcome " + Session["role"] + "!";
            lblTrans.Text = "Welcome " + Session["role"] + "!";
        }
    }
}