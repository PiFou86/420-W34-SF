# Convention de nommage SQL Server

## Statut du document

- **Type** : norme interne de développement
- **Technologie visée** : Microsoft SQL Server
- **Portée** : bases de données, scripts DDL, procédures stockées, fonctions, contraintes et objets associés

---

## 1. Objet

La présente convention définit les règles de nommage à appliquer aux objets SQL Server afin d'assurer :

- l'uniformité du schéma de base de données ;
- une meilleure lisibilité du code SQL ;
- une maintenance facilitée ;
- une identification rapide de la nature des objets ;
- une cohérence entre les scripts, les déploiements et les revues de code.

Cette convention s'appuie sur les pratiques généralement recommandées dans l'écosystème Microsoft SQL Server, notamment l'usage de noms explicites, stables, lisibles et compatibles avec les identifiants standards de SQL Server.

---

## 2. Principes généraux

### 2.1 Lisibilité et clarté

Les noms doivent être :

- explicites ;
- concis ;
- stables dans le temps ;
- compréhensibles sans devoir consulter la définition complète de l'objet.

Les noms vagues ou trop abrégés sont à éviter.

**Exemples recommandés** :

- `Client`
- `Commande`
- `DateCreation`
- `MontantTotal`

**Exemples à éviter** :

- `Tbl1`
- `DataX`
- `ChampA`
- `Info2`

---

### 2.2 Style d'écriture

Le style retenu est le **PascalCase** pour tous les objets nommés.

**Exemples** :

- `Client`
- `LigneCommande`
- `DateModification`
- `USP_ObtenirClientParId`

---

### 2.3 Caractères autorisés

Afin d'éviter l'usage inutile de délimiteurs comme les crochets `[]`, les noms doivent utiliser uniquement :

- des lettres non accentuées ;
- des chiffres, lorsque pertinent ;
- le caractère de soulignement `_` pour les préfixes et séparateurs techniques.

Il faut éviter :

- les espaces ;
- les accents ;
- les tirets `-` ;
- les caractères spéciaux ;
- les mots réservés du langage SQL.

**Exemples recommandés** :

- `Client`
- `Produit`
- `FK_CommandeClientId`

**Exemples à éviter** :

- `[Liste des clients]`
- `commande-client`
- `élève`
- `select`

---

### 2.4 Langue

Les noms doivent être rédigés dans une seule langue à l'intérieur d'une même base de données ou d'un même projet. En contexte francophone institutionnel, l'usage du français est recommandé si le reste du schéma et de la documentation suit déjà cette convention.

Le plus important demeure la cohérence.

---

### 2.5 Usage du singulier

Les tables doivent être nommées au **singulier**, puisqu'elles représentent un type d'entité.

**Exemples** :

- `Client`
- `Commande`
- `Produit`
- `Facture`

---

### 2.6 Noms explicites pour les colonnes

Les colonnes doivent porter des noms descriptifs, sans préfixe technique superflu.

**Exemples** :

- `Id`
- `ClientId`
- `DateCreation`
- `EstActif`
- `MontantTotal`

---

## 3. Conventions de nommage par type d'objet

## 3.1 Tables

### Règle

Le nom d'une table doit :

- être au singulier ;
- être en PascalCase ;
- décrire clairement l'entité représentée.

### Exemples

- `Client`
- `Commande`
- `Produit`
- `HistoriqueConnexion`

---

## 3.2 Colonnes

### Règle

Le nom d'une colonne doit être explicite et refléter le contenu ou le rôle de la donnée.

### Recommandations

- la clé primaire d'une table se nomme généralement `Id` ;
- une clé étrangère se nomme selon l'entité référencée suivie de `Id` ;
- les booléens devraient commencer par `Est`, `Peut` ou `A` lorsque cela améliore la compréhension ;
- les colonnes de date devraient porter des noms comme `DateCreation`, `DateModification`, `DateDebut`, `DateFin`.

### Exemples

- `Id`
- `ClientId`
- `ProduitId`
- `Nom`
- `Prenom`
- `DateCreation`
- `DateModification`
- `EstActif`

---

## 3.3 Clés primaires

### Format

`PK_<nomTable>`

### Exemples

- `PK_Client`
- `PK_Commande`
- `PK_LigneCommande`

### Commentaire

Le nom de la contrainte de clé primaire doit identifier immédiatement la table à laquelle elle appartient.

---

## 3.4 Clés étrangères

### Format

`FK_<nomTableDuChamp><nomDuChamp>`

### Interprétation retenue

- `<nomTableDuChamp>` : table qui porte la clé étrangère ;
- `<nomDuChamp>` : nom de la colonne de clé étrangère.

### Exemples

Si la table `Commande` contient la colonne `ClientId` :

- `FK_CommandeClientId`

Si la table `LigneCommande` contient la colonne `CommandeId` :

- `FK_LigneCommandeCommandeId`

Si la table `LigneCommande` contient la colonne `ProduitId` :

- `FK_LigneCommandeProduitId`

### Commentaire

Cette convention permet d'identifier rapidement où se trouve la contrainte et quelle colonne est concernée.

---

## 3.5 Index

### Format

`IX_<nomDuChamp|description>`

### Règle

Le nom de l'index doit décrire :

- soit la colonne principale indexée ;
- soit une courte description fonctionnelle lorsque l'index porte sur plusieurs colonnes ou répond à un besoin particulier.

### Exemples

- `IX_Nom`
- `IX_DateCreation`
- `IX_ClientId`
- `IX_Commande_ClientId_DateCommande`
- `IX_Produit_RechercheCatalogue`

### Recommandation

Pour un index composite, il est recommandé d'indiquer les colonnes principales dans l'ordre logique de l'index.

---

## 3.6 Procédures stockées utilisateur

### Format

`USP_<nomProcedure>`

### Exemples

- `USP_ObtenirClientParId`
- `USP_AjouterCommande`
- `USP_RechercherProduitsActifs`

### Recommandation

Le nom de la procédure doit commencer par un verbe ou une action claire lorsque cela est possible.

---

## 3.7 Fonctions utilisateur

### Format

`UDF_<nomFonction>`

### Exemples

- `UDF_CalculerAge`
- `UDF_ObtenirMontantTaxes`
- `UDF_FormaterNomComplet`

---

## 3.8 Séquences

### Format

`SQ_<nomSequence>`

### Exemples

- `SQ_NumeroFacture`
- `SQ_NumeroCommande`
- `SQ_CodeClient`

---

## 3.9 Triggers

### Format

`TR_<nomTrigger>`

### Exemples

- `TR_Commande_ApresInsertion`
- `TR_Client_ApresMiseAJour`
- `TR_Produit_ValidationSuppression`

### Recommandation

Le nom devrait idéalement exprimer :

- la table visée ;
- l'événement concerné ;
- l'intention métier, lorsque cela apporte de la clarté.

---

## 3.10 Contraintes CHECK

### Format

`CK_<nomContrainte>`

### Exemples

- `CK_Client_AgeMinimum`
- `CK_Produit_PrixPositif`
- `CK_Commande_TotalSuperieurOuEgalZero`

### Recommandation

Le nom doit refléter la règle de validation imposée.

---

## 4. Tableau synthèse

| Type d'objet | Format |
|---|---|
| Clé primaire | `PK_<nomTable>` |
| Clé étrangère | `FK_<nomTableDuChamp><nomDuChamp>` |
| Index | `IX_<nomDuChamp|description>` |
| Procédure utilisateur | `USP_<nomProcedure>` |
| Fonction utilisateur | `UDF_<nomFonction>` |
| Séquence | `SQ_<nomSequence>` |
| Trigger | `TR_<nomTrigger>` |
| Contrainte CHECK | `CK_<nomContrainte>` |

---

## 5. Exemple d'application

```sql
CREATE TABLE Client
(
    Id INT NOT NULL,
    Nom NVARCHAR(100) NOT NULL,
    Prenom NVARCHAR(100) NOT NULL,
    DateCreation DATETIME2 NOT NULL,
    EstActif BIT NOT NULL,
    Age INT NOT NULL,

    CONSTRAINT PK_Client PRIMARY KEY (Id),
    CONSTRAINT CK_Client_AgeMinimum CHECK (Age >= 14)
);
GO

CREATE TABLE Commande
(
    Id INT NOT NULL,
    ClientId INT NOT NULL,
    DateCommande DATETIME2 NOT NULL,
    MontantTotal DECIMAL(10,2) NOT NULL,

    CONSTRAINT PK_Commande PRIMARY KEY (Id),
    CONSTRAINT FK_CommandeClientId
        FOREIGN KEY (ClientId) REFERENCES Client(Id),
    CONSTRAINT CK_Commande_TotalSuperieurOuEgalZero
        CHECK (MontantTotal >= 0)
);
GO

CREATE INDEX IX_Commande_ClientId_DateCommande
ON Commande (ClientId, DateCommande);
GO

CREATE SEQUENCE SQ_NumeroCommande
    START WITH 1
    INCREMENT BY 1;
GO

CREATE PROCEDURE USP_ObtenirCommandesParClient
    @ClientId INT
AS
BEGIN
    SELECT Id,
           ClientId,
           DateCommande,
           MontantTotal
    FROM Commande
    WHERE ClientId = @ClientId;
END;
GO
```

---

## 6. Recommandations complémentaires

### 6.1 Utilisation des schémas

Lorsque pertinent, les objets devraient être regroupés par schéma logique.

**Exemples** :

- `dbo.Client`
- `vente.Commande`
- `catalogue.Produit`

L'usage des schémas améliore l'organisation, la sécurité et la lisibilité globale du modèle.

---

### 6.2 Cohérence avant sophistication

Une convention simple, appliquée uniformément dans tout le projet, est préférable à une convention très détaillée appliquée de manière partielle.

---

### 6.3 Éviter la surinformation

Les noms doivent rester informatifs sans devenir inutilement lourds.

**Recommandé** :

- `IX_Commande_ClientId_DateCommande`

**À éviter** :

- `IX_TableCommande_ColonneClientId_ColonneDateCommande_IndexNonClustered`

---

### 6.4 Compatibilité avec les outils et scripts

Les noms choisis doivent demeurer compatibles avec :

- les scripts de création et de migration ;
- les outils d'administration ;
- les conventions de déploiement ;
- les revues de code et l'analyse automatisée.

---

## 7. Résumé normatif

Les règles suivantes doivent être appliquées dans tous les nouveaux développements SQL Server du projet :

- utiliser le **PascalCase** ;
- nommer les tables au **singulier** ;
- choisir des noms explicites et stables ;
- éviter les espaces, accents, tirets et mots réservés ;
- nommer les clés primaires selon `PK_<nomTable>` ;
- nommer les clés étrangères selon `FK_<nomTableDuChamp><nomDuChamp>` ;
- nommer les index selon `IX_<nomDuChamp|description>` ;
- nommer les procédures utilisateur selon `USP_<nomProcedure>` ;
- nommer les fonctions utilisateur selon `UDF_<nomFonction>` ;
- nommer les séquences selon `SQ_<nomSequence>` ;
- nommer les triggers selon `TR_<nomTrigger>` ;
- nommer les contraintes CHECK selon `CK_<nomContrainte>`.
