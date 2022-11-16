# Module 05 - Index

## Exercice 1 - Créer des copies de tables pour faire des tests

- Copiez la table "Orders" dans la table "Commande"
- Copiez la table "OrderLines" dans la table "LigneCommande"
- Ne pas mettre de clefs primaires ni d'index

## Exercice 2 - Observations

- Créez une requête qui affiche le détail de la commande 4242
- À partir de la requête précédente, créez la même requête pour la table d'origine
- Affichez le plan d'exécution pour chacune des requêtes et comparez les méthodes de recherche et les temps d'exécution
- Lancez le programme "SQL Server Profiler" et démarrez la surveillance du server
- Quel problème peut poser l'utilisation d'un tel outil ?

## Exercice 3 - Création d'index

- À partir des observations précédentes, créez les index nécessaires pour améliorer les performances des nouvelles tables : création de clef primaire et d'index de type "NON CLUSTERED"
- Validez que le plan d'exécution est similaire à celui des tables originales
