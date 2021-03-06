﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Admin_ViewAuditLog : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(Helper.GetCon());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["position"] != null)
        {
            if (Session["position"].ToString() == "Admin")
            {
                if (!IsPostBack)
                {
                    getAudit();
                    GetEmployees();
                }
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
    
    void getAudit()
    {
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT a.AuditRID, e.EmployeeID, e.LastName, e.FirstName, FORMAT(a.TimeStamp, 'MMM-dd-yyyy HH:mm:ss') as TimeStamp, " +
            "a.Event, a.Description FROM AuditLogs a INNER JOIN Employee e ON a.EmployeeID = e.EmployeeID ORDER BY a.AuditRID DESC";
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataSet ds = new DataSet();
        da.Fill(ds, "Audit");
        lvAudit.DataSource = ds;
        lvAudit.DataBind();
        con.Close();
    }
    void getReportPCov()
    {
        ReportDocument rpt = new ReportDocument();
        rpt.Load(Server.MapPath("~/Reports/AuditLogReport-PCov.rpt"));
        rpt.SetDatabaseLogon("sa", "lazaro009", "DESKTOP-JQC0U4J", "CVFCPayroll");
        rpt.SetParameterValue("startdate", txtStart.Text);
        rpt.SetParameterValue("enddate", txtEnd.Text);
        rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Employee Audit Log Records as of " + DateTime.Now.ToString());
    }
    void getReportEmp()
    {
        ReportDocument rpt = new ReportDocument();
        rpt.Load(Server.MapPath("~/Reports/AuditLogReport-Emp.rpt"));
        rpt.SetDatabaseLogon("sa", "lazaro009", "DESKTOP-JQC0U4J", "CVFCPayroll");
        rpt.SetParameterValue("EmployeeID", ddlEmployees.SelectedValue);
        rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Employee Audit Log Records as of " + DateTime.Now.ToString());
    }
    public void GetEmployees()
    {
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT EmployeeID, (FirstName +' '+ MiddleName +' '+ LastName) AS FullName FROM Employee";
        SqlDataReader dr = com.ExecuteReader();
        ddlEmployees.DataSource = dr;
        ddlEmployees.DataTextField = "FullName";
        ddlEmployees.DataValueField = "EmployeeID";
        ddlEmployees.DataBind();


        con.Close();
    }

    protected void btnGenRep_Click(object sender, EventArgs e)
    {
        getReportPCov();
    }

    protected void btnGenRepEmp_Click(object sender, EventArgs e)
    {
        getReportEmp();
    }
}