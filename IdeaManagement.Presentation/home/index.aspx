<%@ Page Language="C#" AutoEventWireup="false" Trace="false" Inherits="IdeaManagement.Presentation.home.Index" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Here Comes the Suggestion !!!</title>
    <script type="text/javascript" src="../js/jquery1.8.3.min.js"></script>
    <link rel="stylesheet" href="../css/reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../css/grid.css" type="text/css" media="screen" />
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-ui.js"></script>
</head>
<body>
    <form runat="server" id="form1">
        <div id="wrapper">
            <div id="header">
                <!-- #include file="../includes/header.html" -->
                <div class="inner container_12 clearfix">
                </div>
                <strong>
                    <h2 id="top-suggestion">Top Suggestions (Total <%=Convert.ToString(totalSuggestion) %>)</h2>
                </strong>
                <p><i></i></p>
                <div id="tabs">
                    <ul>
                        <li class="category"><a name="votes" href="#tabs-1">Votes</a></li>
                        <li class="category"><a name="new" href="#tabs-1">Newest</a></li>
                        <li class="category"><a name="view" href="#tabs-1">Most Viewed</a></li>
                    </ul>
                    <div id="tabs-1">
                    </div>
                    <div id="top-ideas">
                        <asp:Repeater ID="rptIdeas" runat="server">
                            <ItemTemplate>
                                <ul>
                                    <li>
                                        <div id="ratings">
                                            <div class="vote-border">
                                                <div style="margin-left: 3px"><span class="vote-count"><%#DataBinder.Eval(Container.DataItem,"Votes") %></span></div>
                                                <div>Votes</div>
                                            </div>
                                            <div class="comment-border">
                                                <div style="margin-left: 17px"><span class="comment-count"><%#DataBinder.Eval(Container.DataItem,"CommentsCount") %></span></div>
                                                <div style="display: block">Comments</div>
                                            </div>
                                            <div class="view-border">
                                                <div><span count="<%#DataBinder.Eval(Container.DataItem,"Views") %>" class="view-count_<%#DataBinder.Eval(Container.DataItem,"IdeaId") %>"><%#DataBinder.Eval(Container.DataItem,"Views") %></span></div>
                                                <div>Views</div>
                                            </div>
                                            <div class="idea-title">
                                                <div><a class="desc-page addView" href="DescribedIdea.aspx?id=<%#DataBinder.Eval(Container.DataItem,"IdeaId") %>" ideaid="<%#DataBinder.Eval(Container.DataItem,"IdeaId") %>" target="_blank">Title : <%#DataBinder.Eval(Container.DataItem,"Title") %></a></div>
                                                <div id="idea-desc">
                                                    <h5>Description : </h5>
                                                    <span class="description"><%#DataBinder.Eval(Container.DataItem,"Description") %></span><a class="addView" ideaid="<%#DataBinder.Eval(Container.DataItem,"IdeaId") %>" class="desc-page" href="DescribedIdea.aspx?id=<%#DataBinder.Eval(Container.DataItem,"IdeaId") %>" target="_blank">read more</a>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="float: right" id="author"><i>Posted By : </i><span><%#DataBinder.Eval(Container.DataItem,"RequestedUser") %>, <i><%#GetDaysDifference(DataBinder.Eval(Container.DataItem,"PostedDate")) %> days ago<i /></span></div>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!-- end header inner -->
        </div>
        <!-- end header -->

        <!--<div id="nav" class="container_12 clearfix">
            <ul>
                <li><a href="#">Home</a></li>
                <li><a href="#">About Us</a></li>
                <li><a href="#">Services</a></li>
                <li><a href="#">Products</a></li>
                <li><a href="#">Contact Us</a></li>
            </ul>
        </div>-->
        <!-- end nav -->
        <div id="content">
            <div class="inner container_12 clearfix">
                <div id="main" class="grid_8">
                    <h2>About us</h2>
                    <p><strong>Aspiring to awesomeness? We make it easy to develop and evaluate ideas together with your colleagues, customers, or a customized crowd!</strong></p>

                    <p>The unique multi-functional mobile and web application is trusted by clients such as Caixa Bank, Unicef, Arla Foods, Kinnarps, Choice Hotels, City of Gothenburg etc</p>

                    <p>With us you can easily gather, share and develop trends and ideas, analyze and report in the same digital platform. Extend reach with embeddable widgets and customized crowds.</p>




                    <div id="home-bottom" class="clearfix">

                        <h2>Latest News</h2>

                        <div id="col1" class="grid_7">
                            <h5><a href="#">Here we launch our app</a></h5>

                            <p>
                                Now you can soon manage best ideas and suggestion through our new Mobile App.
                            </p>
                            <p><a href="#">Read More</a></p>
                        </div>

                        <div id="col2" class="grid_7">
                            <h5><a href="#">Join Us</a></h5>

                            <p>
                                We’re true believers in the power of the web and how it connects people to content. You want to use your talents for something big. You want the chance to make a difference, everyday. You want to be part of something that everyone’s talking about. And you wouldn’t mind having lots of fun along the way with people as driven and excited as you.
                            </p>
                            <p><a href="#">Read More</a></p>
                        </div>



                    </div>
                    <!-- end home-bottom -->

                </div>
                <!-- end main -->
                <div id="sidebar" class="grid_4">
                    <div class="inner">

                        <img width="306px" src="../images/idea-management.jpg" alt="image" class="imgborder" />

                        <div id="address">
                            <h3>Contact Information</h3>
                            <p>
                                1234 Any Street,
                                <br />
                                Brooklyn, NY 12345
                            </p>

                            <p>
                                <strong>Phone:</strong> 1(234) 567 8910
                                <br />
                                <strong>Fax:</strong> 1(234) 567 8910
                            </p>

                            <p><strong>E-mail:</strong> companyname@gmail.com</p>
                        </div>
                        <!-- end address -->
                    </div>
                    <!-- end sidebar inner -->

                </div>
                <!-- end sidebar -->
            </div>
            <!-- end content inner -->
        </div>
        <!-- end content -->

        <div id="footer">
            <div class="inner container_12 clearfix">

                <p>
                    Copyright  2016.
                    <!-- Please Do not remove -->
                    Developerd By Suresh Prajapati <a href="#" target="_blank">Chrome Towel Radiator</a><!-- end --><br />
                    <a href="#">Privacy Policy</a> | <a href="#">Terms of Use</a> | <a href="#" title="This page validates as XHTML 1.0 Transitional">
                        <abbr title="eXtensible HyperText Markup Language">XHTML</abbr></a> | <a href="#" title="This page validates as CSS">
                            <abbr title="Cascading Style Sheets">CSS</abbr></a>
                </p>

            </div>
            <!-- end footer inner -->
        </div>
        <!-- end footer -->
        <!-- end wrapper -->
    </form>
    <script type="text/javascript">
        //scrolling
        $(document).ready(function () {
            $("#tabs").tabs();
            $('.addView').click(function () {
                var ideaId = $(this).attr("ideaid");
                var view = $(".view-count_" + ideaId);
                var increaseCount = Number(view.attr("count")) + 1;
                $(".view-count_" + ideaId).text(increaseCount);
                increaseViewCount(ideaId);
            });
            $('.category').click(function (e) {
                window.location.href = "index.aspx?tab=" + $(e.target).attr('name') + "#tabs";
            });
            var selectedTab = getParameterByName("tab", window.location.href) || "";
            if (selectedTab !== "") {
                $("li a[ name=" + selectedTab + "]").addClass('ui-tabs-active ui-state-active ui-state-hover');

                $("li a[ name=votes]").parent().removeClass('ui-tabs-active ui-state-active ui-state-hover');
            }
        });
        function increaseViewCount(ideaId) {
            var url = "/api/idea/view/" + ideaId;
            var posting = $.post(url);
            posting.done(function (data) {
            });
        }
        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
    </script>
</body>
</html>

