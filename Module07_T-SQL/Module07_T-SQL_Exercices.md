# Module 07 - T-SQL

## Exercice 1 - Expérience avec "GO"

Écrivez un script SQL qui :

- déclare une variable `@i` de type `int`
- mettez la variable `@i` à 42
- affiche la valeur de la variable `@i` dans la console
- ajoute l'instruction `GO`
- affiche de nouveau la valeur de la variable `@i` dans la console : que constatez-vous ?

## Exercice 2 - Vive les boucles !

- Écrivez un script SQL qui affiche les nombres de 1 à 10 dans la console.
- Modifiez le script précédent pour afficher les nombres de 1 à 100 dans la console.
- Modifier le script précédent pour afficher en plus si le nombre est pair ou impair.
- Écrivez un nouveau script qui affiche les nombres de 100 à 1 dans la console.

## Exercice 3 - Palindrome

- Déclarez une variable `@mot` de type `varchar(50)`
- Mettez la variable `@mot` à `engagelejeuquejelegagne` (oui, c'est un palindrome)
- Écrivez un script SQL qui affiche le mot `@mot` dans la console et qui affiche si le mot est un palindrome ou non.

## Exercice 4 - Execution de chaines

- Écrivez un script SQL qui affiche la date du jour dans la console
- Transférez ce script en chaines de caractères dans une variable `@script`
- Utilisez l'instruction `EXECUTE sp_executesql @script` pour afficher la date du jour dans la console
- Générez une nouvelle chaine qui contient 10 instructions `PRINT` qui affichent les nombres de 1 à 10 (en utilisant une boucle)
- Exécutez cette chaine de caractères !