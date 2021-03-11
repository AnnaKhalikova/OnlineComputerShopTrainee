<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="Shop.Desktop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align:center">
        <b>Sort by:</b>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="Type" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [Type] FROM [Items] WHERE ([Category] = @Category)" OnSelecting="SqlDataSource1_Selecting">
            <SelectParameters>
                <asp:Parameter DefaultValue="Desktop" Name="Category" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </p>
</asp:Content>
