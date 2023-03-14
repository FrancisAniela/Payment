using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Models
{
    public partial class DbPayContext : DbContext
    {
        private string _connectionString;
        public DbPayContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbPayContext()
        {
        }

        public DbPayContext(DbContextOptions<DbPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Concept> Concepts { get; set; } = null!;
        public virtual DbSet<Income> Incomes { get; set; } = null!;
        public virtual DbSet<Movement> Movements { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<OrganizationsConcept> OrganizationsConcepts { get; set; } = null!;
        public virtual DbSet<Outcome> Outcomes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.AccountId, "account_FK");

                entity.HasIndex(e => e.OrganizationId, "account_organization_FK");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.AccountId)
                    .HasMaxLength(16)
                    .HasColumnName("account_id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrganizationId)
                    .HasMaxLength(16)
                    .HasColumnName("organization_id")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.InverseAccountNavigation)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("accounts_FK");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts_organization_FK");
            });

            modelBuilder.Entity<Concept>(entity =>
            {
                entity.ToTable("concepts");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("incomes");

                entity.HasIndex(e => e.ConceptId, "income_concept_FK");

                entity.HasIndex(e => e.MovementId, "income_movement_FK");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");

                entity.Property(e => e.ConceptId)
                    .HasMaxLength(1)
                    .HasColumnName("concept_id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.MovementId)
                    .HasMaxLength(16)
                    .HasColumnName("movement_id")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Concept)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.ConceptId)
                    .HasConstraintName("incomes_concepts_FK");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.MovementId)
                    .HasConstraintName("incomes_FK");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.ToTable("movements");

                entity.HasIndex(e => e.AccountId, "movements_FK");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.AccountId)
                    .HasMaxLength(16)
                    .HasColumnName("account_id")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movements_FK");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organizations");

                entity.HasIndex(e => e.OrganizationId, "organization_FK");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.OrganizationId)
                    .HasMaxLength(16)
                    .HasColumnName("organization_id")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.OrganizationNavigation)
                    .WithMany(p => p.InverseOrganizationNavigation)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("organizations_FK");
            });

            modelBuilder.Entity<OrganizationsConcept>(entity =>
            {
                entity.ToTable("organizations_concepts");

                entity.HasIndex(e => e.ConceptId, "concept_organization_FK");

                entity.HasIndex(e => e.OrganizationId, "organization_concept_FK_1");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.ConceptId)
                    .HasMaxLength(16)
                    .HasColumnName("concept_id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.OrganizationId)
                    .HasMaxLength(16)
                    .HasColumnName("organization_id")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Concept)
                    .WithMany(p => p.OrganizationsConcepts)
                    .HasForeignKey(d => d.ConceptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organizations_concepts_FK_1");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationsConcepts)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organizations_concepts_FK");
            });

            modelBuilder.Entity<Outcome>(entity =>
            {
                entity.ToTable("outcomes");

                entity.HasIndex(e => e.ConceptId, "outcome_concept_FK_1");

                entity.HasIndex(e => e.MovementId, "outcome_movement_FK");

                entity.Property(e => e.Id)
                    .HasMaxLength(16)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");

                entity.Property(e => e.ConceptId)
                    .HasMaxLength(16)
                    .HasColumnName("concept_id")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.MovementId)
                    .HasMaxLength(16)
                    .HasColumnName("movement_id")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Concept)
                    .WithMany(p => p.Outcomes)
                    .HasForeignKey(d => d.ConceptId)
                    .HasConstraintName("outcomes_FK_1");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.Outcomes)
                    .HasForeignKey(d => d.MovementId)
                    .HasConstraintName("outcomes_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
