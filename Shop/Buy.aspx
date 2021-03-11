<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="Shop.Buy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblChoose" runat="server" Text=""></asp:Label>
    
    <p style="text-align:center">
        <b>Please fill the address to deliver you purches: </b><asp:TextBox ID="txtAddress" Text=""  Width="300px" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valAddress" runat="server" ForeColor="Red" ErrorMessage="Fill Address" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
    </p>
    <p style="text-align:center">
    <asp:Button ID="cmdBuy" runat="server" Text="Buy" CssClass="css3button" OnClick="cmdBuy_Click" />
    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" CssClass="css3button" OnClick="cmdCancel_Click" CausesValidation="False" />
    </p>
    <asp:Label ID="lblOut" runat="server" ForeColor="Red" Text=""></asp:Label>
    

</asp:Content>
