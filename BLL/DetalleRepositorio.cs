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

        public override bool Modificar(Prestamos Cuotas)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.Prestamos.Find(Cuotas.ID);
                foreach (var item in Anterior.Cuotas)
                {
                    if (!Cuotas.Cuotas.Exists(d => d.NumCuotas == item.NumCuotas))
                    { 
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in Cuotas.Cuotas)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(Cuotas).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
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
            try
            {
                Prestamos Cuotas = _contexto.Prestamos.Find(id);

                var Anterior = _contexto.Prestamos.Find(Cuotas.ID);
                foreach (var item in Anterior.Cuotas)
                {
                    if (!Cuotas.Cuotas.Exists(d => d.NumCuotas == item.NumCuotas))
                        _contexto.Entry(item).State = EntityState.Deleted;
                }

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
    }
}
