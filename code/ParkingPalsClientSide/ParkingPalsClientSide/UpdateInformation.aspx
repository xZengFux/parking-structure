<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInformation.aspx.cs" Inherits="ParkingPalsClientSide.UpdateInformation" %>


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
	        box-shadow: 0px 1px 0px 0px #1c1b18;
	        background:linear-gradient(to bottom, #eae0c2 5%, #ccc2a6 100%);
	        background-color:#eae0c2;
	        border-radius:15px;
	        border:2px solid #333029;
	        display:inline-block;
	        cursor:pointer;
	        color:#505739;
	        font-family:Arial;
	        font-size:12px;
	        font-weight:bold;
	        padding:10px 12px;
	        text-decoration:none;
	        text-shadow:0px 1px 0px #ffffff;
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
                    <asp:Label ID="userLabel" runat="server" Text="username" style="font-weight: 700"></asp:Label>
                </asp:TableCell>
           </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    New Email: <asp:TextBox ID="newEmailLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    New Phone Number:<asp:TextBox ID="newPhoneLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    New Password: <asp:TextBox ID="newPasswordLabel" runat="server" Height="22px" style="margin-top: 6px" Width="185px" CssClass="auto-style2"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

           <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                Repeat New Password: <asp:TextBox ID="repeatLabel" runat="server" Height="22px" style="margin-top: 6px; font-weight: 700;" Width="185px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow CssClass="myRow">
                <asp:TableCell CssClass="myCell">
                    <asp:Button CssClass="myButton" ID="updateButton" runat="server" Height="60px" Text="Update" Width="120px" style="font-weight: 700" OnClick="updateButton_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>

