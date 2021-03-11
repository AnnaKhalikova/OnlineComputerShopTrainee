<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shop.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Please fill next fields to create a new account.
    </p>
    <table>
        <tr>
            <td style="width: 164px">Name:</td>
            <td style="width: 532px">
                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px">Password:</td>
            <td style="width: 532px">
                <asp:TextBox ID="txtPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px; height: 29px;">Confirm password:</td>
            <td style="width: 532px; height: 29px;">
                <asp:TextBox ID="txtConfPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfPass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px">Credit Card number:</td>
            <td style="width: 532px">
                <asp:TextBox ID="txtCreditCard" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valCredit" runat="server" ControlToValidate="txtCreditCard" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px">Email:</td>
            <td style="width: 532px">
                <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 164px">Info:</td>
            <td style="width: 532px">
                <asp:TextBox ID="txtInfo" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
    <asp:Button ID="cmdRegister" runat="server" Text="Register" OnClick="cmdRegister_Click" />

    <asp:CompareValidator ID="valComparePass" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConfPass" ErrorMessage="Passwords must be equal" ForeColor="Red"></asp:CompareValidator>

</asp:Content>
