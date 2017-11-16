<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" 
CodeBehind="FormularioVenta.aspx.cs" Inherits="Vista.FormularioVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-header">
        <center><h1 style="background-color:#F3F781">
            Registro de Ventas <small>Parking</small></h1></center>
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
                    Hora Entrada:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtentrada" placeholder="Ingrese la hora de entrada" 
                    runat="server" Width="211px"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Hora Salida:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtsalida" placeholder="Ingrese la hora de salida" 
                    runat="server" Width="211px"></asp:TextBox></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Precio:</h5>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtprecio" runat="server" placeholder="Ingrese # de cedula" 
                    Width="211px"></asp:TextBox></div>
        </div>
        
        <div class="col-md-4">
            <div class="col-md-3">
                <h5>
                    Vehiculo:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="ddlusuarios" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <br />
    <br />
    <!--Aqui van los botones, opacity es para opacarlos, succes:verde, default:gris, info:azul, danger:rojo-->
    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="Btnagregar" runat="server" style="opacity:0.5" class="btn btn-success"
                Text="AGREGAR" onclick="Btnagregar_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnactualizar" runat="server" style="opacity:0.5" class="btn btn-default"
                Text="ACTUALIZAR" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btnbuscar" runat="server" Text="BUSCAR" class="btn btn-info"  style="opacity:0.5" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="Btneliminar" runat="server" style="opacity:0.5" class="btn btn-danger"
                Text="ELIMINAR" onclick="Btneliminar_Click" />
        </div>
    </div>
    <br />
    <br />
    <!--Este row contiene la tabla de informacion-->
    <div class="row">
        <asp:GridView ID="gruillaventas" runat="server" class="table">
        </asp:GridView>
    </div>
</asp:Content>
