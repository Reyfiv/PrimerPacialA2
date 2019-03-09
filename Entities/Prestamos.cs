using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Serializable]
    public class Prestamos
    {
        [Key]
        public int ID { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal InteresAnual { get; set; }
        public int TiempoMeses { get; set; }
        public decimal TotalARetornar { get; set; }
        public DateTime FechaInicio { get; set; }
        public virtual List<CuotasDetalle> Cuotas { get; set; }

        public Prestamos()
        {
            ID = 0;
            CuentaId = 0;
            Capital = 0;
            InteresAnual = 0;
            TiempoMeses = 0;
            FechaInicio = DateTime.Now;
            this.Cuotas = new List<CuotasDetalle>();

        }

    }
}