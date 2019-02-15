-- Opprette bruker

USE INFORMATION_SCHEMA;

-- opprett bruker
DROP USER IF EXISTS 'sn2016gr9'@'localhost' ;
 CREATE USER 'sn2016gr9'@'localhost' IDENTIFIED BY 'sn2016gr9';
 
-- Sjekke at brukeren har blitt opprettet
SELECT *
FROM USER_PRIVILEGES;

-- Tildele brukeren sn2016gr9 leserettigheter til tabeller i databasen sn2016gr9
GRANT SELECT ON sn2016gr9.`postkatalog` TO 'sn2016gr9'@'localhost'; 
GRANT SELECT ON sn2016gr9.`Personer`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`opphold`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`ROM`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`Bestillingstype`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`Innsjekk`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`Pris`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`utsjekk`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`avbestilling`  TO 'sn2016gr9'@'localhost';
GRANT SELECT ON sn2016gr9.`romservice`  TO 'sn2016gr9'@'localhost';


-- -- Tildele brukeren sn2016gr9 oppdaterrettigheter til tabeller i databasen sn2016gr9
GRANT UPDATE ON sn2016gr9.`postkatalog` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9.`Personer` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9.`opphold` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9.`ROM` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9.`Bestillingstype` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9.`Innsjekk` TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9 .`Pris`TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9 .`utsjekk`TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9 .`avbestilling`TO 'sn2016gr9'@'localhost';
GRANT UPDATE ON sn2016gr9 .`romservice`TO 'sn2016gr9'@'localhost';


-- -- Tildele brukeren sn2016gr9 INSERT rettigheter til tabeller i databasen sn2016gr9
GRANT INSERT ON sn2016gr9.`postkatalog`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`Personer`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`opphold`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`ROM`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`Bestillingstype`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`Innsjekk`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`Pris`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`utsjekk`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`avbestilling`  TO 'sn2016gr9'@'localhost';
GRANT INSERT ON sn2016gr9.`romservice`  TO 'sn2016gr9'@'localhost';


-- Tildele brukeren sn2016gr9 sletterettigheter til tabeller i databasen sn2016gr9
GRANT DELETE ON sn2016gr9.`postkatalog` TO 'sn2016gr9'@'localhost'; 
GRANT DELETE ON sn2016gr9.`Personer`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`opphold`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`ROM`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`Bestillingstype`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`Innsjekk`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`Pris`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`utsjekk`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`avbestilling`  TO 'sn2016gr9'@'localhost';
GRANT DELETE ON sn2016gr9.`romservice`  TO 'sn2016gr9'@'localhost';


-- Sjekke tabellrettighetene for brukeren i systemtabellene
SELECT *
FROM TABLE_PRIVILEGES;

-- Pålogget som sn2016gr9
USE sn2016gr9;

SELECT *
FROM ROM;
