﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IAuthRepository<T>
    {
        T GetByNumberIdentification(string id);
        string GetRoleName(string id);
    }
}
