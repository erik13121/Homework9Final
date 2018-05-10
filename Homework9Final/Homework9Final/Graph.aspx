<%@ Page Title="Graph Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="Homework9Final.fonts.Graph" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/Highcharts-4.0.1/js/highcharts.js"></script>
    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
</asp:Content>
