<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework9Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:EntityDataSource runat="server" ID="EntityDataSource1" ConnectionString="name=Mini_ProjectEntities" DefaultContainerName="Mini_ProjectEntities" EnableFlattening="False" EntitySetName="ClientTypes" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeFilter="ClientType"></asp:EntityDataSource>
    <div class="jumbotron">
        <h1>Mini-Project Interface</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <!--I can see now-->
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="EntityDataSource1" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="ClientTypeID">
                <Columns>
                    <asp:BoundField DataField="ClientTypeID" HeaderText="ClientTypeID" ReadOnly="True" SortExpression="ClientTypeID"></asp:BoundField>

                    <asp:BoundField DataField="ClientTypeName" HeaderText="ClientTypeName" SortExpression="ClientTypeName"></asp:BoundField>
                    <asp:BoundField DataField="ClientTypeDescription" HeaderText="ClientTypeDescription" SortExpression="ClientTypeDescription"></asp:BoundField>
             </Columns>
            </asp:GridView>
            <p>
                <a class=""
            </p>
        </div>
       <!--I can see now-->
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
