-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema sn2016gr9
-- -----------------------------------------------------

-- -----------------------------------------------------
-- CREATE Schema sn2016gr9
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `sn2016gr9`;
CREATE SCHEMA IF NOT EXISTS `sn2016gr9` ;
USE `sn2016gr9` ;


-- -----------------------------------------------------
-- Drop tabeller sn2016gr9 hvis eksisterer
-- -----------------------------------------------------
DROP TABLE IF EXISTS `postkatalog`;
DROP TABLE IF EXISTS `Personer`;
DROP TABLE IF EXISTS `opphold`;
DROP TABLE IF EXISTS `ROM`;
DROP TABLE IF EXISTS `Bestillingstype`;
DROP TABLE IF EXISTS `Innsjekk`;
DROP TABLE IF EXISTS `Pris`;
DROP TABLE IF EXISTS `utsjekk`;
DROP TABLE IF EXISTS `avbestilling`;
DROP TABLE IF EXISTS `romservice`;

-- -----------------------------------------------------
-- Table `sn2016gr9`.`Postkatalog`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Postkatalog` (
  `PostNr` INT(4) NOT NULL,
  `Poststed` VARCHAR(30) NULL,
  PRIMARY KEY (`PostNr`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Personer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Personer` (
  `TlfNr` INT(8) NOT NULL,
  `PostNr` INT(4) NULL,
  `Fornavn` VARCHAR(25) NULL,
  `Etternavn` VARCHAR(40)  NULL,
  `Gateadresse` VARCHAR(60) NULL,
  `Epost` VARCHAR(60) NULL,
  PRIMARY KEY (`TlfNr`),
  INDEX `PostNr_idx` (`PostNr` ASC),
  CONSTRAINT `PostNr` FOREIGN KEY (`PostNr`) REFERENCES `sn2016gr9`.`Postkatalog` (`PostNr`)
    on update cascade
  on delete cascade)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `sn2016gr9`.`Opphold`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Opphold` (
  `RomNr` INT(3) NOT NULL,
  `TlfNr` INT(8) NOT NULL,
  `PostNr` INT(4) NULL,
  `TypeService` VARCHAR(60) NULL,
  PRIMARY KEY (`RomNr`,`TlfNr` ),
  INDEX `TlfNr_idx` (`TlfNr` ASC),
  INDEX `PostNr_idx` (`PostNr` ASC),
  CONSTRAINT `TlfNrOppholdFK` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
     on update cascade
  on delete cascade,
  CONSTRAINT `PostNrOppholdFK` FOREIGN KEY (`PostNr`) REFERENCES `sn2016gr9`.`Postkatalog` (`PostNr`)
    on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Rom`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Rom` (
  `RomNr` INT(3),
  `TlfNr` INT(8),
  `RomType` VARCHAR(45),
  `RomStatus` VARCHAR(45),
  PRIMARY KEY (`RomNr`),
  INDEX `TlfNr_idx` (`TlfNr` ASC),
  CONSTRAINT `TlfNrRomFk` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
    on update cascade
  on delete cascade,
CONSTRAINT `OppholdRomNrFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Opphold` (`RomNr`)
on update cascade
on delete cascade)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `sn2016gr9`.`Bestillingstype`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Bestillingstype` (
  `FraDato` DATE,
  `TlfNr` INT(8),
  `RomNr` INT(3),
  `TilDato` DATE,
  `TypeBestilling` VARCHAR(45),
  `AntallPersoner` INT(20),
  `AntallVoksen` INT(20) NULL,
  `AntallBarn` INT(20) NULL,
  `AntallRom` INT(10),
  PRIMARY KEY (`FraDato`, `TlfNr`),
  INDEX `TlfNr_idx` (`TlfNr` ASC),
  INDEX `RomNr_idx` (`RomNr` ASC),
  CONSTRAINT `TlfNrBestillingFK` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
    on update cascade
  on delete cascade,
  CONSTRAINT `RomNrBestillingFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Rom` (`RomNr`)
    on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Innsjekk`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Innsjekk` (
  `FraDato` DATE NOT NULL,
  `RomNr` INT(3) NOT NULL,
  `TlfNr` INT(8) NOT NULL,
  `RomType` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`FraDato`, `RomNr`, `TlfNr`),
  INDEX `TlfNr_idx` (`TlfNr` ASC),
  INDEX `RomNr_idx` (`RomNr` ASC),
  CONSTRAINT `RomNrInnsjekkFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Opphold` (`RomNr`)
    on update cascade
  on delete cascade,
  CONSTRAINT `TlfNrInnsjekkFK` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
    on update cascade
  on delete cascade,
  CONSTRAINT `FraDatoInnsjekkFK` FOREIGN KEY (`FraDato`) REFERENCES `sn2016gr9`.`Bestillingstype` (`FraDato`)
    on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Pris`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Pris` (
  `RomNr` INT(3) NOT NULL,
  `AntallPersoner` INT(20) NULL,
  `AntallVoksen` INT(20) NULL,
  `AntallBarn` INT(20) NULL,
  `AntallRom` INT(10) NULL,
  `PrisRengjøring` INT(4) NULL,
  `PrisDrikke` INT(5) NULL,
  `PrisMat` INT(5) NULL,
  PRIMARY KEY (`RomNr`),
  CONSTRAINT `RomNrPrisFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Rom` (`RomNr`)
  on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Utsjekk`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Utsjekk` (
  `RomNr` INT(3) NOT NULL,
  `TlfNr` INT(8) NULL,
  PRIMARY KEY (`RomNr`),
  INDEX `TlfNr_idx` (`TlfNr` ASC),
  CONSTRAINT `RomNrUtsjekkFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Opphold` (`RomNr`)
      on update cascade
  on delete cascade,
  CONSTRAINT `TlfNrUtsjekkFK` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
    on update cascade
  on delete cascade)
	ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Avbestilling`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Avbestilling` (
  `FraDato` DATE NOT NULL,
  `TlfNr` INT(8) NOT NULL,
  `RomNr` INT(3) NOT NULL,
  PRIMARY KEY (`TlfNr`),
  INDEX `TlfNr_idx` (`FraDato`,`TlfNr` ASC),
  INDEX `RomNr_idx` (`RomNr` ASC),
  CONSTRAINT `TlfNrAvbestillingFK` FOREIGN KEY (`TlfNr`) REFERENCES `sn2016gr9`.`Personer` (`TlfNr`)
    on update cascade
  on delete cascade,
  CONSTRAINT `RomNrAvbestillingFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Opphold` (`RomNr`)
    on update cascade
  on delete cascade,
 CONSTRAINT `FraDatoAvbestillingFK` FOREIGN KEY (`FraDato`) REFERENCES `sn2016gr9`.`Bestillingstype` (`FraDato`)
   on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sn2016gr9`.`Romservice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sn2016gr9`.`Romservice` (
  `RomNr` INT(3) NOT NULL,
  `TypeService` VARCHAR(60) NULL,
    `Rengjøring` VARCHAR(60) NULL,
  `Mat` VARCHAR(45) NULL,
    `AntallMat` VARCHAR(45) NULL,
  `Drikke` VARCHAR(45) NULL,
    `AntallDrikke` VARCHAR(45) NULL,
  PRIMARY KEY (`RomNr`),
  CONSTRAINT `RomNrRomserviceFK` FOREIGN KEY (`RomNr`) REFERENCES `sn2016gr9`.`Rom` (`RomNr`)
    on update cascade
  on delete cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Insert -- Data Postkatalog
-- -----------------------------------------------------

INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0001', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0009', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0010', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0014', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0015', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0016', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0017', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0018', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0019', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0020', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0021', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0022', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0023', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0024', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0025', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0026', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0027', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0028', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0030', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0031', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0032', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0033', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0034', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0037', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0040', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0041', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0042', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0043', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0045', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0046', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0047', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0048', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0050', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0051', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0055', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0080', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0085', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0101', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0102', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0103', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0104', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0105', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0106', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0107', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0110', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0111', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0112', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0113', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0114', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0115', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0116', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0117', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0118', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0119', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0120', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0121', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0122', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0123', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0124', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0125', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0128', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0129', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0130', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0131', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0132', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0133', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0134', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0135', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0136', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0137', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0138', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0139', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0150', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0151', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0152', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0153', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0154', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0155', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0157', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0158', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0159', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0160', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0161', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0162', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0164', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0165', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0166', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0167', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0168', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0169', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0170', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0171', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0172', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0173', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0174', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0175', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0176', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0177', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0178', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0179', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0180', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0181', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0182', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0183', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0184', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0185', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0186', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0187', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0188', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0190', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0191', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0192', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0193', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0196', 'OSLO');
INSERT INTO `Postkatalog` (`PostNr`, `Poststed`) VALUES('0198', 'OSLO');


-- -----------------------------------------------------
-- Insert -- Data Personer
-- -----------------------------------------------------

INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918019', '0001', 'Georg', 'Barth', 'Kringsjågrenda 3F');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918020', '0009', 'Gunnlaug', 'Angeltveit', 'Langmyrgrenda 9');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918021', '0010', 'Morgan', 'Dalland', 'Jansbergveien 19');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918022', '0014', 'Vilde', 'Aksnes', 'Minister Ditleffs vei 44');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918023', '0015', 'Henriette', 'Brobakken', 'Stubberud Sognsvann 1');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918024', '0016', 'Synøve', 'Bakketun', 'Vassøyveien 7');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918025', '0017', 'Ragnvald', 'Allum', 'Utsikten 4');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918026', '0018', 'Oliver', 'Abrahamsen', 'Tarjei Vesaas vei 3A');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918027', '0019', 'Oda', 'Cappelen', 'Norheimskneiken 12');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918028', '0020', 'Andrine', 'Ebbesen', 'Kristianias gate 9');
INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `PostNr`, `Fornavn`, `Etternavn`, `Gateadresse`) VALUES ('90918029', '0021', 'Karl Anton', 'Hoff', 'Furustia 3');

-- -----------------------------------------------------
-- Insert rooms
-- -----------------------------------------------------

INSERT INTO `sn2016gr9`.`rom` (`RomNr`,`TlfNr`, `RomType`,`RomStatus` ) VALUES ('1', '90918019','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('2', '90918020','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('3', '90918021','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('4', '90918022','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('5', '90918023','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('6', '90918024','Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('7', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('8', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('9', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('10', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('11', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('12', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('13', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('14', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('15', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('16', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('17', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('18', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('19', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('20', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('21', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('22', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('23', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('24', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('25', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('26', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('27', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('28', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('29', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('30', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('31', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('32', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('33', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('34', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('35', 'Familierom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`,`TlfNr`, `RomType`,`RomStatus` ) VALUES ('36', '90918025','Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`,`TlfNr`, `RomType`,`RomStatus` ) VALUES ('37', '90918026','Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`,`TlfNr`, `RomType`,`RomStatus` ) VALUES ('38', '90918027','Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('39', '90918028','Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `TlfNr`,`RomType`,`RomStatus` ) VALUES ('40', '90918029','Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('41', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('42', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('43', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('44', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('45', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('46', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('47', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('48', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('49', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('50', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('51', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('52', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('53', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('54', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('55', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('56', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('57', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('58', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('59', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('60', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('61', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('62', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('63', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('64', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('65', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('66', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('67', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('68', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('69', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('70', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('71', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('72', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('73', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('74', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('75', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('76', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('77', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('78', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('79', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('80', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('81', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('82', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('83', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('84', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('85', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('86', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('87', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('88', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('89', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('90', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('91', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('92', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('93', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('94', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('95', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('96', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('97', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('98', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('99', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('100', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('101', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('102', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('103', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('104', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('105', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('106', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('107', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('108', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('109', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('110', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('111', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('112', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('113', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('114', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('115', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('116', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('117', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('118', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('119', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('120', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('121', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('122', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('123', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('124', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('125', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('126', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('127', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('128', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('129', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('130', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('131', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('132', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('133', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('134', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('135', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('136', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('137', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('138', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('139', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('140', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('141', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('142', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('143', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('144', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('145', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('146', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('147', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('148', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('149', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('150', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('151', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('152', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('153', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('154', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('155', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('156', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('157', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('158', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('159', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('160', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('161', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('162', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('163', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('164', 'Dobbeltrom', 'Tilgjengelig');
INSERT INTO `sn2016gr9`.`rom` (`RomNr`, `RomType`,`RomStatus` ) VALUES ('165', 'Dobbeltrom', 'Tilgjengelig');


-- -----------------------------------------------------
-- Insert -- Data Oppholde
-- -----------------------------------------------------

INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('1', '90918019', '0001', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('2', '90918020', '0009', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('3', '90918021', '0010', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('4', '90918022', '0014', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('5', '90918023', '0015', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('6', '90918024', '0016', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('35', '90918025', '0017', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('36', '90918026', '0018', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('37', '90918027', '0019', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('38', '90918028', '0020', 'Vask');
INSERT INTO `sn2016gr9`.`opphold` (`RomNr`, `TlfNr`, `PostNr`, `TypeService`) VALUES ('39', '90918029', '0021', 'Vask');


-- -----------------------------------------------------
-- Insert -- Data BestillingsType
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`,`AntallVoksen`, `AntallBarn`, `AntallRom`) VALUES ('2016-04-01', '90918019', '1', '2016-04-02', 'Bestilling', '2','2', '0', '1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`,`AntallVoksen`, `AntallBarn`, `AntallRom`) VALUES ('2016-04-02', '90918020', '2', '2016-04-03', 'Bestilling', '4', '2', '2','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`,`AntallVoksen`, `AntallBarn`, `AntallRom`) VALUES ('2016-04-03', '90918021', '3', '2016-04-04', 'Bestilling', '3', '2', '1','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`,`AntallVoksen`, `AntallBarn`, `AntallRom`) VALUES ('2016-04-01', '90918022', '4', '2016-04-05', 'Bestilling', '6', '3', '3','2');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-03', '90918023', '5', '2016-04-06', 'Reservasjon', '2','2', '0', '2');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-01', '90918024', '6', '2016-04-06', 'Bestilling', '2', '2', '0','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-01', '90918025', '35', '2016-04-02', 'Reservasjon', '2', '2', '0','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-02', '90918026', '36', '2016-04-03', 'Bestilling', '4', '2', '2','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-01', '90918027', '37', '2016-04-04', 'Bestilling', '3', '2', '1','1');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-01', '90918028', '38', '2016-04-05', 'Bestilling', '6', '3', '3','2');
INSERT INTO `sn2016gr9`.`BestillingsType` (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`,`AntallRom`) VALUES ('2016-04-01', '90918029', '39', '2016-04-07', 'Bestilling', '2', '2', '0','1');


-- -----------------------------------------------------
-- Insert -- Data innsjekk
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '1', '90918019', 'Familierom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-02', '2', '90918020', 'Familierom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-03', '3', '90918021', 'Familierom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '4', '90918022', 'Familierom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '6', '90918024', 'Familierom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-02', '36', '90918026', 'Dobbeltrom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '37', '90918027', 'Dobbeltrom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '38', '90918028', 'Dobbeltrom');
INSERT INTO `sn2016gr9`.`innsjekk` (`FraDato`, `RomNr`, `TlfNr`, `RomType`) VALUES ('2016-04-01', '39', '90918029', 'Dobbeltrom');

-- -----------------------------------------------------
-- Insert -- Data Pris
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('1', '2','2', '0','1', '50.00', '150.00', '210.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('2', '4','2','2', '1', '50.00', '150.00', '250.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('3', '3', '2','1','1', '40.00', '170.00', '200.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('4', '6', '3','3','2', '60.00', '300.00', '200.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('5', '2', '2','0','2', '40.00', '190.00', '200.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('6', '2', '2','0','1', '40.00', '160.00', '200.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('36', '4','2','2', '1', '50.00', '170.00', '299.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('37', '3','2', '1','1', '60.00', '180.00', '300.00');
INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallVoksen`, `AntallBarn`, `AntallRom`, `PrisRengjøring`, `PrisDrikke`, `PrisMat`) VALUES ('38', '6','3', '3','2', '750.00', '190.00', '350.00');

-- -----------------------------------------------------
-- Insert -- Data Utsjekk
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('1', '90918019');
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('2', '90918020');
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('3', '90918021');
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('36', '90918026');
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('37', '90918027');
INSERT INTO `sn2016gr9`.`Utsjekk` (`RomNr`, `TlfNr`) VALUES ('38', '90918028');

-- -----------------------------------------------------
-- Insert -- Data Avbestilling
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`Avbestilling` (`FraDato`, `TlfNr`, `RomNr`) VALUES ('2016-04-01', '90918019', '1');
INSERT INTO `sn2016gr9`.`Avbestilling` (`FraDato`, `TlfNr`, `RomNr`) VALUES ('2016-04-01', '90918020', '2');
INSERT INTO `sn2016gr9`.`Avbestilling` (`FraDato`, `TlfNr`, `RomNr`) VALUES ('2016-04-01', '90918026', '36');
INSERT INTO `sn2016gr9`.`Avbestilling` (`FraDato`, `TlfNr`, `RomNr`) VALUES ('2016-04-01', '90918023', '37');
INSERT INTO `sn2016gr9`.`Avbestilling` (`FraDato`, `TlfNr`, `RomNr`) VALUES ('2016-04-01', '90918025', '3');


-- -----------------------------------------------------
-- Insert -- Data romservice
-- -----------------------------------------------------
INSERT INTO `sn2016gr9`.`romservice` (`RomNr`, `TypeService`, `Rengjøring`, `Mat`, `AntallMat`, `Drikke`, `AntallDrikke`) VALUES ('1', 'VIP', 'Under opphold', 'Diversmatvare', '2', 'Vann', '2');
INSERT INTO `sn2016gr9`.`romservice` (`RomNr`, `TypeService`, `Rengjøring`, `Mat`, `AntallMat`, `Drikke`, `AntallDrikke`) VALUES ('2', 'Vanlig', 'Ved utsjekk', 'Diversmatvare', '3', 'Vann', '4');




SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;