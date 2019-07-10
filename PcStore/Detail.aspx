<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="PcStore.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <a href="javascript:history.back();">Back</a>
    <br />

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <table class="float_box">
        <tr>
            <td rowspan="4" style="width: 270px; height: 300px;">
                <img id="imageProduct" src="" runat="server" style="max-width: 250px; border: none;" />
              
            </td>
            <td>
                <asp:Label runat="server" ID="lblProductName" CssClass="name"></asp:Label></td>
        </tr>
        <tr>
            <td>Price:<asp:Label runat="server" ID="lblPrice" CssClass="price"></asp:Label></td>
        </tr>
        <tr>
            <td>Release Date:<asp:Label runat="server" ID="lblReleaseDate"></asp:Label></td>
        </tr>
         <tr><td>
            <asp:Button ID="btnAddCart" runat="server" CssClass="btn btn-primary btn-lg" Text="カートに入れる" OnClientClick="alert('This is a demo.');return false;"/>
             </td>
        </tr>
        <tr>
            <td colspan="2">
                <pre>
                <asp:Label runat="server" ID="lblDescription"></asp:Label>
                    </pre>
            </td>
        </tr>

    </table>
</asp:Content>
