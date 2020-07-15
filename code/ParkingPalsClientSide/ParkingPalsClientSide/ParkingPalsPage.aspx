<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParkingPalsPage.aspx.cs" Inherits="ParkingPalsClientSide.ParkingPals" %>

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
        <div>
            <h1>
            <asp:Label ID="TitleLabel" runat="server" style="font-family:Arial" Text="Parking Pals"></asp:Label>
            </h1>  
            <h1 style="text-align: center">
                <asp:Button CssClass="myButton" ID="homeLoginButton" runat="server" Text="Login" OnClick="homeLoginButton_Click" />
            </h1>
           
            <h1 style="text-align: center">
            <asp:Button CssClass="myButton" ID="homeSignupButton" runat="server" Text="Sign up" OnClick="homeSignupButton_Click" />
            </h1>
            <h1> 
                <asp:Image ID="Image1" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
            </h1>
            <address>
                <asp:Label ID="Label1" runat="server" style="font-family:Arial" Text="Enter Ticket Number:"></asp:Label>
            </address>
            <h1 style="text-align: center">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button CssClass="myButton" ID="Button1" runat="server" Text="Check Ticket" OnClick="Button1_Click1" />
            </h1>
            <p>
                <asp:Label ID="ticketNumber" runat="server"></asp:Label>
               
            </p>
        </div>
    </form>
</body>
</html>

