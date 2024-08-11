using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class NewCalificacionDTO
    {
        public long idUsuario {  get; set; }
        public long idCurso { get; set; }
        public decimal calificacion {  get; set; }
        public long periodoCalificacion { get; set; }
        public long tipoCalificacion { get; set; }
    }
}
