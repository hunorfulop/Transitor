using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transitor
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "Translator")
            {
                MenuForTranslators.Visible = true;
                MenuForDevs.Visible = false;
            }
            else
            {
                MenuForTranslators.Visible = false;
                MenuForDevs.Visible = true;

            }
        }
    }
}