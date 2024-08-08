using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<T, TRegister, TUpdate>
    {
        T Register(TRegister register);
        bool Inactivate(long id);
        T UpdateInfo(long id, TUpdate update);
    }
}
