using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.BLL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestRequestEntry : System.Web.UI.Page
    {
        PatientManager patientManager= new PatientManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestName();
                testFeeTextBox.Text="";
            }  
        }
        
        private List<Test> selecteTests = null;
        private decimal totalTestBill = 0;
        
        protected void patientAddButton_Click(object sender, EventArgs e)
        {
            Test _test = null;
        //ADD Paitnet Test To GridView
        string value = selectTestDropDownList.SelectedItem.Value;

            if (selectTestDropDownList.SelectedItem.Text== "Select Test")
            {
                Response.Write("<script>alert('" + "Select Test Frist" + "')</script>");
            }
            else
            {
                
                _test = new Test();
                _test = patientManager.GetTestById(value);
                // selecteTests= ViewState["selecteTests"];
                if (ViewState["selecteTests"] == null)
                {
                    selecteTests = new List<Test>();
                    _test.SerialNo = 1;
                    selecteTests.Add(_test);
                    totalTestBill = _test.Fee;
                    ViewState["bill"] = totalTestBill;
                    ViewState["selecteTests"] = selecteTests;

                }
                else
                {
                    totalTestBill = (decimal)ViewState["bill"];
                    selecteTests = (List<Test>)ViewState["selecteTests"];
                    if (selecteTests.Exists(x => x.Id == int.Parse(selectTestDropDownList.SelectedItem.Value)))
                    {
                        Response.Write("<script>alert('" + "Test Already Added To List" + "')</script>");
                    }

                    else
                    {
                        totalTestBill += _test.Fee;
                        _test.SerialNo = selecteTests.Count + 1;
                        selecteTests.Add(_test);
                        ViewState["selecteTests"] = selecteTests;
                    }
                   // totalbillTextBox.Text = totalTestBill.ToString();
                    
                }
               totalbillTextBox.Text = totalTestBill.ToString();
               ViewState["bill"] = totalTestBill;

                //selecteTests.Add(test);
                selecteTests = (List<Test>)ViewState["selecteTests"];
                addedTestGridView.DataSource = selecteTests;
                addedTestGridView.DataBind();
            }


        }

        //Patient Save Button Start
        protected void savePatientButton_Click(object sender, EventArgs e)
        {
            decimal billId = patientManager.SetPatientBillId();
            selecteTests = (List<Test>)ViewState["selecteTests"];
            totalTestBill = (decimal)ViewState["bill"];
            if (patientNameTextBox.Text == "" || dateOfBirthTextBox.Text == "" || phoneNoTextBox.Text == "" || selectTestDropDownList.SelectedIndex == 0)
            {
                Response.Write("<script>alert('" + "Patient Information Field Empty" + "')</script>");
            }
            else
            {
                Patient patient = new Patient(billId, patientNameTextBox.Text, dateOfBirthTextBox.Text,
                    phoneNoTextBox.Text, selecteTests, totalTestBill, DateTime.Today.ToShortDateString());

                int rowAffected = patientManager.SavePataient(patient);
                
                if (rowAffected>0)
                {
                    Response.Write("<script>alert('" + "Patient Information Saved Succesfully" + "')</script>");

                    Session["patient"] = patient;

                    Response.Redirect("PatientEntryReport.aspx");


                }
                else
                {
                    Response.Write("<script>alert('" + "Patient Information Saved Failed!!" + "')</script>");
                }

            }
        }
        //test select change index
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (selectTestDropDownList.SelectedItem.Text == "Select Test")
            {
                testFeeTextBox.Text = "";
            }

            else
            {
                string value = selectTestDropDownList.SelectedItem.Value;
                Test test = new Test();
                test = patientManager.GetTestById(value);
                testFeeTextBox.Text = test.Fee.ToString();
            }

        }
        //load test into dropdownlist
        void LoadTestName()
        {
            TestManager testManager = new TestManager();

            List<Test> testList= testManager.GetAllTestName();
            selectTestDropDownList.DataSource = testList;
            selectTestDropDownList.DataTextField = "Name";
            selectTestDropDownList.DataValueField = "Id";
            selectTestDropDownList.DataBind();
            selectTestDropDownList.Items.Insert(0, "Select Test");
        }

        
    }
}