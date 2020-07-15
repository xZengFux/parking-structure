<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentInformation.aspx.cs" Inherits="ParkingPalsClientSide.PaymentInformation" %>

<!DOCTYPE html>
<style>
.myButton {
            border: none;
            background: #404040;
            color: #ffffff !important;
            font-family: Arial;
            font-weight: 100;
            padding: 10px;
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
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
        <form id="form1" runat="server">
            <asp:Table CssClass="myTable" ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center" BorderColor="white">
                <asp:TableRow CssClass="myRow">
                    <asp:TableCell CssClass="myCell">
                        <asp:Label ID="TitleLabel" runat="server" Text="Payment"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow CssClass="myRow">
                    <asp:TableCell CssClass="myCell">
                        <asp:Button CssClass="myButton" ID="Paypal" runat="server" OnClick="Paypal_Click" Text="Paypal" />
                    </asp:TableCell>

                    <asp:TableCell CssClass="myCell">
                        <asp:Button CssClass="myButton" ID="Apple" runat="server" OnClick="Apple_Click" Text="Apple Pay"  />
                    </asp:TableCell>

                    <asp:TableCell CssClass="myCell">
                        <asp:Button CssClass="myButton" ID="Google" runat="server" OnClick="Google_Click" Text="Google Pay"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow CssClass="myRow">
                    <asp:TableCell CssClass="myCell">
                        <asp:Button CssClass="myButton" ID="Button1" runat="server" Text="Back to the Future" OnClick="Back_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>


        <div style="text-align:center">
            

            <br />
            <br />
            <br />
            
            <br />
            <br />
            <br />
            
            <br />
            <br />
            <br />
            

        </div>
    </form>
</body>
</html>


