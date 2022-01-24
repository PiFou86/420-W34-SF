using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Entite
{
    public interface IDepotAdresse
    {
        void AjouterAdresse(Adresse p_adresse);
        List<Adresse> RechercherAdresseParRequete(string p_partieNomVille);
        public List<Adresse> RechercherAdresseProcedureStockee(string p_partieNomVille);
    }
}
