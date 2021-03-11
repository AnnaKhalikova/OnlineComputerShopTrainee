<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Shop.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page for adding a new product.
        Avaible only for admin  -->
    <asp:Label ID="lblResult" ForeColor="Red" runat="server"></asp:Label>
    <h3>Add new product:
    </h3>

    <table class="addTable">
        <tr>
            <td><b>Product type:</b></td>
            <td>
                <asp:DropDownList ID="drpProductType" runat="server" AutoPostBack="True" Width="310px" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [Category] FROM [Items]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 201px"><b>Name:</b></td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><b>Quantity:</b></td>
            <td><asp:TextBox ID="txtQuant" Width="300px" runat="server" />
            <asp:RequiredFieldValidator ID="valQuant" runat="server" ControlToValidate="txtQuant" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 201px"><b>Image:</b> </td>
            <td>
                <asp:DropDownList ID="drpImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="cmdUploadimage" runat="server" Text="Upload" OnClick="cmdUploadimage_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 201px"><b>Description:</b> </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDes" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>  
         <tr>
            <td style="width: 201px"><b>Price:</b></td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 201px"><b>Type:</b> </td>
            <td>
                <asp:TextBox ID="txtType" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valType" runat="server" ControlToValidate="txtType" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />


    <asp:Button ID="cmdSave" runat="server" Text="Save" OnClick="cmdSave_Click" />
    <br />


</asp:Content>
