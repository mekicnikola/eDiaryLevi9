using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPartTwo.Model
{
    public class Engine
    {
        public int EngineId { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }

        public virtual Car Car { get; set; }

        public int EngineTypeId { get; set; }
        public virtual EngineType EngineType { get; set; }
    }
}
