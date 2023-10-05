<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KpopZtation.Views.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:2% 10%">
        <div method="post">
            <div class="form-group">
                <label for="AlbumLbl">Album Name</label>
                <asp:TextBox ID="Albumtxt" runat="server" class="form-control"></asp:TextBox>

                <label for="AlbumDescLbl">Description</label>
                <asp:TextBox ID="AlbumDescTxt" runat="server" class="form-control"></asp:TextBox>

                <label for="AlbumPriceLbl">Price</label>
                <asp:TextBox ID="AlbumPriceTxt" runat="server" class="form-control"></asp:TextBox>

                <label for="AlbumStockLbl">Stock</label>
                <asp:TextBox ID="AlbumStockTxt" runat="server" class="form-control"></asp:TextBox>

                
            </div>

            <asp:FileUpload ID="AlbumFileUpload" runat="server" text="Upload Album Image" />
            
            
      
            </div>
        <asp:Label ID="ErrorTxt" runat="server" Text=""></asp:Label>
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="btn btn-success mb-2 w-100" OnClick="SubmitBtn_Click"/>
        <a>
            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn btn-danger mb-2 w-100" OnClick="CancelBtn_Click"/>
        </a>
        </div>
</asp:Content>

