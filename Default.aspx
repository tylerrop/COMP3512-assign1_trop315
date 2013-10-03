<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fixed Default Page</title>
   
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!--Bootstrap-->
    <link href="bootstrap-3.0.0/dist/css/bootstrap.css" rel="stylesheet">

    <!--Custom styles for Boostrap Jumbotron template from getbootstrap.com/examples/jumbotron/# -->
    <link href="bootstrap-3.0.0/jumbotron.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="bootstrap-3.0.0/assets/js/html5shiv.js" ></script>
        <script src="bootstrap-3.0.0/assets/js/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">

    <!--Top navigation-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                <!--End of navbar-toggle-->
                </button>
                <a class="navbar-brand" href="#">Assign 1</a>
            <!--End of navbar-header-->
            </div>

            <!--Top nav menu-->
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Home</a></li>
                    <li><a href="#about">About Us</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Pages <b class="caret"></b></a>
              
                        <ul class="dropdown-menu">
                            <li><a href="#">Artists Data List (Part 1)</a></li>
                            <li><a href="#">Single Artists    (Part 2)</a></li>
                            <li><a href="#">Single Work    (Part 3)</a></li>
                            <li><a href="#">Search            (Part 4)</a></li>
                            <!--Dont need this code for now
                            <li class="divider"></li>
                            <li class="dropdown-header">Nav header</li>
                            <li><a href="#">Separated link</a></li>
                            <li><a href="#">One more separated link</a></li>
                            -->
                        <!--End of dropdown-menu-->
                        </ul>
                    <!--End of dropdown li-->
                    </li>
              <!--End of nav navbar-nav-->
              </ul>
              
              <!--Right search-->
              <div class="navbar-form navbar-right">
                    <!--Search box-->
                  <p>Tyler Rop</p>
                    <div class="form-group">
                        <input type="text" placeholder="Search" class="form-control" />
                    <!--End of form-group-->
                    </div>

                    <!--Search button-->
                    <button type="submit" class="btn btn-primary">Search</button>
              <!--End of search form-->
              </div>


            <!--End of navbar-collapse collapse-->  
            </div>
        <!--End of container-->    
        </div>
    <!--End of navbar navbar-inverse navbar-fixed-top-->
    </div>



        </form>

        <!-- Bootstrap core JavaScript
        ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="bootstrap-3.0.0/assets/js/jquery.js"></script>
        <script src="bootstrap-3.0.0/dist/js/bootstrap.min.js"></script>

    
</body>
</html>