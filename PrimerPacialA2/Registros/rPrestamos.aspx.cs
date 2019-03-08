using BLL;
using Entities;
using PrimerPacialA2.Utilidades;
using System;
using System.Linq.Expressions;

namespace PrimerPacialA2.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaCombo();
        }

        protected void BindGrid()
        {
            DatosGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Cuotas;
            DatosGridView.DataBind();
        }

        protected void Limpiar()
        {
            PrestamoIdTextBox.Text = "0";
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoMesesTextBox.Text = string.Empty;
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();
        }

        protected void LlenaCombo()
        {
            RepositorioBase<Cuenta> repositorioBase = new RepositorioBase<Cuenta>();

            CuentaIdDropDownList.DataSource = repositorioBase.GetList(t => true);
            CuentaIdDropDownList.DataValueField = "CuentaID";
            CuentaIdDropDownList.DataTextField = "CuentaID";
            CuentaIdDropDownList.DataBind();

            ViewState["Prestamos"] = new Prestamos();
        }

        protected Prestamos LlenaClase(Prestamos prestamos)
        {
            prestamos = (Prestamos)ViewState["Prestamos"];
            prestamos.ID = Utils.ToInt(PrestamoIdTextBox.Text);
            prestamos.CuentaId = Utils.ToInt(CuentaIdDropDownList.Text);
            prestamos.Capital = Utils.ToDecimal(CapitalTextBox.Text);
            prestamos.InteresAnual = Utils.ToDecimal(InteresTextBox.Text);
            prestamos.TiempoMeses = Utils.ToInt(TiempoMesesTextBox.Text);
            return prestamos;
        }

        protected void LlenaCampos(Prestamos prestamos)
        {
            Limpiar();
            PrestamoIdTextBox.Text = prestamos.ID.ToString();
            CuentaIdDropDownList.Text = prestamos.CuentaId.ToString();
            CapitalTextBox.Text = prestamos.Capital.ToString();
            InteresTextBox.Text = prestamos.InteresAnual.ToString();
            TiempoMesesTextBox.Text = prestamos.TiempoMeses.ToString();

            //filtro para buscar mi detalle por id del prestamo, recordando que ya lo tengo enlazado con una variable qeu le hace referencia en el detalle.
            //Asi puedo hacer que me muestre el detalle cuando lo busco en el Registro De Prestamos.
            Expression<Func<CuotasDetalle, bool>> filtro = x => true;
            RepositorioBase<CuotasDetalle> repositorioBase = new RepositorioBase<CuotasDetalle>();
            int id = prestamos.ID;
            filtro = c => c.ID == id;
            DatosGridView.DataSource = repositorioBase.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            DetalleRepositorio repositorio = new DetalleRepositorio();
            RepositorioBase<Prestamos> repositorioBase = new RepositorioBase<Prestamos>();
            Prestamos prestamos = new Prestamos();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }

            prestamos = LlenaClase(prestamos);
            if (prestamos.ID == 0)
                paso = repositorioBase.Guardar(prestamos);
            else
                paso = repositorio.Modificar(prestamos);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                Limpiar();
            }
        }
    }
}