using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LicensePlate { get; set; }
        public string Description { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
