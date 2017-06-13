using System;
using DiagnosticManagementSystem.BLL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        PaymentManager paymentManager = new PaymentManager();
        private Patient patient = null;
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (patientIdBillSearchTextBox.Text=="")
            {
                Response.Write("<script>alert('" + "Bill Id Field Is Empty" + "')</script>");
            }
            else
            {
                ShowData();
            }
          

        }

        protected void billPayButton_Click(object sender, EventArgs e)
        {
            patient = new Patient();
            patient = paymentManager.GetPatientByBillId(int.Parse(patientIdBillSearchTextBox.Text));
            if (amountTextBox.Text == "")
            {
                Response.Write("<script>alert('" + "Ammount Is Empty" + "')</script>");
            }
            else
            {
                if (decimal.Parse(amountTextBox.Text) > patient.UnpaidBill)
                {
                    Response.Write("<script>alert('" + "Sorry Amount Is Gratter Then Due Ammount" + "')</script>");
                }
                else
                {
                    int rowAffected = paymentManager.UpdateBill(decimal.Parse(amountTextBox.Text), patient);

                    Response.Write("<script>alert('" + "Bill Update Successfully" + "')</script>");
                }
            }
            ShowData();
        }

        private void ShowData()
        {
            patient = new Patient();
            patient = paymentManager.GetPatientByBillId(int.Parse(patientIdBillSearchTextBox.Text));

            if (patient == null)
            {
                Response.Write("<script>alert('" + "No Patient Found With This BillId" + "')</script>");
            }
            else
            {
                testListGridView.DataSource = patient.Tests;
                testListGridView.DataBind();

                billDateShowLabel.Text = patient.Patiententrydate;
                totalFeeShowLabel.Text = patient.TotalBill.ToString();
                paidAmountShowLabel.Text = patient.PaidBill.ToString();
                dueAmountShowLabel.Text = patient.UnpaidBill.ToString();

            }
        }
    }
}