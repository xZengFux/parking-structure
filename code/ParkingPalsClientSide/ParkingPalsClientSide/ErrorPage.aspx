<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ParkingPalsClientSide.ErrorPage" %>

<!DOCTYPE html>

    <style>
        .myButton {
            border: none;
            background: #404040;
            color: #ffffff !important;
            font-family: Arial;
            font-weight: 100;
            padding: 15px;
            text-transform: uppercase;
            border-radius: 6px;
            display: inline-block;
            transition: all 0.3s ease 0s;
            }
    </style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <asp:Table ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center" BorderColor="white">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Image ID="Image1" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                 <asp:TableCell>
                <div style="text-align: center">
                    <h1 style="font-family:Arial">
                        What are you looking for?
                    </h1>
                    <h3 style="font-family:Arial">
                        Sorry, the page you were expecting has moved or doesn't exist anymore. 
                    </h3>
                </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button CssClass="myButton" ID="Button1" runat="server" Text="Back to the Future" OnClick="Button1_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>

