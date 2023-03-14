using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class Account
    {
        public Account()
        {
            InverseAccountNavigation = new HashSet<Account>();
            Movements = new HashSet<Movement>();
        }

        public byte[] Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[] OrganizationId { get; set; } = null!;
        public byte[]? AccountId { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Account? AccountNavigation { get; set; }
        public virtual Organization Organization { get; set; } = null!;
        public virtual ICollection<Account> InverseAccountNavigation { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }
    }
}
