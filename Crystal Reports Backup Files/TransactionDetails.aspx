<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="KpopZtation.Views.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:2% 10%">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Transaction Id</th>
                    <th scope="col">Album</th>
                    <th scope="col">Album Name</th>
                    <th scope="col">Album Quantity</th>
                    <th scope="col">Album Price</th>
                   
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="TableRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            
                            <td scope="row"><%# Eval("TransactionId") %></td>
                            <td scope="row">
                                <img src="../Assets/Albums/<%# Eval("AlbumImage") %>" class="card-img-top" alt="Gambar ga ketemu bos" style="max-width:200px;">
                            </td>
                            <td scope="row"><%# Eval("AlbumName") %></td>
                            <td scope="row"><%# Eval("AlbumQuantity") %></td>
                            <td scope="row"><%# Eval("AlbumPrice") %></td>   
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
