<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="lobin._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h1>CADASTRAR USUÁRIO</h1>

    Email: <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox> <br />
    Senha: <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" TextMode="Password"></asp:TextBox> <br />
    Conferir Senha: <asp:TextBox runat="server" ID="txtConfsenha" CssClass="form-control" TextMode="Password"></asp:TextBox> <br />
    <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" CssClass="btn btn-primary"/> 

</asp:Content>
