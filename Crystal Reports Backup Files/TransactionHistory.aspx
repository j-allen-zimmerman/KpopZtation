<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:2% 10%">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Transaction Id</th>
                    <th scope="col">Transaction Date</th>
                    <th scope="col">Customer Name</th>
                    <th scope="col">Courier</th>
                    <th scope="col"></th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="TableRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            
                            <td scope="row"><%# Eval("TransactionId") %></td>
                            <td scope="row"><%# Eval("TransactionDate") %></td>
                            <td scope="row"><%# Eval("CustomerName") %></td>
                            <td scope="row">Bang Danes</td>
                            <td scope="row">
                                <asp:LinkButton ID="OpenDetail" runat="server" class="btn btn-outline-success" CommandArgument='<%#Eval("TransactionId") %>' OnClick="OpenDetail_Click">Open Detail</asp:LinkButton>
                            </td>
             
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
       
    </div>
</asp:Content>
