using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class UnpaidBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            if (toDateTextBox.Text == "" || fromDateTextBox.Text == "")
            {
                Response.Write("<script>alert('" + "Date Field Is Empty" + "')</script>");
            }
            else
            {
                Reports report = new Reports();



                DateTime d1 = DateTime.Parse(fromDateTextBox.Text);
                DateTime d2 = DateTime.Parse(toDateTextBox.Text);

                List<Patient> patients = report.GetUnpaidBillReport(d1, d2);

                unpaidbillreportGridView.DataSource = patients;
                unpaidbillreportGridView.DataBind();
                decimal toatlAmmount = 0;
                foreach (Patient patient in patients)
                {
                    toatlAmmount += patient.UnpaidBill;
                }

                totatlAmmountShowTextBox.Text = toatlAmmount.ToString();
                Session["Testlist"] = patients;
                Session["TotalAmmount"] = toatlAmmount;
                Session["fromDate"] = d1;
                Session["toDate"] = d2;
            }

        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnpaidBillReportShow.aspx");
        }
    }
}