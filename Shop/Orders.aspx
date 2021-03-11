<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Shop.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblOut" runat="server" Visible="false" Text=""></asp:Label>


    <br />
    <asp:GridView ID="grdOrders" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Visible="False" Width="95%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="Ammount" HeaderText="Ammount" SortExpression="Ammount" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Info" HeaderText="Info" SortExpression="Info" />
            <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" SortExpression="TotalPrice" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Orders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Orders] ([ClientID], [ProductID], [Ammount], [Price], [Date], [Info], [TotalPrice]) VALUES (@ClientID, @ProductID, @Ammount, @Price, @Date, @Info, @TotalPrice)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Orders]" UpdateCommand="UPDATE [Orders] SET [ClientID] = @ClientID, [ProductID] = @ProductID, [Ammount] = @Ammount, [Price] = @Price, [Date] = @Date, [Info] = @Info, [TotalPrice] = @TotalPrice WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ClientID" Type="Int32" />
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="Ammount" Type="Int32" />
            <asp:Parameter Name="Price" Type="Int32" />
            <asp:Parameter Name="Date" Type="String" />
            <asp:Parameter Name="Info" Type="String" />
            <asp:Parameter Name="TotalPrice" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ClientID" Type="Int32" />
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="Ammount" Type="Int32" />
            <asp:Parameter Name="Price" Type="Int32" />
            <asp:Parameter Name="Date" Type="String" />
            <asp:Parameter Name="Info" Type="String" />
            <asp:Parameter Name="TotalPrice" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


</asp:Content>
