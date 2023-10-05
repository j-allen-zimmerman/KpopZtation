<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="KpopZtation.Views.Carts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:2% 10%">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Albums</th>
                    <th scope="col">Albums Name</th>
                    <th scope="col">Albums Quantity</th>
                    <th scope="col">Albums Price</th>
                    <th scope="col">Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="TableRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td scope="row">
                                <img src="../Assets/Albums/<%# Eval("AlbumImage") %>" class="card-img-top" alt="Gambar ga ketemu bos" style="max-width:200px;">
                            </td>
                            <td scope="row"><%# Eval("AlbumName") %></td>
                            <td scope="row"><%# Eval("Quantity") %></td>
                            <td scope="row"><%# Eval("AlbumPrice") %></td>
                            <td scope="row">
                                <asp:LinkButton ID="DeleteLinkBtn" runat="server" OnClick="DeleteLinkBtn_Click" CommandArgument='<%#Eval("AlbumId") %>' class="btn btn-outline-danger"  > Delete </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" class="btn btn-success w-100 mt-2" OnClick="CheckoutBtn_Click"/>
    </div>
</asp:Content>
