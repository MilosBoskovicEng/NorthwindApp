<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="WebPresentation.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LabelContactName" runat="server" Text="Username:"></asp:Label><br>
    <asp:TextBox ID="TextBoxContactName" runat="server"></asp:TextBox><br><br>
    <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label><br />
    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox><br><br>
    <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
</asp:Content>
