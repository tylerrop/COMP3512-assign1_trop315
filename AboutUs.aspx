<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AboutUs.aspx.vb" Inherits="AboutUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    http://localhost:11250/COMP3512-assign1_trop315/Default.aspx#about
    <title>COMP 3532 - Assign #1 | About Us</title>
   
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" type="image/png" href="art-images/server_client_exchange.ico" />

    <!--Bootstrap-->
    <link href="bootstrap-3.0.0/dist/css/bootstrap.css" rel="stylesheet">

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
                    
                    <!--ASP CHANGE-->
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
        <!--changed from 10-->
        <div class="col-lg-12">
            
                    <!--overall upper artist info content holder-->
                    <div class="col-lg-12">
                    
                    <!--Page title-->
                    <h2>About Us</h2>
                    

                        <!--Self picture col-xs-4 col-sm-4 col-md-4 col-lg-4-->
                        <img src="art-images/MRU_2c_logo_RGB.jpg"
                             alt="Mount Royal University Logo"
                             class="noLeftPadding col-xs-12 col-sm-4 col-md-4 col-lg-4"/>

                        <!--About Info-->
                        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-6">
                            <!--artist description paragraph-->
                            <p class="col-lg-12 noLeftPadding lead">This website was coded by Tyler Rop for the class of COMP 3512 at Mount Royal University in the Fall semester of 2013.</p>
                            <p class="col-lg-12 noLeftPadding lead">The images and copy text present in this site are not owned by Tyler Rop and are not for sale.</p>            
                        <!--End of col-xs-12 col-sm-6 col-md-8 col-lg-8-->                          
                        </div>  
                        

                        <div class="col-xs-12 col-sm-8 col-sm-offset-4 col-md-offset-4 col-md-8 col-lg-offset-4 col-lg-6">
                        <!--Panel for ArtistWork Details-->
                            <div class="panel panel-default">
                                <div class="panel-heading noMargins leftPadEightPix boldText">Assignment Details</div>
                                
                                <!-- Table -->
                                <table class="table">
                                    <!--Date-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Date: </td>
                                        <td class="col-sm-3">October 18, 2013</td>
                                    </tr>

                                    <!--University-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">University:</td>
                                        <td class="col-sm-3">Mount Royal University</td>
                                    </tr>

                                    <!--Class-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Class:</td>
                                        <td class="col-sm-3">COMP 3512</td>
                                    </tr>

                                    <!--Professor-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Professor:</td>
                                        <td class="col-sm-3">Randy Connolly</td>
                                    </tr>

                                    <!--Student-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Student:</td>
                                        <td class="col-sm-3">Tyler Rop</td>
                                    </tr>
                                    
                                    <!--Assignment-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Assignment:</td>
                                        <td class="col-sm-3">#1 Database-Driven Web Pages</td>
                                    </tr>
                                                                       
                                    </tr>
                                </table>
                                
                            <!--End of panel panel-default-->
                            </div>
                            
                        <!--End of col-xs-12 col-sm-6 col-md-8 col-lg-8-->                          
                        </div>  


        <!--End of row-->
        </div>
        

    <!--End of container-->
    </div> 
        
     
    </form>

   <!-- Bootstrap core JavaScript
   ================================================== -->
   <!-- Placed at the end of the document so the pages load faster -->
   <script src="bootstrap-3.0.0/assets/js/jquery.js"></script>
   <script src="bootstrap-3.0.0/dist/js/bootstrap.min.js"></script>


</body>
</html>
