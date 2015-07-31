<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container backGround">
        <br />
        <nav class="navbar navbar-inverse">
            <div class="navbar-header">
              <a class="navbar-brand" href="#">RSS Tec Mundo</a>
            </div>
        </nav>
        <br />
        <asp:Repeater ID="rptRSS" runat="server">
            <ItemTemplate>
                <div>
                    <h3>
                        <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="lblTitle"></asp:Label></h3>
                    <a href='<%# Eval("Link") %>'>
                        <%# Eval("Link") %></a>
                    <p>
                        <%# Eval("Description") %>
                    </p>
                </div>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
