using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class NumberOfRoom
    {
        public NumberOfRoom()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
