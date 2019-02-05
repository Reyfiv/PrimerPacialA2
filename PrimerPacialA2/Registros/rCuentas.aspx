<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentas.aspx.cs" Inherits="PrimerPacialA2.Registros.rCuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel" style="background-color:black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium; color:white">Registro de Cuentas</div>
    </div>
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <%--CuentaId--%>
            <div class="form-group">
                <label for="CuentaIdTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Cuenta Id</label>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:TextBox ID="CuentaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size:large" TextMode="Number"></asp:TextBox>                  
                </div>
                 <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "Cuenta Id" solo acepta numeros' ControlToValidate="CuentaIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-sm" OnClick="BuscarButton_Click"  />
                </div>
            </div>
              <%--Nombre y balance--%>
            <div class="form-group">
                <label for="NombreTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Nombre</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="NombreTextBox" runat="server" class="form-control input-sm" Style="font-size:large"></asp:TextBox>   
                    <asp:RequiredFieldValidator ID="ValidaNombre" runat="server" ErrorMessage="El campo &quot;Nombre&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Nombre es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>

                <label for="BalanceTextBox" class="col-md-1 control-label input-sm" style="font-size:large">Balance</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="BalanceTextBox" runat="server" class="form-control input-sm" Style="font-size:large"></asp:TextBox>                  
                </div>
                 <asp:RegularExpressionValidator ID="ValidaBalanceNUM" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="BalanceTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidaBalance" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="BalanceTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--Fecha--%>
            <div class="form-group">
                <div class="col-md-8">
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size:large" Visible="false"></asp:TextBox>
                </div>
            </div>
             <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary btn-md" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-md"  ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger btn-md" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
       </div>
    </div>
           
</asp:Content>
