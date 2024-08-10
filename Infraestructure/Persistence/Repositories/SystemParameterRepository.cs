using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class SystemParameterRepository : ISystemParameterRepository<SystemParameter, SystemParameterDetails>
    {
        private readonly VVContext _context;

        public SystemParameterRepository(VVContext context)
        {
            _context = context;
        }

        public List<SystemParameter> GetAll()
        {
            return _context.SystemParameters.Include(sp => sp.Details).ToList();
        }

        public SystemParameterDetails GetByDetailId(long id)
        {
            return _context.SystemParametersDetails.Where(spd => spd.Id == id).FirstOrDefault() ?? throw new Exception("No se encontró detalle!");
        }

        public SystemParameter GetById(long id)
        {
            return _context.SystemParameters.Where(sp => sp.Id == id).Include(sp => sp.Details).FirstOrDefault() ?? throw new Exception("No se encontró parametro");
        }

        public SystemParameter RegisterNew(SystemParameter entity)
        {
            _context.SystemParameters.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
