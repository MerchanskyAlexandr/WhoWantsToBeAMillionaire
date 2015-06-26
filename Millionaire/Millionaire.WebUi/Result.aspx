<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Millionaire.WebUi.Result" %>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Result
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="lblResult" CssClass="lblResult" runat="server" Text="Label"></asp:Label>
</asp:Content>

