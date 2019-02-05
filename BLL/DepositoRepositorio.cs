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
                    _contexto.Cuenta.Find(entity.CuentaID).Balance += entity.Monto;
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
                _contexto.Cuenta.Find(entity.CuentaID).Balance -= entity.Monto;
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

    }

    
}
 