<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetup.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
         <fieldset>
             <legend>Test Setup</legend>
             
             <div class="test-setup">
                 <fieldset  style="width: 90%;
    margin: auto;
    padding: 10px;">
                     <table  style=" width: 90%;
    margin: auto;">
                     <tr>
                         <td>Test Name:</td>
                         <td colspan="1">
                             <asp:TextBox ID="testNameTextBox" runat="server" Width="250px"></asp:TextBox>
                         </td>
                         
                        </tr>
                     <tr>
                         <td>
                             Fee</td>
                         <td><asp:TextBox ID="testFeeTextBox" runat="server" Width="250px"></asp:TextBox>
                         </td>
                         <td>BDT</td>
                        </tr>
                     <tr>
                         <td>Test Type</td>
                         <td colspan="1">
                             <asp:DropDownList ID="testTypeDropDownList" runat="server" Height="16px" Width="250px"></asp:DropDownList>
                         </td>
                         
                        </tr>
                     <tr>
                         <td></td>
                         <td >
                             <asp:Button ID="testSaveButton"  runat="server" Text="Save"  style="padding: 5px 15px; margin-top: 15px;" CssClass="auto-style1" OnClick="testSaveButton_Click" Width="78px"/>
                         </td>
                        
                        </tr>
                 </table>
                 </fieldset>
                 <asp:GridView ID="testNameGridView" runat="server" AutoGenerateColumns="False" Style="width: 100%;margin-top: 15px;">
                         <Columns >
                       <asp:TemplateField HeaderText="SL" >
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("SerialNo") %>'>"></asp:Label>
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

                    <Columns>
                       <asp:TemplateField HeaderText="Type Name">
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("TestType") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                 </asp:GridView>
             </div>

         </fieldset>
    
    </div>
    </form>
</body>
</html>
