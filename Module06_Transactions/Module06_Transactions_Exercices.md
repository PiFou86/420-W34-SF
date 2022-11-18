# Module 06 - Transactions / CTE / Sous-requêtes

## Exercice 1 - Transactions

Un nouveau pays a fait son apparition, le "Listenbourg". Depuis que son ministère de l'intérieur a [partagé la carte de son état](https://twitter.com/IntrListenbourg/status/1587114632061272064) ([Cache de l'image pour la pérennité](img/FgaQNkpX0AEP7cs.jpeg)), vous devez créer un script pour l'intégrer à notre base de données 'Wide World Importers'. En effet, ce nouvel état est une occasion à ne pas louper pour de nouvelles ventes !!

Écrire un script SQL qui :

1. Débute une transaction
2. Ajoute le pays "Listenbourg"
3. Fait un point de sauvegarde
4. Ajoute l'état "Province de la trompe"
5. Annule le dernier ajout
6. Ajoute les états :
    1. Fluberde
    2. Kusterde
    3. Mitteland
    4. Caséière
    5. Adriàs
7. Fait un point de sauvegarde
8. Ajoute la ville "LePainChocolat"
9. Annule le dernier ajout
10. Ajoute la capitale "Lurenberg" à l'état "Fluberde"
11. Valide la transaction

## Exercice 2 - CTE

Reprendre les requêtes suivantes et donnez une version simplifiée en utilisant le CTE :

```sql
-- Requête 1 - Évitez les calculs en double
SELECT o.OrderId
     , ol.[Description]
	 , ol.Quantity
	 , FORMAT(ol.UnitPrice, 'C') AS UnitPrice
	 , FORMAT(ol.Quantity * ol.UnitPrice, 'C') AS TotalHT
	 , FORMAT(ol.Quantity * ol.UnitPrice * ol.TaxRate / 100.0, 'C') AS Taxes
FROM Sales.Orders o
INNER JOIN Sales.OrderLines ol ON ol.OrderID = o.OrderID
WHERE o.OrderID = 217829

-- Requête 2 - Évitez les décompositions de dates dans le SELECT
SELECT 
	  i.InvoiceID
	, c.CustomerID
	, c.CustomerName
	, il.[Description]
	, il.Quantity
	, FORMAT(il.UnitPrice, 'C') AS PrixUnitaire
	, FORMAT(il.Quantity * il.UnitPrice, 'C') AS PrixHT
	, FORMAT(il.TaxAmount, 'C') AS Taxes
	, FORMAT(il.Quantity * il.UnitPrice + il.TaxAmount, 'C') AS PrixTTC
FROM Sales.Invoices i
INNER JOIN Sales.InvoiceLines il ON i.InvoiceID = il.InvoiceID
INNER JOIN sales.Customers c ON c.CustomerID = i.CustomerID
WHERE i.InvoiceID = 4242
GROUP BY 
	  i.InvoiceID
	, c.CustomerID
	, c.CustomerName
	, il.[Description]
	, il.Quantity
	, il.UnitPrice
	, il.Quantity * il.UnitPrice 
	, il.TaxAmount

-- Requête 3 - Évitez les sommes recalculées avec deux expressions
INSERT Sales.InvoicesCache(InvoiceID, MontantTaxes, MontantHT, MontantTTC)
SELECT 
	  i.InvoiceID
	, SUM(il.TaxAmount)
	, SUM(il.Quantity * il.UnitPrice)
	, SUM(il.Quantity * il.UnitPrice) + SUM(il.TaxAmount)
FROM Sales.Invoices i
INNER JOIN Sales.InvoiceLines il ON i.InvoiceID = il.InvoiceID
GROUP BY i.InvoiceID

-- Requête 4 - Simplifiez la requête en séparant la partie sélection des données de l'application de fonctions de fenêtrage
SELECT 
    ROW_NUMBER() OVER (ORDER BY i.InvoiceID, il.InvoiceLineID) AS NumeroLigne
  , i.InvoiceID
  , il.UnitPrice
  , il.Quantity 
  , FORMAT(il.Quantity * il.UnitPrice, 'C') AS PrixHT
  , FORMAT(il.TaxAmount, 'C') AS Taxes
  , FORMAT(SUM(il.Quantity * il.UnitPrice + il.TaxAmount) OVER (PARTITION BY i.InvoiceID ORDER BY il.InvoiceLineID ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW), 'C') AS TotalTTCCourant
FROM Sales.Invoices i
INNER JOIN Sales.InvoiceLines il ON il.InvoiceID = i.InvoiceID
WHERE i.InvoiceID = 126
ORDER BY i.InvoiceID
```

## Exercice 3 - Sous-requêtes

- Affichez le nom de la ville (Cities) qui est dans l'adresse postale de chaque client (Customers) avec son nom
- Affichez le nom de la ville et de l'état (StateProvince) de chaque client avec son nom
- Affichez le nom de la ville, de l'état et du pays (Countries) de chaque client avec son nom
- Affichez les vendeurs qui ont un volume de vente supérieur à la moyenne pour le mois de novembre 2020

## Exercice 4 - Réécritures

Réécrivez les requêtes précédentes sans utiliser de sous-requête.
