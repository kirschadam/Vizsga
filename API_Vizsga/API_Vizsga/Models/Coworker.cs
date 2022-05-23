using System;
using System.Collections.Generic;

#nullable disable

namespace API_Vizsga.Models
{
    public partial class Coworker
    {
        public Coworker()
        {
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}
