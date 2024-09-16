# Module 10 - ORM

## Exercice 1 - Gestion d'adoptions de chats

Vous avez été mandaté pour développer une application d'adoption de chats. Les personnes peuvent adopter plusieurs chats, mais chaque chat ne peut être adopté qu'une seule fois par un seul utilisateur.

Les personnes sont identifiées par un identifiant unique, un nom et un prénom. Les chats, quant à eux, sont identifiés par un identifiant unique, un nom et, si adopté, un propriétaire et une date d'adoption.

### Exercice 1.1 - Création de la base de données

- Modélisez la base de données
- Écrivez les requête DDL pour créer la base de données
- Écrivez quelques requêtes DML pour remplir la base de données :
  - Ajoutez des personnes avec et sans adoption
  - Ajoutez des chats avec et sans adoption
- Écrivez une procédure qui renvoie la liste des chats adoptés par une personne
- Écrivez une procédure qui renvoie la liste des chats non adoptés

### Exercice 1.2 - Création d'une application de gestion d'adoptions

En vous inspirant de l'application de démonstration du cours, créez une application qui permet de :

- Saisir un chat à adopter
- Saisir une personne
- Afficher les personnes sans chercher à afficher les chats
- Afficher les chats avec leurs propriétaires si existants
- Afficher les chats non adoptés
- Afficher les chats adoptés par une personne
- Adopter un chat par une personne

Grandes étapes :

- Créez la solution `Module10_ORM_GestionAdoptions` avec le projet `GestionAdoptionUI` de type `Console`
- Ajoutez les projets :
  - `GestionAdoptionEntite` : de type bibliothèque de classes
    - Contient les entités `Personne` et `Chat` :
      - L'entité `Personne` n'inclut pas la liste des chats adoptés (vous pourrez le faire en option)
    - Contient les interfaces `IDepotPersonne` et `IDepotChat` avec les opérations CRUD ainsi que les méthodes `ChatsAdoptesParPersonne` et `ChatsNonAdoptes` qui exécutent les procédures créées précédemment
  - `GestionAdoptionBL` : de type bibliothèque de classes
    - Dépend de `GestionAdoptionEntite`
    - Contient les classes :
      - `PersonneBL` : manipulation de personnes
        - Prend un dépôt de personnes en paramètres
      - `ChatBL` : manipulation des chats
        - Prends un dépôt de chats en paramètres
      - `GestionAdoptionBL` : adoption de chats
        - Prends un dépôt de personnes et de chats en paramètres
  - `GestionAdoptionUI` : de type application console
    - Dépend de `GestionAdoptionBL`, `GestionAdoptionEntite`, `GestionAdoptionDAL_SQLServerEF`
    - Contient la classe :
      - `PersonneUI` : interface utilisateur pour la gestion des personnes. Cette classe est instanciée dans le main. Elle contient la logique des menus d'options.
  - `GestionAdoptionDAL_SQLServerEF` : de type bibliothèque de classes
    - Dépend de `GestionAdoptionEntite`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.Extensions.Configuration.Json`
    - Contient les classes :
      - `Personne` : DTO. N'incluez pas la navigation vers la liste des chats adoptés (vous pourrez le faire en option)
      - `Chat` : DTO. Incluez la navigation vers le propriétaire si adopté
      - `ApplicationDBContext` : contexte de base de données
      - `DALDbContextGeneration` : classe qui génère le contexte de base de données. Adaptez la classe fournie en exemple dans le cours
      - `DepotPersonne` : dépôt de personnes implanté avec EntityFramework
      - `DepotChat` : dépôt de chats implanté avec EntityFramework
- Débutez par l'affichage des personnes sans aller chercher les chats adoptés. Pour cela, vous devez coder les fonctions nécessaires dans les classes IDepotPersonne, PersonneBL, DepotPersonne et PersonneUI
- Faites de même pour la liste des chats en affichant le propriétaire s'il est adopté
- Faites les variants pour les chats adoptés et non adoptés (utilisez votre fonction SQL)
- Codez l'ajout d'une personne et d'un chat à adopter
- Codez la fonctionnalité d'adoption d'un chat

## Exercice 2 - Gestion de location de vidéos

Vous avez été mandaté pour développer une application de location de vidéos. Les personnes peuvent louer plusieurs vidéos, mais chaque vidéo ne peut être louée qu'une seule fois par un seul utilisateur (Nous n'avons qu'une licence d'utilisation par vidéo). Une vidéo ne peut être louée que par une personne vidéo à la fois. Vous n'avez pas à gérer les historiques. Une vidéo est louée pour une durée de 7 jours. Une personne ne peut louer que 5 vidéos maximum en même temps.

Vous devez écrire une application qui permet de saisir des vidéos et de les louer. Vous devez également pouvoir afficher les vidéos louées et les vidéos non louées.

La majorité des validations doivent être faites dans la couche de persistance de données (i.e. la base de données).

Environnement technique de votre client :

- Base de données SQL Server
- .Net 8.0
- Entity Framework Core 8.x
- Application console
