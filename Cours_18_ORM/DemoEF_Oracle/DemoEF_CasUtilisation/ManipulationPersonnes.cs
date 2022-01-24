using DemoEF_Entite;

namespace DemoEF_CasUtilisation
{
    public class ManipulationPersonnes
    {
        private IDepotPersonne m_depotPersonne;
        private IDepotAdresse m_depotAdresse;

        public ManipulationPersonnes(IDepotPersonne p_depotPersonne, IDepotAdresse p_depotAdresse)
        {
            this.m_depotPersonne = p_depotPersonne;
            this.m_depotAdresse = p_depotAdresse;
        }
    }
}