using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Serializable]
    public class Cuenta
    {
        [Key]
        public int CuentaID { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }
        public DateTime Fecha { get; set; }

        public Cuenta()
        {
            CuentaID = 0;
            Nombre = string.Empty;
            Balance = 0;
            Fecha = DateTime.Now;
        }
    }
}
