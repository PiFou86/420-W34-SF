using DemoEF_Entite;

namespace DemoEF_CasUtilisation;

public class ManipulationPersonnes : IDisposable
{
    private readonly IDepotPersonne m_depotPersonne;
    private readonly IDepotAdresse m_depotAdresse;
    private readonly ITransactionBD m_transaction;

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

        if (this.m_depotPersonne.ObtenirPersonne(p_personne.PersonneId) is not null)
        {
            throw new InvalidOperationException($"La personne d'identifiant {p_personne.PersonneId} existe déjà !");
        }

        if (!this.EstPersonneValide(p_personne))
        {
            throw new ArgumentOutOfRangeException(nameof(p_personne));
        }

        try
        {
            Console.Out.WriteLine("Ajout d'une personne !");

            this.m_transaction.BeginTransaction();
            Adresse? adresse = p_personne.AdresseActuelle;
            p_personne.AdresseActuelle = null;
            this.m_depotPersonne.AjouterPersonne(p_personne);
            p_personne.AdresseActuelle = adresse;
            if (p_personne.AdresseActuelle is not null)
            {
                Adresse? adresseBD = this.m_depotAdresse.Obtenir(p_personne.AdresseActuelle.AdresseId);
                if (adresseBD is null)
                {
                    p_personne.AdresseActuelle.ProprietaireAdresseId = p_personne.PersonneId;
                    this.m_depotAdresse.AjouterAdresse(p_personne.AdresseActuelle);
                }

                this.m_depotPersonne.MAJPersonne(p_personne);
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

    private bool EstPersonneValide(Personne p_personne)
    {
        // Valider la personne et l'adresse si disponible
        // Exemple de validations : valider que le code postal est bien dans la ville visée. Valider que la ville existe, etc.
        // Les validations peuvent se faire en utilisant un autre dépot par exemple.
        return true;
    }

    public void MAJPersonne(Personne p_personne)
    {
        if (p_personne is null)
        {
            throw new ArgumentNullException(nameof(p_personne));
        }

        if (this.m_depotPersonne.ObtenirPersonne(p_personne.PersonneId) is null)
        {
            throw new InvalidOperationException($"La personne d'identifiant {p_personne.PersonneId} n'existe pas !");
        }

        if (!this.EstPersonneValide(p_personne))
        {
            throw new ArgumentOutOfRangeException(nameof(p_personne));
        }

        try
        {
            this.m_transaction.BeginTransaction();
            Adresse? adresse = p_personne.AdresseActuelle;
            if (adresse is not null)
            {
                Adresse? adresseBD = this.m_depotAdresse.Obtenir(adresse.AdresseId);
                if (adresseBD is null)
                {
                    this.m_depotAdresse.AjouterAdresse(adresse);
                }

            }

            this.m_depotPersonne.MAJPersonne(p_personne);

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
