# Module 04 - Fonction de fenêtrage

## Exercice 1 - Durée entre événements

Soit les données suivantes :

| **EventID** | **UserId** | **Date**            | **EventType**     | **Description**                 |
|-------------|------------|---------------------|-------------------|---------------------------------|
| **1**       | 1          | 2022-11-11 08:08:01 |  Login            | User AlexTerrieur log-in        |
| **2**       | 2          | 2022-11-11 08:09:02 |  Login            | User AlainTerrieur log-in       |
| **3**       | 1          | 2022-11-11 08:09:02 |  DocumentReading  | Reading document with id : 156  |
| **4**       | 1          | 2022-11-11 08:09:02 |  DocumentReading  | Reading document with id : 157  |
| **5**       | 1          | 2022-11-11 08:09:02 |  DocumentReading  | Reading document with id : 158  |
| **6**       | 1          | 2022-11-11 08:09:02 |  DocumentReading  | Reading document with id : 159  |
| **7**       | 1          | 2022-11-11 08:09:02 |  DocumentReading  | Reading document with id : 160  |
| **8**       | 1          | 2022-11-11 08:09:03 |  DocumentReading  | Reading document with id : 161  |
| **9**       | 1          | 2022-11-11 08:09:03 |  DocumentReading  | Reading document with id : 162  |
| **10**      | 1          | 2022-11-11 08:09:03 |  DocumentReading  | Reading document with id : 163  |
| **11**      | 1          | 2022-11-11 08:09:03 |  DocumentReading  | Reading document with id : 164  |
| **12**      | 2          | 2022-11-11 08:10:52 |  DocumentReading  | Reading document with id : 9346 |
| **13**      | 2          | 2022-11-11 08:11:25 |  DocumentSaving   | Saving document with id : 9346  |
| **14**      | 2          | 2022-11-11 08:13:31 |  DocumentSaving   | Saving document with id : 9346  |
| **15**      | 2          | 2022-11-11 08:24:09 |  DocumentReading  | Reading document with id : 9824 |

- Créez la base de données "M04_Window_Function"
- Dans cette base de données, créer la table "ApplicationEvents" et insérez les données précédentes
- Écrire une requête qui affiche par utilisateur, le numéro de l'événement, la date, le type, la description et le temps en seconde depuis l'événement précédent
- Que peut-on déduire du résultat de la requête sachant que les utilisateurs 1 et 2 sont des humains ?

## Exercice 2 - Wide World Importers

En utilisant les fonctions de fenêtrage et les fonctions d'agrégat, écrire les requêtes qui permettent de :

- Afficher le détail des transactions pour le client d'identifiant 401 : numéro de ligne, numéro de ligne dans le mois, identifiant de client, date de la transaction, montant et total courant depuis le premier enregistrement (Table : CustomerTransactions).

<details>
    <summary>Extrait résultat attendu</summary>

| **NumeroLigne** | **NumeroLigneDansLeMois** | **CustomerID** | **TransactionDate** | **MontantTransaction** | **TotalCourant** |
|-----------------|---------------------------|----------------|---------------------|------------------------|------------------|
| **1**           | 1                         | 401            | 2013-01-01          | $694.03                | $694.03          |
| **2**           | 2                         | 401            | 2013-01-01          | $14.95                 | $708.98          |
| **3**           | 3                         | 401            | 2013-01-01          | $263.35                | $972.33          |
| **…**           | …                         | …              | …                   | …                      | …                |
| **580**         | 580                       | 401            | 2013-01-31          | $1,346.65              | $54,469.12       |
| **581**         | 581                       | 401            | 2013-01-31          | $3,366.05              | $57,835.17       |
| **582**         | 582                       | 401            | 2013-01-31          | $1,813.55              | $59,648.72       |
| **583**         | 1                         | 401            | 2013-02-01          | ($59,648.72)           | $0.00            |
| **584**         | 2                         | 401            | 2013-02-01          | $395.60                | $395.60          |
| **585**         | 3                         | 401            | 2013-02-01          | $793.85                | $1,189.45        |
| **…**           | …                         | …              | …                   | …                      | …                |
| **947**         | 365                       | 401            | 2013-02-28          | $3,049.80              | $41,219.11       |
| **948**         | 366                       | 401            | 2013-02-28          | $1,782.73              | $43,001.84       |
| **949**         | 367                       | 401            | 2013-02-28          | $523.25                | $43,525.09       |
| **…**           | …                         | …              | …                   | …                      | …                |

</details>

- Effectuer le traitement précédent pour le client d'identifiant 404

- Afficher le détail de la facture d'identifiant 126 : numéro de ligne, numéro de facture, prix unitaire, quantité, prix hors taxes, taxes et total courant dans la facture (tables Invoices, InvoiceLines).

<details>
    <summary>Résultat attendu</summary>

| **NumeroLigne** | **InvoiceID** | **UnitPrice** | **Quantity** | **PrixHT** | **Taxes** | **TotalTTCCourant** |
|-----------------|---------------|---------------|--------------|------------|-----------|---------------------|
| **1**           | 126           | 105.00        | 90           | $9,450.00  | $1,417.50 | $10,867.50          |
| **2**           | 126           | 3.70          | 108          | $399.60    | $59.94    | $11,327.04          |
| **3**           | 126           | 13.00         | 10           | $130.00    | $19.50    | $11,476.54          |
| **4**           | 126           | 32.00         | 7            | $224.00    | $33.60    | $11,734.14          |
| **5**           | 126           | 25.00         | 5            | $125.00    | $18.75    | $11,877.89          |

</details>

- Afficher le montant des ventes par année, mois et vendeurs. Les données doivent être triées par année, mois et montant des ventes pour le mois visé. Vous devez avoir les colonnes suivantes : numéro de ligne, année, mois, classement du vendeur dans le mois en cours, tiers, nom complet, montant des ventes (tables Invoices, InvoiceLines, People) :

<details>
    <summary>Exemple</summary>

| **NumeroDeLigne** | **AnneeVentes** | **MoisVentes** | **Classement** | **Tiers** | **FullName**       | **MontantVentes** |
|-------------------|-----------------|----------------|----------------|-----------|--------------------|-------------------|
| **1**             | 2013            | 1              | 1              | 1         | Hudson Onslow      | $484,782.95       |
| **2**             | 2013            | 1              | 2              | 1         | Kayla Woodcock     | $392,324.20       |
| **3**             | 2013            | 1              | 3              | 1         | Sophia Hinton      | $389,433.50       |
| **4**             | 2013            | 1              | 4              | 1         | Amy Trefl          | $374,377.85       |
| **5**             | 2013            | 1              | 5              | 2         | Jack Potter        | $370,331.75       |
| **6**             | 2013            | 1              | 6              | 2         | Anthony Grosse     | $363,910.20       |
| **7**             | 2013            | 1              | 7              | 2         | Hudson Hollinworth | $363,369.15       |
| **8**             | 2013            | 1              | 8              | 3         | Archer Lamble      | $359,316.65       |
| **9**             | 2013            | 1              | 9              | 3         | Taj Shand          | $340,702.90       |
| **10**            | 2013            | 1              | 10             | 3         | Lily Code          | $331,861.70       |
| **11**            | 2013            | 2              | 1              | 1         | Jack Potter        | $319,803.15       |
| **12**            | 2013            | 2              | 2              | 1         | Hudson Onslow      | $303,760.05       |
| **13**            | 2013            | 2              | 3              | 1         | Sophia Hinton      | $299,130.40       |
| **14**            | 2013            | 2              | 4              | 1         | Amy Trefl          | $298,098.75       |
| **...**           | ...             | ...            | ...            | ...       | ...                | ...               |

</details>
