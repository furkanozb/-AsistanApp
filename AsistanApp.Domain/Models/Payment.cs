using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Indents = new HashSet<Indent>();
        }

        public int Id { get; set; }
        public int? PaymentCategoryId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedPaymentDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public virtual PaymentCategory PaymentCategory { get; set; }
        public virtual ICollection<Indent> Indents { get; set; }
    }
}
