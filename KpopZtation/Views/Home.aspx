<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        a{
            text-decoration:none
        }
        .carousel-item {
            transition: transform 0.5s ease;
        }
        .carousel-item-next.carousel-item-start,
        .carousel-item-prev.carousel-item-end {
            transform: translateX(0);
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="../Img/blackpink.jpg" class="d-block w-100" alt="Image 1" />
                <div class="carousel-caption">
                    <h3>BlackPink</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/aespa.png" class="d-block w-100" alt="Image 2" />
                <div class="carousel-caption">
                    <h3>Aespa</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/fifty_fifty.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Fifty Fifty</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/girls_generation.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Girls Generation</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/itzy.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Itzy</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/ive.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Ive</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/le_sserafim.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Le Sserafim</h3>
                </div>
            </div>
            <div class="carousel-item"">
                <img src="../Img/newjeans.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>NewJeans</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/red_velvet.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Red Velvet</h3>
                </div>
            </div>
            <div class="carousel-item">
                <img src="../Img/twice.png" class="d-block w-100" alt="Image 3" />
                <div class="carousel-caption">
                    <h3>Twice</h3>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden"></span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden"></span>
        </button>
    </div>
    <div class="p-5">
        <div class="popular-categories-section mb-5">
            <div>
                <div class="d-flex card-group justify-content-around">
                    <%--@foreach ($categories as $category)
                        <button type="submit" class="btn text-left border p-4" value="{{ $category->id }}"
                            name="category">{{ $category->name }}</button>
                    @endforeach--%>
                </div>
            </div>
        </div>
        <div class="all-gigs-section" style="margin: 0 3%" >
           <asp:Button ID="InsertArtistBtn" runat="server" Text="Insert Artist" Onclick="InsertArtistBtn_Click" class="btn btn-primary"/>
            
           <br />
            <h2 class="mb-4" style="font-size: 36px;">All Products</h2>
            <div class="" style="display: grid; grid-template-columns: repeat(5, minmax(0, 1fr)); gap: 1rem;" id="post-data">
                
                
                <asp:Repeater ID="CardRepeater" runat="server" OnItemDataBound="CardRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="card m-2 card-cloth" style="text-decoration:none">
                            <asp:LinkButton ID="OpenDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("ArtistID") %>' Onclick="OpenDetail_Click" >
                                <div>
                                    <p>
                                        
                                    </p>
                                    <div class="card-body">
                                        <p class="card-text title-hover"><%# Eval("ArtistName") %></p>
                                    </div>
                                    <div class="list-group list-group-flush">
                                        <img src="../Assets/Artists/<%# Eval("ArtistImage") %>" class="card-img-top" alt="Gambar ga ketemu bos">
                                    </div>
                                   

                                </div>
                            </asp:LinkButton>
                            
                            <div class="HomeBtnRepeater">
                                 <asp:LinkButton ID="UpdateLinkBtn" runat="server" OnClick="UpdateLinkBtn_Click" CommandArgument='<%#Eval("ArtistID") %>' Style="cursor: pointer"  class="btn btn-outline-warning mb-3"> Update </asp:LinkButton>
                                 <asp:LinkButton ID="DeleteLinkBtn" runat="server" OnClick="DeleteLinkBtn_Click" CommandArgument='<%#Eval("ArtistID") %>' class="btn btn-outline-danger"  > Delete </asp:LinkButton>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</asp:Content>