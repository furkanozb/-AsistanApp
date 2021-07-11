using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class PaymentCategory
    {
        public PaymentCategory()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
