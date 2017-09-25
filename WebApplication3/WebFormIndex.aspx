<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormIndex.aspx.cs" Inherits="WebApplication3.WebFormIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="WebFormindex.css"/>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
        <h1>Gestion de cursos</h1>
        <asp:HyperLink ID="HyperLink1" runat="server" BorderColor="Red" BorderStyle="Groove" BorderWidth="2px" Font-Size="X-Large" NavigateUrl="~/WebFormCursos.aspx">Cursos</asp:HyperLink><br/>
        <asp:HyperLink ID="HyperLink2" runat="server" BorderColor="Red" BorderStyle="Groove" BorderWidth="2px" Font-Size="X-Large" NavigateUrl="~/WebFormAlumnos.aspx">Alumnos</asp:HyperLink><br/>
        <asp:HyperLink ID="HyperLink3" runat="server" BorderColor="Red" BorderStyle="Groove" BorderWidth="2px" Font-Size="X-Large" NavigateUrl="~/WebFormNotas.aspx">Notas</asp:HyperLink><br/>
    </div>
    </form>
</body>
</html>
