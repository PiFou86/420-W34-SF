# Module 09 - Triggers

## Exercice 1 - Historisation

- Créez une base de données `M09_Trigger`
- Créez la table `Personne` et `PersonneHistorique` avec les colonnes suivantes :
  - `PersonneId` (int, PK, Identity)
  - `Prenom` (nvarchar(50))
  - `Nom` (nvarchar(50))
  - `DateNaissance` (date)
- Écrivez un trigger qui historise les personnes supprimer de la table `Personne` dans la table `PersonneHistorique`
- Testez votre trigger en insérant des personnes dans la table `Personne` et en les supprimant

## Exercice 2 - Appréciation

- Créez la table `note` avec les colonnes suivantes :
  - `NoteId` (int, PK, Identity)
  - `Note` (decimal : trois chiffres avant la virgule et deux chiffres après la virgule)
  - `Appreciation` (nvarchar(50))
- Créez un trigger qui met à jour la colonne `Appreciation` en fonction de la colonne `Note` :
  - `Note` entre 0 et 10 : `Appreciation` = `Insuffisant`
  - `Note` entre 10 et 12 : `Appreciation` = `Passable`
  - `Note` entre 12 et 14 : `Appreciation` = `Bien`
  - `Note` entre 14 et 20 : `Appreciation` = `Très bien`
- Testez votre trigger en insérant des notes dans la table `note`
- Créez un trigger qui fait la mise à jour de la colonne `Appreciation` à chaque mise à jour
- Est-ce que vous pouvez faire en sorte que ce trigger ne fasse pas la mise à jour du champ que si la colonne `Note` est modifiée ? (indice : [`UPDATE`](https://learn.microsoft.com/en-us/sql/t-sql/functions/update-trigger-functions-transact-sql))
- Testez votre trigger en insérant des notes dans la table `note`
- Est-ce que l'utilisation d'un trigger est la meilleure solution pour mettre à jour la colonne `Appreciation` ? Pourquoi ? ("Quand on a un marteau, tout devient un clou")

## Exercice 3 - World Wide Importers

### Exercice 3.1 - Conciliation

- Créez la table `ConciliationCommandeFacture` avec les colonnes suivantes :
  - `ConciliationCommandeFactureId` (int, PK, Identity)
  - `StockItemID` (int, FK vers `Warehouse.StockItems`)
  - `QuantiteCommande` (int)
  - `QuantiteFacture` (int)
- Créez deux triggers (un pour `InvoiceLine` et `OrderLines`) qui à l'insertion ou la modification d'un enregistrementmet à jour la table `ConciliationCommandeFacture` en fonction de la quantité commandée et facturée

### Exercice 3.2 - Total des factures

- Créez la table `TotalFacture` avec les colonnes suivantes :
  - `TotalFactureId` (int, PK, Identity)
  - `InvoiceId` (int, FK vers `Sales.Invoices`)
  - `Total` (decimal : trois chiffres avant la virgule et deux chiffres après la virgule)
- Créez un trigger qui à l'insertion, la modification ou la suppression d'un enregistrement dans `Sales.InvoiceLines` met à jour la table `TotalFacture` en fonction du total de la facture

#### Exercice 3.3 - Événements

- Créez la table `Evenements` avec les colonnes suivantes :
  - `EvenementId` (int, PK, Identity)
  - `CustomerID` (int, FK vers `Sales.Customers`)
  - `Date` (datetime)
  - `Description` (nvarchar(404))
- Créez un trigger qui inscrit un enregistrement dans la table `Evenements` si le volume de facturation pour le mois courant est supérieur à 100 000 $ et qu'aucun enregistrement n'a été inscrit pour le mois courant. La description doit être : `Volume de facturation supérieur à 100 000 $ pour le mois courant pour le client <CustomerFulleName>`
