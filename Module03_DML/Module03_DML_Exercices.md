# Module 03 - Langage de manipulation de données

Dans ce module, vous allez devoir dessiner les étapes d'exécutions de requêtes sur des exemples simples afin de valider votre compréhension de l'ordre des exécutions des différentes parties de l'instruction ```SELECT```.

Vous allez ensuite devoir installer la base de données "Wide World Importers" provenant des bases de données exemple de Microsoft.

La base de données "Wide World Importers" est décrite dans la documentation :

- [Informations générales](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-what-is)
- [Description des schémas et des tables](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-oltp-database-catalog)
- [Génération de données jusqu'à la date courante](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-generate-data)

## Préalable 1 - Restoration de la base de données "Wide World Importers"

### Préalable 1.1 - Téléchargement de la base de données

- Téléchargez le [fichier zip ici](https://1drv.ms/u/s!AmZSjqmP5Ux1kaQW7lYjSAsH89pDmw?e=XTOVOG)
- Désarchivez le fichier dans le répertoire ```C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup```

### Préalable 1.2 - Restoration de la base de données

- Lancez SSMS et connectez-vous à votre SGBD
- À partir de l'explorateur d'objets, faites un clic droit sur l'option "Databases" et choisissez "Restore Database..."
![Restoration de la base de données - Option](img/WideWorldImporters_Restore00.png)
- Dans la nouvelle fenêtre, sélectionnez l'option "Device" et spécifiez le chemin de votre fichier à restaurer grâce à l'option "..."
- La base de données ainsi que le plan de restauration vont s'afficher en dessus du chemin du fichier : cliquez simplement sur le bouton "OK"
![Restoration de la base de données - Choix du fichier et restoration](img/WideWorldImporters_Restore01.png)
- SSMS devrait vous indiquer que la restauration a été effectuée avec succès

## Exercice 1 - On expérimente le papier

Soit les tables "etudiant", "cours" et "etudiant_cours" :

| **etudiantId** | **prenom** | **nom**  |
|----------------|------------|-----------|
| 1       | Marie   | Vière   |
| 2       | Alex    | Terrieur |
| 3       | Alain   | Terrieur |
| 4       | Gille   | Éparballe |
| 5       | Alain   | Verse   |

| **coursId** | **titre**               |
|-------------|---------------------------------------|
| 1      | Philosophie              |
| 2      | Introduction à la productivité    |
| 3      | Viennoiserie - Spécialité Chocolatine |

| **etudiantId** | **coursId** | **dateDebut** | **dateFin** | **noteFinale** |
|----------------|-------------|---------------|-------------|----------------|
| 1       | 3      | 2022-08-29  | NULL    | NULL      |
| 2       | 3      | 2022-08-29  | NULL    | NULL      |
| 3       | 3      | 2022-08-29  | NULL    | NULL      |
| 4       | 3      | 2022-01-03  | 2022-06-06 | 54       |
| 5       | 3      | 2022-01-03  | NULL    | NULL      |
| 5       | 3      | 2022-08-29  | NULL    | NULL      |
| 1       | 1      | 2022-01-03  | 2022-06-06 | 81       |
| 2       | 1      | 2022-01-03  | 2022-06-06 | 50       |
| 3       | 1      | 2022-01-03  | 2022-06-06 | 75       |
| 4       | 1      | 2022-01-03  | 2022-06-06 | 45       |
| 5       | 1      | 2022-01-03  | NULL    | NULL      |

- Sur papier, écrivez les requêtes suivantes et illustrez-les comme dans le cours :

 - Affichez le titre de tous les cours qui contiennent la lettre 'c' dans le titre
 - Affichez les étudiants qui suivent au moins deux cours avec le nombre de cours suivi (dateFin IS NULL)
 - Affichez le nombre de cours réussis pour chaque étudiant
 - Affichez la liste des cours suivis par au moins un étudiant pour la session qui a débuté le '2022-08-29'

- Ouvrez SSMS et implantez les tables et les données dans la base de données 'M03_Exercice1'
- Testez vos requêtes précédentes

## Exercice 2 - Wide World Importers - Warehouse

Voici une extraction des tables contenues dans le schéma "Warehouse" avec lequel vous allez travailler. Pour plus de détails, vous pouvez [vous référer à la référence ici](../BDs/README.md).

![Diagramme physique](img/WideWorldImporters_Physique_Warehouse.png)

- Analysez les champs de la table "Warehouse.StockItems"
- Écrivez les requêtes suivantes à partir du schéma "Warehouse" :
 - Affichez l'ensemble des produits donc la quantité disponible est supérieure à 500000
 - Affichez l'ensemble des produits qui ont au moins deux groupes
 - Affichez l'ensemble des produits qui n'ont pas de groupe

## Exercice 3 - Wide World Importers - Sales

- Connectez-vous à votre SGBD avec SSMS
- À partir de l'option "Database Diagrams" de la base de données "Wide World Importers", créez un diagramme qui contient la table "Invoices" et "Orders" et ses dépendances directes du schéma "Sales".
- Écrivez les requêtes suivantes :
 1. Affichez les commandes non facturées
 2. Comptez le nombre de commandes non facturées
 3. Prenez l'identifiant d'une de ces commandes et affichez le détail de la commande avec le total avant taxes et après taxes
 4. Affichez le chiffre d'affaire non facturé
 5. Affichez le chiffre d'affaire non facturé par année
 6. Affichez le chiffre d'affaire non facturé par année et par mois
 7. Affichez les commandes de plus de 3 articles qui ne sont pas facturées
 8. Affichez la facture 4242 avec son détail (+ montant sans et avec taxes)
 9. À partir de votre précédente requête, trouvez une manière d'insérer le résultat dans la nouvelle table "Facture_4242" (Ne pas faire d'INSERT ici voir [SELECT ... INTO](https://learn.microsoft.com/en-us/sql/t-sql/queries/select-into-clause-transact-sql))
 10. Créez une nouvelle table dans le schéma "Sales" qui s'appelle "InvoicesCache" qui permettra d'ajouter de l'information aux factures sans toucher aux tables d'origines. Elle doit contenir, en plus des informations de liaisons :
   - Le montant total des taxes
   - Le montant de la facture avant et après taxes
 11. Écrivez une requête d'insertion qui remplit la nouvelle table
 12. Ajoutez une clause à votre requête qui vous évite les erreurs d'insertion à la deuxième exécution de la requête.

## Exercice 4 - Summit (Optionnel - Exercices en plus)

### Exercice 4.1 - Importation de la base de données

- Prenez le fichier `summit.sql`` et exécutez le

### Exercice 4.2 - Select / From / Where

1. Affichez la liste des clients avec le nom de leur vendeur associé. (14 enregistrements)
2. Affichez le nom, le titre d’emploi et la date d'embauche des employés qui ont été embauchés entre le 15 mai 1990 et le 30 décembre 1991. Affichez le tout en ordre décroissant de nom de famille. (13 enregistrements)
3. Affichez le nom de tous les employés du département des ventes (sales) dont le salaire n’est pas entre 1500 et 2000 (5 enregistrements)
4. Affichez le nom et le titre des employés qui n’ont pas de supérieur. (1 enregistrement)
5. Affichez les noms des employés dont la troisième lettre est un a. (2 enregistrements)
6. Affichez le nom des employés qui ont un n dans leur nom et que leur département est Operations. (7 enregistrements)
7. Affichez l’adresse des entrepôts ayant en stock le produit New Air Pump. (4 enregistrements)
8. Affichez le numéro des commandes comportant un des produits suivants : Bunny Boot, Bunny Ski Pole, Pro Ski Boot ou Pro Ski Pole. La requête ne doit pas produire le même numéro de commande plus d'une fois. (2 enregistrements)
9. Affichez le numéro, nom et prénom des employés dont le prénom est Mark ou Colin ET dont le nom est Patel ou Magee. (1 enregistrement)
10. Affichez le nom des clients, le numéro de la commande ainsi que la date de la commande pour toutes les commandes commandées entre le 4 et le 9 septembre 1992 inclusivement et qui ont été payées par carte de crédit. Le résultat de la requête doit être trié par nom de client en ordre décroissant. (5 enregistrements)
11. Affichez le no, nom, le salaire mensuel de l'employé et le montant d’une augmentation potentielle de 15 %, renommez cette dernière colonne Montant de l’augmentation. (25 enregistrements)
12. Affichez tous les numéros de commande ainsi que les dates de commande et de livraison pour toutes les commandes ayant été effectuées pendant un mois d'août et expédiées pendant un mois de septembre, peu importe l'année. (6 enregistrements)
13. Affichez le nom de l'employé, sa date d'embauche et ajoutez une colonne affichant la date de révision du salaire. Cette date est après six mois de service. (25 enregistrements)
14. Pour chaque employé dont le salaire bi-annuel (2 fois par année) est 9000 $ ou plus, affichez le nom complet, le salaire et la date d’embauche. (4 enregistrements)
15. Affichez le nombre d’années qui se sont écoulées depuis l’embauche de Carmen Velasquez. Arrondissez la valeur obtenue à deux chiffres après la virgule. (1 enregistrement)
16. Affichez le nom de famille des employés, leur date d'embauche et leur ancienneté. L'ancienneté est équivalente aux années entièrement complétées (pas de décimales). Les titres des colonnes à l'affichage doivent être les suivants : Nom, Date d'embauche, Ancienneté. (25 enregistrements)
17. Pour chaque produit de la commande 106, affichez le nom du produit, la quantité achetée, le prix unitaire, le sous-total avant taxes ainsi que le total avec taxes. (6 enregistrements)

### Exercice 4.3 - Select / From / Where

1. Affichez le nom et le salaire de tous les employés qui gagne plus de 1000.00 $ mensuellement. Le salaire inscrit dans la base de données est un salaire mensuel. (18 enregistrements)
2. Affichez le nom de tous les employés du département 50. (2 enregistrements)
3. Affichez le nom, le numéro et la cote de crédit des clients dont le numéro de représentant est 11. Les enregistrements retournés doivent être affichés en ordre croissant de nom de client. (4 enregistrements)
4. Affichez le nom de l'employé et son titre mais le tout sous la forme suivante: "Magee est un Sales Representative". La nouvelle colonne se nomme Description. (25 enregistrements)
5. Affichez la liste des clients avec le nom de leur vendeur associé. (14 enregistrements)
6. Affichez le nom, le titre d’emploi et la date d'embauche des employés qui ont été embauchés entre le 15 mai 1990 et le 30 décembre 1991. Affichez le tout en ordre décroissant de nom de famille. (13 enregistrements)
7. Affichez le nom de tous les employés du département des ventes (sales) dont le salaire n’est pas entre 1500 et 2000 (5 enregistrements)
8. Affichez le nom et le titre des employés qui n’ont pas de supérieur. (1 enregistrement)
9. Affichez les noms des employés dont la troisième lettre est un a. (2 enregistrements)
10. Affichez le nom des employés qui ont un n dans leur nom et que leur département est Operations. (5 enregistrements)
11. Affichez le nom, le numéro et la cote de crédit des clients dont le nom de famille de leur représentant est Magee. Les enregistrements retournés doivent être affichés en ordre croissant de nom de client. (4 enregistrements)
12. Affichez le nom des produits inscrits sur la commande 102. (2 enregistrements) 
13. Affichez le nom des clients qui ont déjà payés une commande par carte de crédit (CREDIT). (12 enregistrements)
14. Affichez les clients qui ont une cote de crédit excellente et qui habitent en Europe, information fournie par la table S_REGION. (2 enregistrements)
15. Affichez l’adresse des entrepôts ayant en stock le produit New Air Pump. (4 enregistrements)
16. Affichez le numéro des commandes comportant un des produits suivants : Bunny Boot, Bunny Ski Pole, Pro Ski Boot ou Pro Ski Pole. La requête ne doit pas produire le même numéro de commande plus d'une fois. (2 enregistrements)
17. Affichez l'adresse des entrepôts de la région America, ce qui inclut South America et North America. (2 enregistrements)
18. Affichez le numéro, nom et prénom des employés dont le prénom est Mark ou Colin ET dont le nom est Patel ou Magee. (1 enregistrement)
19. Affichez le nom des vendeurs (first_name et last_name sur une même colonne et séparés d'une espace) et le nom de tous leurs clients (name). Triez en ordre croissant de nom de vendeur et de clients. Utilisez des noms de colonnes significatifs dans votre affichage. (14 enregistrements)
20. Affichez le nom des clients, le numéro de la commande ainsi que la date de la commande pour toutes les commandes commandées entre le 4 et le 9 septembre 1992 inclusivement et qui ont été payées par carte de crédit. Le résultat de la requête doit être trié par nom de client en ordre décroissant

### Exercice 4.4 - Agrégation

1. Affichez le nombre de personnes par corps d'emploi (title). Triez les enregistrements en ordre croissant du nombre. (8 enregistrements)
2. Affichez le id et le nom de chaque département avec le total d’employés pour chacun ainsi que le salaire moyen du département. Triez les enregistrements en ordre décroissant de salaire moyen. (12 enregistrements)
3. Affichez la moyenne du montant des achats des commandes de chaque client. Le nom du client doit apparaître. (13 enregistrements)
4. Affichez le salaire maximum, minimum, la moyenne ainsi que la somme. Renommez ces colonnes MAXIMUM, MINIMUM, MOYENNE, SOMME. (1 enregistrement)
5. Modifiez la requête précédente afin qu'elle affiche ces résultats pour chaque corps d'emploi. (8 enregistrements)
6. Affichez le nombre de supérieurs différents (manager_id) sans toutefois afficher leurs noms. (1 enregistrement)
7. Affichez la différence entre le plus haut et le plus bas salaire. (1 enregistrement)
8. Pour chaque commande, affichez la quantité moyenne d'items commandés et le numéro de commande. Vous ne devez faire afficher que les commandes dont la quantité moyenne d'items est supérieure à 70. (4 enregistrements)
9. Combien y a-t-il d'enregistrements dans la table s_product ? Vous ne devez pas faire afficher tous les enregistrements afin de le déterminer. (1 enregistrement)
10. Quel est le total des ventes par nom de vendeur (nom complet sur une seule colonne, séparé d'une espace) ? L’affichage doit comporter également le numéro de vendeur (sales_rep_id ) et le total des ventes pour chaque vendeur. (5 enregistrements)
11. Affichez le nombre de commandes qui existent par région. L'affichage doit contenir le nom de chacune des régions avec le nombre total de commande pour chacune d'entre elle. (5 enregistrements)
12. Affichez le nombre d'employés embauchés par année. L'affichage doit contenir l'année d'embauche avec le nombre d'employés embauchés pour chacune des années trouvées à l'aide de la date d'embauche. (3 enregistrements)
13. Affichez pour chacun des produits, la quantité totale commandée. L'affichage doit inclure chaque nom de produit et la quantité totale commandée pour chacun de ces produits. Ne retourner que les enregistrements dont la quantité totale commandée est supérieure à 500. (4 enregistrements)
14. Affichez le nom des employés avec le nombre de clients gérés par chaque employé. (5 enregistrements)

## Exercice 5 - Importation des données #1 - Zonage municipal - Zones (Cours 3/3)

### Exercice 5.1 - Préparation de l'importation

1. Naviguez le site [Zonage municipal - Zones](https://www.donneesquebec.ca/recherche/dataset/vque_56/resource/36afc3b9-a6d5-447f-93fa-443f44e94b7c) et téléchargez le fichier CSV
2. Placez le fichier dans le répertoire 'C:\DFC-Info\S3\420-W34-SF\M03\Data'
3. Dupliquez deux fois ce fichier et nommez les copies : ```vdq-zonagemunicipalzones_01.csv``` et ```vdq-zonagemunicipalzones_02.csv```
4. Modifiez les deux fichiers dans Visual Studio Code de telle sorte que :
  1. Fichier ```vdq-zonagemunicipalzones_01.csv```
   1. Supprimez les lignes 2 à 6
  2. Fichier ```vdq-zonagemunicipalzones_02.csv```
   1. Supprimez les 5 dernières lignes de données
5. Créez la base de données "M03_Exercice4" et placez vous dedans
6. Créez les tables ```importation_vdq_zonagemunicipalzones_01``` et ```importation_vdq_zonagemunicipalzones_02``` avec les colonnes ```ID```, ```SUPERFICIE```, ```PERIMETRE``` de type ```VARCHAR(8000)``` et ```GEOMETRIE``` de type ```VARCHAR(max)```

### Exercice 5.2 - Importation de nos fichiers CSV

1. Importez les données des deux fichiers dans les tables éponymes. Pour cela, utilisez la requête suivante pour le premier fichier et adaptée-là pour le deuxième fichier :

```sql
BULK INSERT importation_vdq_zonagemunicipalzones_01
FROM N'C:\DFC-Info\S3\420-W34-SF\M03\Data\vdq-zonagemunicipalzones_01.csv'
WITH
(
    FORMAT='CSV',
    FIRSTROW=2
)
```

2. Validez que les deux tables contiennent bien les données
3. Essayez la requête suivante qui convertit la chaine de caractères de la géométrie dans le type ```geometry``

```sql
SELECT [ID]
   ,[SUPERFICIE]
   ,[PERIMETRE]
   ,GEOMETRY::Parse([GEOMETRIE]) AS GEOMETRIE
FROM importation_vdq_zonagemunicipalzones_01
```

4. Allez dans l'onglet "Spacial results" et observez l'affichage.

### Exercice 5.3 - Fusion de données

1. Créez la table ```zonageMunicipal``` qui contient tous les champs sus-mentionnés mais avec les bons types de données
2. Lisez [la documentation de l'instruction ```MERGE```](https://learn.microsoft.com/en-us/sql/t-sql/statements/merge-transact-sql) et appliquez la fusion de la table ```importation_vdq_zonagemunicipalzones_01``` dans la table ```zonageMunicipal```
3. Dans votre instruction ```MERGE```, ajouter le paramètre ```OUTPUT``` si ce n'est pas déjà fait avec le code suivant : ```OUTPUT deleted.*, $action, inserted.*```
4. Effectuer la même chose pour la deuxième table d'importation. Posez-vous les questions suivantes :
  1. Qu'avez-vous fait des enregistrements présents dans la source mais pas dans la destination ?
  2. Qu'avez-vous fait des enregistrements présents dans la destination mais pas dans la source ?
  3. Comment réagissez-vous l'action à prendre si la zone existe ?
5. Modifiez votre fichier SQL afin que vous puissiez l'exécuter sans erreur à chaque exécution : la BD doit être supprimée et recréée à chaque exécution par exemple
