<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntry.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestRequestEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 163px;
            padding: 10px 0px;
        }
        .auto-style2 {
            width: 90%;
            margin: auto;
            margin-top: 20px;
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    
       <fieldset>
           <legend>Test Request Entry</legend>
            <div class="auto-style2">
                <table >
            <tr>
                <td class="auto-style1">Name Of The Patient</td>
                <td>
                    <asp:TextBox ID="patientNameTextBox" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Date Of Birth</td>
                <td>
                    <asp:TextBox ID="dateOfBirthTextBox" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Mobile NO</td>
                <td>
                    <asp:TextBox ID="phoneNoTextBox" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style1">Select Test</td>
                <td>
                    <asp:DropDownList ID="selectTestDropDownList"  runat="server" Width="251px" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged">
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    FEE <asp:TextBox ID="testFeeTextBox" runat="server" style="margin-left: 10px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:Button ID="patientAddButton" runat="server" Text="ADD" style="padding: 5px 15px; margin-top: 15px;" OnClick="patientAddButton_Click" />
                </td>
            </tr>
            </table>
                
                <asp:GridView ID="addedTestGridView" runat="server" AutoGenerateColumns="False" Style="width: 100%;margin-top: 15px;">
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

                    
                </asp:GridView>
                
                <div>
                      
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: right;">Total Fee:
                                <asp:TextBox Style="margin-left: 20px" ID="totalbillTextBox" runat="server"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>
                            <td style="text-align: right;"><asp:Button ID="savePatientButton" runat="server" Text="Save" style="float: right; padding: 5px 15px; margin-top: 15px;" OnClick="savePatientButton_Click"  /></td>
                        </tr>
                      
                    </table>
                      
                </div>


            </div>
       </fieldset>
    
    </div>
    </form>
</body>
</html>
