using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Part04_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Search(1, "CHANGE");
        }
    }

    //Search by title call. #1 for searchNum
    protected void Button1_OnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Part04_Search.aspx?Search1=" + HttpUtility.UrlEncode(TitleSearch.Text));
        string search = HttpUtility.UrlEncode(TitleSearch.Text);
        Search(1, search);
    }

    //search by Description call. #2 for searchNum
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Part04_Search.aspx?Search2=" + HttpUtility.UrlEncode(DescSearch.Text));
        string search = HttpUtility.UrlEncode(DescSearch.Text);
        Search(2, search);
    }

    //search by No Filter call. #3 for searchNum
    protected void Button3_OnClick(object sender, EventArgs e)
    {
        string search = HttpUtility.UrlEncode(NoFiltSearch.Text);
        Search(3, search);
  
    }

    private void Search(int searchNum, string query)
    {
        int i = searchNum;
        string q = query;
        
    }


}