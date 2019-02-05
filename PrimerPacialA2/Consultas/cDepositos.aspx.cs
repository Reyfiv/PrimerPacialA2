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
    public partial class cDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        private void MetodoBuscar()
        {
            Expression<Func<Deposito, bool>> filtro = x => true;
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();

            int id;
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://DepositoId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.DepositoID == id;
                    break;
                case 2://CuentaId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CuentaID == id;
                    break;
                case 3: //Concepto
                    filtro = c => c.Concepto.Contains(CriterioTextBox.Text);
                    break;
                case 4://Monto
                    n = Utilidades.Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.Monto == n;
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