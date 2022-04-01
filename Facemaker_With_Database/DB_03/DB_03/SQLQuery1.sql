
DROP TABLE IF EXISTS [dbo].Person;

CREATE TABLE [dbo].Person
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fname] NCHAR(10) NOT NULL, 
    [lname] NCHAR(10) NOT NULL, 
    [city] NCHAR(10) NOT NULL,
    
);

INSERT INTO Person  (fname ,lname , city)  VALUES ('Russ', 'DaShan', 'Kentville');
