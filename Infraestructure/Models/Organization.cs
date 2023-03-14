using System;
using System.Collections.Generic;

namespace Infraestructure.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Accounts = new HashSet<Account>();
            InverseOrganizationNavigation = new HashSet<Organization>();
            OrganizationsConcepts = new HashSet<OrganizationsConcept>();
        }

        public byte[] Id { get; set; } = null!;
        public byte[]? OrganizationId { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Organization? OrganizationNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Organization> InverseOrganizationNavigation { get; set; }
        public virtual ICollection<OrganizationsConcept> OrganizationsConcepts { get; set; }
    }
}
