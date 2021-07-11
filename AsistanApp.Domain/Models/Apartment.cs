using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            Indents = new HashSet<Indent>();
        }

        public int Id { get; set; }
        public bool? FullOrEmpty { get; set; }
        public int? FloorId { get; set; }
        public int? NumberOfRoomId { get; set; }
        public string UserId { get; set; }
        public bool? HostOrTenant { get; set; }

        public virtual BlokFloor Floor { get; set; }
        public virtual NumberOfRoom NumberOfRoom { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<Indent> Indents { get; set; }
    }
}
