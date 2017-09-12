using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DepartmentHead_getOvertimeApplication : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetCon());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (Session["position"].ToString() == "Department Head")
            {
                GetOvertimeApplication();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }



    void GetOvertimeApplication()
    {
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT o.OTRID, e.FirstName + ' ' + e.LastName as Fullname, o.Date, o.Hours, o.StartTime, o.EndTime, o.Reason, o.Status, o.ApprovedBy FROM OvertimeRecords o INNER JOIN Employee e ON o.EmployeeID = e.EmployeeID WHERE o.Status = 'Pending'";
        SqlDataReader dr = com.ExecuteReader();
        lvOvertimeApp.DataSource = dr;
        lvOvertimeApp.DataBind();
        con.Close();
    }
}