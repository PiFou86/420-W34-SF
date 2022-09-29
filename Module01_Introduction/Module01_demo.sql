USE master;
GO

IF DB_ID ('annuaire') IS NULL
CREATE DATABASE annuaire;
GO

USE annuaire;
GO

--DROP TABLE personne;
IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='personne' AND xtype='U')
CREATE TABLE personne (
	personneId UNIQUEIDENTIFIER PRIMARY KEY,
	nom VARCHAR(30) NOT NULL,
	prenom VARCHAR(30) NOT NULL,
	dateNaissance DATE NOT NULL,

	INDEX IX_personne_nom NONCLUSTERED (nom),
	INDEX IX_personne_prenom NONCLUSTERED (prenom)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='typeContact' AND xtype='U')
CREATE TABLE typeContact (
	typeContactId INT PRIMARY KEY,
	[description] VARCHAR(30) NOT NULL
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='contact' AND xtype='U')
CREATE TABLE contact (
	contactId UNIQUEIDENTIFIER PRIMARY KEY,
	typeContact INT NOT NULL CONSTRAINT FK_contact_typeContact FOREIGN KEY REFERENCES typeContact(typeContactId),
	personneId UNIQUEIDENTIFIER NOT NULL,
	valeur VARCHAR(1024) NOT NULL,

	CONSTRAINT FK_contact_personneId FOREIGN KEY (personneId) REFERENCES personne(personneId)
);
