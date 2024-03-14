using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPartTwo.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string ChassisNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public virtual Engine Engine { get; set; }
    }
}

