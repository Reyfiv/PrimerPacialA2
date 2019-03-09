﻿using BLL;
using Entities;
using PrimerPacialA2.Utilidades;
using System;
using System.Collections.Generic;
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
            CuentaIdDropDownList.DataTextField = "Nombre";
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
            DateTime date;
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resultado == true)
                prestamos.Fecha = date;
            prestamos.Cuotas = (List<CuotasDetalle>)ViewState["CuotasDetalle"];
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

            //filtro para buscar mi detalle por id del prestamo, recordando que ya lo tengo enlazado con una variable que le hace referencia en el detalle.
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


        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PrestamoIdTextBox.Text);
            DetalleRepositorio repositorio = new DetalleRepositorio();
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
            DetalleRepositorio repositorio = new DetalleRepositorio();
            var prestamos = repositorio.Buscar(Utils.ToInt(PrestamoIdTextBox.Text));
            Limpiar();
            if (prestamos != null)
            {     
                LlenaCampos(prestamos);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El Prestamo que intenta buscar no existe", "Error", "error");
        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
            Prestamos prestamos = new Prestamos();
            CuotasDetalle cuotas = new CuotasDetalle();
            List<CuotasDetalle> cuotasDetalles = new List<CuotasDetalle>();

            decimal interes, capital, meses, montoPagar;
            interes = Utils.ToDecimal(InteresTextBox.Text);
            capital = Utils.ToDecimal(CapitalTextBox.Text);
            meses = Utils.ToInt(TiempoMesesTextBox.Text);

            for (int i = 0 ; i < Utils.ToInt(TiempoMesesTextBox.Text) ; i++)
            {
                cuotas.Interes = interes * capital / meses;
                cuotas.Capital = capital / meses;
                cuotas.MontoPorCuota = cuotas.Interes + cuotas.Capital;

                montoPagar = cuotas.Interes * meses + capital;
                if (i == 0)
                {
                    cuotas.BCE = montoPagar - (cuotas.Interes + cuotas.Capital);
                }
                else
                {
                    cuotas.BCE = cuotas.BCE  - (cuotas.Interes + cuotas.Capital); 
                    
                }
                if(i == 0)
                {
                    cuotasDetalles.Add(new CuotasDetalle(0, Utils.ToInt(PrestamoIdTextBox.Text), cuotas.Fecha, cuotas.Interes, cuotas.Capital, cuotas.MontoPorCuota, cuotas.BCE));
                }
                else
                    cuotasDetalles.Add(new CuotasDetalle(0, Utils.ToInt(PrestamoIdTextBox.Text), cuotas.Fecha.AddMonths(i), cuotas.Interes, cuotas.Capital, cuotas.MontoPorCuota, cuotas.BCE));

                ViewState["CuotasDetalle"] = cuotasDetalles;
                DatosGridView.DataSource = ViewState["CuotasDetalle"];
                DatosGridView.DataBind();
            }
            
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
                paso = repositorio.Guardar(prestamos);
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