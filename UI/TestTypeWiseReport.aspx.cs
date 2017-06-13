using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestTypeWiseReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reportShowButton_Click(object sender, EventArgs e)
        {
            if (toDateTextBox.Text == "" || fromDateTextBox.Text == "")
            {
                Response.Write("<script>alert('" + "Date Field Is Empty" + "')</script>");
            }
            else
            {
                Reports reports = new Reports();



                DateTime d1 = DateTime.Parse(fromDateTextBox.Text);
                DateTime d2 = DateTime.Parse(toDateTextBox.Text);

                List<Reports> testReportses = reports.GetTestTypeWiseReport(d1, d2);

                typeGridView.DataSource = testReportses;
                typeGridView.DataBind();
                decimal toatlAmmount = 0;
                foreach (Reports r in testReportses)
                {
                    toatlAmmount += decimal.Parse(r.Ammount);
                }

                totatlAmmountShowTextBox.Text = toatlAmmount.ToString();
                Session["Testlist"] = testReportses;
                Session["TotalAmmount"] = toatlAmmount;
                Session["fromDate"] = d1;
                Session["toDate"] = d2;
            }

        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestTypewisereportShow.aspx");
        }
    }
}