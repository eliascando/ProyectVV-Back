using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Matricula
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long UserId { get; set; }
        public long TypeId { get; set; }
        public DateTime CreationTime { get; set; }
        public bool Status {  get; set; }
    }
}
