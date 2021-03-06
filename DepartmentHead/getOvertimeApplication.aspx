﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DepartmentHead.master" AutoEventWireup="true" CodeFile="getOvertimeApplication.aspx.cs" Inherits="DepartmentHead_getOvertimeApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    <i class="fa fa-inbox"></i> View Pending Overtime Application Forms
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
        <div class="col-lg-9">
            <table class="table table-hover">
                <thead>
                    <th>Overtime ID</th>
                    <th>Employee</th>
                    <th>Date</th>
                    <th>Hours</th>
                    <th>Start Time</th>
                    <th>End Time</th>
                    <th>Reason</th>
                    <th>Status</th>
                    <th>Approved By</th>
                </thead>
                <tbody>
                    <asp:ListView ID="lvOvertimeApp" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lbLeaveRID" runat="server"
                                        Text= '<%# Eval("OTRID") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbEmployeeID" runat="server"
                                    Text='<%# Eval("Fullname") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbDate" runat="server"
                                    Text= '<%# Eval("Date") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbHours" runat="server"
                                    Text= '<%# Eval("Hours") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbStart" runat="server"
                                    Text= '<%# Eval("StartTime") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbEnd" runat="server"
                                    Text='<%# Eval("EndTime") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbReason" runat="server"
                                    Text= '<%# Eval("Reason") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbStatus" runat="server"
                                    Text= '<%# Eval("Status") %>' />
                            </td>

                            <td>
                                <asp:Label ID="lbApprove" runat="server"
                                    Text= '<%# Eval("ApprovedBy") %>' />
                            </td>

                            <td>
                                <a href='updateOvertimeForm.aspx?OTRID=<%# Eval("OTRID") %>' onclick='return confirm("Are you sure?")';
                                    <button type="button" class="btn btn-success" title="Approval">
                                        <i class="fa fa-pencil" />
                                    </button>
                            </td>
                        </tr>
                      </ItemTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>
    </form>
</asp:Content>

