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
    public partial class cCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        private void MetodoBuscar()
        {
            Expression<Func<Cuenta, bool>> filtro = x => true;
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();

            int id;
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://CuentaId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CuentaID == id;
                    break;
                case 2://Nombre
                    filtro = c => c.Nombre.Contains(CriterioTextBox.Text);
                    break;
                case 3: //Balance
                    n = Utilidades.Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.Balance == n;
                    break;
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            MetodoBuscar();
        }
    }
}