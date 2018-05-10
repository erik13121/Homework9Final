<%@ Page Title="Booking Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Homework9Final.Booking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--Clients table-->
    <div class="row">
        <div class="col-xs-2 col-sm-3 col-md-4 col-lg-6 form-group">
            <br />
            <asp:GridView ID="dgvClients" runat="server" Width="600px"></asp:GridView>
            <br />
            <asp:Label ID="lblClient" runat="server" Text="Client ID:"></asp:Label>
            <asp:DropDownList ID="dbxClientIDs" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button CssClass="btn-md" ID="btnStartBooking" runat="server" Text="Start Booking" OnClick="btnCreateBooking_Click" />
            <asp:Button ID="btnCancelBooking" runat="server" Text="Cancel Booking" Enabled="false" OnClick="btnCancelBooking_Click"/>
        </div>
    </div>

    <!--Vehicles table-->
    <div class="row">
        <div class="col-xs-2 col-sm-3 col-md-4 col-lg-6 form-group">
            <asp:GridView ID="dgvVehicles" runat="server" Width="600px"></asp:GridView>
            <br />
            <asp:Label ID="lblVehicleID" runat="server" Text="Vehicle ID:"></asp:Label>
            <asp:DropDownList ID="dbxVehicleIDs" runat="server" Enabled="false"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
            <asp:Calendar ID="calDate" runat="server" Enabled="false"></asp:Calendar>
            <br />
            <asp:Button CssClass="btn-md" ID="btnPlaceBooking" runat="server" Text="Place Booking" OnClick="btnPlaceBooking_Click" Enabled="false" />
            <br />
            <br />
            <asp:Label ID="lblSearchClientsViaVehicles" runat="server" Text="Search for Clients via Vehicle ID:"></asp:Label>
            <br />
            <asp:DropDownList ID="dbxVehicleIDsforClients" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
            <br />
            <br />
            <asp:Label ID="lblBookings" runat="server" Text="Bookings:"></asp:Label>
            <asp:GridView ID="dgvBookings" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="lblDateforVehicleTypes" runat="server" Text="Date for seeing what Vehicle Types a certain Client booked:"></asp:Label>
            <br />
            <asp:Calendar ID="calDateQueryVehicleType" runat="server"></asp:Calendar>
            <br />
            <asp:Label ID="lblClientIDforQuery" runat="server" Text="Client ID:"></asp:Label>
            <br />
            <asp:DropDownList ID="dbxClientIDforQuery" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnDisplayVehicleTypesofClient" runat="server" Text="Display" OnClick="btnDisplayVehicleTypesofClient_Click" />
            <br />
            <br />
            <asp:GridView ID="dgvVehicleTypesviaClient" runat="server">
            </asp:GridView>
            <br />
        </div>
    </div>


</asp:Content>
