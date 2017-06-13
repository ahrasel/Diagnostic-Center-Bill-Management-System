<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBill.aspx.cs" Inherits="DiagnosticManagementSystem.UI.UnpaidBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 467px;
        }
        .auto-style2 {
            width: 455px;
        }
        .auto-style3 {
            width: 272px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 60%; margin: auto;">
    <fieldset>
        <legend>Unpaid Bill Report</legend>
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
                            <asp:TextBox ID="toDateTextBox" runat="server" Width="189px" Height="28px" TextMode="Date"></asp:TextBox>
                            <asp:Button ID="showButton" runat="server" Text="Show"  Style=" margin-left:20px;  padding: 5px 15px; margin-top: 15px;" OnClick="showButton_Click"/>
                            
                        </td>
                    </tr>
                    </table>
            </div>
            <div>
                <asp:GridView ID="unpaidbillreportGridView" runat="server" AutoGenerateColumns="False" Style="margin-bottom: 15px; width: 100%;margin-top: 15px;">
                         <Columns >
                       <asp:TemplateField HeaderText="SL" >
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("SerialNo") %>'>"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                     
                         <Columns >
                       <asp:TemplateField HeaderText="Bill Number" >
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Billid") %>'>"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Contact No">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("MobileNo") %>'>"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Patient Name">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'>"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                    
                    <Columns>
                       <asp:TemplateField HeaderText="Bill Amount">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("UnpaidBill") %>'>"></asp:Label>
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
