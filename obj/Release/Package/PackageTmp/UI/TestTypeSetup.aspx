<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetup.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestTypeSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type SetUp</title>
    <link href="../CSS/Style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <fieldset>
        <legend>Test Type Setup</legend>
       
            <div style="width: 100%; margin: auto;">
            <fieldset style="width: 95%; margin: auto;">
                <div style="width: 320px; margin: auto;padding: 10px 0px">
                    <asp:Label  runat="server" Text="Type Name:"></asp:Label>
                <asp:TextBox Style="margin-left: 20px;" ID="testTypeNameTextBox" runat="server" Width="206px"></asp:TextBox>
                <asp:Button style="float: right;    padding: 5px 15px; margin-right: 7px; margin-top: 15px;" ID="testTypeSaveButton" runat="server" Text="Save" OnClick="testTypeSaveButton_Click" />
                </div>
            </fieldset>
               <div  style="width: 95%; margin: auto;">
                    <asp:GridView  Style="width: 100%; margin-top: 15px; width: 95%;" ID="testTypeShowGridView"  runat="server" AutoGenerateColumns="False">
                    <Columns>
                       <asp:TemplateField HeaderText="SL" >
                           <ItemTemplate>
                               <asp:Label ID="gridviewSerialNoShowLabel" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>

                    <Columns>
                       <asp:TemplateField HeaderText="Type Name">
                           <ItemTemplate>
                               <asp:Label ID="gridviewTypeNameNoShowLabel" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               </div> 
               

            
        </div>

    </fieldset>
    </div>
    </form>
</body>
</html>
