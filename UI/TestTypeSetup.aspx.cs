using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.BLL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.UI
{
    public partial class TestTypeSetup : System.Web.UI.Page
    {
        TesttypeManager testtypeManager = new TesttypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllTypeName();
        }

        private string name = "Rasel";
        protected void testTypeSaveButton_Click(object sender, EventArgs e)
        {
            if (testTypeNameTextBox.Text!="")
            {
                if (testtypeManager.IsTesttypeExist(testTypeNameTextBox.Text) == false)
                {
                    testtypeManager.SaveTesttype(new TestType(testTypeNameTextBox.Text));
                    Response.Write("<script>alert('" + "Test Type Name Saved Successfully" + "')</script>");
                    testTypeNameTextBox.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('" + "Test Type Name Already Exist" + "')</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('" + "Test Type Name Field is empty" + "')</script>");
            }
            GetAllTypeName();
        }

        protected void GetAllTypeName()
        {
            List<TestType> types = testtypeManager.GetAllTypeName();
            testTypeShowGridView.DataSource = types;
            testTypeShowGridView.DataBind();
        }
    }
}