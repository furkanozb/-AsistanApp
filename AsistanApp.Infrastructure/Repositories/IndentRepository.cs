using AsistanApp.Domain.Interfaces;
using AsistanApp.Domain.Models;
using AsistanApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistanApp.Infrastructure.Repositories
{
    public class IndentRepository:Repository<Indent>, IIndentRepository
    {
        public IndentRepository(AsistanAppDbContext context) : base(context)
        {

        }
    }
}
