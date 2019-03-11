<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepotePrestamos.aspx.cs" Inherits="PrimerPacialA2.Reportes.RepotePrestamos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content8" ContentPlaceHolderID="MainContent" runat="server">
          <div class="panel-body">
             <div class="form-horizontal col-md-12" role="form">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <rsweb:ReportViewer  ID="PrestamosReportViewer" runat="server" ProcessingMode="Remote" Height="741px" style="text-align:center" Width="1195px">
                       <ServerReport ReportPath="" ReportServerUrl=""/>
                 </rsweb:ReportViewer>
             </div>
          </div>
</asp:Content>
