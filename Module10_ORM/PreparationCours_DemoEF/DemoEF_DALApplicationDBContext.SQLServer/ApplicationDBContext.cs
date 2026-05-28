using DemoEF_DALApplicationDBContext.SQLServer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;

namespace DemoEF_DALApplicationDBContext.SQLServer
{
    public class ApplicationDBContext : DbContext, ITransactionBD
    {
        private IDbContextTransaction? m_transaction;
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Console.Out.WriteLine("ApplicationDBContext.ctor(...)");
        }

        // Ajout pour EF 7 et 8
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .ToTable(tb => tb.HasTrigger("TR_PersonneU_Historisation"));

            base.OnModelCreating(modelBuilder);

        }

        // Éviter les problèmes de null : https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
        // Utilisation de la nouvelle syntaxe C# 8 pour les propriétés de navigation : https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#navigation-properties
        // et définitions : https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties#required-properties
        public required DbSet<Personne> Personne {get; set; }
        public required DbSet<Adresse> Adresse {get; set; }

        public List<Adresse> ObtenirAdressesPourVilleContenant(string p_partieNomVille)
        {
            return this.Adresse.FromSqlRaw("EXECUTE Obtenir_Adresses_Ville_Contenant {0};", p_partieNomVille).ToList();
        }

        public void BeginTransaction()
        {
            if (this.m_transaction is not null)
            {
                throw new InvalidOperationException("Une transaction est déjà débutée");
            }
            this.m_transaction = this.Database.BeginTransaction();
        }

        // Non obligatoire, on le fera seulement si on veut des transactions explicites dans les méthodes du repository
        public void Commit()
        {
            if (this.m_transaction is null)
            {
                throw new InvalidOperationException("Une transaction doit être débutée");
            }
            this.m_transaction.Commit();
            this.m_transaction?.Dispose();
            this.m_transaction = null;
        }

        public void Rollback()
        {
            if (this.m_transaction is null)
            {
                throw new InvalidOperationException("Une transaction doit être débutée");
            }
            this.m_transaction.Rollback();
            this.m_transaction?.Dispose();
            this.m_transaction = null;
        }

        public override void Dispose()
        {
            Console.Out.WriteLine("ApplicationDBContext.Dispose");
            this.m_transaction?.Dispose();
            this.m_transaction = null;
            base.Dispose();
        }
    }
}
