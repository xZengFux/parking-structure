<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountInformation.aspx.cs" Inherits="ParkingPalsClientSide.AccountInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
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
    </style>

</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Table CssClass="myTable" ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                <asp:TableRow CssClass="myRow">
                    <asp:TableCell CssClass="myCell">

                        <asp:Table ID="InfoTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    Account Information                           
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    Username: <asp:Label ID="userLabel" runat="server" Text="user"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    Email: <asp:Label ID="emailLabel" runat="server" Text="email"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    Phone number: <asp:Label ID="phoneLabel" runat="server" Text="phone"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="updateButtton" runat="server" Text="Update Information" OnClick="UpdateButton_Click"/>
                                </asp:TableCell>
                            </asp:TableRow>


                            <asp:TableRow>
                                <asp:TableCell style="border-color:white">
                                    <asp:Image ID="Image1" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="backButton" runat="server" Text="Back" OnClick="BackButton_Click"/>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </asp:TableCell>
                    <asp:TableCell>
                        
                        <asp:Table ID="UsageTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                         
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    Membership Status: <asp:Label ID="statusLabel" runat="server" Text="status"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:CheckBox ID="deleteBox" runat="server" Text="Delete Account?" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button ID="deleteButton" runat="server" Text="Delete Account!" OnClick="DeleteButton_Click" />
                                </asp:TableCell>
                            </asp:TableRow>

                           
                        </asp:Table>
                        <asp:Label ID="deleteMessage" runat="server"></asp:Label>
                   </asp:TableCell>


                </asp:TableRow>
            </asp:Table>

            
        </div>
        
    </form>
</body>
</html>


