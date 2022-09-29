# Cours 18 - ORM

Vous êtes mandaté pour créer une application d'adoption de chats par des personnes. Une personne peut adopter plusieurs chats. Un chat ne peut être adopté qu'une seule fois par une seule personne.

Une personne est définie par :

- Un identifiant unique
- Un nom
- Un prénom

Un chat est défini par :

- Un identifiant unique
- Un nom
- Un propriétaire si adopté
- Une date d'adoption si adopté

## Exercice 1 - Création de la base de données

- Modélisez la base de données
- Écrivez les requête DDL pour créer la base de données : chaque nom de table doit être préfixée par "a_"
- Écrivez quelques requêtes DML pour remplir la base de données :
  - Ajoutez des personnes avec et sans adoption
  - Ajoutez des chats avec et sans adoption
- Écrivez une fonction qui renvoie la liste des chats adoptés par une personne
- Écrivez une fonction qui renvoie la liste des chats non adoptés

## Exercice 2 - Création d'une application de gestion d'adoptions

En vous inspirant de l'application de démonstration du cours, créez une application qui permet de :

- Saisir un chat à adopter
- Saisir une personne
- Afficher les personnes sans chercher à afficher les chats
- Afficher les chats avec leurs propriétaires si existants
- Afficher les chats non adoptés
- Afficher les chats adoptés par une personne
- Adopter un chat par une personne

Grandes étapes :

- Créez la solution "Cours18_ORM_GestionAdoption" avec le projet "GestionAdoptionUI" de type "Console"
- Ajoutez les projets :
  - GestionAdoptionEntite : de type bibliothèque de classes
    - Contient les entités Personne et Chat :
      - L'entité Personne n'inclut pas la liste des chats adoptés (vous pourrez le faire en option)
    - Contient les interfaces IDepotPersonne et IDepotChat
  - GestionAdoptionBL :
    - Dépend de GestionAdoptionEntite
    - Contient les classes :
      - PersonneBL : manipulation de personnes
        - Prend un dépôt de personnes en paramètres
      - ChatBL : manipulation des chats
        - Prends un dépôt de chats en paramètres
      - GestionAdoptionBL : adoption de chats
        - Prends un dépôt de personnes et de chats en paramètres
    - GestionAdoptionUI :
      - Dépend de GestionAdoptionBL, GestionAdoptionEntite, GestionAdoptionDAL_EF
      - Contient le classe :
        - PersonneUI : interface utilisateur pour la gestion des personnes. Cette classe est instanciée dans le main. Elle contient la logique des menus d'options.
    - GestionAdoptionDAL_EF :
      - Dépend de GestionAdoptionEntite, Oracle.EntityFrameworkCore, Microsoft.Extensions.Configuration.Json
      - Contient les classes :
        - Personne : DTO. N'incluez pas la navigation vers la liste des chats adoptés (vous pourrez le faire en option)
        - Chat : DTO. Incluez la navigation vers le propriétaire si adopté
        - ApplicationDBContext : contexte de base de données
        - DALDbContextGeneration : classe qui génère le contexte de base de données. Adaptez la classe fournie en exemple dans le cours
        - DepotPersonne : dépôt de personnes implanté avec EntityFramework
        - DepotChat : dépôt de chats implanté avec EntityFramework
- Débutez par l'affichage des personnes sans aller chercher les chats adoptés. Pour cela, vous devez coder les fonctions nécessaires dans les classes IDepotPersonne, PersonneBL, DepotPersonne et PersonneUI.
- Faites de même pour la liste des chats en affichant le propriétaire s'il est adopté.
- Faites les variants pour les chats adoptés et non adoptés (utilisez votre fonction SQL).
- Codez l'ajout d'une personne et d'un chat à adopter.
- Codez la fonctionnalité d'adoption d'un chat.
