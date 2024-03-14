using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPartTwo.Model
{
    public class EngineType
    {
        public int EngineTypeId { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Engine> Engines { get; set; }

        public EngineType()
        {
            Engines = new HashSet<Engine>();
        }
    }
}
