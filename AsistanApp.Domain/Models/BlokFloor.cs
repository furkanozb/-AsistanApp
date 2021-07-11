using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class BlokFloor
    {
        public BlokFloor()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public int? BlokId { get; set; }
        public string Name { get; set; }

        public virtual Blok Blok { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
