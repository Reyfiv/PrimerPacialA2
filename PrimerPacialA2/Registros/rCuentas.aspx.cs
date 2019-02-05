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
    public partial class rCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
                    var registro = repositorio.Buscar(id);

                    if (registro == null)
                    {
                        Utils.ShowToastr(this.Page, "Registro no encontrado", "Error", "error");
                    }
                    else
                    {
                        LlenaCampos(registro);
                    }
                }
            }
        }

        private void Limpiar()
        {
            CuentaIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
        }

        private Cuenta LlenaClase(Cuenta cuenta)
        {
            int id;
            bool result = int.TryParse(CuentaIdTextBox.Text, out id);
            if (result == true)
            {
                cuenta.CuentaID = id;
            }
            else
            {
                cuenta.CuentaID = 0;
            }
            cuenta.Nombre = NombreTextBox.Text;
            decimal bal;
            bool resultado = decimal.TryParse(BalanceTextBox.Text, out bal);
            if (resultado == true)
            {
                cuenta.Balance = bal;
            }
            else
            {
                cuenta.Balance = 0;
            }
            DateTime date;
            bool resultados = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resultados == true)
                cuenta.Fecha = date;
            return cuenta;
        }

        private void LlenaCampos(Cuenta cuenta)
        {
            Limpiar();
            CuentaIdTextBox.Text = Convert.ToString(cuenta.CuentaID);
            NombreTextBox.Text = cuenta.Nombre;
            BalanceTextBox.Text = Convert.ToString(cuenta.Balance);
            FechaTextBox.Text = Convert.ToString(cuenta.Fecha);
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositorioBase = new RepositorioBase<Cuenta>();
            Cuenta cuenta = new Cuenta();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }

            cuenta = LlenaClase(cuenta);
            if (cuenta.CuentaID == 0)
                paso = repositorioBase.Guardar(cuenta);
            else
                paso = repositorioBase.Modificar(cuenta);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CuentaIdTextBox.Text);
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            if (repositorio.Eliminar(id))
            {
                Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
            }
            else
                Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            var cuenta = repositorio.Buscar(Utils.ToInt(CuentaIdTextBox.Text));

            if (cuenta != null)
            {
                Limpiar();
                LlenaCampos(cuenta);

                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El usuario que intenta buscar no existe", "Error", "error");
        }
    }
}