using Entite = DemoEF_Entite;
using DemoEF_DALApplicationDBContext.SQLServer.DTO;

namespace DemoEF_DALApplicationDBContext.SQLServer
{
    public class DepotAdresseEF : Entite.IDepotAdresse
    {
        private ApplicationDBContext m_dbContext;

        public DepotAdresseEF(ApplicationDBContext p_dbContext)
        {
            if (p_dbContext == null)
            {
                throw new ArgumentNullException(nameof(p_dbContext));
            }

            this.m_dbContext = p_dbContext;
        }

        public void AjouterAdresse(Entite.Adresse p_adresse)
        {
            if (p_adresse == null)
            {
                throw new ArgumentNullException(nameof(p_adresse));
            }

            Adresse adresse = new Adresse(p_adresse);
            adresse.AdresseId = 0;
            this.m_dbContext.Add(adresse);
            this.m_dbContext.SaveChanges();
            this.m_dbContext.ChangeTracker.Clear();
            p_adresse.AdresseId = adresse.AdresseId;

        }

        public void Dispose()
        {
            ; // le contexte sera ici disposé par le dispose de la transaction
        }

        public Entite.Adresse? Obtenir(int p_id)
        {
            return this.m_dbContext.Adresse.Where(a => a.AdresseId == p_id).Select(a => a.VersEntite()).SingleOrDefault();
        }

        public List<Entite.Adresse> RechercherAdresseParRequete(string p_partieNomVille)
        {
            if (p_partieNomVille is null)
            {
                throw new ArgumentNullException(nameof(p_partieNomVille));
            }

            return this.m_dbContext.Adresse.Where(a => a.Ville.Contains(p_partieNomVille)).Select(a => a.VersEntite()).ToList();
        }

        public List<Entite.Adresse> RechercherAdresseProcedureStockee(string p_partieNomVille)
        {
            if (p_partieNomVille is null)
            {
                throw new ArgumentNullException(nameof(p_partieNomVille));
            }

            return this.m_dbContext.ObtenirAdressesPourVilleContenant(p_partieNomVille).Select(a => a.VersEntite()).ToList();
        }
    }
}
