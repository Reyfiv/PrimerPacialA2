using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Serializable]
    public class CuotasDetalle
    {
        [Key]
        public int NumCuotas { get; set; }
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal MontoPorCuota { get; set; }
        public decimal BCE { get; set; }

        [ForeignKey("ID")]
        public virtual Prestamos Prestamos { get; set; }

        public CuotasDetalle()
        {
            NumCuotas = 0;
            ID = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            MontoPorCuota = 0;
            BCE = 0;
        }

        public CuotasDetalle(int numCuotas,int id, DateTime fecha, decimal interes, decimal capital,decimal montoPorCuota, decimal bce)
        {
            NumCuotas = numCuotas;
            ID = id;
            Fecha = fecha;
            Interes = interes;
            Capital = capital;
            MontoPorCuota = montoPorCuota;
            BCE = bce;
        }
    }
}
