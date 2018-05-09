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
            <!--CRUD for Client-->
        <h3> <label for="inputdefault">CRUD:</label></h3>
        <table class="table table-hover">
    <thead>
        <tr>
            <th>Row</th>
            <th>First Name</th>
            <th>Last Name</th>            
            <th>TitleID</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>2</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>3</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>4</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
         </tr>
         </tbody>
    </table>
    <!--CRUD for Client-->
    <!--CRUD for Vehicles-->
                <h3> <label for="inputdefault">CRUD:</label></h3>
        <table class="table table-hover">
    <thead>
        <tr>
            <th>Vehicle Name</th>
            <th>Vehicle Description</th>
            <th>VehicleID</th>            
            <th>CRUD</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>2</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>3</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
        </tr>
        <tr>
            <td>4</td>
            <td></td>
            <td></td>
            <td><button type="button" class="btn btn-primary">Create</button><button type="button" class="btn btn-primary">Read</button><button type="button" class="btn btn-primary">Update</button><button type="button" class="btn btn-primary">Delete</button></td>
         </tr>
         </tbody>
    </table>
    <!--CRUD for Vehicles-->
    <!--Fuzzy search bar-->
        <label for="inputdefault">Fuzzy Search:</label>
        <p><input class="form-control" id="inputdefault" type="text" placeholder="Search.."></p>
        <p><a href="" class="btn btn-primary btn-md">Search</a></p>

    <!--Order by ascending function button-->
        <p><a href="" class="btn btn-primary btn-md">Order By Ascending</a></p>
        <p></p>
    <!--Order by ascending function button-->

    </div>
    <!--Graph-->
    <canvas id="myChart" style="max-width: 500px;"></canvas>

    <!--Graph-->
    <!--drop down where you add two tables???-->

                <p></p>
    <!--drop down where you add two tables????-->

    </div>

</asp:Content>
