<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.Views.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <<div style="padding:2% 10%">
        <div method="post">
            <div class="form-group">
                <label for="inputArtist">Artist Name</label>
                <asp:TextBox ID="ArtistTxt" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:FileUpload ID="ArtistFileUpload" runat="server" text="Upload Artist Image" />
            
            
      
        </div>
        <asp:Label ID="ErrorTxt" runat="server" Text=""></asp:Label>
        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="btn btn-success mb-2 w-100" OnClick="SubmitBtn_Click"/>
        <a>
            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="btn btn-danger mb-2 w-100" OnClick="CancelBtn_Click"/>
        </a>
   </div>
</asp:Content>
