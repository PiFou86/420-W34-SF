using DemoEF_Entite;
using DemoEF_Oracle;
using DemoEF_CasUtilisation;

IManipulationPersonneFactory manipulationPersonneFactory = new ManipulationPersonneFactory();

// Projection de données de la BD
DemoObtenirPersonnesSansAdresse();
DemoObtenirPersonnesAvecAdresse();

// Ajout de personnes (INSERT)
DemoAjoutPersonneSansAdresse();
DemoAjoutPersonneAvecAdresse();
DemoAjoutPersonneAvecAdresseRollback();
DemoObtenirPersonnesSansAdresse();

// Appel de fonction SQL
DemoRechercherAdressesContenantUnMot();

void DemoObtenirPersonnesSansAdresse()
{
    Console.Out.WriteLine("DemoObtenirPersonnesSansAdresse");

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        List<Personne>? personnesSansAdresse = mp.ObtenirPersonnes(inclureAdresse: false);

        personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
    }
    Console.Out.WriteLine();
}

void DemoObtenirPersonnesAvecAdresse()
{
    Console.Out.WriteLine("DemoObtenirPersonnesAvecAdresse");

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        List<Personne>? personnesSansAdresse = mp.ObtenirPersonnes(inclureAdresse: true);

        personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
    }
    Console.Out.WriteLine();
}

void DemoAjoutPersonneSansAdresse()
{
    Console.Out.WriteLine("DemoAjoutPersonneSansAdresse");

    Personne personneSansAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: false);
    Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneSansAdresse.PersonneId}");
    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        mp.AjouterPersonne(personneSansAdresse);
    }

    Console.Out.WriteLine();
}

void DemoAjoutPersonneAvecAdresse()
{
    Console.Out.WriteLine("DemoAjoutPersonneAvecAdresse");

    Personne personneSansAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
    Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneSansAdresse.PersonneId}");
    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        mp.AjouterPersonne(personneSansAdresse);
    }

    Console.Out.WriteLine();
    // using (ApplicationDBContext dbContext = DALDbContextGeneration.ObtenirApplicationDBContext())
    // {
    //     IDepotAdresse depotAdresse = new DepotAdresseEF(dbContext);
    //     IDepotPersonne depotPersonne = new DepotPersonneEF(dbContext);

    //     using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
    //     {
    //         try
    //         {
    //             Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(true);
    //             Adresse? adresse = personneAvecAdresse.AdresseActuelle;
    //             personneAvecAdresse.AdresseActuelle = null;

    //             Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
    //             depotPersonne.AjouterPersonne(personneAvecAdresse);
    //             if (adresse is not null)
    //             {
    //                 depotAdresse.AjouterAdresse(adresse);
    //             }
    //             personneAvecAdresse.AdresseActuelle = adresse;
    //             depotPersonne.MAJPersonne(personneAvecAdresse);

    //             transaction.Commit();
    //             Console.Out.WriteLine("Transaction confirmée !");
    //         }
    //         catch (Exception ex)
    //         {
    //             transaction.Rollback();
    //             Console.Out.WriteLine("Transaction annulée !");
    //             Console.Error.WriteLine(ex.Message);
    //         }
    //     }
    // }
}

void DemoAjoutPersonneAvecAdresseRollback()
{
    Console.Out.WriteLine("DemoAjoutPersonneAvecAdresseRollback");

    Personne personneSansAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
    Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneSansAdresse.PersonneId}");
    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        mp.AjouterPersonne(personneSansAdresse);
    }

    Console.Out.WriteLine();
}

void DemoRechercherAdressesContenantUnMot()
{
    Console.Out.WriteLine("DemoRechercherAdressesContenantUnMot");

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        Console.Out.WriteLine("RechercherAdresseParRequete");
        List<Adresse> adressesParRequete = mp.RechercherAdresseParRequete("é");
        adressesParRequete.ForEach(a => Console.Out.WriteLine(a));

        Console.Out.WriteLine("RechercherAdresseProcedureStockee");
        List<Adresse> adressesParProcedureStockee = mp.RechercherAdresseProcedureStockee("é");
        adressesParProcedureStockee.ForEach(a => Console.Out.WriteLine(a));
    }

    Console.Out.WriteLine();
}