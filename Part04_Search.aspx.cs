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
        if (!IsPostBack)
        {
            BindData();
        }
    }

   

    //hides and shows the title search text box and button
    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {

        if (TitleFilterButton.Checked)
        {
            TitleSearch.Visible = true;
            DescSearch.Visible = false;
        }
        else if (DescFilterButton.Checked)
        {
            TitleSearch.Visible = false;
            DescSearch.Visible = true;
        }
        else if (NoFilterButton.Checked)
        {
            TitleSearch.Visible = false;
            DescSearch.Visible = false;
        }

    }

    //passes the appropriate url parameter on press of the button depending on which checkbox and which text box is selected
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
        else if(NoFilterButton.Checked)
        {
            Response.Redirect("Part04_Search.aspx?everything=t");
        }
    }

    //the search itself
    public void BindData()
    {
        try
        {
            string sqlQuery = "";

            string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //ms database debris
            //binding th database based on the queries to the repeater
            OleDbConnection conn = new OleDbConnection(connString);
            //used as a parameter for searching the th sql database
            OleDbParameter parameter = null;

            //queries based on which textbox the search is from
            if (Request.QueryString["title"] != null)
            {
                //@title is the parameter that comes in from the URL
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks WHERE Title LIKE @title";
                parameter = new OleDbParameter("@title", "%" + Request.QueryString["title"].ToString() + "%");
            }

            else if (Request.QueryString["desc"] != null)
            {
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks WHERE Description LIKE @desc";
                parameter = new OleDbParameter("@desc", "%" + Request.QueryString["desc"].ToString() + "%");
            }

            else if (Request.QueryString["everything"]  == "t")
            {
                sqlQuery += "SELECT Title, Description, ImageFileName, ArtWorkID FROM ArtWorks";
                parameter = new OleDbParameter("@everything", "%" + "%");
            }

            //if none of the needed info is given you dont get data
            //or the no filter box is checked
            if(Request.QueryString["title"] != null | Request.QueryString["desc"] != null | Request.QueryString["everything"]=="t")
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter(sqlQuery, connString);

                //adds in sql query as uses it a basis for the database search
                adapt.SelectCommand.Parameters.Add(parameter);

                DataTable dt = new DataTable();
                adapt.Fill(dt);



                //highlight
                HighlightSearchResults(dt);
                




                //repeater
                searchRepeater.DataSource = dt;
                searchRepeater.DataBind();
            }
        }
        catch(Exception ex)
        {
            Response.Redirect("Error.aspx");
        }
    }


    public void NavBarSearch_SearchPage(object sender, EventArgs e)
    {
        if (RightSearch.Text != null)
        {
            Response.Redirect("Part04_Search.aspx?title=" + RightSearch.Text);
        }
    }

    //highlight
    public DataTable HighlightSearchResults(DataTable dt)
    {
        //checking for text from the Decriptiom
        if (Request.QueryString["desc"] != null)
        {
            for (int c = 0; c < dt.Rows.Count; c++ )
            {
                string query = Request.QueryString["desc"];
                string replace = dt.Rows[c]["Description"].ToString();

                replace = replace.Replace(query, "<mark>" + query + "</mark>");
                
                //put it back in the data table
                dt.Rows[c]["Description"] = replace;

            }

        }

        return dt;
    }


}