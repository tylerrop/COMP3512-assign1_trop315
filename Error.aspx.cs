using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void NavBarSearch_ErrorPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }
}