<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Shop.Pages.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/Accounts/AccountManage.aspx">Account manage</asp:HyperLink>
    <h1 style="text-align:center">All the products:</h1>
    <asp:Button ID="cmdAddNew" CssClass="css3button" runat="server" Text="Add new product" OnClick="cmdAddNew_Click"/>
    <p>
        <asp:SqlDataSource ID="sqlDesktop" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Items] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Items] ([Category], [Name], [Quantity], [Image], [Description], [PublishDate], [Price], [Type]) VALUES (@Category, @Name, @Quantity, @Image, @Description, @PublishDate, @Price, @Type)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Items] ORDER BY [Category], [Id]" UpdateCommand="UPDATE [Items] SET [Category] = @Category, [Name] = @Name, [Quantity] = @Quantity, [Image] = @Image, [Description] = @Description, [PublishDate] = @PublishDate, [Price] = @Price, [Type] = @Type WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Category" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Image" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="PublishDate" Type="String" />
                <asp:Parameter Name="Price" Type="Int32" />
                <asp:Parameter Name="Type" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Category" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Image" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="PublishDate" Type="String" />
                <asp:Parameter Name="Price" Type="Int32" />
                <asp:Parameter Name="Type" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BorderColor="#0033CC" BorderWidth="0px" CellPadding="4" CellSpacing="4" DataKeyNames="Id" DataSourceID="sqlDesktop" ForeColor="#333333" GridLines="None" Width="98%" Font-Bold="False" Font-Italic="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderStyle="Double" Wrap="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings Position="TopAndBottom" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </p>
    </asp:Content>
