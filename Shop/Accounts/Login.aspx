<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shop.Accounts.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Please login or <asp:HyperLink ID="lnkRegister" NavigateUrl="~/Register.aspx" runat="server">register</asp:HyperLink> to make a purchase.
    </p>
    <table style="height: 127px; width: 537px">
        <tr>
            <td>Login:</td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPass" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdLogin" runat="server" Text="Login" OnClick="cmdLogin_Click" />
                <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
