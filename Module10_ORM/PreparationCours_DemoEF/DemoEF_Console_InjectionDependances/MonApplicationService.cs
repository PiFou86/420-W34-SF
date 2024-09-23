using DemoEF_Framework;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Console_InjectionDependances
{
    internal class MonApplicationService : IHostedService
    {
        private MonApplication m_monApplication;
        public MonApplicationService(MonApplication monApplication)
        {
            this.m_monApplication = monApplication;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Projection de données de la BD
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesSansRecupererAdresse();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesEnRecuperantAdresses();
            }

            // Ajout de personnes (INSERT)
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoAjoutPersonneSansAdresse();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesEnRecuperantAdresses();
            }
            ConsoleExtensions.WaitForEnterKey();

            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoAjoutPersonneAvecAdresse();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesEnRecuperantAdresses();
            }
            ConsoleExtensions.WaitForEnterKey();

            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoAjoutPersonneAvecAdresseRollback();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesEnRecuperantAdresses();
            }
            ConsoleExtensions.WaitForEnterKey();

            // Appel de fonction SQL
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoRechercherAdressesContenantUnMot();
            }
            ConsoleExtensions.WaitForEnterKey();

            // Modification d'une personne (adresse ici)
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoModificationPersonneAvecAdresse();
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                this.m_monApplication.DemoObtenirPersonnesEnRecuperantAdresses();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
