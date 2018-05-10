<%@ Page Title="Graph Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="Homework9Final.fonts.Graph" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/Chart.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        #chart_container{
            width:400px;
            height:400px;
            border:1px solid #000;
            padding:1px;
            border-radius:4px;
        }
    </style>
    <div class="row">
        <div id="chart_container">
            <canvas id="chart">

            </canvas>
        </div>
    </div>
</asp:Content>
