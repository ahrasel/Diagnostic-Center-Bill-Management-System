<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagnosticManagementSystem.UI.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 62px;
        }
        .auto-style2 {
            width: 174px;
            text-align: right;
        }
        .auto-style3 {
            width: 218px;
            text-align: center;
        }
        .auto-style4 {
            width: 95%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <fieldset>
            <legend>PayBill</legend>
            
            <div style="width: 70%; margin: auto;">
                <table>
                    <tr>
                        <td class="auto-style1">Bill No</td>
                        <td>
                            <asp:TextBox ID="patientIdBillSearchTextBox" runat="server" Width="172px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="searchButton" runat="server" Text="Search" Width="80px" OnClick="searchButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            
            <div style="width: 95%; margin: auto;">
                <fieldset>
                    <div style="margin: auto;" class="auto-style4">
                        <div>
                    <asp:GridView ID="testListGridView" runat="server" AutoGenerateColumns="False" Style="width: 100%;margin-top: 15px; margin-bottom: 15px;">
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
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Fee">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    
                </asp:GridView>
                </div>
                        <div>
                            
                            <table style="width:100%;">
                                <tr>
                                    <td class="auto-style2">Bill Date</td>
                                    <td class="auto-style3">
                                        <asp:Label ID="billDateShowLabel" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Total Fee</td>
                                    <td class="auto-style3">
                                        <asp:Label ID="totalFeeShowLabel" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Paid Amount</td>
                                    <td class="auto-style3">
                                        <asp:Label ID="paidAmountShowLabel" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Due Amount</td>
                                    <td class="auto-style3">
                                        <asp:Label ID="dueAmountShowLabel" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Amount</td>
                                    <td class="auto-style3">
                                        <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align: center">
                                        <asp:Button ID="billPayButton" runat="server" Text="Pay" Style="margin-left: 37px; padding: 5px 15px; margin-top: 15px;" OnClick="billPayButton_Click"/></td>
                                </tr>
                                </table>
                            
                        </div>
                    </div>
                </fieldset>
            </div>

        </fieldset>
    
    </div>
    </form>
</body>
</html>
