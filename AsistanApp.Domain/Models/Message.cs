using System;
using System.Collections.Generic;

#nullable disable

namespace AsistanApp.Domain.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string WriterUserId { get; set; }
        public string RecipientId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual AspNetUser Recipient { get; set; }
        public virtual AspNetUser WriterUser { get; set; }
    }
}
