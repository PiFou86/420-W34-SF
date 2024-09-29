using DemoEF_CasUtilisation;
using DemoEF_DALApplicationDBContext.SQLServer;
using DemoEF_Entite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Console_InjectionDependances
{
    internal static class DemoEFConsoleConfigDI
    {
        public static IServiceCollection AddDemoEFConfigDI(this IServiceCollection services)
        {
            // Ajout des correspondances pour les IDepotXYZ
            services.AddScoped<IDepotAdresse, DepotAdresseEF>();
            services.AddScoped<IDepotPersonne, DepotPersonneEF>();
            // Ajout du type ITransaction. Attention ne pas utiliser la syntaxe d'ajout classique sinon il va créer un autre ApplicationDBContext par ITransaction
            //builder.Services.AddScoped<ITransactionBD, ApplicationDBContext>();
            // Utilisez plutot la résolution du ApplicationDBContext à partir du fournisseur qui lui va utiliser la vie de type Scoped et donc renvoyé celui déjà créé dans le scope.
            services.AddScoped<ITransactionBD>(provider => provider.GetService<ApplicationDBContext>()!);

            // Ajout du type ManipulationPersonnes afin qu'il soit connu du moteur
            services.AddScoped<ManipulationPersonnes>();
            services.AddSingleton<MonApplication>();

            return services;
        }
    }
}
