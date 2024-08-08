using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Calificacion
    {
        public long Id { get; set; }
        public long MatriculaId { get; set; }
        public decimal Grade { get; set; }
        public long GradeType { get; set; }
        public long GradePeriodId {  get; set; }
        public bool Status { get; set; }
    }
}
