<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypewisereportShow.aspx.cs" Inherits="DiagnosticManagementSystem.UI.TestTypewisereportShow" %>
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
        <rsweb:ReportViewer style="margin: auto" ID="testtypeWiseReportViewer" runat="server" Width="70%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="RdlcReport\Typewisereport.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
