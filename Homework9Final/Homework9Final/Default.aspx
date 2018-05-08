<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework9Final._Default" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--Heading-->

    <asp:EntityDataSource runat="server" ID="EntityDataSource1" ConnectionString="name=Mini_ProjectEntities" DefaultContainerName="Mini_ProjectEntities" EnableFlattening="False" EntitySetName="ClientTypes" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeFilter="ClientType"></asp:EntityDataSource>
    <div class="jumbotron">
        <h1>
                <div class="col-sm-2">
                <p><img class="thumbnail img-responsive" src="https://c.ymcdn.com/sites/dermpa.site-ym.com/resource/resmgr/DiplomateIcon.jpg" /></p>
                </div>
                <a class="text-primary">ata</a><a class="text-muted">sync</a></h1>       
                <p class="lead">A comprehensive tool for all your data storage and display needs...</p>
    </div>
    <!--Heading-->
    <!--Navigation bar-->
             <nav class="navbar navbar-default">
             <div class="container-fluid">
         <div class="navbar-header">
             <a class="navbar-brand" href="#">Navigation</a>
        </div>
             <ul class="nav navbar-nav">
                <li><a href="#">Home</a></li>
                 <li><a href="CRUD.aspx.cs">CRUD</a></li>
                    <li><a href="#">Client</a></li>
                 <li><a href="#">Graph</a></li>
             </ul>
        </div>
    </nav>
    <!--Navigation bar-->
    <!--Register client function-->
        <h3> <label for="inputdefault">Register Client:</label></h3>
        <div class="form-group">
            <label for="inputlg">Name:</label>
            <input class="form-control input-md" id="inputlg" type="text">
        </div>

        <div class="form-group">
            <label for="inputlg">Surname:</label>
            <input class="form-control input-md" id="inputlg" type="text">
        </div>
        <div class="form-group">
            <label for="inputlg">Title Descritpion:</label>
            <input class="form-control input-md" id="inputlg" type="text">
            <p><a href="" class="btn btn-primary btn-md">Add Client</a></p>
        </div>
    <!--Register client function-->
    <!--Fuzzy search bar-->
        <label for="inputdefault">Fuzzy Search:</label>
        <p><input class="form-control" id="inputdefault" type="text" placeholder="Search.."></p>
        <p><a href="" class="btn btn-primary btn-md">Search</a></p>

    <!--Order by ascending function button-->
        <p><a href="" class="btn btn-primary btn-md">Order By Ascending</a></p>
        <p></p>
    <!--Order by ascending function button-->
    </div>

    <!--drop down where you add two tables-->

                <p></p>
    <!--drop down where you add two tables-->

    </div>

</asp:Content>
