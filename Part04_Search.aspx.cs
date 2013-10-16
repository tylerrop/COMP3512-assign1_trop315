using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web.Security;

using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Part04_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   //hiding the forms and buttons until a radio option is selected
        TitleSearch.Visible = false;
        Button1.Visible = false;
        DescSearch.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;



        if (!IsPostBack)
        {
            CreateSearchQuery(1, "TEST STRING");
        }
    }

    //hides and shows the title search text box and button
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

        if (FilterButton.Checked)
        {
            TitleSearch.Visible = true;
            Button1.Visible = true;
        }
        else
        {
            TitleSearch.Visible = false;
            Button1.Visible = false;

        }
    }

    //hides and shows the description search text box and button
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

        if (FilterButton.Checked)
        {
            DescSearch.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            DescSearch.Visible = false;
            Button2.Visible = false;

        }
    }

    //hides and shows the no filter button
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

        if (FilterButton.Checked)
        {
            Button3.Visible = true;
        }
        else
        {
            Button3.Visible = false;

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