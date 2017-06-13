using DiagnosticManagementSystem.DAL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.BLL
{
    public class PaymentManager
    {
        PaymentGateway paymentGateway = new PaymentGateway();
        public Patient GetPatientByBillId(int billId)
        {
            return paymentGateway.GetPatientByBillId(billId);

            //throw new NotImplementedException();
        }

        public int UpdateBill(decimal amount, Patient patient)
        {

            return paymentGateway.UpdateBill(amount, patient);
            //throw new NotImplementedException();
        }
    }
}