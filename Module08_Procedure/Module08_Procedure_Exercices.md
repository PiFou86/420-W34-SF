# Module 08 - Procédures, fonctions et curseurs

## Exercice 1 - Des prénoms / noms

- Écrivez une fonction qui renvoie un prénom aléatoire.
- Écrivez une fonction qui renvoie un nom aléatoire.

## Exercice 2 - Des listes de prénoms / noms

- Écrivez une fonction qui génère une liste de `n` prénoms / noms / date de naissance aléatoires

## Exercice 3 - Summit.sql

### Exercice 3.1

Créez une procédure nommée augmenterEmployes qui augmente le salaire de tous les employés de 10%.

### Exercice 3.2

Créez une procédure nommée ajouterEmploye qui reçoit le numéro, le prénom, le nom et le département de l’employé et qui ajoute ce nouvel employé à la base de données. 

Vous devrez générer le userid qui est composé de la 1ère lettre du prénom et des 7 premières lettres du nom de famille. Le tout est en minuscules.

### Exercice 3.3

Modifiez la procédure ajouterEmploye afin de fournir aussi le numéro du supérieur de l’employé. Ce nouvel argument doit être facultatif. Si on ne fournit pas de numéro de supérieur, le supérieur de l’employé doit être l’employé numéro 1 (la présidente).

### Exercice 3.4

Créez une procédure nommée spProc1. La procédure reçoit en argument un entier qui est un numéro de commande. Elle affiche alors le total de la commande correspondante. Si le numéro de commande n'existe pas, la procédure doit afficher un message, par exemple avec une exécution demandée pour le numéro 10, on reçoit le message :

Le total de la commande 102 est 8335$
ou
Il n'y a pas de commande : 10

### Exercice 3.5

Créez une procédure nommée spProc2. La procédure reçoit en argument un numéro de client et affiche la commande la plus récente de ce client. La procédure doit indiquer clairement si le numéro de client fourni n'existe pas, ou bien si le client existe mais n'a jamais fait de commande. La procédure fait appel à la procédure spProc1 pour l'affichage du total de la commande. Testez avec le client 208, vous devriez obtenir la commande 104.

 
### Exercice 3.6

Créez une procédure nommée spProc3. La procédure reçoit un nom de client et affiche la commande la plus récente de ce client. La procédure doit afficher si le nom de client est inexistant. La procédure trouve le numéro de client associé au nom de client et appelle spProc2 avec ce numéro. Testez avec 'Muench Sports' qui est le client 208, vous devriez donc obtenir la commande 104. Testez aussi un nom inexistant.


### Exercice 3.7

Créez une procédure nommée spProc4. La procédure reçoit un numéro de vendeur (d'employé) en argument et affiche le nombre de clients ayant fait affaire avec cet employé. Le script doit indiquer clairement si le numéro transmis est inexistant ou si l'employé n'a jamais fait affaire avec un client.

La procédure doit retourner le code 0 si tout est correct, 1 si le numéro d’employé est inexistant et 2 si cet employé n’a pas de clients. À des fins de vérification, sachez que les employés 11, 12, 13, 14 et 15 traitent avec les clients.


### Exercice 3.8

Créez une fonction qui reçoit en paramètre un numéro de client et qui retourne le nom complet de ce client.

### Exercice 3.9

Bâtissez la fonction fctInventaire qui calcule et retourne la valeur de l'inventaire de l'entrepôt (warehouse) dont le numéro (id) est passé en paramètre. Pour calculer la valeur de l'inventaire, il faut faire la somme des quantités en stock (AMOUNT_IN_STOCK) multipliées par la valeur unitaire du produit (SUGGESTED_WHLSL_PRICE), et ce pour chaque produit. 

À titre de vérification :
```
select fctInventaire (301) ;
affiche 163045.00

select fctInventaire (401) ;
afffiche 339094.71
```

## Exercice 4 - WideWorldImporters

### Exercice 4.1 - Liste des utilisateurs

Écrivez une procédure qui prend en paramètre une partie de nom d'utilisateur et qui affiche la liste des utilisateurs qui correspondent à cette partie de nom d'utilisateur.

### Exercice 4.2 - Modification du nom d'utilisateur

Écrivez une procédure stockée qui prend en paramètre l'identifiant d'un utilisateur et un nouveau nom d'utilisateur et qui modifie le nom d'utilisateur de l'utilisateur. (Vous devez mettre le champ ValidFrom à la date du jour)

### Exercice 4.3 - Changement de mot de passe

- Écrivez la procédure "ChangerMotDePasse" qui prend en paramètre un nom d'utilisateur, l'ancien et le nouveau mot de passe et qui change le mot de passe de l'utilisateur si l'ancien mot de passe est correct :
  - Table `[Application].[People]`
  - Valider l'ancien mot de passe : comparer le mot de passe hashé avec le résultat de l'appel de la fonction `HASHBYTES(N'SHA2_256', @OldPassword + FullName)`
  - Met à jour le mot de passe, c'est à dire le mot de passe hashé avec la valeur `HASHBYTES(N'SHA2_256', @NewPassword + FullName) WHERE Username = @Username`
  - Met à jour le champ ValidFrom pour la date du jour
  - Met à jour la possibilité de se connecter à la valeur 1
  - Interdit de modifier le mot de passe de l'utilisateur `1`
  - Affiche (avec `PRINT`) si le mot de passe a été modifié ou non

<details>
    <summary>Correction</summary>

Voir le code de la procédure stockée `[Website].[ChangePassword]`.

</details>

### Exercice 4.4 - Curseurs

- Écrivez une procédure qui insère les noms des utilisateurs débutant par une lettre de `a` à `l` dans la table "UtilisateursAL" et les utilisateurs de `m` à `z` dans la table "UtilisateursMZ". Cette procédure doit utiliser un curseur.
- Est-ce que vous pouvez faire la même chose sans un curseur ? Si oui, écrivez une nouvelle procédure et comparez les performances.

### Exercice 4.5 - Procédures utilitaires

- Écrivez une procédure qui renvoie la dernière commande d'un client
- Écrivez une procédure qui renvoie la dernière facture d'un client
- Écrivez une procédure qui écrit le total d'une commande. Elle affiche "La commande n'existe pas" si la commande n'existe pas. Si la commande existe, elle affiche "La commande numéro 123 a un total de : 12355$"
- Écrivez une procédure qui renvoie le nombre total de commandes d'un client
- Écrivez une procédure qui renvoie le nombre total de factures d'un client
