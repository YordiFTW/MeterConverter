using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using test.Enums;

namespace test.Model
{
    public class Calculation
    {
        public int Id { get; set; }
        [Required]
        public double Waarde1 { get; set; }
        public double Waarde2 { get; set; }

        public int KeuzeId { get; set; }

        public string Error { get; set; }

        public KeuzeMenu KeuzeMenu { get; set; }

        public DateTime Datum { get; set; }
    }
}
