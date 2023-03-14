using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class OrganizationsConcept
    {
        public byte[] Id { get; set; } = null!;
        public byte[] ConceptId { get; set; } = null!;
        public byte[] OrganizationId { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Concept Concept { get; set; } = null!;
        public virtual Organization Organization { get; set; } = null!;
    }
}
