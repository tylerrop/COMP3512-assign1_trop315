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
        //get the Artist IF from the URL and convert it to an int
        int queryString = Int32.Parse(Request.QueryString["ArtistID"]); 

        if (queryString > 121  | queryString < 1)
        {
            Response.Redirect("Error.aspx");
        }

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