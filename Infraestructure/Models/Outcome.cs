using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class Outcome
    {
        public byte[] Id { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[]? ConceptId { get; set; }
        public byte[]? MovementId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Concept? Concept { get; set; }
        public virtual Movement? Movement { get; set; }
    }
}
