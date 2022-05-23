using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_Vizsga.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public int Brand { get; set; }
        public int Type { get; set; }
        public int CoworkerId { get; set; }

        [JsonIgnore]
        public virtual Coworker Coworker { get; set; }
    }
}
