using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;


public partial class Part04_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        //if not a postback then the search is run
        if (!IsPostBack)
        {
            BindData();
        }
    }


    //hides and shows Title and/or Description text box depending on which radio button is selected
    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        //the title radio is checked so the title text box is shown and the desciption text box hidden
        if (TitleFilterButton.Checked)
        {
            TitleSearch.Visible = true;
            DescSearch.Visible = false;
        }

        //the description radio is checked so the title text box is hidden and the description text box shown
        else if (DescFilterButton.Checked)
        {
            TitleSearch.Visible = false;
            DescSearch.Visible = true;
        }

        //the no filter radio is checked so the title text box is hidden and the description text box hiden
        else if (NoFilterButton.Checked)
        {
            TitleSearch.Visible = false;
            DescSearch.Visible = false;
        }

    }

    //redirects the search page with the appropriate url parameter on press of the filter button depending on
    //which textbox is selected and which radio button is checked
    public void FilterButtonPress(object sender, EventArgs e)
    {
        //if there is text we post it back to the page to run the query

        //title search selected
        if(TitleSearch.Text != null && TitleFilterButton.Checked)
        {
            Response.Redirect("Part04_Search.aspx?title=" + TitleSearch.Text);
        }

        //description search selected
        else if(DescSearch.Text != null && DescFilterButton.Checked)
        {
            Response.Redirect("Part04_Search.aspx?desc=" + DescSearch.Text);
        }

        //no filter search selected
        //the everything=t is appended to the url simply so that the the no filter option will not be run when the user enters 
        //random text to the url
        else if(NoFilterButton.Checked)
        {
            Response.Redirect("Part04_Search.aspx?everything=t");
        }
    }

    //search method
    //creates and executes a sql statement depending on the users search query and the url for it
    //description search results are highlighted to show the search query
    public void BindData()
    {
        try
        {
            //the sql query that wil be executed. Made blank by default.
            string sqlQuery = "";

            //create th connection to the database
            string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //binding th database based on the queries to the repeater
            OleDbConnection conn = new OleDbConnection(connString);

            //used as a parameter for searching the th sql database
            OleDbParameter parameter = null;

            //queries based on which textbox the search is from and are checked to actually have a search parameter attached to them
            //title search query
            if (Request.QueryString["title"] != null && Request.QueryString["title"] != "")
            {
                //@title is the parameter that comes in from the URL
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks WHERE Title LIKE @title";
                parameter = new OleDbParameter("@title", "%" + Request.QueryString["title"].ToString() + "%");
            }

            //descpription search query
            else if (Request.QueryString["desc"] != null)
            {
                //@desc is the parameter that comes in from the URL
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks WHERE Description LIKE @desc";
                parameter = new OleDbParameter("@desc", "%" + Request.QueryString["desc"].ToString() + "%");
            }

            //no filter query
            else if (Request.QueryString["everything"]  == "t")
            {
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks";
                parameter = new OleDbParameter("@everything", "%" + "%");
            }

            //if there is a query that is valid then we fill a DataTable with the needed info.
            if(Request.QueryString["title"] != null | Request.QueryString["desc"] != null | Request.QueryString["everything"]=="t")
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter(sqlQuery, connString);

                //adds in sql query as uses it a basis for the database search
                adapt.SelectCommand.Parameters.Add(parameter);

                //creating and filling the DataTable
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                //The DataTable is passed to have the description text to be highlighted when the query is present in the description text
                HighlightSearchResults(dt);
                
                //the repeater for the search results is filled
                searchRepeater.DataSource = dt;
                searchRepeater.DataBind();
            }
        }

        //if thee is an exception then the page is directed to the error page
        catch(Exception ex)
        {
            Response.Redirect("Part04_Search.aspx");
        }
    }

    //redirect for the navbar search box to make an auto title search request
    public void NavBarSearch_SearchPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }

    //Highlights the appropriate text in the ArtWork Description based on the description search query
    public DataTable HighlightSearchResults(DataTable dt)
    {
        //checking for text from the Decription
        if (Request.QueryString["desc"] != null)
        {
            //reading through the entire description and adding in mark tags to highlight the search query
            for (int c = 0; c < dt.Rows.Count; c++ )
            {
                //getting the description search query
                string query = Request.QueryString["desc"];
                string replace = dt.Rows[c]["Description"].ToString();


                //adding in the mark tags around the search query for this row
                replace = replace.Replace(query, "<mark>" + query + "</mark>");
                
                //puts the row back in the data table with the updated mark tags
                dt.Rows[c]["Description"] = replace;

            }

        }

        return dt;
    }


}