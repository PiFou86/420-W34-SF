IF DB_ID('Module10_ORM') IS NULL
BEGIN
	CREATE DATABASE Module10_ORM;
END

USE Module10_ORM;
GO

CREATE TABLE Personne (
    PersonneId INT IDENTITY PRIMARY KEY,
    Nom VARCHAR(30) NOT NULL,
    Prenom VARCHAR(30) NOT NULL
);
GO

CREATE TABLE Adresse (
    AdresseId INT IDENTITY PRIMARY KEY,
    PersonneId INT NOT NULL,
    NoCivique VARCHAR(10) NOT NULL,
    Odonyme VARCHAR(50) NOT NULL,
    Ville VARCHAR(50) NOT NULL,
    CONSTRAINT FK_Adresse_Proprietaire_Adresse FOREIGN KEY (PersonneId) REFERENCES Personne(PersonneId)
);
GO

ALTER TABLE Personne
ADD AdresseActuelleId INT NULL;

ALTER TABLE Personne
ADD CONSTRAINT FK_Personne_Adresse_Actuelle FOREIGN KEY (AdresseActuelleId) REFERENCES Adresse(AdresseId);

INSERT INTO Personne(Nom, Prenom) VALUES ('Vière', 'Marie');
INSERT INTO Personne(Nom, Prenom) VALUES ('Éparbal', 'Gille');
INSERT INTO Personne(Nom, Prenom) VALUES ('Terrieur', 'Alex');

INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Lévis');
INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Québec');
INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Montréal');

UPDATE Personne SET AdresseActuelleId = 1 WHERE PERSONNEID = 1;

CREATE OR ALTER PROCEDURE Obtenir_Adresses_Ville_Contenant(@p_partie_ville VARCHAR)
AS
BEGIN
    SELECT AdresseId, PersonneId, NoCivique, Odonyme, Ville
    FROM Adresse
    WHERE Ville LIKE '%' + @p_partie_ville + '%'
END;
GO



SELECT * FROM Personne;
SELECT * FROM Adresse;

EXECUTE Obtenir_Adresses_Ville_Contenant 'é';