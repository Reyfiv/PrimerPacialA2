using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class CuotasDetalle
    {
        public int NumCuotas { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal BCE { get; set; }

        public CuotasDetalle()
        {
            NumCuotas = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            BCE = 0;
        }

        public CuotasDetalle(int numCuotas, DateTime fecha, decimal interes, decimal capital, decimal bce)
        {
            NumCuotas = numCuotas;
            Fecha = fecha;
            Interes = interes;
            Capital = capital;
            BCE = bce;
        }
    }
}
