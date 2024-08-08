using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Curso
    {
        public long Id {  get; set; }
        public string Description {  get; set; }
        public string Parallel { get; set; }
        public long CycleId { get; set; }
        public decimal Price {  get; set; }
        public decimal Hours {  get; set; }
        public bool Status { get; set; }
    }
}
