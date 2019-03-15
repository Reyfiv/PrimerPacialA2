using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleRepositorio : RepositorioBase<Prestamos>
    {
        public override Prestamos Buscar(int id)
        {
            Prestamos Cuotas = new Prestamos();
            try
            {
                Cuotas = _contexto.Prestamos.Find(id);
                if (Cuotas != null)
                {
                    Cuotas.Cuotas.Count();
                    foreach (var item in Cuotas.Cuotas)
                    {
                        //int a = item.NumCuotas;
                        //int b = item.ID;
                        //DateTime c = item.Fecha;
                        //decimal d = item.Interes;
                        //decimal e = item.Capital;
                        //decimal f = item.BCE;
                    }
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return Cuotas;
        }

        public override bool Modificar(Prestamos prestamos)
        {
            bool paso = false;
            decimal monto = 0;
            decimal montoAnterior = 0; 
            try
            {
                //Buscamos la Detalle(cuota) anterior convertiendola en una lista
                //OJO:AsNoTracking() sirve para que el conetexto no le de seguimiento a la entidad y hacer porder manipular su estado.
                var DetalleAnterior = _contexto.Cuotas.Where(x => x.ID == prestamos.ID).AsNoTracking().ToList();
                //Afectando la tabla de cuentas
                foreach (var item in DetalleAnterior)
                {
                    montoAnterior += item.MontoPorCuota;
                }
                _contexto.Cuenta.Find(prestamos.CuentaId).Balance -= montoAnterior;
                foreach (var item in prestamos.Cuotas)
                {
                    monto += item.MontoPorCuota;
                }
                _contexto.Cuenta.Find(prestamos.CuentaId).Balance += monto;

                //Marcamos como eleminado las celdas que sobran en el Detalle(Cuotas) Anterior de la base de datos
                foreach (var item in DetalleAnterior)
                {
                    if (!prestamos.Cuotas.Exists(x => x.NumCuotas.Equals(item.NumCuotas)))
                    {
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                //Modificamos o agregamos las celdas que necesitamos con los nuevos datos 
                //OJO: No modificar el item directamente despues de cambiarle el estado
                //porque al dar la segunda vuelta dara un error de que la entidad a sido modicada.
                foreach (var item in prestamos.Cuotas)
                {
                    _contexto.Entry(item).State = item.NumCuotas == 0 ? EntityState.Added : EntityState.Modified;
                }

                //Modificamos la entediad completa
                _contexto.Entry(prestamos).State = EntityState.Modified;
                //Guardamos los Cambios 
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            decimal monto = 0;
            try
            {
                Prestamos Cuotas = _contexto.Prestamos.Find(id);

                var Anterior = _contexto.Prestamos.Find(Cuotas.ID);
                foreach (var item in Anterior.Cuotas)
                {
                    if (!Cuotas.Cuotas.Exists(d => d.NumCuotas == item.NumCuotas))
                        _contexto.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in Cuotas.Cuotas)
                {
                    monto -= item.MontoPorCuota;
                }
                _contexto.Cuenta.Find(Cuotas.CuentaId).Balance += monto;
                _contexto.Prestamos.Remove(Cuotas);

                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Guardar(Prestamos entity)
        {
            bool paso = false;
            decimal monto = 0;
            _contexto = new DAL.Contexto();
            try
            {
                foreach (var item in entity.Cuotas)
                {
                    monto += item.MontoPorCuota;
                }
                _contexto.Cuenta.Find(entity.CuentaId).Balance += monto;
                _contexto.Prestamos.Add(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
