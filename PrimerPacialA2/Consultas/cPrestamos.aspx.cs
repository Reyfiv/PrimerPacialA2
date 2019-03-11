using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerPacialA2.Consultas
{
    public partial class cPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        private void MetodoBuscar()
        {
            Expression<Func<Prestamos, bool>> filtro = x => true;
            RepositorioBase<Prestamos> repositorio = new RepositorioBase<Prestamos>();

            int id;
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://PrestamoId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.ID == id;
                    break;
                case 2://Capital
                    n = Utilidades.Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.Capital == n;
                    break;
                case 3: //InteresAnual
                    n = Utilidades.Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.InteresAnual == n;
                    break;
                case 4://TiempoEnMeses
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.TiempoMeses == id;
                    break;
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"\Reportes\RepotePrestamos.aspx");
        }
    }
}