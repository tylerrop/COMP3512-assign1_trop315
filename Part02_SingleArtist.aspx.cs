using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Part02_SingleArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //redirect for the navbar search box to make an auto title search request
    public void NavBarSearch_ArtistPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }
}