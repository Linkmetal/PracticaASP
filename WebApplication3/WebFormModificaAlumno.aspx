<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormModificaAlumno.aspx.cs" Inherits="WebApplication3.WebFormModificaAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="WebFormModificaAlumnos.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divAlumno">
      
		<asp:Label runat ="server"> Cod_Alu</asp:Label>
        <asp:TextBox ID = "tboxCod_Alu" runat = "server" ></asp:TextBox>
        <br />
        <asp:Label runat = "server" > Cod_Cur</asp:Label>
        <asp:DropDownList ID="listacursos" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
            <asp:ListItem Value="-1" Text="--Seleccione un curso--"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat = "server" > DNI</asp:Label>
        <asp:TextBox ID = "tboxDni" runat = "server" ></asp:TextBox>
        <br />
        <asp:Label runat = "server" > Apellidos</asp:Label>
        <asp:TextBox ID = "tboxApellidos" runat = "server" ></asp:TextBox>
        <br />
        <asp:Label runat = "server" > Nombre</asp:Label>
        <asp:TextBox ID = "tboxNombre" runat = "server" ></asp:TextBox>
        <br />
        <asp:Button Text="Confirmar" ID="btnModiAlumnos" runat="server" OnClick="button_click" />
        <asp:HyperLink id="volver" NavigateUrl="~/WebFormAlumnos.aspx" runat="server" >Volver</asp:HyperLink>

    </div>
    </form>
</body>
</html>
