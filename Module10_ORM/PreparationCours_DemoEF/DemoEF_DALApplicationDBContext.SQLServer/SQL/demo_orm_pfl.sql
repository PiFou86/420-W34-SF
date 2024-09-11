USE master;
GO

IF 1 = 0
BEGIN
	DECLARE @kill varchar(8000) = '';  
	SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
	FROM sys.dm_exec_sessions
	WHERE database_id  = db_id('Module10_ORM')

	EXEC(@kill);

	DROP DATABASE Module10_ORM;
END

IF DB_ID('Module10_ORM') IS NULL
BEGIN
	CREATE DATABASE Module10_ORM;
END
GO

USE Module10_ORM;
GO

IF NOT EXISTS(SELECT name FROM sys.sysobjects WHERE Name = N'Personne' AND xtype = N'U')
BEGIN
	CREATE TABLE Personne (
		PersonneId INT IDENTITY PRIMARY KEY,
		Nom VARCHAR(30) NOT NULL,
		Prenom VARCHAR(30) NOT NULL
	);

	INSERT INTO Personne(Nom, Prenom) VALUES ('Vière', 'Marie');
	INSERT INTO Personne(Nom, Prenom) VALUES ('Éparbal', 'Gille');
	INSERT INTO Personne(Nom, Prenom) VALUES ('Terrieur', 'Alex');

	CREATE TABLE PersonneHistorique (
		PersonneHistoriqueId INT IDENTITY PRIMARY KEY,
		PersonneId INT NOT NULL,
		Nom VARCHAR(30) NOT NULL,
		Prenom VARCHAR(30) NOT NULL,
		AdresseActuelleId INT NULL,
		UpdateDate DATETIME NOT NULL,
		UpdateBy NVARCHAR(128) NOT NULL
	);
END;

IF NOT EXISTS(SELECT name FROM sys.sysobjects WHERE Name = N'Adresse' AND xtype = N'U')
BEGIN
	CREATE TABLE Adresse (
		AdresseId INT IDENTITY PRIMARY KEY,
		PersonneId INT NOT NULL,
		NoCivique VARCHAR(10) NOT NULL,
		Odonyme VARCHAR(50) NOT NULL,
		Ville VARCHAR(50) NOT NULL,
		CONSTRAINT FK_Adresse_Proprietaire_Adresse FOREIGN KEY (PersonneId) REFERENCES Personne(PersonneId)
	);

	ALTER TABLE Personne
	ADD AdresseActuelleId INT NULL;

	ALTER TABLE Personne
	ADD CONSTRAINT FK_Personne_Adresse_Actuelle FOREIGN KEY (AdresseActuelleId) REFERENCES Adresse(AdresseId);

	INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Lévis');
	INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Québec');
	INSERT INTO Adresse(PersonneId, NoCivique, Odonyme, Ville) VALUES (1, '123', 'Chat', 'Montréal');

	UPDATE Personne SET AdresseActuelleId = 1 WHERE PERSONNEID = 1;
END;
GO

CREATE OR ALTER PROCEDURE Obtenir_Adresses_Ville_Contenant(@p_partie_ville VARCHAR)
AS
BEGIN
    SELECT AdresseId, PersonneId, NoCivique, Odonyme, Ville
    FROM Adresse
    WHERE Ville LIKE '%' + @p_partie_ville + '%'
END;
GO

CREATE OR ALTER TRIGGER TR_PersonneU_Historisation
ON Personne AFTER UPDATE
AS
	INSERT INTO PersonneHistorique(PersonneId, Nom, Prenom, AdresseActuelleId, UpdateDate, UpdateBy)
	SELECT PersonneId, Nom, Prenom, AdresseActuelleId, GETDATE(),  SUSER_SNAME()
	FROM deleted
GO


EXECUTE Obtenir_Adresses_Ville_Contenant 'é';


SELECT * FROM Personne;
SELECT * FROM Adresse;
SELECT * FROM PersonneHistorique;