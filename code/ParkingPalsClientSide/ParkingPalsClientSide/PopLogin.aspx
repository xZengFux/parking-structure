<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopLogin.aspx.cs" Inherits="ParkingPalsClientSide.PopLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            .myTable {
        border: none;
        border-radius: 25px;
        background-color:lightgrey;
    }

    .myCell {
        border: none;
        font-family: Arial;
    }

    .myRow {
        border-style: hidden;
        font-family: Arial;
    }
    .myImage{
            border-radius: 25px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Table CssClass="myTable" ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center" BorderColor="white">
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    <asp:Image CssClass="myImage" ID="Image1" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
                </asp:TableCell>
                <asp:TableCell CssClass="myCell">
                <div style="text-align: center">
                    <asp:Label ID="labelUsername" runat="server" style="text-align: center" Text="Enter Username"></asp:Label>
                    :
                    <asp:TextBox ID="getUsernameText" runat="server" OnTextChanged="getUsernameText_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="labelPassword" runat="server" Text="Enter Password"></asp:Label>
                    :
                    <asp:TextBox ID="getPasswordText" runat="server" TextMode="Password" OnTextChanged="getPasswordText_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Button CssClass="myButton" ID="checkCredentialsButton" runat="server" style="text-align: center" Text="Login" OnClick="checkCredentialsButton_Click" />

                    <span style="padding-left:2em"></span>

                    <br />
                    <asp:Label ID="labelError" runat="server"></asp:Label>
                </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>


