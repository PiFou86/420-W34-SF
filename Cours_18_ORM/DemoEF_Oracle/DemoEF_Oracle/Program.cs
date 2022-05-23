using DemoEF_Entite;
using DemoEF_Oracle;
using DemoEF_CasUtilisation;

IManipulationPersonneFactory manipulationPersonneFactory = new ManipulationPersonneFactory();

// Projection de données de la BD
DemoObtenirPersonnesSansRecupererAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();

// Ajout de personnes (INSERT)
DemoAjoutPersonneSansAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();
Console.In.ReadLine();

DemoAjoutPersonneAvecAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();
Console.In.ReadLine();
DemoAjoutPersonneAvecAdresseRollback();
DemoObtenirPersonnesEnRecuperantAdresses();
Console.In.ReadLine();

// Appel de fonction SQL
DemoRechercherAdressesContenantUnMot();
Console.In.ReadLine();

// Modification d'une personne (adresse ici)
DemoModificationPersonneAvecAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();

void DemoObtenirPersonnesSansRecupererAdresse()
{
    Console.Out.WriteLine("DemoObtenirPersonnesSansRecupererAdresse");

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        List<Personne>? personnesSansAdresse = mp.ObtenirPersonnes(inclureAdresse: false);

        personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
    }
    Console.Out.WriteLine();
}

void DemoObtenirPersonnesEnRecuperantAdresses()
{
    Console.Out.WriteLine("DemoObtenirPersonnesEnRecuperantAdresses");

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

    Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
    Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");

    try
    {
        using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
        {
            mp.AjouterPersonne(personneAvecAdresse);
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
        Console.Error.WriteLine(ex.Message);
    }

    Console.Out.WriteLine();
}

void DemoAjoutPersonneAvecAdresseRollback()
{
    Console.Out.WriteLine("DemoAjoutPersonneAvecAdresseRollback");

    Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
    Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
    try
    {
        using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
        {
            // Le code affaire ne devrait pas permettre au code d'aller jusqu'a la couche de persistance normalement mais le permet ici pour l'exemple
            personneAvecAdresse.AdresseActuelle = new Adresse(0, 0, null!, null!, null!);
            mp.AjouterPersonne(personneAvecAdresse);
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
        Console.Error.WriteLine(ex.Message);
    }

    Console.Out.WriteLine();
}

void DemoModificationPersonneAvecAdresse()
{
    Console.Out.WriteLine("DemoModificationPersonneAvecAdresse");

    Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
    try
    {
        using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
        {
            Adresse? adresse = personneAvecAdresse.AdresseActuelle;
            personneAvecAdresse.AdresseActuelle = null;
            Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
            mp.AjouterPersonne(personneAvecAdresse);
            personneAvecAdresse.AdresseActuelle = adresse;
            Console.Out.WriteLine($"Tentative de MAJ d'une peronne : {personneAvecAdresse.PersonneId}");
            mp.MAJPersonne(personneAvecAdresse);
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
        Console.Error.WriteLine(ex.Message);
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
