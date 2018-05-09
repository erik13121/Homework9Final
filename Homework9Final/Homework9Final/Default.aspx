<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework9Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="col-sm-2">
            <p>
                <img class="thumbnail img-responsive" src="https://c.ymcdn.com/sites/dermpa.site-ym.com/resource/resmgr/DiplomateIcon.jpg" />
            </p>
        </div>
        <a class="text-primary">ata</a><a class="text-muted">sync</a>
        <p class="lead">A comprehensive tool for all your data storage and display needs...</p>
    </div>

    <div class="row">
        <!--Register Client-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Register Client</span></h1>
            <label for="inputClientID">ClientID:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputClientID" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <label for="inputName">Name:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputName" runat="server"></asp:TextBox>
            <br />
            <label for="inputEmail">Email:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputEmail" runat="server"></asp:TextBox>
            <br />
            <label for="inputContactNumber">Contact Number:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputContactNumber" runat="server"></asp:TextBox>
            <br />
            <label for="dbxClientTypeName">Client Type:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxClientTypeName" runat="server"></asp:DropDownList>
            <!--Register Client button-->
            <br />
            <!--Update Client button-->
            <asp:Button CssClass="btn-md-5" ID="btnAddClient" runat="server" Text="Register Client" OnClick="btnAddClient_Click" />
            <asp:Button CssClass="btn-md-5" ID="btnUpdateClient" runat="server" Text="Update Client" OnClick="btnUpdateClient_Click" />
            <asp:Button CssClass="btn-md-5" ID="btnDeleteClient" runat="server" Text="Delete Client" OnClick="btnDeleteClient_Click" />
            <br />
            <br />

            <!--Table with all Client Information-->
            <label for="inputClientFuzzySearch">Fuzzy Search:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputClientFuzzySearch" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn-md" ID="btnClientFuzzySearch" runat="server" Text="Search" OnClick="btnClientFuzzySearch_Click" />
            <br />
            <asp:GridView ID="dgvClients" runat="server" Width="600px"></asp:GridView>
            <br />
        </div>

        <!--Select Client-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Select Client</span></h1>
            <label for="dbxClientID">ClientID:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxClientID" runat="server"></asp:DropDownList>
            <asp:Button CssClass="btn-md-5" ID="btnSelectClient" runat="server" Text="Select Client" OnClick="btnSelectClient_Click" />
        </div>
    </div>

    <div class="row">
        <!--Cruds-->
        <!--Client Type Crud-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Client Type</span></h1>
            <label for="inputClientTypeID">Client Type ID:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputClientTypeID" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <label for="inputClientTypeName">Client Type Name:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputClientTypeName" runat="server"></asp:TextBox>
            <br />
            <label for="inputClientTypeDescription">Client Type Description:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputClientTypeDescription" runat="server"></asp:TextBox>
            <br />

            <!--Register Client button-->
            <br />
            <!--Update Client button-->
            <asp:Button CssClass="btn-md" ID="btnAddClientType" runat="server" Text="Add Client Type" OnClick="btnAddClientType_Click" />
            <asp:Button CssClass="btn-md" ID="btnUpdateClientType" runat="server" Text="Update Client Type" OnClick="btnUpdateClientType_Click" />
            <asp:Button CssClass="btn-md" ID="btnDeleteClientType" runat="server" Text="Delete Client Type" OnClick="btnDeleteClientType_Click" />
            <br />

            <!--Table with all Client Type Information-->
            <asp:GridView ID="dgvClientTypes" runat="server" Width="600px"></asp:GridView>
            <br />
        </div>

        <!--Select Client Type-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Select Client Type</span></h1>
            <label for="dbxClientTypeID">Client Type ID:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxClientTypeID" runat="server"></asp:DropDownList>
            <asp:Button CssClass="btn-md-5" ID="btnSelectClientType" runat="server" Text="Select Client Type" OnClick="btnSelectClientType_Click" />
        </div>
    </div>

    <div class="row">
        <!--Register Vehicle-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Register Vehicle</span></h1>
            <label for="inputVehicleID">Vehicle ID:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleID" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <label for="inputVehicleName">Vehicle Name:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleName" runat="server"></asp:TextBox>
            <br />
            <label for="inputVehicleDescription">Vehicle Description:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleDescription" runat="server"></asp:TextBox>
            <br />
            <label for="dbxVehicleTypeName">Vehicle Type:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxVehicleTypeName" runat="server"></asp:DropDownList>
            <!--Register Vehicle button-->
            <br />
            <!--Update Vehicle button-->
            <asp:Button CssClass="btn-md" ID="btnAddVehicle" runat="server" Text="Register Vehicle" OnClick="btnAddVehicle_Click" />
            <asp:Button CssClass="btn-md" ID="btnUpdateVehicle" runat="server" Text="Update Vehicle" OnClick="btnUpdateVehicle_Click" />
            <asp:Button CssClass="btn-md" ID="btnDeleteVehicle" runat="server" Text="Delete Vehicle" OnClick="btnDeleteVehicle_Click" />
            <br />
            <br />

            <!--Table with all Vehicle Information-->
            <label for="inputVehicleFuzzySearch">Fuzzy Search:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleFuzzySearch" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn-md" ID="btnVehicleFuzzySearch" runat="server" Text="Search" OnClick="btnVehicleFuzzySearch_Click" />
            <br />
            <asp:GridView ID="dgvVehicles" runat="server" Width="600px"></asp:GridView>
            <br />
        </div>

        <!--Select Vehicle-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Select Vehicle</span></h1>
            <label for="dbxVehicleID">Vehicle ID:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxVehicleID" runat="server"></asp:DropDownList>
            <asp:Button CssClass="btn-md-5" ID="btnSelectVehicle" runat="server" Text="Select Vehicle" OnClick="btnSelectVehicle_Click" />
        </div>
    </div>

    <div class="row">
        <!--Cruds-->
        <!--Vehicle Type Crud-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Vehicle Type</span></h1>
            <label for="inputVehicleTypeID">Vehicle Type ID:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleTypeID" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <label for="inputVehicleTypeName">Vehicle Type Name:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleTypeName" runat="server"></asp:TextBox>
            <br />
            <label for="inputVehicleTypeDescription">Vehicle Type Description:</label><br />
            <asp:TextBox CssClass="input-lg" ID="inputVehicleTypeDescription" runat="server"></asp:TextBox>
            <br />

            <!--Register Vehicle Type button-->
            <br />
            <!--Update Vehicle Type button-->
            <asp:Button CssClass="btn-md" ID="btnAddVehicleType" runat="server" Text="Add Vehicle Type" OnClick="btnAddVehicleType_Click" />
            <asp:Button CssClass="btn-md" ID="btnUpdateVehicleType" runat="server" Text="Update Vehicle Type" OnClick="btnUpdateVehicleType_Click" />
            <asp:Button CssClass="btn-md" ID="btnDeleteVehicleType" runat="server" Text="Delete Vehicle Type" OnClick="btnDeleteVehicleType_Click" />
            <br />

            <!--Table with all Vehicle Type Information-->
            <asp:GridView ID="dgvVehicleTypes" runat="server" Width="600px"></asp:GridView>
            <br />
        </div>

        <!--Select Vehicle Type-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Select Vehicle Type</span></h1>
            <label for="dbxVehicleTypeID">Vehicle Type ID:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxVehicleTypeID" runat="server"></asp:DropDownList>
            <asp:Button CssClass="btn-md-5" ID="btnSelectVehicleType" runat="server" Text="Select Vehicle Type" OnClick="btnSelectVehicleType_Click" />
        </div>
    </div>


</asp:Content>
