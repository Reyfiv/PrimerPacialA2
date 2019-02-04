using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Deposito
    {
        [Key]
        public int DepositoID { get; set; }
        public int CuentaID { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Deposito()
        {
            DepositoID = 0;
            CuentaID = 0;
            Concepto = string.Empty;
            Monto = 0;
            Fecha = DateTime.Now;
        }
    }
}
