using System;
using System.Data;
using DiagnosticManagementSystem.Model;
using Microsoft.Reporting.WebForms;

namespace DiagnosticManagementSystem.UI
{
    public partial class PatientEntryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }
        void ShowReport()
        {
            Patient patient = (Patient)Session["patient"];
            DataTable dataTable = GetTestList();

            ReportDataSource reportDataSource = new ReportDataSource("PatientEntryReport", dataTable);
            patientEntryReportViewer.LocalReport.DataSources.Add(reportDataSource);

            //Path
            patientEntryReportViewer.LocalReport.ReportPath = "RdlcReport/PatientEntryReport.rdlc";
            //Parameters

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("billNo",patient.Billid.ToString()),
                new ReportParameter("patientName",patient.Name),
                new ReportParameter("dateOfBirth",patient.DateOfBirth),
                new ReportParameter("mobileNo",patient.MobileNo),
                new ReportParameter("entryDate",DateTime.Today.ToShortDateString()),
                new ReportParameter("totalFee",patient.TotalBill.ToString()),
            };
           // patientEntryReportViewer.ProcessingMode = ProcessingMode.Local;
            patientEntryReportViewer.LocalReport.SetParameters(reportParameters);
            //Refresh
            patientEntryReportViewer.LocalReport.Refresh();

        }

        private DataTable GetTestList()
        {
            Patient patient = (Patient)Session["patient"];

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("SerialNo", typeof(int));
            dataTable.Columns.Add("Test", typeof(string));
            dataTable.Columns.Add("Fee", typeof(int));

            

            foreach (Test test in patient.Tests)
            {
                DataRow row = dataTable.NewRow();
                row["SerialNo"] = test.SerialNo;
                row["Test"] = test.Name;
                row["Fee"] = test.Fee;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

    }
}