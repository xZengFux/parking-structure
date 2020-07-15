<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ParkingPalsClientSide.HomePage" %>

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
            <!--
            This is the home page.<br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            
            <br />
            -->
            <asp:Table CssClass="myTable" ID="MainTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                <asp:TableRow CssClass="myRow">
                    <asp:TableCell CssClass="myCell">

                        <asp:Table ID="ButtonTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Label ID="ticketNumberText" runat="server" style="font-family:Arial"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="accountInformationButton" runat="server" Text="Account Information" OnClick="accountInformationButton_Click" style="font-family:Arial"/>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="PaymentButton" runat="server" Text="Payment" OnClick="PaymentButton_Click" style="font-family:Arial"/>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="buttonDirections" runat="server" Text="Get Directions" OnClick="Directions_Click" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Button CssClass="myButton" ID="buttonCreateAccount" runat="server" Text="Create Account" OnClick="CreateAccount_Click" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Label ID="LabelLPR" runat="server" style="font-family:Arial"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                   <asp:Button CssClass="myButton" ID="AdminCarPrice" runat="server" Text="Get Car Prices" visibility="hidden"  OnClick="AdminCarPrice_Click" />
                                    <asp:Label ID="CarPriceLabel" runat="server" style="font-family:Arial"></asp:Label>
                                     <asp:Label ID="StateLabel" runat="server" style="font-family:Arial"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="getGasInformation" runat="server" style="font-family:Arial"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                            <asp:Label ID="LabelTraffic" runat="server" style="font-family:Arial"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    <asp:Image style="border-radius:25px" ID="Image1" runat="server" src = "images/Parking Pals Logo.PNG" Height="250px" Width="250px" />
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>

                    </asp:TableCell>
                    <asp:TableCell>
                        
                        <asp:Table ID="WedgitTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center" Height="100%">
                            <asp:TableRow style="border-style:hidden">
                                <asp:TableCell CssClass="myCell">
                                    
                                    <asp:Table ID="TimeParkedTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Time you have parked
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                <asp:Label ID="labelGetParkedTime" runat="server"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                    
                                </asp:TableCell>
                                <asp:TableCell CssClass="myCell">

                                    <asp:Table ID="CostParkedTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Total Cost based off time
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                $<asp:Label ID="labelGetParkedCost" runat="server"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">

                                    <asp:Table ID="ReservationTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Reservation
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                <asp:Label ID="labelReservationID" runat="server"></asp:Label> <br />
                                                <asp:Label ID="labelReservationSpot" runat="server"></asp:Label><br />
                                                <asp:Label ID="labelReservationTime" runat="server"></asp:Label><br />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                </asp:TableCell>
                                <asp:TableCell CssClass="myCell">
                                    
                                    <asp:Table CssClass="myTable" ID="StallLocationTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Parked Location
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                <asp:Label ID="labelGetParkedStall" runat="server"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                    
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow CssClass="myRow">
                                <asp:TableCell CssClass="myCell">
                                    
                                    <asp:Table CssClass="myTable" ID="AvaiableSpotTable" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Avaiable Spots
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                <asp:Label ID="labelGetAvaiableSpots" runat="server"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                </asp:TableCell>
                                <asp:TableCell CssClass="myCell">
                                    
                                    <asp:Table ID="WeatherTabel" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                Weather
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="myRow">
                                            <asp:TableCell CssClass="myCell">
                                                <asp:Label ID="labelGetWeather" runat="server"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>

                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>


                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            
        </div>
       <asp:Label ID="AccountInfo" runat="server"></asp:Label>
    </form>
</body>
</html>


