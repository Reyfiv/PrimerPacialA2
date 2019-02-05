using BLL;
using Entities;
using PrimerPacialA2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerPacialA2.Registros
{
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaCombo();
        }
        
        private void Limpiar()
        {
            DepositoIdTextBox.Text = "0";
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }

        private Deposito LlenaClase(Deposito deposito)
        {
            int id;
            bool result = int.TryParse(DepositoIdTextBox.Text, out id);
            if (result == true)
            {
                deposito.DepositoID = id;
            }
            else
            {
               deposito.DepositoID = 0;
            }
            int c;
            bool resultados = int.TryParse(CuentaIdDropDownList.Text, out c);
            if (resultados == true)
            {
                deposito.CuentaID = c;
            }
            else
            {
                deposito.CuentaID = 0;
            }
            deposito.Concepto = ConceptoTextBox.Text;
            decimal bal;
            bool resultado = decimal.TryParse(MontoTextBox.Text, out bal);
            if (resultado == true)
            {
                deposito.Monto = bal;
            }
            else
            {
                deposito.Monto = 0;
            }
            DateTime date;
            bool resultadoss = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resultadoss == true)
                deposito.Fecha = date;
            return deposito;
        }

        private void LlenaCampos(Deposito deposito)
        {
            Limpiar();
            DepositoIdTextBox.Text = Convert.ToString(deposito.DepositoID);
            CuentaIdDropDownList.Text = Convert.ToString(deposito.CuentaID);
            ConceptoTextBox.Text = deposito.Concepto;
            MontoTextBox.Text = Convert.ToString(deposito.Monto);
        }

        protected void LlenaCombo()
        {
            RepositorioBase<Cuenta> repositorioBase = new RepositorioBase<Cuenta>();

            CuentaIdDropDownList.DataSource = repositorioBase.GetList(t => true);
            CuentaIdDropDownList.DataValueField = "CuentaID";
            CuentaIdDropDownList.DataTextField = "CuentaID";
            CuentaIdDropDownList.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            var deposito = repositorio.Buscar(Utils.ToInt(DepositoIdTextBox.Text));

            if (deposito != null)
            {
                Limpiar();
                LlenaCampos(deposito);

                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El usuario que intenta buscar no existe", "Error", "error");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Deposito deposito = new Deposito();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }

            deposito = LlenaClase(deposito);
            if (deposito.DepositoID == 0)
                paso = repositorio.Guardar(deposito);
            else
                paso = repositorio.Modificar(deposito);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DepositoIdTextBox.Text);
            DepositoRepositorio repositorio = new DepositoRepositorio();
            if (repositorio.Eliminar(id))
            {
                Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
            }
            else
                Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            Limpiar();
        }
    }
}