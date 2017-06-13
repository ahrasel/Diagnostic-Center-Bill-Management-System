using System;
using System.Collections.Generic;
using System.Data;
using DiagnosticManagementSystem.Model;
using Microsoft.Reporting.WebForms;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestTypewisereportShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }


        //--------------Methods-----------
        void ShowReport()
        {
            List<Reports> testReportses = (List<Reports>)Session["Testlist"];
            decimal totalAmount = (decimal)Session["TotalAmmount"];
            DateTime d1 = (DateTime)Session["fromDate"];
            DateTime d2 = (DateTime)Session["toDate"];
            DataTable dataTable = GetTestList();

            ReportDataSource reportDataSource = new ReportDataSource("typewise", dataTable);
            testtypeWiseReportViewer.LocalReport.DataSources.Add(reportDataSource);

            //Path
            testtypeWiseReportViewer.LocalReport.ReportPath = "RdlcReport/Typewisereport.rdlc";
            //Parameters
            ReportParameter[] reportParameters = new ReportParameter[]
                       {
                new ReportParameter("totalAmount",totalAmount.ToString()),
                new ReportParameter("fromDate",d1.ToString()),
                new ReportParameter("toDate",d2.ToString()),
                       };

            testtypeWiseReportViewer.LocalReport.SetParameters(reportParameters);
            //Refresh
            testtypeWiseReportViewer.LocalReport.Refresh();

        }

        private DataTable GetTestList()
        {
            List<Reports> testReportses = (List<Reports>)Session["Testlist"];

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Serial", typeof(int));
            dataTable.Columns.Add("TestTypeName", typeof(string));
            dataTable.Columns.Add("TotalNo", typeof(int));
            dataTable.Columns.Add("Amount", typeof(string));



            foreach (Reports report in testReportses)
            {
                DataRow row = dataTable.NewRow();
                row["Serial"] = report.SerialNo;
                row["TestTypeName"] = report.TestTypeName;
                row["TotalNo"] = report.NoTesTtype;
                row["Amount"] = report.Ammount;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        //--------------Methods-----------
    }
}