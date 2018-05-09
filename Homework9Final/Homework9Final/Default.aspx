<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework9Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
            <asp:Button class="btn-md" ID="btnAddClient" runat="server" Text="Register Client" OnClick="btnAddClient_Click" />
            <asp:Button class="btn-md" ID="btnUpdateClient" runat="server" Text="Update Client" OnClick="btnUpdateClient_Click" />
            <asp:Button class="btn-md" ID="btnDeleteClient" runat="server" Text="Delete Client" OnClick="btnDeleteClient_Click" />
            <br />
            <br />

            <!--Table with all Client Information-->
            <asp:GridView ID="dgvClients" runat="server" Width="600px"></asp:GridView>
            <br />
        </div>

        <!--Select Client-->
        <div class="col-sm-3 col-md-4 col-lg-6 form-group">
            <h1><span class="label label-default">Select Client</span></h1>
            <label for="dbxClientID">ClientID:</label><br />
            <asp:DropDownList CssClass="input-lg" ID="dbxClientID" runat="server"></asp:DropDownList>
            <asp:Button ID="btnSelectClient" runat="server" Text="Select Client" OnClick="btnSelectClient_Click" />
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
            <asp:Button class="btn-md" ID="btnAddClientType" runat="server" Text="Add Client Type" OnClick="btnAddClientType_Click" />
            <asp:Button class="btn-md" ID="btnUpdateClientType" runat="server" Text="Update Client" OnClick="btnUpdateClientType_Click" />
            <asp:Button class="btn-md" ID="btnDeleteClientType" runat="server" Text="Delete Client" OnClick="btnDeleteClientType_Click" />
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
            <asp:Button ID="btnSelectClientType" runat="server" Text="Select Client Type" OnClick="btnSelectClientType_Click" />
        </div>
    </div>


</asp:Content>
