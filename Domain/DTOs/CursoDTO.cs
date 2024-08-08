using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CursoDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Parallel { get; set; }
        public string Cycle { get; set; }
        public decimal Price { get; set; }
        public decimal Hours { get; set; }
        public bool Status { get; set; }
        public long StudentsRegistered { get; set; }
    }
}
