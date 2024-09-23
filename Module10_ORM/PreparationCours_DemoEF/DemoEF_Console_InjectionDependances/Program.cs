// Enlever le commentaire pour tester la version service
//#define Version_Service

// Ajoutez le package nuget Microsoft.Extensions.Hosting
// Ajoutez le package nuget Microsoft.Extensions.Configuration.Json


using DemoEF_CasUtilisation;
using DemoEF_Console_InjectionDependances;
using DemoEF_DALApplicationDBContext.SQLServer;
using DemoEF_Entite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Utilisation d'un objet de type monteur (Builder) qui est un patron de
// type création : https://refactoring.guru/fr/design-patterns/builder
// L'idée est d'avoir un objet sur lequel on ajoute des configurations
// à la fin de la configuration, on demande au constructeur de construire le vrai objet
// avec la méthode "Construire" (Build) que vous voyez vers la fin du code.

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Par défaut, il va faire la configuration suivante : https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createapplicationbuilder?view=net-8.0#microsoft-extensions-hosting-host-createapplicationbuilder(system-string())
// À retenir : l'ajout des variables d'environnement et la lecture des fichiers de configuration json.
// Début configuration faite automatiquement ici
//IHostEnvironment env = builder.Environment;

//// Permet de lire la configuration des variables d'environnement
//// Et ajout des fichiers de configuration appsettings.json et appsettings.develpment.json si existant
//builder.Configuration
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
// Fin de la configuration faite automatiquement.

// On va chercher la configuration de la BD : serveur, BD, utilisateur qui sont décrits dans la chaine de connexion du fichier appsettings.json

string connectionString = builder.Configuration.GetConnectionString("PersonnesConnection") ?? throw new InvalidOperationException("Connection string 'PersonnesConnection' not found.");

// Configuration de l'injection de dépendance pour la classe ApplicationDBContext. Durée de vie Scope (par unité de travail - Unit of work)
// Dans notre cas, il faudra faire un bloc de porté (scope) qui représentera une unité de travail (Unit of work)
// AddDbContext est une méthode d'extension qui provient de l'asembly Microsoft.EntityFrameworkCore
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));
// Ajout des correspondances pour les IDepotXYZ
builder.Services.AddScoped<IDepotAdresse, DepotAdresseEF>();
builder.Services.AddScoped<IDepotPersonne, DepotPersonneEF>();
// Ajout du type ITransaction. Attention ne pas utiliser la syntaxe d'ajout classique sinon il va créer un autre ApplicationDBContext par ITransaction
//builder.Services.AddScoped<ITransactionBD, ApplicationDBContext>();
// Utilisez plutot la résolution du ApplicationDBContext à partir du fournisseur qui lui va utiliser la vie de type Scoped et donc renvoyé celui déjà créé dans le scope.
builder.Services.AddScoped<ITransactionBD>(provider => provider.GetService<ApplicationDBContext>()!);

// Ajout du type ManipulationPersonnes afin qu'il soit connu du moteur
builder.Services.AddScoped<ManipulationPersonnes>();
builder.Services.AddSingleton<MonApplication>();

// Pour le transformer en service
#if Version_Service
builder.Services.AddHostedService<MonApplicationService>();
#endif

IHost host = builder.Build();



// Si c'est un service
#if Version_Service
await host.RunAsync();
#else
// Si ce n'est pas un service
MonApplication? monApplication = host.Services.GetService<MonApplication>();
monApplication?.Run();
#endif