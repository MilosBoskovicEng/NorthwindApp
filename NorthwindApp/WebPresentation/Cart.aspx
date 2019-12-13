<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebPresentation.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Table ID="TableCart" runat="server" CellPadding="2" CellSpacing="2" CssClass="aa"></asp:Table><br><br>
    <asp:Button ID="ButtonOrder" runat="server" Text="Order" OnClick="ButtonOrder_Click" />
    <link rel="stylesheet" href="style.css" />
</asp:Content>
