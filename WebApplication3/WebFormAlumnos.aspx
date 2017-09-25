<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAlumnos.aspx.cs" Inherits="WebApplication3.WebFormAlumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="WebFormAlumnos.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divAlumnos">
        <asp:GridView ID = "gridAlumnos" runat ="server" 
             AutoGenerateColumns="False" 
             OnRowCommand="gridAlumnos_ItemCommand" >
            <Columns>
                <asp:BoundField DataField = "COD_CUR" HeaderText="CURSO"></asp:BoundField>
                <asp:BoundField DataField = "COD_ALU" HeaderText="CÓDIGO ALUMNO"></asp:BoundField>
                <asp:BoundField DataField = "DNI" HeaderText="DNI"></asp:BoundField>
                <asp:BoundField DataField = "APELLIDOS" HeaderText="APELLIDOS"></asp:BoundField>
                <asp:BoundField DataField = "NOMBRE" HeaderText="NOMBRE"></asp:BoundField>
                <asp:ButtonField ButtonType = "Image" CommandName="Modifica" ImageUrl="~/male-user-edit_25348.ico"></asp:ButtonField>
                <asp:ButtonField ButtonType = "Image" CommandName="Borra" ImageUrl="~/male-user-remove_25351.ico" ></asp:ButtonField>
            </Columns>
         </asp:GridView>
         <br /><br />
        <asp:HyperLink id="volver" NavigateUrl="~/WebFormIndex.aspx" runat="server" >Volver</asp:HyperLink>
    </div>
    </form>
</body>
</html>
