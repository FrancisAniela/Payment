using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class Concept
    {
        public Concept()
        {
            Incomes = new HashSet<Income>();
            OrganizationsConcepts = new HashSet<OrganizationsConcept>();
            Outcomes = new HashSet<Outcome>();
        }

        public byte[] Id { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<OrganizationsConcept> OrganizationsConcepts { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; }
    }
}
