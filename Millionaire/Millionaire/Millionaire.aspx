<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Millionaire.aspx.cs" Inherits="Millionaire.Millionaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Millionaire</title>
    <link href="App_Style/main.css" rel="stylesheet" />
</head>
<body>
    <form id="mainForm" runat="server">
        
        <div id="wrapper-of-tooltips">

            <asp:Button ID="btnHall" CssClass="tooltips-buttons" runat="server" Text="" OnClick="btnHall_Click"/>
            <asp:Button ID="btnCall" CssClass="tooltips-buttons" runat="server" Text="" OnClick="btnCall_Click" />
            <asp:Button ID="btnFifty" CssClass="tooltips-buttons" runat="server" Text="" OnClick="btnFifty_Click" />
            
        </div>

        <div id ="wrapper-of-cash">
            <table id ="tblMoney" runat="server">
                <tr>
                    <td class="million">
                        15. $ 1 MILLION
                    </td>
                </tr>
                <tr>
                    <td>
                        14. $ 500 000
                    </td>
                </tr>
                <tr>
                    <td>
                        13. $ 250 000
                    </td>
                </tr>
                <tr>
                    <td>
                        12. $ 125 000
                    </td>
                </tr>
                <tr>
                    <td>
                        11. $ 64 000
                    </td>
                </tr>
                <tr>
                    <td class="safe-sum">
                        10. $ 32 000
                    </td>
                </tr>
                <tr>
                    <td>
                        9. $ 16 000
                    </td>
                </tr>
                <tr>
                    <td>
                        8. $ 8 000
                    </td>
                </tr>
                <tr>
                    <td>
                        7. $ 4 000
                    </td>
                </tr>
                <tr>
                    <td>
                        6. $ 2 000
                    </td>
                </tr>
                <tr>
                    <td class="safe-sum">
                        5. $ 1 000
                    </td>
                </tr>
                <tr>
                    <td>
                        4. $ 500
                    </td>
                </tr>
                <tr>
                    <td>
                        3. $ 300
                    </td>
                </tr>
                <tr>
                    <td>
                        2. $ 200
                    </td>
                </tr>
                <tr>
                    <td>
                        1. $ 100
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="wrapper-of-quest-answr">
            
            <asp:Label ID="lblQuestions" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnA" CssClass="answer-buttons" runat="server" Text="" OnClick="btnA_Click" />
            <asp:Button ID="btnB" CssClass="answer-buttons" runat="server" Text="" OnClick="btnB_Click" />
            <asp:Button ID="btnC" CssClass="answer-buttons" runat="server" Text="" OnClick="btnC_Click" />
            <asp:Button ID="btnD" CssClass="answer-buttons" runat="server" Text="" OnClick="btnD_Click" />        
            

        </div>
    </form>
</body>
</html>
