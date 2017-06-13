using System;
using System.Collections.Generic;
using System.Data;
using DiagnosticManagementSystem.Model;
using Microsoft.Reporting.WebForms;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestWiseReportShow : System.Web.UI.Page
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
            decimal totalAmount =(decimal) Session["TotalAmmount"];
            DateTime d1 =(DateTime) Session["fromDate"];
            DateTime d2= (DateTime)Session["toDate"];
            DataTable dataTable = GetTestList();

            ReportDataSource reportDataSource = new ReportDataSource("testwise", dataTable);
            testWiseReportViewer.LocalReport.DataSources.Add(reportDataSource);

            //Path
            testWiseReportViewer.LocalReport.ReportPath = "RdlcReport/Testwisereport.rdlc";
            //Parameters
            ReportParameter[] reportParameters = new ReportParameter[]
                       {
                new ReportParameter("totalAmount",totalAmount.ToString()),
                new ReportParameter("fromDate",d1.ToString()),
                new ReportParameter("toDate",d2.ToString()),
                       };

            testWiseReportViewer.LocalReport.SetParameters(reportParameters);
            //Refresh
            testWiseReportViewer.LocalReport.Refresh();

        }

        private DataTable GetTestList()
        {
            List<Reports> testReportses = (List<Reports>)Session["Testlist"] ;

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Serial", typeof(int));
            dataTable.Columns.Add("TestName", typeof(string));
            dataTable.Columns.Add("TotalNoTest", typeof(int));
            dataTable.Columns.Add("Amount", typeof(string));



            foreach (Reports report in testReportses)
            {
                DataRow row = dataTable.NewRow();
                row["Serial"] = report.SerialNo;
                row["TestName"] = report.TestName;
                row["TotalNoTest"] = report.NoOfTest;
                row["Amount"] = report.Ammount;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        //--------------Methods-----------
    }
}