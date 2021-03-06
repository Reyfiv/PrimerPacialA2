﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPrestamos.aspx.cs" Inherits="PrimerPacialA2.Consultas.cPrestamos" %>

<asp:Content ID="Content7" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel" style="background-color:black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium; color:white">Consulta de Prestamos</div>
    </div>
    <%--Entradas de las consulta--%>
    <div class="form-group">
            <div class="col-md-4">
                    <asp:DropDownList ID="FiltroDropDownList" runat="server" Class="form-control input-sm" style="font-size:medium">
                            <asp:ListItem Selected="True">Todo</asp:ListItem>
                            <asp:ListItem>Prestamo Id</asp:ListItem>
                            <asp:ListItem>Capital</asp:ListItem>
                            <asp:ListItem>Interes Anual</asp:ListItem>
                            <asp:ListItem>Tiempo en meses</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="col-md-6">
                 <asp:TextBox ID="CriterioTextBox" runat="server" class="form-control input-sm" style="font-size:medium"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="BuscarButton_Click" />
            </div>
        </div>
    <br/>
    <br/>
    <%--Grid--%>
    <div class="table-responsive">
        <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField ControlStyle-ForeColor="Black"
                        DataNavigateUrlFields="ID"
                        DataNavigateUrlFormatString="/Registros/rPrestamos.aspx?Id={0}"
                        Text="Editar">
                    </asp:HyperLinkField>
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="true" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
        </asp:GridView>
         <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="ImprimirButton" runat="server" Text="Imprimir" class="btn btn-warning btn-lg" OnClick="ImprimirButton_Click" />
                    </div>
                </div>
            </div>
    </div>
</asp:Content>