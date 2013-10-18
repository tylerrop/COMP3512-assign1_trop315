using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Part03_SingleWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //redirect for the navbar search box to make an auto title search request
    public void NavBarSearch_ArtworkPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }

    //redirects the user to the Error page if there is a problem with the value in the URL for the ArtWorkID
    public void SingleWorkURL(object sender, SqlDataSourceStatusEventArgs e)
    {
        //seeing if the data source returns something
        //if nothing is returns then the user is directed to the Error page
        if (e.AffectedRows < 1)
        {
            Response.Redirect("Error.aspx");
        }
    }
}