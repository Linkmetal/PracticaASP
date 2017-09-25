<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormNotas.aspx.cs" Inherits="WebApplication3.WebFormNotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="WebFormNotas.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="listacursos" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="index_changed">
            <asp:ListItem Value="-1" Text="--Seleccione un curso--"></asp:ListItem>
        </asp:DropDownList>

        <asp:Gridview ID="gridnotas" runat="server"
            AutoGenerateColumns="False" 
             OnRowCommand="gridnotas_ItemCommand">
            <Columns>
                <asp:BoundField DataField = "COD_ALU" HeaderText="CÓDIGO ALUMNO"></asp:BoundField>
                <asp:BoundField DataField = "APELLIDOS" HeaderText="APELLIDOS"></asp:BoundField>
                <asp:BoundField DataField = "NOMBRE" HeaderText="NOMBRE"></asp:BoundField>
                <asp:BoundField DataField = "NOTA1" HeaderText="NOTA1"></asp:BoundField>
                <asp:BoundField DataField = "NOTA2" HeaderText="NOTA2"></asp:BoundField>
                <asp:BoundField DataField = "NOTA3" HeaderText="NOTA3"></asp:BoundField>
                <asp:BoundField DataField = "MEDIA" HeaderText="MEDIA"></asp:BoundField>


                <asp:ButtonField ButtonType = "Button" CommandName="Modifica" Text="Modificar" ></asp:ButtonField>

            </Columns>
        </asp:Gridview>
        <asp:Panel ID="ModNotas" runat="server" Visible="false">
            <br />
            Nota1:&nbsp<asp:TextBox autopostback="true" runat="server" ID="n1" OnTextChanged="CalculaMedia"></asp:TextBox><br /><br />
            Nota2:&nbsp<asp:TextBox autopostback="true" runat="server" ID="n2" OnTextChanged="CalculaMedia"></asp:TextBox><br /><br />
            Nota3:&nbsp<asp:TextBox autopostback="true" runat="server" ID="n3" OnTextChanged="CalculaMedia"></asp:TextBox><br /><br />
            Media:&nbsp<asp:TextBox runat="server" ID="med" ReadOnly="true" BackColor="Gray" ></asp:TextBox><br /><br />
            <asp:Button runat="server" text="Guardar" OnClick="GuardarNotas"/>
        </asp:Panel>

        <asp:HyperLink id="volver" NavigateUrl="~/WebFormIndex.aspx" runat="server" >Volver</asp:HyperLink>
    </div>
    </form>
</body>
</html>
