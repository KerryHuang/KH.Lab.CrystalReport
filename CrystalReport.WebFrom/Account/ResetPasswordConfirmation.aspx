<%@ Page Title="變更密碼" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="CrystalReport.WebFrom.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>您的密碼已變更。按一下 <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">這裡</asp:HyperLink> 登入 </p>
    </div>
</asp:Content>
