// See https://aka.ms/new-console-template for more information

using DemoEF_DALApplicationDBContext;
using DemoEF_Entite;
using DemoEF_Oracle;
using Microsoft.EntityFrameworkCore.Storage;

DemoObtenirPersonnesSansAdresse();
DemoObtenirPersonnesAvecAdresse();

DemoAjoutPersonneSansAdresse();
DemoAjoutPersonneAvecAdresse();
DemoAjoutPersonneAvecAdresseRollback();
DemoObtenirPersonnesSansAdresse();

DemoRechercherAdressesContenantUnMot();

void DemoObtenirPersonnesSansAdresse()
{
    Console.Out.WriteLine("DemoObtenirPersonnesSansAdresse");

    List<Personne>? personnesSansAdresse = null;
    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

        personnesSansAdresse = depotPersonne.ObtenirPersonnes(inclureAdresse: false);
    }

    personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
    Console.Out.WriteLine();
}

void DemoObtenirPersonnesAvecAdresse()
{
    Console.Out.WriteLine("DemoObtenirPersonnesAvecAdresse");

    List<Personne>? personnesAvecAdresse = null;
    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

        personnesAvecAdresse = depotPersonne.ObtenirPersonnes(inclureAdresse: true);
    }

    personnesAvecAdresse?.ForEach(p => Console.Out.WriteLine(p));
    Console.Out.WriteLine();
}

void DemoAjoutPersonneSansAdresse()
{
    Console.Out.WriteLine("DemoAjoutPersonneSansAdresse");

    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                Personne personneSansAdresse = GenerateurDonnees.GenererPersonne(false);

                Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneSansAdresse.PersonneId}");
                depotPersonne.AjouterPersonne(personneSansAdresse);

                transaction.Commit();
                Console.Out.WriteLine("Transaction confirmée !");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.Out.WriteLine("Transaction annulée !");
                Console.Error.WriteLine(ex.Message);
            }
        }
    }

    Console.Out.WriteLine();
}

void DemoAjoutPersonneAvecAdresse()
{
    Console.Out.WriteLine("DemoAjoutPersonneAvecAdresse");

    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotAdresse depotAdresse = new DepotAdresseEF(dbContext);
        IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(true);
                Adresse? adresse = personneAvecAdresse.AdresseActuelle;
                personneAvecAdresse.AdresseActuelle = null;

                Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
                depotPersonne.AjouterPersonne(personneAvecAdresse);
                if (adresse is not null)
                {
                    depotAdresse.AjouterAdresse(adresse);
                }
                personneAvecAdresse.AdresseActuelle = adresse;
                depotPersonne.MAJPersonne(personneAvecAdresse);

                transaction.Commit();
                Console.Out.WriteLine("Transaction confirmée !");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.Out.WriteLine("Transaction annulée !");
                Console.Error.WriteLine(ex.Message);
            }
        }
    }

    Console.Out.WriteLine();
}

void DemoAjoutPersonneAvecAdresseRollback()
{
    Console.Out.WriteLine("DemoAjoutPersonneAvecAdresseRollback");

    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotAdresse depotAdresse = new DepotAdresseEF(dbContext);
        IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(true);
                Adresse? adresse = personneAvecAdresse.AdresseActuelle;
                personneAvecAdresse.AdresseActuelle = null;

                Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
                depotPersonne.AjouterPersonne(personneAvecAdresse);
                if (adresse is not null)
                {
                    depotAdresse.AjouterAdresse(adresse);
                }
                personneAvecAdresse.AdresseActuelle = adresse;
                depotPersonne.MAJPersonne(personneAvecAdresse);

                Console.Out.WriteLine($"Personne qui va être annulée : {personneAvecAdresse.PersonneId} avec adresse : {adresse.AdresseId}");

                throw new Exception("Simulation erreur !");

                transaction.Commit();
                Console.Out.WriteLine("Transaction confirmée !");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.Out.WriteLine("Transaction annulée !");
                Console.Error.WriteLine(ex.Message);
            }
        }
    }

    Console.Out.WriteLine();
}

void DemoRechercherAdressesContenantUnMot()
{
    Console.Out.WriteLine("DemoRechercherAdressesContenantUnMot");

    using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    {
        IDepotAdresse depotAdresse = new DepotAdresseEF(dbContext);

        Console.Out.WriteLine("RechercherAdresseParRequete");
        List<Adresse> adressesParRequete = depotAdresse.RechercherAdresseParRequete("é");
        adressesParRequete.ForEach(a => Console.Out.WriteLine(a));
        
        Console.Out.WriteLine("RechercherAdresseProcedureStockee");
        List<Adresse> adressesParProcedureStockee = depotAdresse.RechercherAdresseProcedureStockee("é");
        adressesParProcedureStockee.ForEach(a => Console.Out.WriteLine(a));
    }

    Console.Out.WriteLine();
}