﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PayOfficer.master" AutoEventWireup="true" CodeFile="ViewContRecords.aspx.cs" Inherits="HumanResource_EmpContRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Contribution Records
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <form runat="server" class="form-horizontal">
        <div class="col-lg-12">
            <div class="form-group">
                <table class="table table-hover">
                    <thead>
                        <th>Contribution Type</th>
                        <th>Contribution Rate</th>
                        <th>Date Started</th>
                        <th>No. of Times</th>
                        <th>Total Contribution</th>
                    </thead>
                    <tbody>
                        <asp:ListView ID="lvContRec" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("ContributionType") %></td>
                                <td> <%# Eval("ContributionRate") %></td>
                                <td> <%# Eval("NoOfCont") %></td>
                                <td> <%# Eval("TotalContribution") %> </td>
                                <td> <%# Eval("DateStarted", "{0: MMM/dd/yyyy }") %></td>
                            </tr>
                        </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</asp:Content>

