<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReportShow.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestWiseReportShow" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <rsweb:ReportViewer style="margin: auto" ID="testWiseReportViewer" runat="server" Width="70%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="RdlcReport\Testwisereport.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
