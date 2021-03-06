<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notebook.aspx.cs" Inherits="Shop.Pages.Notebook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align:center">
        Sort by:
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="Type">
        </asp:DropDownList>
    </p>
    
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [Type] FROM [Items] WHERE ([Category] = @Category)">
            <SelectParameters>
                <asp:Parameter DefaultValue="Notebook" Name="Category" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </p>
</asp:Content>
