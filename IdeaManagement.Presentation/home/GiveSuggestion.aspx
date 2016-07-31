<%@ Page Language="C#" AutoEventWireup="false" Inherits="IdeaManagement.Presentation.home.GiveSuggestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Suggestion Is Important</title>
    
    <style>
        #tblForm {
            margin: 20px;
        }

            #tblForm input {
                margin-left: 20px;
                margin:10px;
            }

            #tblForm textarea {
                margin-left: 20px;
                margin:10px;
            }
    </style>
    <script src="../js/jquery1.8.3.min.js"></script>
</head>
<body>
    <form action="/" method="post">
        <fieldset>
            <div id="wrapper">
                <div id="header">
                    <!-- #include file="../includes/header.html" -->
                </div>
                <div>
                    <table id="tblForm">
                        <tr>
                            <td>Name</td>
                            <td>
                                <input id="txtName" type="text" name="name" required="required" />
                            </td>
                            <td><span id="spnName"></span></td>
                        </tr>
                        <tr>
                            <td>Title</td>
                            <td>
                                <input id="txtTitle" type="text" name="name" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td>
                                <textarea id="txtDescription" maxlength="500" rows="4" cols="50" runat="server" resize="none" required="required"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="display: inline-block; margin: 10px"><a href="#" id="btnSave" class="button-0">Save</a></div>
            </div>
        </fieldset>
    </form>
    <script type="text/javascript">
        var name = "";
        var title = "";
        var description = "";
        function isErrorValidation() {
            var isError = false;
            var regNameExp = new RegExp('^[.a-zA-z\' ]+$');

            if (name === "" || !regNameExp.test(name)) {
                alert("Please enter a valid name");
                isError = true;
                return isError;
            }
            if (title === "") {
                alert("Title cannot be empty");
                isError = true;
                return isError;
            }
            if (description === "") {
                alert("Description cannot be empty");
                isError = true;
                return isError;
            }
            else { return false; }
        }
        function saveSuggestion(objDetails) {
            if (!isErrorValidation()) {
                var url = "/api/idea/summary/";
                var posting = $.post(url, objDetails);
                posting.done(function (data) {
                    if (data) {
                        alert("Data saved successfully, thanks for participating")
                        window.location.href = "/home/index.aspx";
                    }
                });
            };
        }
        $("#btnSave").click(function () {
            name = $("#txtName").val() || "";
            title = $("#txtTitle").val() || "";
            description = $("#txtDescription").val() || "";
            var objDetails = {
                "title": title
                    , "description": description
                    , "requestedUser": name
                    , "userId": 0
            }
            saveSuggestion(objDetails);
        });
    </script>
</body>
</html>
