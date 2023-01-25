using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Entite
{
    public interface IDepotPersonne : IDisposable
    {
        Personne? ObtenirPersonne(int p_personneId, bool inclureAdresse = false);
        List<Personne> ObtenirPersonnes(bool inclureAdresse = false);
        void AjouterPersonne(Personne p_personne);
        void MAJPersonne(Personne personneAvecAdresse);
    }
}
