<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="Millionaire.WebUi.Game" %>

<%@ Register Src="~/tableCash.ascx" TagPrefix="uc1" TagName="tableCash" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Game
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="content" runat="server">
    <div id="wrapper-of-game">
        <div id="wrapper-of-tooltips">

            <asp:Button ID="btnHall" CssClass="tooltips-buttons btnHall" runat="server" Text="" OnClick="btnHall_Click"/>
            <asp:Button ID="btnCall" CssClass="tooltips-buttons btnCall" runat="server" Text="" OnClick="btnCall_Click"/>
            <asp:Button ID="btnFifty" CssClass="tooltips-buttons btnFifty" runat="server" Text="" OnClick="btnFifty_Click"/>
            <asp:Button ID="btnMoney" CssClass="tooltips-buttons btnMoney" runat="server" Text="" OnClick="btnMoney_Click"/>

            
        </div>

        <div id ="wrapper-of-cash">
            <uc1:tableCash runat="server" ID="TableCash" />
        </div>
        
        <div id="wrapper-of-quest-answr">
            
            <asp:Label ID="lblQuestions" CssClass="lblQuestions" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnA" CssClass="answer-buttons btnA" runat="server" Text="" OnClick="btnA_Click"/>
            <asp:Button ID="btnB" CssClass="answer-buttons btnB" runat="server" Text="" OnClick="btnB_Click"/>
            <asp:Button ID="btnC" CssClass="answer-buttons btnC" runat="server" Text="" OnClick="btnC_Click"/>
            <asp:Button ID="btnD" CssClass="answer-buttons btnD" runat="server" Text="" OnClick="btnD_Click"/>        
            

        </div>
    </div>
</asp:Content>
