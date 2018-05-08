<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework9Final._Default" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:EntityDataSource runat="server" ID="EntityDataSource1" ConnectionString="name=Mini_ProjectEntities" DefaultContainerName="Mini_ProjectEntities" EnableFlattening="False" EntitySetName="ClientTypes" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeFilter="ClientType"></asp:EntityDataSource>
    <div class="jumbotron">
        <h1>Mini-Project Interface</h1>
        <p class="lead">Hi.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &rArr;</a></p>
    </div>

    <!--Register client function-->
   <div class="form-group">
    <label for="inputdefault">Register Client</label>
    <input class="form-control" id="inputdefault" type="text">
     

    <p><a href="" class="btn btn-primary btn-md">Add Client &rArr;</a></p>
    </div>
    <!--Register client function-->
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-4">
            <h2>1</h2>
            <p>
                 I can see clearly now
            </p>
            <p>
                <a class="btn btn-default" href="http://tinytuba.com">Learn more &rArr;</a>
            </p>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-4">
            <h2>2</h2>
            <p>
                Wait theres no crud
            </p>
            <p>  
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &rArr;</a>
            </p>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4">
            <h2>3</h2>
            <p>
               RUAN GET A CRUD
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &rArr;</a>
            </p>
        </div>
    </div>

</asp:Content>
