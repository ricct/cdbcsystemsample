<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PcStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="float_box">
        <asp:Literal ID="lblInfo" runat="server" Visible="false">
             <br />
            <span style="color:red">Please take a look at following page before you start.</span> <br />
            <a href="https://github.com/ricct/cdbcsystemsample">https://github.com/ricct/cdbcsystemsample</a><br />
        </asp:Literal>

        <asp:Literal ID="lblError" runat="server" Visible="false"></asp:Literal>
        <h2>Product List</h2>
        <input class="form-control" id="searchInput" type="text" placeholder="Search..">
        <br />
        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
                <ul class="list-group" id="productList">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <a href="./Detail?productcode=<%#Eval("PRODUCT_CODE")%>">
                        <div class="divimg">
                            <img src='./ShowImage?imagetype=product&code=<%#Eval("PRODUCT_CODE")%>' alt='<%#Eval("PRODUCT_NAME")%>' class="image" />
                        </div>
                    </a>
                    <p class="name"><%#Eval("PRODUCT_NAME")%></p>
                    <p class="price"><%#Eval("CURRENCY_CODE")%> <%#FormatNumber(Eval("PRODUCT_PRICE"))%></p>
                    <p class="category"><%#Eval("CATEGORY_NAME")%></p>
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p>Nothing here.</p>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <script>
        $(document).ready(function () {
            $("#searchInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#productList li").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>

</asp:Content>




