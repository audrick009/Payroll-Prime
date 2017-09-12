using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class getLeaveApplication : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetCon());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (Session["position"].ToString() == "Department Head")
            {
                GetLeaveApplication();
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


    void GetLeaveApplication()
    {
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT l.LeaveRID, e.Firstname + ' ' + e.Lastname as Fullname, l.Status, l.LeaveType, l.Days, l.StartingDate, l.EndingDate FROM LeaveRecords l INNER JOIN Employee e ON l.EmployeeID = e.EmployeeID WHERE l.Status = 'Pending'";
        SqlDataReader dr = com.ExecuteReader();
        lvLeaveApp.DataSource = dr;
        lvLeaveApp.DataBind();
        con.Close();
        

    }
}