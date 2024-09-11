using DemoEF_Entite;
using DemoEF_CasUtilisation;
using DemoEF_Console;
using DemoEF_Framework;

//     "PersonnesConnection" : "Data source=localhost:1521/orcl; User Id=pfleon; Password=Bonjour01.+;"
// IManipulationPersonneFactory manipulationPersonneFactory = new ManipulationPersonneOracleFactory();
//     "PersonnesConnection" : "Server=.;Database=Module10_ORM;Trusted_Connection=True;MultipleActiveResultSets=true"


//ConsoleExtensions.EntitleMessage("Un texte répond de façon plus ou moins pertinente à des critères qui en déterminent la qualité littéraire. On retient en particulier la structure d'ensemble, la syntaxe et la ponctuation, l'orthographe lexicale et grammaticale, la pertinence et la richesse du vocabulaire, la présence de figures de style, le registre de langue et la fonction recherchée (narrative, descriptive, expressive, argumentative, injonctive, poétique). C'est l'objet de l'analyse littéraire.");

IManipulationPersonneFactory manipulationPersonneFactory = new ManipulationPersonneSQLServerFactory();

// Projection de données de la BD
DemoObtenirPersonnesSansRecupererAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();

// Ajout de personnes (INSERT)
DemoAjoutPersonneSansAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();
ConsoleExtensions.WaitForEnterKey();

DemoAjoutPersonneAvecAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();
ConsoleExtensions.WaitForEnterKey();

DemoAjoutPersonneAvecAdresseRollback();
DemoObtenirPersonnesEnRecuperantAdresses();
ConsoleExtensions.WaitForEnterKey();


// Appel de fonction SQL
DemoRechercherAdressesContenantUnMot();
ConsoleExtensions.WaitForEnterKey();

// Modification d'une personne (adresse ici)
DemoModificationPersonneAvecAdresse();
DemoObtenirPersonnesEnRecuperantAdresses();



void DemoObtenirPersonnesSansRecupererAdresse()
{
    ConsoleExtensions.EntitleMessage("Démonstration obtenir les personnes sans récuperer les adresses", ConsoleColor.Blue, ConsoleColor.White);

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        List<Personne>? personnesSansAdresse = mp.ObtenirPersonnes(inclureAdresse: false);

        personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
    }
    Console.Out.WriteLine();
}

void DemoObtenirPersonnesEnRecuperantAdresses()
{
    ConsoleExtensions.EntitleMessage("Démonstration obtenir les personnes avec récupération des adresses", ConsoleColor.Blue, ConsoleColor.White);

    using (ManipulationPersonnes mp = manipulationPersonneFactory.Creer())
    {
        List<Personne>? personnesavecAdresse = mp.ObtenirPersonnes(inclureAdresse: true);

        personnesavecAdresse?.ForEach(p => Console.Out.WriteLine(p));
    }
    Console.Out.WriteLine();
}

void DemoAjoutPersonneSansAdresse()
{
    ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne sans adresse", ConsoleColor.Blue, ConsoleColor.White);

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
    ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne avec une adresse", ConsoleColor.Blue, ConsoleColor.White);

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
    ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne avec adresse mais avec ROLLBACK", ConsoleColor.Blue, ConsoleColor.White);

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
    Console.Out.WriteLine("Démonstration de la modification d'une personne avec une adresse", ConsoleColor.Blue, ConsoleColor.White);

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
    ConsoleExtensions.EntitleMessage("Démonstration de la recherche d'adresses contenant un mot en utilisant une requête et en utilisant la procédure stockée", ConsoleColor.Blue, ConsoleColor.White);

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
