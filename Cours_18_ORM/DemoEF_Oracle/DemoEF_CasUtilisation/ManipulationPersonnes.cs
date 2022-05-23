using DemoEF_Entite;

namespace DemoEF_CasUtilisation;

public class ManipulationPersonnes : IDisposable
{
    private IDepotPersonne m_depotPersonne;
    private IDepotAdresse m_depotAdresse;
    private ITransactionBD m_transaction;

    public ManipulationPersonnes(IDepotPersonne p_depotPersonne, IDepotAdresse p_depotAdresse, ITransactionBD p_transaction)
    {
        this.m_depotPersonne = p_depotPersonne;
        this.m_depotAdresse = p_depotAdresse;
        this.m_transaction = p_transaction;
    }

    public List<Personne> ObtenirPersonnes(bool inclureAdresse = false)
    {
        List<Personne> personnes = this.m_depotPersonne.ObtenirPersonnes(inclureAdresse);

        return personnes;
    }

    public void AjouterPersonne(Personne p_personne)
    {
        if (p_personne is null)
        {
            throw new ArgumentNullException(nameof(p_personne));
        }

        try
        {
            this.m_transaction.BeginTransaction();

            this.m_depotPersonne.AjouterPersonne(p_personne);
            if (p_personne.AdresseActuelle is not null)
            {
                this.m_depotAdresse.AjouterAdresse(p_personne.AdresseActuelle);
            }

            this.m_transaction.Commit();
            Console.Out.WriteLine("Transaction confirmée !");
        }
        catch (System.Exception ex)
        {
            Console.Out.WriteLine("Transaction annulée !");
            Console.Error.WriteLine(ex.Message);
            this.m_transaction.Rollback();

            throw;
        }
    }

    public void MAJPersonne(Personne p_personne)
    {
        if (p_personne is null)
        {
            throw new ArgumentNullException(nameof(p_personne));
        }

        try
        {
            this.m_transaction.BeginTransaction();

            this.m_depotPersonne.MAJPersonne(p_personne);
            if (p_personne.AdresseActuelle is not null)
            {
                Adresse? adresse = this.m_depotAdresse.Obtenir(p_personne.AdresseActuelle.AdresseId);
                if (adresse is null)
                {
                    this.m_depotAdresse.AjouterAdresse(p_personne.AdresseActuelle);
                }
            }

            this.m_transaction.Commit();
            Console.Out.WriteLine("Transaction confirmée !");
        }
        catch (System.Exception ex)
        {
            Console.Out.WriteLine("Transaction annulée !");
            Console.Error.WriteLine(ex.Message);
            this.m_transaction.Rollback();

            throw;
        }
    }

    public List<Adresse> RechercherAdresseParRequete(string p_partieNomVille)
    {
        if (p_partieNomVille is null)
        {
            throw new ArgumentNullException(nameof(p_partieNomVille));
        }

        return this.m_depotAdresse.RechercherAdresseParRequete(p_partieNomVille);
    }

    public List<Adresse> RechercherAdresseProcedureStockee(string p_partieNomVille)
    {
        if (p_partieNomVille is null)
        {
            throw new ArgumentNullException(nameof(p_partieNomVille));
        }

        return this.m_depotAdresse.RechercherAdresseProcedureStockee(p_partieNomVille);
    }

    public void Dispose()
    {
        this.m_depotAdresse?.Dispose();
        this.m_depotPersonne?.Dispose();
        this.m_transaction?.Dispose();
    }
}
