using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Part01_ArtistsDataList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void NavBarSearch_DataListPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }
}