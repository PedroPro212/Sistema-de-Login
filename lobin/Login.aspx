<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lobin.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>LOGIN</h1>

    Email: <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
    Senha: <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" TextMode="Password"></asp:TextBox> <br />
    <asp:Button runat="server" ID="btnEntrar" Text="Cadastrar" CssClass="btn btn-primary" OnClick="btnEntrar_Click"/>
   

</asp:Content>
