﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class NewMatriculaDTO
    {
        public long CourseId { get; set; }
        public long UserId { get; set; }
        public long TypeId { get; set; }
    }
}
