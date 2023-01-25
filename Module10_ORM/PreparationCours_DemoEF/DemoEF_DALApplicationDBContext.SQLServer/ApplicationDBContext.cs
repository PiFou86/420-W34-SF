using DemoEF_DALApplicationDBContext.SQLServer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoEF_DALApplicationDBContext.SQLServer
{
    public class ApplicationDBContext : DbContext, ITransactionBD
    {
        private IDbContextTransaction? m_transaction;
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            ;
        }

        // Éviter les problèmes de null : https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
        public DbSet<Personne> Personne => Set<Personne>(); // { get; set; }
        public DbSet<Adresse> Adresse => Set<Adresse>();  // { get; set; }

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
            this.m_transaction?.Dispose();
            this.m_transaction = null;
            base.Dispose();
        }
    }
}
