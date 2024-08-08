using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UpdateCursoDTO
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Hours { get; set; }
    }
}
