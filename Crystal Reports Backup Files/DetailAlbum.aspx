<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="DetailAlbum.aspx.cs" Inherits="KpopZtation.Views.DetailAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div style="margin: 2% 0% ">
        
        <div class="d-flex justify-content-around ">

            <div class="flex-left-gig">
                <h1><asp:Label ID="AlbumNameLbl" runat="server"></asp:Label></h1>
                <asp:Image ID="AlbumImage" runat="server" class="card-img-top title-hover" style="max-width:500px;"/>
                
                <p><asp:Label ID="DescLbl" runat="server"></asp:Label></p>
            </div>

            <div class="flex-right-gig">
                <div class="card mb-3" style="width:24rem">
                    <div class="card-body">
                        <div class="d-flex justify-content-between font-weight-bold">
                            <div class="Quantity">
                                <asp:Label ID="QuantityLbl" runat="server" Text="Quantity"></asp:Label>
                                <asp:Button ID="MinusBtn" runat="server" Text="-" OnClientClick="decreaseQuantity(); return false;" />
                                <asp:TextBox ID="QuantityTxt" runat="server" style="max-width: 60px" Text="0"></asp:TextBox>
                                <asp:Button ID="PlusBtn" runat="server" Text="+" OnClientClick="increaseQuantity(); return false;" />
                            </div>
                            
                            <asp:Button ID="AddToCartBtn" runat="server" Text="Add to cart" class="btn btn-outline-success" OnClick="AddToCartBtn_Click"/>
                            
                        </div>
                    </div>
                </div>

                <div class="card-body">
                    <div class="list-group list-group-flush">  
                        <asp:Label ID="ErrorTxt" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <p class="card-text title-hover"><asp:Label ID="AlbumDescLbl" runat="server"></asp:Label></p>
                        <p class="card-text title-hover"><asp:Label ID="AlbumPriceLbl" runat="server"></asp:Label></p>
                        <p class="card-text title-hover"><asp:Label ID="AlbumStockLbl" runat="server"></asp:Label></p>
                    </div> 
                </div>
            </div>
        </div>
     </div>

    <script>
        function decreaseQuantity() {
            var quantityTxt = document.getElementById('<%= QuantityTxt.ClientID %>');
            var currentQuantity = parseInt(quantityTxt.value);
        
            if (currentQuantity > 0) {
                quantityTxt.value = currentQuantity - 1;
            }
        }
    
        function increaseQuantity() {
            var quantityTxt = document.getElementById('<%= QuantityTxt.ClientID %>');
            var currentQuantity = parseInt(quantityTxt.value);

            quantityTxt.value = currentQuantity + 1;
        }
    </script>
</asp:Content>


