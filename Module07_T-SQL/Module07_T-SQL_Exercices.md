# Module 07 - T-SQL

## Pré-requis

Matériel requis : summit.sql (à exécuter avant de commencer si nécessaire)

## Exercice 1 - Expérience avec "GO"

Écrivez un script SQL qui :

- déclare une variable `@i` de type `int`
- mettez la variable `@i` à 42
- affiche la valeur de la variable `@i` dans la console
- ajoute l'instruction `GO` directement après la déclaration/affectation de votre variable.
- affiche de nouveau la valeur de la variable `@i` dans la console : que constatez-vous ?

## Exercice 2 - Vive les boucles !

- Écrivez un script SQL qui affiche les nombres de 1 à 10 dans la console.
- Modifier le script précédent pour afficher en plus si le nombre est pair ou impair.

## Exercice 3 - Summit.sql

### Exercice 3.1 - Statistiques sur les salaires

Écrivez un script qui compte et affiche dans la console le nombre d'employés ayant un salaire de moins de 1000 $ et le nombre d'employés gagnant 1000 $ et plus. Voici un exemple de sortie :

```
Employés gagnant moins de 1000 $ :
7
Employés gagnant 1000 $ et plus :
18
```

### Exercice 3.2 - Meilleur vendeur

Écrivez un script qui affiche dans la console le meilleur vendeur de la compagnie, c'est-à-dire celui dont le total des ventes est le plus élevé.

```
L'employé ayant vendu le plus est: Magee, Colin
et il a vendu 1629066.37$
```

## Exercice 4 - Palindrome

- Déclarez une variable `@mot` de type `varchar(50)`
- Mettez la variable `@mot` à `engagelejeuquejelegagne` (oui, c'est un palindrome)
- Écrivez un script SQL qui affiche le mot `@mot` dans la console et qui affiche si le mot est un palindrome ou non.

## Exercice 5 - Execution de chaines - Optionel

- Écrivez un script SQL qui affiche la date du jour dans la console
- Transférez ce script en chaines de caractères dans une variable `@script`
- Utilisez l'instruction `EXECUTE sp_executesql @script` pour afficher la date du jour dans la console
- Générez une nouvelle chaine qui contient 10 instructions `PRINT` qui affichent les nombres de 1 à 10 (en utilisant une boucle)
- Exécutez cette chaine de caractères !
