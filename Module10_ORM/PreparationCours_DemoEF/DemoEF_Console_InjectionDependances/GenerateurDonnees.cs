using DemoEF_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Console_InjectionDependances
{
    internal class GenerateurDonnees
    {
        private static Random _generateurNombres = new Random(DateTime.Now.Millisecond);

        // Utilitaires
        public static Personne GenererPersonne(bool p_inclureAdresse)
        {
            // https://fr.wikipedia.org/wiki/Liste_des_noms_de_famille_les_plus_courants_au_Québec
            string[] noms = {
                            "Tremblay",
                            "Gagnon",
                            "Roy",
                            "Côté",
                            "Bouchard",
                            "Gauthier",
                            "Morin",
                            "Lavoie",
                            "Fortin",
                            "Gagné",
                            "Ouellet",
                            "Pelletier",
                            "Bélanger",
                            "Lévesque",
                            "Bergeron",
            };
            // https://www.retraitequebec.gouv.qc.ca/fr/services-en-ligne-outils/banque-de-prenoms/Pages/recherche_par_popularite.aspx?AnRefBp=2019&NbPre=10
            string[] prenoms = {
                "Olivia",
                "Emma",
                "Alice",
                "Charlie",
                "Charlotte",
                "Liam",
                "William",
                "Thomas",
                "Léo",
                "Noah",
                };
            int idPersonne = _generateurNombres.Next(10000, 9999999);
            Adresse? adresse = p_inclureAdresse ? GenererAdresseAleatoire(idPersonne) : null;
            return new Personne(
                                idPersonne,
                                noms[_generateurNombres.Next(0, noms.Length)],
                                prenoms[_generateurNombres.Next(0, prenoms.Length)],
                                adresse?.ProprietaireAdresseId,
                                adresse,
                                (adresse is null) ? new List<Adresse>() : new List<Adresse>() { adresse }
            );
        }

        public static Adresse GenererAdresseAleatoire(int p_idPersonne)
        {
            Random random = new Random();
            string[] tableauOdonyme = { "des roses", "de la grande route", "des perchaudes", "du pommier" };
            string[] tableauNomMunicipalite = { "Beauceville", "Quebec", "St-Georges", "Ste-Foy" };

            string numeroCivique = random.Next(9999).ToString();
            int odonymeIndice = random.Next(tableauOdonyme.Length);
            int nomMunicipaliteIndice = random.Next(tableauNomMunicipalite.Length);

            Adresse nouvelleAdresse = new Adresse(
                _generateurNombres.Next(10000, 9999999), 
                p_idPersonne,
                numeroCivique, 
                tableauOdonyme[odonymeIndice], 
                tableauNomMunicipalite[nomMunicipaliteIndice]
                );

            return nouvelleAdresse;
        }
    }
}
