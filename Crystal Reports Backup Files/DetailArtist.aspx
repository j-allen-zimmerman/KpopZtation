<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="DetailArtist.aspx.cs" Inherits="KpopZtation.Views.DetailArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 2% 0% ">
        <asp:Button ID="InsertAlbumBtn" runat="server" Text="Insert Album" class="btn btn-primary" OnClick="InsertAlbumBtn_Click"/>
        <div class="d-flex justify-content-around ">
            <div class="flex-left-gig">
                <h1><asp:Label ID="ArtistNameTxt" runat="server"></asp:Label></h1>
                <asp:Image ID="ArtistImage" runat="server" class="card-img-top title-hover" style="max-width:500px;"/>
                <%--<h5 class="mt-3">Detail : </h5>--%>
                <p><asp:Label ID="DescLbl" runat="server"></asp:Label></p>
                
            </div>
            <div class="flex-right-gig">
                <div class="card mb-3" style="width:24rem">
                    <asp:Repeater ID="CardRepeater" runat="server" OnItemDataBound="CardRepeater_ItemDataBound">
                            <ItemTemplate>
                            <div class="card m-2 card-cloth">
                                <asp:LinkButton ID="OpenAlbumDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("AlbumID") %>' Onclick="OpenAlbumDetail_Click" >
                                    <div>
                                            
                                        <div class="card-body">
                                            <p class="card-text title-hover"><%# Eval("AlbumName") %></p>
                                            <img src="../Assets/Albums/<%# Eval("AlbumImage") %>" class="card-img-top" alt="Gambar ga ketemu bos">
                                        </div>
                                        <div class="card-body">
                                            <div class="list-group list-group-flush">
                                                
                                            <p class="card-text title-hover"><%# Eval("AlbumPrice") %></p>
                                            <p class="card-text title-hover"><%# Eval("AlbumDescription") %></p>
                                        </div>      
                                        </div>
                                            
                                   

                                    </div>
                                </asp:LinkButton>
                                <div class="HomeBtnRepeater">
                                        <asp:LinkButton ID="UpdateLinkBtn" runat="server" OnClick="UpdateLinkBtn_Click" CommandArgument='<%#Eval("AlbumID") %>' Style="cursor: pointer"  class="btn btn-outline-warning mb-3"> Update </asp:LinkButton>
                                        <asp:LinkButton ID="DeleteLinkBtn" runat="server" OnClick="DeleteLinkBtn_Click" CommandArgument='<%#Eval("AlbumID") %>' class="btn btn-outline-danger"  > Delete </asp:LinkButton>
                                </div>

                                     
                            </div>
                            </ItemTemplate>
                     </asp:Repeater>
                    
                </div>
                
            </div>
        </div>
        </div>
</asp:Content>
