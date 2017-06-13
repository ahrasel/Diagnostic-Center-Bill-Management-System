using System;
using System.Collections.Generic;
using System.Data;
using DiagnosticManagementSystem.Model;
using Microsoft.Reporting.WebForms;

namespace DiagnosticManagementSystem.UI
{
    public partial class UnpaidBillReportShow : System.Web.UI.Page
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
            List<Patient> patients = (List<Patient>)Session["Testlist"];
            decimal totalAmount = (decimal)Session["TotalAmmount"];
            DateTime d1 = (DateTime)Session["fromDate"];
            DateTime d2 = (DateTime)Session["toDate"];
            DataTable dataTable = GetTestList();

            ReportDataSource reportDataSource = new ReportDataSource("unpaidBillreports", dataTable);
            UnpaidBillReportViewer.LocalReport.DataSources.Add(reportDataSource);

            //Path
            UnpaidBillReportViewer.LocalReport.ReportPath = "RdlcReport/UnpaidBillReport.rdlc";
            //Parameters
            ReportParameter[] reportParameters = new ReportParameter[]
                       {
                new ReportParameter("totalAmount",totalAmount.ToString()),
                new ReportParameter("fromDate",d1.ToString()),
                new ReportParameter("toDate",d2.ToString()),
                       };

            UnpaidBillReportViewer.LocalReport.SetParameters(reportParameters);
            //Refresh
            UnpaidBillReportViewer.LocalReport.Refresh();

        }

        private DataTable GetTestList()
        {
            List<Patient> patients = (List<Patient>)Session["Testlist"];

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("SerialNo", typeof(int));
            dataTable.Columns.Add("BillNo", typeof(string));
            dataTable.Columns.Add("ContactNo", typeof(int));
            dataTable.Columns.Add("PatientName", typeof(string));
            dataTable.Columns.Add("BillAmount", typeof(string));



            foreach (Patient p in patients)
            {
                DataRow row = dataTable.NewRow();
                row["SerialNo"] = p.SerialNo;
                row["BillNo"] = p.Billid;
                row["ContactNo"] = p.MobileNo;
                row["PatientName"] = p.Name;
                row["BillAmount"] = p.UnpaidBill;
                dataTable.Rows.Add(row);

            }
            return dataTable;
        }
        //--------------Methods-----------
    }
}