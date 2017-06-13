<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReport.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 117px;
        }
        .auto-style2 {
            width: 331px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 60%; margin: auto;">
    <fieldset>
        <legend>Test Wise Report</legend>
        <div style="width: 90%; margin: auto;">
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style1">From Date</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="fromDateTextBox" runat="server" Width="189px" Height="28px" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">To Date</td>
                        <td class="auto-style2">
                           <%--<asp:TextBox ID="toDateTextBox" runat="server" Width="189px" Height="28px" placeholder="YYYY-MM-DD"></asp:TextBox>--%>
                           <asp:TextBox ID="toDateTextBox" runat="server" TextMode="Date" Height="28px" Width="189px"></asp:TextBox>
                            <asp:Button ID="showButton" runat="server" Text="Show"  Style=" margin-left:20px;  padding: 5px 15px; margin-top: 15px;" OnClick="showButton_Click"/>
        
                        </td>
                    </tr>
                    </table>
            </div>
            <div>
                <asp:GridView ID="testShowGridView" runat="server" AutoGenerateColumns="False" Style="margin-bottom: 15px; width: 100%;margin-top: 15px;">
                         <Columns >
                       <asp:TemplateField HeaderText="SL" >
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                     
                         <Columns >
                       <asp:TemplateField HeaderText="Test Name" >
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Total Test">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("NoOfTest") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Total Amount">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Ammount") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                 </asp:GridView>
            </div>
            <div>
             <table style="width:100%;">
                    <tr >
                        <td style="text-align: center" class="auto-style3">
                            <asp:Button ID="printButton" runat="server" Text="Print" Width="83px" OnClick="printButton_Click" />

                        </td>
                        <td style="text-align: center">
                            Total
                            <asp:TextBox ID="totatlAmmountShowTextBox" runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </fieldset>
    </div>
    </form>
</body>
</html>
