<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="PrimerPacialA2.Registros.rPrestamos" %>

<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" style="background-color:black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium; color:white">Registro de Prestamos</div>
    </div>
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <%--PrestamoId--%>
            <div class="form-group">
                <label for="PrestamoIdTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Prestamo Id</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="PrestamoIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size:large" TextMode="Number"></asp:TextBox>                  
                </div>
                    <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "Prestamo Id" solo acepta numeros' ControlToValidate="PrestamoIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-sm" OnClick="BuscarButton_Click" />
                </div>
            </div>
            <br />
                <%--CuentaId--%>
            <div class="form-group">
                <label for="CuentaIdDropDownList" class="col-md-3 control-label input-sm" style="font-size:large">Cuenta</label>
                <div class="col-md-8">
                    <asp:DropDownList ID="CuentaIdDropDownList" runat="server" Class="form-control input-sm" style="font-size:large" >
                    </asp:DropDownList>
                </div>
            </div>
            <br/>
             <%--Capital y interes--%>
            <div class="form-group">
                <label for="CapitalTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Capital</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="CapitalTextBox" runat="server" class="form-control input-sm" Style="font-size:large; text-align:center"></asp:TextBox> 
                    <asp:RegularExpressionValidator ID="Valida" runat="server" ErrorMessage='Campo "Capital" solo acepta numeros' ControlToValidate="CapitalTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="ValidaCapital" runat="server" ErrorMessage="El campo &quot;Capital&quot; esta vacio" ControlToValidate="CapitalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Capital es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>

                <label for="InteresTextBox" class="col-md-1 control-label input-sm" style="font-size:large">Interes</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="InteresTextBox" runat="server" class="form-control input-sm" Style="font-size:large; text-align:center"></asp:TextBox>  
                </div>
                    <label for="InteresTextBox" style="font-size:large">%</label>
                    <asp:RegularExpressionValidator ID="ValidaMontoNUM" runat="server" ErrorMessage='Campo "Interes" solo acepta numeros' ControlToValidate="InteresTextBox" ValidationExpression="^[0.0-9.0]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidaInteres" runat="server" ErrorMessage="El campo &quot;Monto&quot; esta vacio" ControlToValidate="InteresTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Interes obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <br/>
           
            <%--Tiempo en Meses--%>
            <div class="form-group">
                <label for="TiempoMesesTextBox" class="col-md-3 control-label input-sm" style="font-size:large">Tiempo en meses</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="TiempoMesesTextBox" runat="server" class="form-control input-sm" Style="font-size:large; text-align:center"></asp:TextBox> 
                    <asp:RegularExpressionValidator ID="ValidaMeses" runat="server" ErrorMessage='Campo "Tiempo en meses" solo acepta numeros' ControlToValidate="TiempoMesesTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="ValidaMeses2" runat="server" ErrorMessage="El campo &quot;Tiempo en meses&quot; esta vacio" ControlToValidate="TiempoMesesTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Capital es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>

                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="CalcularButton" runat="server" Text="Calcular Cuotas" class="btn btn-success btn-sm" OnClick="CalcularButton_Click" />
                </div>
            </div>
            <br/>
             <%--Cuotas--%>
            <div class="table-responsive">  
                <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="true" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
            </div>
            <br />
            <%--Fecha--%>
            <div class="form-group">
                <div class="col-md-8">
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size:large" Visible="false"></asp:TextBox>
                </div>
            </div>
          
            <%--TotalAretornar--%>
            <div class="form-group">
                <label for="TotalARetornarTextBox" class="col-md-8 control-label input-sm" style="font-size:large">Total a Retornar</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="TotalARetornarTextBox" runat="server" class="form-control input-sm" Style="font-size:large; text-align:center" ReadOnly="true"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="TotalARetornarTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Capital es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator> 
                </div>
            </div>
            <br />
             <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary btn-md" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-md"  ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger btn-md" OnClick="EliminarButton_Click"  />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
