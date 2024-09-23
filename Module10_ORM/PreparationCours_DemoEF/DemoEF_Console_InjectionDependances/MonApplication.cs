// Ajoutez le package nuget Microsoft.Extensions.Hosting
// Ajoutez le package nuget Microsoft.Extensions.Configuration.Json


using DemoEF_CasUtilisation;
using DemoEF_Entite;
using DemoEF_Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoEF_Console_InjectionDependances
{
    internal class MonApplication
    {
        private IServiceProvider m_serviceProvider;
        public MonApplication(IServiceProvider serviceProvider)
        {
            this.m_serviceProvider = serviceProvider;
        }

        public void Run()
        {
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
        }

        public void DemoObtenirPersonnesSansRecupererAdresse()
        {
            ConsoleExtensions.EntitleMessage("Démonstration obtenir les personnes sans récuperer les adresses", ConsoleColor.Blue, ConsoleColor.White);

            using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
            {
                using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                {
                    List<Personne>? personnesSansAdresse = mp.ObtenirPersonnes(inclureAdresse: false);

                    personnesSansAdresse?.ForEach(p => Console.Out.WriteLine(p));
                }
            }
            Console.Out.WriteLine();
        }

        public void DemoObtenirPersonnesEnRecuperantAdresses()
        {
            ConsoleExtensions.EntitleMessage("Démonstration obtenir les personnes avec récupération des adresses", ConsoleColor.Blue, ConsoleColor.White);

            using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
            {
                using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                {
                    List<Personne>? personnesavecAdresse = mp.ObtenirPersonnes(inclureAdresse: true);

                    personnesavecAdresse?.ForEach(p => Console.Out.WriteLine(p));
                }
            }
            Console.Out.WriteLine();
        }

        public void DemoAjoutPersonneSansAdresse()
        {
            ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne sans adresse", ConsoleColor.Blue, ConsoleColor.White);

            Personne personneSansAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: false);
            Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneSansAdresse.PersonneId}");
            using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
            {
                using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                {
                    mp.AjouterPersonne(personneSansAdresse);
                }
            }

            Console.Out.WriteLine();
        }

        public void DemoAjoutPersonneAvecAdresse()
        {
            ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne avec une adresse", ConsoleColor.Blue, ConsoleColor.White);

            Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
            Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");

            try
            {
                using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
                {
                    using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                    {
                        mp.AjouterPersonne(personneAvecAdresse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
                Console.Error.WriteLine(ex.Message);
            }

            Console.Out.WriteLine();
        }

        public void DemoAjoutPersonneAvecAdresseRollback()
        {
            ConsoleExtensions.EntitleMessage("Démonstration de l'ajout d'une personne avec adresse mais avec ROLLBACK", ConsoleColor.Blue, ConsoleColor.White);

            Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
            Console.Out.WriteLine($"Tentative d'ajout d'une peronne : {personneAvecAdresse.PersonneId}");
            try
            {
                using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
                {
                    using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                    {
                        // Le code affaire ne devrait pas permettre au code d'aller jusqu'a la couche de persistance normalement mais le permet ici pour l'exemple
                        personneAvecAdresse.AdresseActuelle = new Adresse(0, 0, null!, null!, null!);
                        mp.AjouterPersonne(personneAvecAdresse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
                Console.Error.WriteLine(ex.Message);
            }

            Console.Out.WriteLine();
        }

        public void DemoModificationPersonneAvecAdresse()
        {
            Console.Out.WriteLine("Démonstration de la modification d'une personne avec une adresse", ConsoleColor.Blue, ConsoleColor.White);

            Personne personneAvecAdresse = GenerateurDonnees.GenererPersonne(p_inclureAdresse: true);
            try
            {
                using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
                {
                    using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
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
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erreur durant l'appel de la couche affaire :");
                Console.Error.WriteLine(ex.Message);
            }

            Console.Out.WriteLine();
        }

        public void DemoRechercherAdressesContenantUnMot()
        {
            ConsoleExtensions.EntitleMessage("Démonstration de la recherche d'adresses contenant un mot en utilisant une requête et en utilisant la procédure stockée", ConsoleColor.Blue, ConsoleColor.White);

            using (IServiceScope serviceScope = this.m_serviceProvider.CreateScope())
            {
                using (ManipulationPersonnes mp = serviceScope.ServiceProvider.GetRequiredService<ManipulationPersonnes>())
                {
                    Console.Out.WriteLine("RechercherAdresseParRequete");
                    List<Adresse> adressesParRequete = mp.RechercherAdresseParRequete("é");
                    adressesParRequete.ForEach(a => Console.Out.WriteLine(a));

                    Console.Out.WriteLine("RechercherAdresseProcedureStockee");
                    List<Adresse> adressesParProcedureStockee = mp.RechercherAdresseProcedureStockee("é");
                    adressesParProcedureStockee.ForEach(a => Console.Out.WriteLine(a));
                }
            }

            Console.Out.WriteLine();
        }

    }
}