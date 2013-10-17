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

                //repeater
                searchRepeater.DataSource = dt;
                searchRepeater.DataBind();
                


            }
        }
        catch
        {
        }
    }
























    //Search by title call. #1 for searchNum
    protected void Button1_OnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Part04_Search.aspx?Search1=" + HttpUtility.UrlEncode(TitleSearch.Text));
        string search = HttpUtility.UrlEncode(TitleSearch.Text);
        CreateSearchQuery(1, search);
    }

    //search by Description call. #2 for searchNum
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Part04_Search.aspx?Search2=" + HttpUtility.UrlEncode(DescSearch.Text));
        string search = HttpUtility.UrlEncode(DescSearch.Text);
        CreateSearchQuery(2, search);
    }

    //search by No Filter call. #3 for searchNum
    protected void Button3_OnClick(object sender, EventArgs e)
    {
        CreateSearchQuery(3, "");
    }

    private void CreateSearchQuery(int searchNum, string query)
    {   
        //i is used to determine which type of search we're
        //1 is the Filter by title identifier i
        //2 is the Filter by description identifier i
        //3 is the no filter identifier i
        int i = searchNum;

        //q is the query that is passed in from the text box.
        //for i = 1 & or 2 the query q is grabbed from the URL
        //for i = 3 the query is blank because we dont need anything from it to filter with 
        string q = query;

        //filter by title
        if( i == 1 )
        {
            string sql = "SELECT ArtWorkID FROM ArtWorks WHERE Title LIKE " + query;
            DataBaseSearch(sql);
        }

        //filter by description
        else if (i == 2)
        {
            string sql = "SELECT ArtWorkID FROM ArtWorks WHERE Description LIKE " + query;
            DataBaseSearch(sql);
        }

        //filter by nothing
        //this is the default is the user changes the number in the url to be anything that isnt 1 or 2
        else
        {
            string sql = "SELECT ArtWorkID FROM ArtWorks";
            DataBaseSearch(sql);
        }
    }

    private string DataBaseSearch(string sql)
    {   
        //this will be an ArtWordID from the database
        string results = "";

        // retrieve the connection string from our config file
        string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //create the connection
        //SqlConnection conn = new SqlConnection(connString);

        try
        {
            //create the sql command
            //SqlCommand cmd = new SqlCommand(sql, conn);

            //create the data adapter
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            //fill a data table from the adapter
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            //now data bind to the data table
            //grdProducts.DataSource = dt;
            //grdProducts.DataBind();
        }

        catch (Exception ex)
        {
            //Response.Redirect("Part04_Search.aspx?Search3=" + HttpUtility.UrlEncode(NoFiltSearch.Text));
            Response.Redirect("Error.aspx");
            
        }

        return results;
    }


}