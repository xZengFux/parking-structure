<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="ParkingPalsClientSide.SignupPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style2 {
            font-weight: bold;
        }
        .myCheckBox{
              display: block;
              position: center;
              padding-left: 35px;
              margin-bottom: 12px;
              cursor: pointer;
              font-family: Arial;
              -webkit-user-select: none;
              -moz-user-select: none;
              -ms-user-select: none;
              user-select: none;
        }
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
<body style="text-align: center">
    <form id="form1" runat="server">
        <asp:Table CssClass="myTable" ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    <asp:Image CssClass="myImage" ID="Image2" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Sign up Information: 
                </asp:TableCell>
           </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    UserName: 
                    <asp:TextBox ID="UserLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    First Name: <asp:TextBox ID="FirstnameLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Last Name: <asp:TextBox ID="LastnameLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

           <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                Email: <asp:TextBox ID="EmailLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Phone Number: <asp:TextBox ID="PhoneLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Account Type:
            <asp:CheckBoxList CssClass="myCheckBox" ID="AccountList" runat="server">
                <asp:ListItem>Premium</asp:ListItem>
                <asp:ListItem>Standard</asp:ListItem>
                <asp:ListItem>Free</asp:ListItem>
            </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Password:
            <asp:TextBox ID="PasswordLabel" TextMode="Password" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    Repeat Password:
            <asp:TextBox ID="RepeatLabel" TextMode="Password" runat="server" Height="22px" style="margin-top: 6px; font-weight: 700;" Width="185px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    <asp:Button CssClass="myButton" ID="SignupButton" runat="server" Height="60px" Text="Sign up" Width="120px" style="font-weight: 700" OnClick="signupButton_Click" />
                </asp:TableCell>
            </asp:TableRow>



        </asp:Table>



    </form>
</body>
</html>

