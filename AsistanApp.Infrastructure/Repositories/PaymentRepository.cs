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
    public class PaymentRepository: Repository<Payment>,IPaymentRepository
    {
        public PaymentRepository(AsistanAppDbContext context) : base(context)
        {

        }
    }
}
