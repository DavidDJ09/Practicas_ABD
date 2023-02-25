<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label13" runat="server" Font-Size="X-Large" ForeColor="Blue" Text="Libros"></asp:Label>
        <asp:GridView ID="gdvDatos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="isbn" HeaderText="isbn" SortExpression="isbn" />
                <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                <asp:BoundField DataField="numeroDeEdicion" HeaderText="numeroDeEdicion" SortExpression="numeroDeEdicion" />
                <asp:BoundField DataField="anioPublicacion" HeaderText="anioPublicacion" SortExpression="anioPublicacion" />
                <asp:BoundField DataField="autores" HeaderText="autores" SortExpression="autores" />
                <asp:BoundField DataField="paisDePublicacion" HeaderText="paisDePublicacion" SortExpression="paisDePublicacion" />
                <asp:BoundField DataField="sinopsis" HeaderText="sinopsis" SortExpression="sinopsis" />
                <asp:BoundField DataField="carrera" HeaderText="carrera" SortExpression="carrera" />
                <asp:BoundField DataField="materia" HeaderText="materia" SortExpression="materia" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:practica2ConnectionString %>" SelectCommand="SELECT * FROM [libros] ORDER BY [id]"></asp:SqlDataSource>
        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="Blue" Text="Agregar Registro"></asp:Label>
        <div>
            <asp:Label ID="Label3" runat="server" Text="ID"></asp:Label>
        </div>
        <asp:TextBox ID="txtId" runat="server" Width="89px"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="ISBN"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Título"></asp:Label>
        <p>
            <asp:TextBox ID="txtTitulo" runat="server" Width="446px"></asp:TextBox>
        </p>
        <asp:Label ID="Label6" runat="server" Text="Número de edición"></asp:Label>
        <p>
            <asp:TextBox ID="txtNumEdicion" runat="server" Width="152px"></asp:TextBox>
        </p>
        <asp:Label ID="Label7" runat="server" Text="Año de publicación"></asp:Label>
        <p>
            <asp:TextBox ID="txtAnio" runat="server" Width="102px"></asp:TextBox>
        </p>
        <asp:Label ID="Label8" runat="server" Text="Nombre de los autores"></asp:Label>
        <p>
            <asp:TextBox ID="txtAutores" runat="server" Height="69px" Width="443px"></asp:TextBox>
        </p>
        <asp:Label ID="Label9" runat="server" Text="País de publicación"></asp:Label>
        <p>
            <asp:TextBox ID="txtPais" runat="server" Width="289px"></asp:TextBox>
        </p>
        <asp:Label ID="Label10" runat="server" Text="Sinópsis"></asp:Label>
        <p>
            <asp:TextBox ID="txtSinopsis" runat="server" Height="143px" Width="436px"></asp:TextBox>
        </p>
        <asp:Label ID="Label11" runat="server" Text="Carrera"></asp:Label>
        <p>
            <asp:TextBox ID="txtCarrera" runat="server" Width="430px"></asp:TextBox>
        </p>
        <asp:Label ID="Label12" runat="server" Text="Materia"></asp:Label>
        <p>
            <asp:TextBox ID="txtMateria" runat="server" Width="431px"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" Width="228px" />
        </p>
        <p>
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
