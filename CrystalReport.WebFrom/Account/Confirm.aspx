<%@ Page Title="帳戶確認" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="CrystalReport.WebFrom.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>。</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                感謝您確認帳戶。按一下 <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">這裡</asp:HyperLink>  登入             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                發生錯誤
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
