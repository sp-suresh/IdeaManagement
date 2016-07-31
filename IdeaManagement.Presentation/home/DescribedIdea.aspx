<%@ Page Language="C#" Trace="false" AutoEventWireup="false" Inherits="IdeaManagement.Presentation.home.DescribedIdea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detailed - Suggestion</title>
    <style>
        #comment {
            margin: 15px;
        }

        #header {
            padding: 10px;
        }
    </style>
    <script src="../js/jquery1.8.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="header">
                <!-- #include file="../includes/header.html" -->
            </div>
            <div>
                <div style="padding:10px">
                    <div>
                        <h4>Title : </h4>
                        <%=objSummary.Title %>
                        <div></div>
                    </div>
                    <div>
                        <h4>Full Description</h4>
                        <%=objSummary.Description %>
                    </div>
                    <div style="float: right !important">
                        <h4>Author : <%=objSummary.RequestedUser%></h4>
                    </div>
                </div>
            </div>
            <div style="padding: 20px">
                <h4>All Comments : </h4>
                <ul style="lis">
                    <asp:Repeater ID="rptComments" runat="server">
                        <ItemTemplate>
                            <li><%# Container.DataItem.ToString()%></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div>
                <div  style="display:inline-block">
                    <input class="rate" id="btnThumbUp" type="button" name="Up" value="Thmub Up" />

                </div>
                <div  style="display:inline-block">
                    <input class="rate" id="btnThumbDown" type="button" name="Down" value="Thmub Down" />

                </div>
                    </div>
            </div>
            <div id="comment">
                <div>
                    Add a comment<div>
                        <textarea id="txtComments"></textarea>
                    </div>
                </div>
            </div>
            <div style="padding :10px">
                <input id="btnComment" type="button" value="Post Comment" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var ideaId = '<%=ideaId%>';
        $("#btnComment").click(function () {
            saveComments();
        });
        $(".rate").click(function () {
            saveRatings(this);
        });
        function saveRatings(e) {
            var voteType = $(e).attr("name") || "";
            if (voteType !== "") {
                var url = "";
                if (voteType === "Up") {
                    url = "/api/idea/votes/?ideaId=" + ideaId + "&voteType=1";
                }
                else {
                    url = "/api/idea/votes/?ideaId=" + ideaId + "&voteType=2";
                }
                var posting = $.post(url);
                posting.done(function (data) {
                    alert("Thank you for your vote");
                    window.location.href = "/home/index.aspx";
                });
            }

        }
        function saveComments() {
            var comments = $("#txtComments").val() || "";
            if (comments !== "") {
                var url = "/api/idea/comments?ideaId=" + ideaId + "&comments=" + comments;
                var posting = $.post(url);
                posting.done(function (data) {
                    alert("Thank you for your feedback/comments");
                    window.location.href = "/home/index.aspx";
                });
            }
            else {
                alert("Please fill comments");
            }
        }
    </script>
</body>
</html>
