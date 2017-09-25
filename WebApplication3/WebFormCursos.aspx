<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCursos.aspx.cs" Inherits="WebApplication3.WebFormCursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="WebFormCursos.css?t=<%= DateTime.Now.Ticks %>" media="screen" />
    <link rel="stylesheet" href="WebFormCursos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Cursos</h1>
    <div id="divCursos">
        <asp:Panel runat="server">
            <asp:Label Text="Código Curso" runat="server" />
            <asp:TextBox runat="server" ID="tbox1" />
            <br />

            <asp:Label Text="Descripción" runat="server" />
            <asp:TextBox runat="server" ID="tbox2" />
            <br />

            <asp:Label Text="Horas" runat="server" />
            <asp:TextBox runat="server" ID="tbox3" />
            <br />

            <asp:Label Text="Tutor" runat="server" />
            <asp:TextBox runat="server" ID="tbox4" />
            <br />
            
        </asp:Panel>
        <div id="divBotones">
            <asp:Button Text="|<" runat="server" ID="first" OnClick="first_Click" />
            <asp:Button Text="<<" runat="server" ID="prev" OnClick="prev_Click" />
            <asp:Button Text=">>" runat="server" ID="next" OnClick="next_Click" />
            <asp:Button Text=">|" runat="server" ID="last" OnClick="last_Click" />
            <asp:Button Text="Nuevo" runat="server" ID="nuevo" OnClick="nuevo_Click" />
            <asp:Button Text="Graba" runat="server" ID="graba" OnClick="graba_Click" />
            <asp:Button Text="Borra" runat="server" ID="borra" OnClick="borra_Click" />
            <asp:Button Text="Cancelar" runat="server" ID="cancelar" OnClick="cancelar_Click" />
        </div>
            <br />
        <br />
        <br />
        <asp:HyperLink  id="volver" NavigateUrl="~/WebFormIndex.aspx" runat="server"  >Volver</asp:HyperLink>

    </div>
    </form>
</body>
</html>
