<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="PrimerPacialA2.Registros.rDepositos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel" style="background-color:black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium; color:white">Registro de Depositos</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <%--DepositoId--%>
            <div class="form-group">
                <label for="DepositoIdTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Deposito Id</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="DepositoIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size:large" TextMode="Number"></asp:TextBox>                  
                </div>
                 <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "Cuenta Id" solo acepta numeros' ControlToValidate="DepositoIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-sm" OnClick="BuscarButton_Click" />
                </div>
            </div>
              <br/>
            <%--CuentaId--%>
            <div class="form-group">
                <label for="CuentaIdDropDownList" class="col-md-3 control-label input-sm" style="font-size:large">Cuenta</label>
                <div class="col-md-8">
                   <asp:DropDownList ID="CuentaIdDropDownList" runat="server" Class="form-control input-sm" style="font-size:large">
                     </asp:DropDownList>
                </div>
            </div>
            <br/>
             <%--Concepto y Monto--%>
            <div class="form-group">
                <label for="ConceptoTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Concepto</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="ConceptoTextBox" runat="server" class="form-control input-sm" Style="font-size:large"></asp:TextBox>   
                    <asp:RequiredFieldValidator ID="ValidaConcepto" runat="server" ErrorMessage="El campo &quot;Concepto&quot; esta vacio" ControlToValidate="ConceptoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Concepto es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>

                <label for="MontoTextBox" class="col-md-1 control-label input-sm" style="font-size:large">Monto</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="MontoTextBox" runat="server" class="form-control input-sm" Style="font-size:large"></asp:TextBox>                  
                </div>
                 <asp:RegularExpressionValidator ID="ValidaMontoNUM" runat="server" ErrorMessage='Campo "Monto" solo acepta numeros' ControlToValidate="MontoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidaMonto" runat="server" ErrorMessage="El campo &quot;Monto&quot; esta vacio" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Monto obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
             <br/>
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
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary btn-md" OnClick="NuevoButton_Click"  />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-md"  ValidationGroup="Guardar" OnClick="GuardarButton_Click"  />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger btn-md" OnClick="EliminarButton_Click"  />
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>