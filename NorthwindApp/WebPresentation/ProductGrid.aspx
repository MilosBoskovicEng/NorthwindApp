<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductGrid.aspx.cs" Inherits="WebPresentation.ProductGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="productID" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="productName" HeaderText="Product Name" />
            <asp:BoundField DataField="unitPrice" HeaderText="Price" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='ProductDetails.aspx?id=<%# Eval("productID") %>'>Details...</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
