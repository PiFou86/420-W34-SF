# Module 08 - Procédures, fonctions et curseurs

## Exercice 1 - Des prénoms / noms

- Écrivez une fonction qui renvoie un prénom aléatoire.
- Écrivez une fonction qui renvoie un nom aléatoire.

## Exercice 2 - Des listes de prénoms / noms

- Écrivez une fonction qui génère une liste de `n` prénoms / noms / date de naissance aléatoires

## Exercice 3 - WideWorldImporters

### Exercice 3.1 - Liste des utilisateurs

Écrivez une procédure qui prend en paramètre une partie de nom d'utilisateur et qui affiche la liste des utilisateurs qui correspondent à cette partie de nom d'utilisateur.

### Exercice 3.2 - Modification du nom d'utilisateur

Écrivez une procédure stockée qui prend en paramètre l'identifiant d'un utilisateur et un nouveau nom d'utilisateur et qui modifie le nom d'utilisateur de l'utilisateur.

### Exercice 3.3 - Changement de mot de passe

- Écrivez la procédure "ChangerMotDePasse" qui prend en paramètre un nom d'utilisateur, l'ancien et le nouveau mot de passe et qui change le mot de passe de l'utilisateur si l'ancien mot de passe est correct :
  - Table `[Application].[People]`
  - Valider l'ancien mot de passe : comparer le mot de passe hashé avec le résultat de l'appel de la fonction `HASHBYTES(N'SHA2_256', @OldPassword + FullName)`
  - Met à jour le mot de passe, c'est à dire le mot de passe hashé avec la valeur `HASHBYTES(N'SHA2_256', @NewPassword + FullName) WHERE Username = @Username`
  - Met à jour la possibilité de se connecter à la valeur 1
  - Interdit de modifier le mot de passe de l'utilisateur `1`
  - Affiche (avec `PRINT`) si le mot de passe a été modifié ou non

<details>
    <summary>Correction</summary>

Voir le code de la procédure stockée `[Website].[ChangePassword]`.

</details>

### Exercice 3.4 - Curseurs

- Écrivez une procédure qui insère les noms des utilisateurs débutant par une lettre de `a` à `l` dans la table "UtilisateursAL" et les utilisateurs de `m` à `z` dans la table "UtilisateursMZ". Cette procédure doit utiliser un curseur.
- Est-ce que vous pouvez faire la même chose sans un curseur ? Si oui, écrivez une nouvelle procédure et comparez les performances.

### Exercice 3.5 - Procédures utilitaires

- Écrivez une procédure qui renvoie la dernière commande d'un client
- Écrivez une procédure qui renvoie la dernière facture d'un client
- Écrivez une procédure qui écrit le total d'une commande. Elle affiche "La commande n'existe pas" si la commande n'existe pas. Si la commande existe, elle affiche "La commande numéro 123 a un total de : 12355$"
- Écrivez une procédure qui renvoie le nombre total de commandes d'un client
- Écrivez une procédure qui renvoie le nombre total de factures d'un client
