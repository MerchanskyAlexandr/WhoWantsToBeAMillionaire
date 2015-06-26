<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Millionaire.WebUi.Default" %>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Main
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="content" runat="server">
    
    <div id ="wrapper-login-form">
        
        <div id ="welcome"></div>    
        <asp:TextBox ID="txtUserName" CssClass="txt-user-name" runat="server" AutoPostBack="False"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                    ErrorMessage="Required Field" ControlToValidate="txtUserName"
                    ForeColor="Red" Display="Dynamic" />

                <asp:RegularExpressionValidator ID="revUserName" runat="server"
                    ErrorMessage="Length should not exceed 12"  ControlToValidate="txtUserName"
                    ValidationExpression="^[0-9a-zA-Zа-яА-Яі]{1,12}$"
                    ForeColor="Red" Display="Dynamic" />

        <asp:Button ID="btnStartGame" CssClass="btn-start-game" runat="server" Text="" OnClick="btnStartGame_Click" />

    </div>

</asp:Content>
