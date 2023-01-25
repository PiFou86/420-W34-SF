using DemoEF_DALApplicationDBContext.SQLServer;
using DemoEF_Entite;
using DemoEF_CasUtilisation;

public class ManipulationPersonneSQLServerFactory : IManipulationPersonneFactory
{
    public ManipulationPersonnes Creer()
    {
        ApplicationDBContext applicationDBContext = DALDbContextGeneration.ObtenirApplicationDBContext();
        IDepotPersonne depotPersonne = new DepotPersonneEF(applicationDBContext);
        IDepotAdresse depotAdresse = new DepotAdresseEF(applicationDBContext);
        ManipulationPersonnes mp = new ManipulationPersonnes(depotPersonne, depotAdresse, applicationDBContext);

        return mp;
    }
}