using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BLL
{
    public class DepositoRepositorio : RepositorioBase<Deposito>
    {
        
        public override bool Guardar(Deposito entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<Deposito>().Add(entity) != null)
                {
                    _contexto.Cuenta.Find(entity.CuentaID).Balance -= entity.Monto;
                    _contexto.SaveChanges();
                    paso = true;
                }
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
                Deposito entity = _contexto.Set<Deposito>().Find(id);
                _contexto.Cuenta.Find(entity.CuentaID).Balance += entity.Monto;
                _contexto.Set<Deposito>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(Deposito entity)
        {
            bool paso = false;
            RepositorioBase < Deposito> repositorio = new RepositorioBase<Deposito>();
            try
            {
                var depositosanterior = repositorio.Buscar(entity.DepositoID);

                var Cuenta = _contexto.Cuenta.Find(entity.CuentaID);
                var Cuentasanterior = _contexto.Cuenta.Find(depositosanterior.CuentaID);

                if (entity.CuentaID != depositosanterior.CuentaID)
                {
                    Cuenta.Balance -= entity.Monto;
                    Cuentasanterior.Balance -= depositosanterior.Monto;
                }

                decimal diferencia;
                diferencia = entity.Monto - depositosanterior.Monto;
                Cuenta.Balance -= diferencia;

                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

    }

}
 