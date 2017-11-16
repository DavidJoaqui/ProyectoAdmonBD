<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true"
    CodeBehind="FormularioVehiculo.aspx.cs" Inherits="Vista.FormularioVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <center>
            <h1 style="background-color: #F3F781">
                Registro de Vehiculos <small>Parking</small></h1>
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
                <asp:TextBox ID="txtcodigo" placeholder="Ingrese el código" runat="server" Width="211px"></asp:TextBox></div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Placa:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtplaca" placeholder="Ingrese # de placa" runat="server" Width="211px"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Color:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtcolor" placeholder="Ingrese el color" runat="server" Width="211px"></asp:TextBox></div>
        </div>
    </div>
    <div>
    <div class="row">
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Persona:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="ddlpersona" class="btn btn-default dropdown-toggle" runat="server"
                    Style="min-width: 100%">
                </asp:DropDownList>
            </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-3">
                    <h5>
                        Tipo vehiculo:</h5>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddltipovehiculo" class="btn btn-default dropdown-toggle" runat="server"
                        Style="min-width: 100%">
                    </asp:DropDownList>
                </div>                
            </div>
            </div>
            </div>
            
    <br />
    <br />
    <!--Aqui van los botones, opacity es para opacarlos, succes:verde, default:gris, info:azul, danger:rojo-->
    
    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="Btnagregar" runat="server"  Style="opacity: 0.5"
                class="btn btn-success" Text="AGREGAR" onclick="Btnagregar_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnactualizar" runat="server"  Style="opacity: 0.5"
                class="btn btn-default" Text="ACTUALIZAR" onclick="Btnactualizar_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnbuscar" runat="server" Text="BUSCAR" 
            class="btn btn-info" Style="opacity: 0.5" onclick="Btnbuscar_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btneliminar" runat="server"  Style="opacity: 0.5"
                class="btn btn-danger" Text="ELIMINAR" onclick="Btneliminar_Click" />
        </div>
    </div>
    <br />
    <br />
    <!--Este row contiene la tabla de informacion-->
    <div class="row">
        <asp:GridView ID="gruillavehiculo" runat="server" class="table">
        </asp:GridView>
    </div>
</asp:Content>
