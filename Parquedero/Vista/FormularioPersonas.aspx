<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true"
    CodeBehind="FormularioPersonas.aspx.cs" Inherits="Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <center>
            <h1 style="background-color: #F3F781">
                Registro de Personas <small>Parking</small></h1>
        </center>
    </div>
    <!--Regillas para el formulario y el combobox-->
    <div class="row">
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Código:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtcodigo" placeholder="Ingrese el código" runat="server" Width="211px"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Nombre:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtnombres" placeholder="Ingrese el nombre" runat="server" Width="211px"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Apellidos:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtapellidos" placeholder="Ingrese el apellido" runat="server" Width="211px"></asp:TextBox></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Cedula:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtcedula" runat="server" placeholder="Ingrese # de cedula" Width="211px"></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Telefono:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txTelefono" runat="server" placeholder="Ingrese su telefono" Width="211px"></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Usuario:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="ddlusuarios" class="btn btn-default dropdown-toggle" runat="server"
                    Style="min-width: 100%">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <br />
    <br />
    <!--Aqui van los botones, opacity es para opacarlos, succes:verde, default:gris, info:azul, danger:rojo-->
    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="Btnagregar" runat="server" OnClick="Btnagregar_Click" Style="opacity: 0.5"
                class="btn btn-success" Text="AGREGAR" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnactualizar" runat="server" OnClick="Btnactualizar_Click" Style="opacity: 0.5"
                class="btn btn-default" Text="ACTUALIZAR" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnbuscar" runat="server" Text="BUSCAR" class="btn btn-info" Style="opacity: 0.5"
                OnClick="Btnbuscar_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btneliminar" runat="server" OnClick="Btneliminar_Click" Style="opacity: 0.5"
                class="btn btn-danger" Text="ELIMINAR" />
        </div>
    </div>
    <br />
    <br />
    <!--Este row contiene la tabla de informacion-->
    <div class="row">
        <asp:GridView ID="gruillapersonas" runat="server" class="table">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
