using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class Movement
    {
        public Movement()
        {
            Incomes = new HashSet<Income>();
            Outcomes = new HashSet<Outcome>();
        }

        public byte[] Id { get; set; } = null!;
        public byte[] AccountId { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal? Amount { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Outcome> Outcomes { get; set; }
    }
}
