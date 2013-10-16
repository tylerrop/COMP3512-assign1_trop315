<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Part04_Search.aspx.cs" Inherits="Part04_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COMP 3532 - Assign #1 | Search (Part 04)</title>
   
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" type="image/png" href="art-images/favicon.png"/>

    <!--Bootstrap-->
    <link href="bootstrap-3.0.0/dist/css/bootstrap.css" rel="stylesheet"/>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="bootstrap-3.0.0/assets/js/html5shiv.js" ></script>
        <script src="bootstrap-3.0.0/assets/js/respond.min.js"></script>
    <![endif]-->

    <!--Custom CSS styles-->
    <link href="bootstrap-3.0.0/customStyles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

    <!--Top navigation-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <!--menu button for moile screen sizes-->
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                <!--End of navbar-toggle-->
                </button>
                
                <!--Assign 1 home link-->
                <asp:HyperLink ID="Assign1Link" runat="server" CssClass="navbar-brand" NavigateUrl="~/Default.aspx" Text="Assign 1" /> 
             
            <!--End of navbar-header-->
            </div>

            <!--Top nav menu-->
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><asp:HyperLink ID="HomeLink" runat="server" NavigateUrl="~/Default.aspx" Text="Home" /></li>
                    <li><asp:HyperLink ID="AboutLink" runat="server" NavigateUrl="~/AboutUs.aspx" Text="About Us" /></li>
                    
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Pages <b class="caret"></b></a>
                        <!--ASP CHANGE-->


                        <ul class="dropdown-menu">
                            <li><asp:HyperLink ID="ArtistsDataLink" runat="server" NavigateUrl="~/Part01_ArtistsDataList.aspx" Text="Artists Data List (Part 1)" /></li>
                            <li><asp:HyperLink ID="SingleArtistLink" runat="server" NavigateUrl="~/Part02_SingleArtist.aspx" Text="Single Artists (Part 2)" /></li>
                            <li><asp:HyperLink ID="SingleWorkLink" runat="server" NavigateUrl="~/Part03_SingleWork.aspx" Text="Single Work (Part 3)" /></li>
                            <li><asp:HyperLink ID="SearchLink" runat="server" NavigateUrl="~/Part04_Search.aspx" Text="Search (Part 4)" /></li>
                            <!--Dont need this code for now
                        <!--End of dropdown-menu-->
                        </ul>
                    <!--End of dropdown li-->
                    </li>
              <!--End of nav navbar-nav-->
              </ul>
              
              <!--Right search-->
              <div class="navbar-form navbar-right">
                    <!--Search box-->
                    <p id="nameBlock">Tyler Rop</p>
                    <div class="form-group">
                        <asp:TextBox Text="Search Paintings" ID="RightSearch" TextMode="SingleLine" runat="server" CssClass="form-control" />
                    <!--End of form-group-->
                    </div>
                    
                    <!--Search button-->
                    <asp:Button ID="RightSubmit" runat="server" Text="Search" CssClass="btn btn-primary" />
                    <!--End of search form-->
              </div>


            <!--End of navbar-collapse collapse-->  
            </div>
        <!--End of container-->    
        </div>
    <!--End of navbar navbar-inverse navbar-fixed-top-->
    </div>

    <!--Extra top spacing between navbar and content-->
    <br />
    <div class="topSpacing"></div>

    <div class="container">
        <div class="col-lg-12">
            <h1>Search Results</h1>
        
            <div class="highlight">
              
                <asp:RadioButton ID="FilterButton" runat="server" Value="1" Text=" Filter by Title" /> 
                <asp:TextBox ID="TitleSearch" TextMode="SingleLine" runat="server" CssClass="form-control"/>

                <asp:RadioButton runat="server" Value="2" Text=" Filter by Description" /> 
                <asp:TextBox ID="DescSearch" TextMode="SingleLine" runat="server" CssClass="form-control" />

                <asp:RadioButton runat="server" Value="3" Text=" No Filter (show all artworks)" /> 
                <asp:TextBox ID="NoFiltSearch" TextMode="SingleLine" runat="server" CssClass="form-control" />
                <br />

                <asp:Button ID="Button1" runat="server" Text="Filter 1" CssClass="btn btn-primary" OnClick="Button1_OnClick" />

                <asp:Button ID="Button2" runat="server" Text="Filter 2" CssClass="btn btn-primary" OnClick="Button2_OnClick" />

                <asp:Button ID="Button3" runat="server" Text="Filter 3" CssClass="btn btn-primary" OnClick="Button3_OnClick" />

            <!--End of col-lg-12 highlight-->
            </div>
                
            <asp:Repeater runat="server" DataSourceID="sqlArtists">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><a href="Part03_SingleWork.aspx?ArtWorkID=#"><img src="art-images/artists/square-medium/103.jpg" alt="" /></a></td>
                            <td class="topText leftPadEightPix"><a href="Part03_SingleWork.aspx?ArtWorkID=#">image name link</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce in tempus dolor. Fusce id justo et nisi volutpat elementum in in odio. Sed congue pulvinar aliquet. Curabitur in mi sapien. Nullam tristique enim at tortor dignissim, quis hendrerit justo dignissim. Sed nisi felis, dictum non lorem at, porta tempus magna. In convallis sollicitudin commodo.

                                </p>
                            </td>
                        </tr>
                    </table>               

                   <br clear="all"/>
                           
                </ItemTemplate>
            </asp:Repeater>
        
         <!--End of col-lg-12-->
        </div>

    <!--End of container-->
    </div>



    <asp:SqlDataSource ID="sqlArtists" 
                       runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                       SelectCommand="SELECT * FROM [Artists] ORDER BY LastName"
                       ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
    </asp:SqlDataSource>


    </form>

   <!-- Bootstrap core JavaScript
   ================================================== -->
   <!-- Placed at the end of the document so the pages load faster -->
   <script src="bootstrap-3.0.0/assets/js/jquery.js"></script>
   <script src="bootstrap-3.0.0/dist/js/bootstrap.min.js"></script>


</body>
</html>
