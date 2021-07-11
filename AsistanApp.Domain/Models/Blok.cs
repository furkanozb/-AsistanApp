using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Blok
    {
        public Blok()
        {
            BlokFloors = new HashSet<BlokFloor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BlokFloor> BlokFloors { get; set; }
    }
}
