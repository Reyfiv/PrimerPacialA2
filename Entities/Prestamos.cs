using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Prestamos
    {
        public int ID { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal InteresAnual { get; set; }
        public int TiempoMeses { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<CuotasDetalle> Cuotas { get; set; }
        public decimal Total { get; set; }

        public Prestamos()
        {
            ID = 0;
            CuentaId = 0;
            Capital = 0;
            InteresAnual = 0;
            TiempoMeses = 0;
            Fecha = DateTime.Now;
            this.Cuotas = new List<CuotasDetalle>();
            Total = 0;
        }

        public void AgregarDetalle(int numCuotas, DateTime fecha, decimal interes, decimal capital, decimal bce)
        {
            this.Cuotas.Add(new CuotasDetalle(numCuotas, fecha, interes, capital, bce));
        }
    }
}