using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Entite
{
    public interface IDepotAdresse : IDisposable
    {
        void AjouterAdresse(Adresse p_adresse);
        Adresse? Obtenir(int p_id);
        List<Adresse> RechercherAdresseParRequete(string p_partieNomVille);
        public List<Adresse> RechercherAdresseProcedureStockee(string p_partieNomVille);
    }
}
