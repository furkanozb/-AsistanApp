using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Indent
    {
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public int? ApartmentId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Apartment Payment { get; set; }
        public virtual Payment PaymentNavigation { get; set; }
    }
}
