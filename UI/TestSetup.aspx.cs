using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.BLL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestSetup : System.Web.UI.Page
    {
        TestManager testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllTestName();
            if (!IsPostBack)
            {
                LoadTesttypeList();
            }
            
        }

       

        protected void testSaveButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text=="" || testFeeTextBox.Text=="")
            {
                Response.Write("<script>alert('" + "Name Or Fee Filed Is Empty" + "')</script>");
            }
            else if(testTypeDropDownList.SelectedIndex==-1)
            {
                Response.Write("<script>alert('" + "You Must Select Test Type" + "')</script>");
            }
            else
            {
                int rowAffected = testManager.SaveTest(new Test(testNameTextBox.Text,decimal.Parse(testFeeTextBox.Text),testTypeDropDownList.SelectedValue));
                try
                {
                    if (testManager.IsTetsExist(testNameTextBox.Text,testTypeDropDownList.SelectedValue))
                    {
                        if (rowAffected > 0)
                        {
                            Response.Write("<script>alert('" + "Test Name Saved Successfully" + "')</script>");
                            testNameTextBox.Text = "";
                            testFeeTextBox.Text = "";
                        }
                        else
                        {
                            Response.Write("<script>alert('" + "Semiler Test Already Exist On Your System!!" + "')</script>");
                        }
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message + "')</script>");
                }
            }
            GetAllTestName();

         }
        private void LoadTesttypeList()
        {
            TesttypeManager manager = new TesttypeManager();
            List<TestType> list= new List<TestType>();
            list = manager.GetAllTypeName();
            testTypeDropDownList.DataSource = list;
            testTypeDropDownList.DataTextField = "Name";
            testTypeDropDownList.DataBind();
        }

        void GetAllTestName()
        {
            List<Test> testNameList = testManager.GetAllTestName();
            //testNameList = testManager.GetAllTestName();
            testNameGridView.DataSource = testNameList;
            testNameGridView.DataBind();

        }
    }
}