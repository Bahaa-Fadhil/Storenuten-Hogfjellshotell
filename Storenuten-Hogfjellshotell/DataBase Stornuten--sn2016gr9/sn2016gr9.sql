-- MySQL dump 10.13  Distrib 5.7.10, for Win64 (x86_64)
--
-- Host: localhost    Database: sn2016gr9
-- ------------------------------------------------------
-- Server version	5.7.10-log

USE `mysql`;
DROP USER IF EXISTS 'sn2016gr9'@'localhost';
CREATE USER 'sn2016gr9'@'localhost' IDENTIFIED BY 'sn2016gr9';
GRANT ALL PRIVILEGES ON sn2016gr9.* TO sn2016gr9@'localhost';

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `avbestilling`
--

DROP TABLE IF EXISTS `avbestilling`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `avbestilling` (
  `FraDato` date NOT NULL,
  `TlfNr` int(8) NOT NULL,
  `RomNr` int(3) NOT NULL,
  PRIMARY KEY (`TlfNr`),
  KEY `TlfNr_idx` (`FraDato`,`TlfNr`),
  KEY `RomNr_idx` (`RomNr`),
  CONSTRAINT `FraDatoAvbestillingFK` FOREIGN KEY (`FraDato`) REFERENCES `bestillingstype` (`FraDato`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `RomNrAvbestillingFK` FOREIGN KEY (`RomNr`) REFERENCES `opphold` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrAvbestillingFK` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avbestilling`
--

LOCK TABLES `avbestilling` WRITE;
/*!40000 ALTER TABLE `avbestilling` DISABLE KEYS */;
INSERT INTO `avbestilling` VALUES ('2016-04-01',90918019,1),('2016-04-01',90918020,2),('2016-04-01',90918023,37),('2016-04-01',90918025,3),('2016-04-01',90918026,36);
/*!40000 ALTER TABLE `avbestilling` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bestillingstype`
--

DROP TABLE IF EXISTS `bestillingstype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bestillingstype` (
  `FraDato` date NOT NULL,
  `TlfNr` int(8) NOT NULL,
  `RomNr` int(3) DEFAULT NULL,
  `TilDato` date DEFAULT NULL,
  `TypeBestilling` varchar(45) DEFAULT NULL,
  `AntallPersoner` int(20) DEFAULT NULL,
  `AntallVoksen` int(20) DEFAULT NULL,
  `AntallBarn` int(20) DEFAULT NULL,
  `AntallRom` int(10) DEFAULT NULL,
  PRIMARY KEY (`FraDato`,`TlfNr`),
  KEY `TlfNr_idx` (`TlfNr`),
  KEY `RomNr_idx` (`RomNr`),
  CONSTRAINT `RomNrBestillingFK` FOREIGN KEY (`RomNr`) REFERENCES `rom` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrBestillingFK` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bestillingstype`
--

LOCK TABLES `bestillingstype` WRITE;
/*!40000 ALTER TABLE `bestillingstype` DISABLE KEYS */;
INSERT INTO `bestillingstype` VALUES ('2016-04-01',90918019,1,'2016-04-02','Bestilling',2,2,0,1),('2016-04-01',90918022,4,'2016-04-05','Bestilling',6,3,3,2),('2016-04-01',90918024,6,'2016-04-06','Bestilling',2,2,0,1),('2016-04-01',90918025,35,'2016-04-02','Reservasjon',2,2,0,1),('2016-04-01',90918027,37,'2016-04-04','Bestilling',3,2,1,1),('2016-04-01',90918028,38,'2016-04-05','Bestilling',6,3,3,2),('2016-04-01',90918029,39,'2016-04-07','Bestilling',2,2,0,1),('2016-04-02',90918020,2,'2016-04-03','Bestilling',4,2,2,1),('2016-04-02',90918026,36,'2016-04-03','Bestilling',4,2,2,1),('2016-04-03',90918021,3,'2016-04-04','Bestilling',3,2,1,1),('2016-04-03',90918023,5,'2016-04-06','Reservasjon',2,2,0,2);
/*!40000 ALTER TABLE `bestillingstype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `innsjekk`
--

DROP TABLE IF EXISTS `innsjekk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `innsjekk` (
  `FraDato` date NOT NULL,
  `RomNr` int(3) NOT NULL,
  `TlfNr` int(8) NOT NULL,
  `RomType` varchar(45) NOT NULL,
  PRIMARY KEY (`FraDato`,`RomNr`,`TlfNr`),
  KEY `TlfNr_idx` (`TlfNr`),
  KEY `RomNr_idx` (`RomNr`),
  CONSTRAINT `FraDatoInnsjekkFK` FOREIGN KEY (`FraDato`) REFERENCES `bestillingstype` (`FraDato`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `RomNrInnsjekkFK` FOREIGN KEY (`RomNr`) REFERENCES `opphold` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrInnsjekkFK` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `innsjekk`
--

LOCK TABLES `innsjekk` WRITE;
/*!40000 ALTER TABLE `innsjekk` DISABLE KEYS */;
INSERT INTO `innsjekk` VALUES ('2016-04-01',1,90918019,'Familierom'),('2016-04-01',4,90918022,'Familierom'),('2016-04-01',6,90918024,'Familierom'),('2016-04-01',37,90918027,'Dobbeltrom'),('2016-04-01',38,90918028,'Dobbeltrom'),('2016-04-01',39,90918029,'Dobbeltrom'),('2016-04-02',2,90918020,'Familierom'),('2016-04-02',36,90918026,'Dobbeltrom'),('2016-04-03',3,90918021,'Familierom');
/*!40000 ALTER TABLE `innsjekk` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opphold`
--

DROP TABLE IF EXISTS `opphold`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opphold` (
  `RomNr` int(3) NOT NULL,
  `TlfNr` int(8) NOT NULL,
  `PostNr` int(4) DEFAULT NULL,
  `TypeService` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`RomNr`,`TlfNr`),
  KEY `TlfNr_idx` (`TlfNr`),
  KEY `PostNr_idx` (`PostNr`),
  CONSTRAINT `PostNrOppholdFK` FOREIGN KEY (`PostNr`) REFERENCES `postkatalog` (`PostNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrOppholdFK` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opphold`
--

LOCK TABLES `opphold` WRITE;
/*!40000 ALTER TABLE `opphold` DISABLE KEYS */;
INSERT INTO `opphold` VALUES (1,90918019,1,'Vask'),(2,90918020,9,'Vask'),(3,90918021,10,'Vask'),(4,90918022,14,'Vask'),(5,90918023,15,'Vask'),(6,90918024,16,'Vask'),(35,90918025,17,'Vask'),(36,90918026,18,'Vask'),(37,90918027,19,'Vask'),(38,90918028,20,'Vask'),(39,90918029,21,'Vask');
/*!40000 ALTER TABLE `opphold` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personer`
--

DROP TABLE IF EXISTS `personer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personer` (
  `TlfNr` int(8) NOT NULL,
  `PostNr` int(4) DEFAULT NULL,
  `Fornavn` varchar(25) DEFAULT NULL,
  `Etternavn` varchar(40) DEFAULT NULL,
  `Gateadresse` varchar(60) DEFAULT NULL,
  `Epost` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`TlfNr`),
  KEY `PostNr_idx` (`PostNr`),
  CONSTRAINT `PostNr` FOREIGN KEY (`PostNr`) REFERENCES `postkatalog` (`PostNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personer`
--

LOCK TABLES `personer` WRITE;
/*!40000 ALTER TABLE `personer` DISABLE KEYS */;
INSERT INTO `personer` VALUES (90918019,1,'Georg','Barth','Kringsjågrenda 3F',NULL),(90918020,9,'Gunnlaug','Angeltveit','Langmyrgrenda 9',NULL),(90918021,10,'Morgan','Dalland','Jansbergveien 19',NULL),(90918022,14,'Vilde','Aksnes','Minister Ditleffs vei 44',NULL),(90918023,15,'Henriette','Brobakken','Stubberud Sognsvann 1',NULL),(90918024,16,'Synøve','Bakketun','Vassøyveien 7',NULL),(90918025,17,'Ragnvald','Allum','Utsikten 4',NULL),(90918026,18,'Oliver','Abrahamsen','Tarjei Vesaas vei 3A',NULL),(90918027,19,'Oda','Cappelen','Norheimskneiken 12',NULL),(90918028,20,'Andrine','Ebbesen','Kristianias gate 9',NULL),(90918029,21,'Karl Anton','Hoff','Furustia 3',NULL);
/*!40000 ALTER TABLE `personer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postkatalog`
--

DROP TABLE IF EXISTS `postkatalog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `postkatalog` (
  `PostNr` int(4) NOT NULL,
  `Poststed` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`PostNr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postkatalog`
--

LOCK TABLES `postkatalog` WRITE;
/*!40000 ALTER TABLE `postkatalog` DISABLE KEYS */;
INSERT INTO `postkatalog` VALUES (1,'OSLO'),(9,'OSLO'),(10,'OSLO'),(14,'OSLO'),(15,'OSLO'),(16,'OSLO'),(17,'OSLO'),(18,'OSLO'),(19,'OSLO'),(20,'OSLO'),(21,'OSLO'),(22,'OSLO'),(23,'OSLO'),(24,'OSLO'),(25,'OSLO'),(26,'OSLO'),(27,'OSLO'),(28,'OSLO'),(30,'OSLO'),(31,'OSLO'),(32,'OSLO'),(33,'OSLO'),(34,'OSLO'),(37,'OSLO'),(40,'OSLO'),(41,'OSLO'),(42,'OSLO'),(43,'OSLO'),(45,'OSLO'),(46,'OSLO'),(47,'OSLO'),(48,'OSLO'),(50,'OSLO'),(51,'OSLO'),(55,'OSLO'),(80,'OSLO'),(85,'OSLO'),(101,'OSLO'),(102,'OSLO'),(103,'OSLO'),(104,'OSLO'),(105,'OSLO'),(106,'OSLO'),(107,'OSLO'),(110,'OSLO'),(111,'OSLO'),(112,'OSLO'),(113,'OSLO'),(114,'OSLO'),(115,'OSLO'),(116,'OSLO'),(117,'OSLO'),(118,'OSLO'),(119,'OSLO'),(120,'OSLO'),(121,'OSLO'),(122,'OSLO'),(123,'OSLO'),(124,'OSLO'),(125,'OSLO'),(128,'OSLO'),(129,'OSLO'),(130,'OSLO'),(131,'OSLO'),(132,'OSLO'),(133,'OSLO'),(134,'OSLO'),(135,'OSLO'),(136,'OSLO'),(137,'OSLO'),(138,'OSLO'),(139,'OSLO'),(150,'OSLO'),(151,'OSLO'),(152,'OSLO'),(153,'OSLO'),(154,'OSLO'),(155,'OSLO'),(157,'OSLO'),(158,'OSLO'),(159,'OSLO'),(160,'OSLO'),(161,'OSLO'),(162,'OSLO'),(164,'OSLO'),(165,'OSLO'),(166,'OSLO'),(167,'OSLO'),(168,'OSLO'),(169,'OSLO'),(170,'OSLO'),(171,'OSLO'),(172,'OSLO'),(173,'OSLO'),(174,'OSLO'),(175,'OSLO'),(176,'OSLO'),(177,'OSLO'),(178,'OSLO'),(179,'OSLO'),(180,'OSLO'),(181,'OSLO'),(182,'OSLO'),(183,'OSLO'),(184,'OSLO'),(185,'OSLO'),(186,'OSLO'),(187,'OSLO'),(188,'OSLO'),(190,'OSLO'),(191,'OSLO'),(192,'OSLO'),(193,'OSLO'),(196,'OSLO'),(198,'OSLO');
/*!40000 ALTER TABLE `postkatalog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pris`
--

DROP TABLE IF EXISTS `pris`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pris` (
  `RomNr` int(3) NOT NULL,
  `AntallPersoner` int(20) DEFAULT NULL,
  `AntallVoksen` int(20) DEFAULT NULL,
  `AntallBarn` int(20) DEFAULT NULL,
  `AntallRom` int(10) DEFAULT NULL,
  `PrisRengjøring` int(4) DEFAULT NULL,
  `PrisDrikke` int(5) DEFAULT NULL,
  `PrisMat` int(5) DEFAULT NULL,
  PRIMARY KEY (`RomNr`),
  CONSTRAINT `RomNrPrisFK` FOREIGN KEY (`RomNr`) REFERENCES `rom` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pris`
--

LOCK TABLES `pris` WRITE;
/*!40000 ALTER TABLE `pris` DISABLE KEYS */;
INSERT INTO `pris` VALUES (1,2,2,0,1,50,150,210),(2,4,2,2,1,50,150,250),(3,3,2,1,1,40,170,200),(4,6,3,3,2,60,300,200),(5,2,2,0,2,40,190,200),(6,2,2,0,1,40,160,200),(36,4,2,2,1,50,170,299),(37,3,2,1,1,60,180,300),(38,6,3,3,2,750,190,350);
/*!40000 ALTER TABLE `pris` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rom`
--

DROP TABLE IF EXISTS `rom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rom` (
  `RomNr` int(3) NOT NULL,
  `TlfNr` int(8) DEFAULT NULL,
  `RomType` varchar(45) DEFAULT NULL,
  `RomStatus` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`RomNr`),
  KEY `TlfNr_idx` (`TlfNr`),
  CONSTRAINT `OppholdRomNrFK` FOREIGN KEY (`RomNr`) REFERENCES `opphold` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrRomFk` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rom`
--

LOCK TABLES `rom` WRITE;
/*!40000 ALTER TABLE `rom` DISABLE KEYS */;
INSERT INTO `rom` VALUES (1,90918019,'Familierom','Tilgjengelig'),(2,90918020,'Familierom','Tilgjengelig'),(3,90918021,'Familierom','Tilgjengelig'),(4,90918022,'Familierom','Tilgjengelig'),(5,90918023,'Familierom','Tilgjengelig'),(6,90918024,'Familierom','Tilgjengelig'),(7,NULL,'Familierom','Tilgjengelig'),(8,NULL,'Familierom','Tilgjengelig'),(9,NULL,'Familierom','Tilgjengelig'),(10,NULL,'Familierom','Tilgjengelig'),(11,NULL,'Familierom','Tilgjengelig'),(12,NULL,'Familierom','Tilgjengelig'),(13,NULL,'Familierom','Tilgjengelig'),(14,NULL,'Familierom','Tilgjengelig'),(15,NULL,'Familierom','Tilgjengelig'),(16,NULL,'Familierom','Tilgjengelig'),(17,NULL,'Familierom','Tilgjengelig'),(18,NULL,'Familierom','Tilgjengelig'),(19,NULL,'Familierom','Tilgjengelig'),(20,NULL,'Familierom','Tilgjengelig'),(21,NULL,'Familierom','Tilgjengelig'),(22,NULL,'Familierom','Tilgjengelig'),(23,NULL,'Familierom','Tilgjengelig'),(24,NULL,'Familierom','Tilgjengelig'),(25,NULL,'Familierom','Tilgjengelig'),(26,NULL,'Familierom','Tilgjengelig'),(27,NULL,'Familierom','Tilgjengelig'),(28,NULL,'Familierom','Tilgjengelig'),(29,NULL,'Familierom','Tilgjengelig'),(30,NULL,'Familierom','Tilgjengelig'),(31,NULL,'Familierom','Tilgjengelig'),(32,NULL,'Familierom','Tilgjengelig'),(33,NULL,'Familierom','Tilgjengelig'),(34,NULL,'Familierom','Tilgjengelig'),(35,NULL,'Familierom','Tilgjengelig'),(36,90918025,'Dobbeltrom','Tilgjengelig'),(37,90918026,'Dobbeltrom','Tilgjengelig'),(38,90918027,'Dobbeltrom','Tilgjengelig'),(39,90918028,'Dobbeltrom','Tilgjengelig'),(40,90918029,'Dobbeltrom','Tilgjengelig'),(41,NULL,'Dobbeltrom','Tilgjengelig'),(42,NULL,'Dobbeltrom','Tilgjengelig'),(43,NULL,'Dobbeltrom','Tilgjengelig'),(44,NULL,'Dobbeltrom','Tilgjengelig'),(45,NULL,'Dobbeltrom','Tilgjengelig'),(46,NULL,'Dobbeltrom','Tilgjengelig'),(47,NULL,'Dobbeltrom','Tilgjengelig'),(48,NULL,'Dobbeltrom','Tilgjengelig'),(49,NULL,'Dobbeltrom','Tilgjengelig'),(50,NULL,'Dobbeltrom','Tilgjengelig'),(51,NULL,'Dobbeltrom','Tilgjengelig'),(52,NULL,'Dobbeltrom','Tilgjengelig'),(53,NULL,'Dobbeltrom','Tilgjengelig'),(54,NULL,'Dobbeltrom','Tilgjengelig'),(55,NULL,'Dobbeltrom','Tilgjengelig'),(56,NULL,'Dobbeltrom','Tilgjengelig'),(57,NULL,'Dobbeltrom','Tilgjengelig'),(58,NULL,'Dobbeltrom','Tilgjengelig'),(59,NULL,'Dobbeltrom','Tilgjengelig'),(60,NULL,'Dobbeltrom','Tilgjengelig'),(61,NULL,'Dobbeltrom','Tilgjengelig'),(62,NULL,'Dobbeltrom','Tilgjengelig'),(63,NULL,'Dobbeltrom','Tilgjengelig'),(64,NULL,'Dobbeltrom','Tilgjengelig'),(65,NULL,'Dobbeltrom','Tilgjengelig'),(66,NULL,'Dobbeltrom','Tilgjengelig'),(67,NULL,'Dobbeltrom','Tilgjengelig'),(68,NULL,'Dobbeltrom','Tilgjengelig'),(69,NULL,'Dobbeltrom','Tilgjengelig'),(70,NULL,'Dobbeltrom','Tilgjengelig'),(71,NULL,'Dobbeltrom','Tilgjengelig'),(72,NULL,'Dobbeltrom','Tilgjengelig'),(73,NULL,'Dobbeltrom','Tilgjengelig'),(74,NULL,'Dobbeltrom','Tilgjengelig'),(75,NULL,'Dobbeltrom','Tilgjengelig'),(76,NULL,'Dobbeltrom','Tilgjengelig'),(77,NULL,'Dobbeltrom','Tilgjengelig'),(78,NULL,'Dobbeltrom','Tilgjengelig'),(79,NULL,'Dobbeltrom','Tilgjengelig'),(80,NULL,'Dobbeltrom','Tilgjengelig'),(81,NULL,'Dobbeltrom','Tilgjengelig'),(82,NULL,'Dobbeltrom','Tilgjengelig'),(83,NULL,'Dobbeltrom','Tilgjengelig'),(84,NULL,'Dobbeltrom','Tilgjengelig'),(85,NULL,'Dobbeltrom','Tilgjengelig'),(86,NULL,'Dobbeltrom','Tilgjengelig'),(87,NULL,'Dobbeltrom','Tilgjengelig'),(88,NULL,'Dobbeltrom','Tilgjengelig'),(89,NULL,'Dobbeltrom','Tilgjengelig'),(90,NULL,'Dobbeltrom','Tilgjengelig'),(91,NULL,'Dobbeltrom','Tilgjengelig'),(92,NULL,'Dobbeltrom','Tilgjengelig'),(93,NULL,'Dobbeltrom','Tilgjengelig'),(94,NULL,'Dobbeltrom','Tilgjengelig'),(95,NULL,'Dobbeltrom','Tilgjengelig'),(96,NULL,'Dobbeltrom','Tilgjengelig'),(97,NULL,'Dobbeltrom','Tilgjengelig'),(98,NULL,'Dobbeltrom','Tilgjengelig'),(99,NULL,'Dobbeltrom','Tilgjengelig'),(100,NULL,'Dobbeltrom','Tilgjengelig'),(101,NULL,'Dobbeltrom','Tilgjengelig'),(102,NULL,'Dobbeltrom','Tilgjengelig'),(103,NULL,'Dobbeltrom','Tilgjengelig'),(104,NULL,'Dobbeltrom','Tilgjengelig'),(105,NULL,'Dobbeltrom','Tilgjengelig'),(106,NULL,'Dobbeltrom','Tilgjengelig'),(107,NULL,'Dobbeltrom','Tilgjengelig'),(108,NULL,'Dobbeltrom','Tilgjengelig'),(109,NULL,'Dobbeltrom','Tilgjengelig'),(110,NULL,'Dobbeltrom','Tilgjengelig'),(111,NULL,'Dobbeltrom','Tilgjengelig'),(112,NULL,'Dobbeltrom','Tilgjengelig'),(113,NULL,'Dobbeltrom','Tilgjengelig'),(114,NULL,'Dobbeltrom','Tilgjengelig'),(115,NULL,'Dobbeltrom','Tilgjengelig'),(116,NULL,'Dobbeltrom','Tilgjengelig'),(117,NULL,'Dobbeltrom','Tilgjengelig'),(118,NULL,'Dobbeltrom','Tilgjengelig'),(119,NULL,'Dobbeltrom','Tilgjengelig'),(120,NULL,'Dobbeltrom','Tilgjengelig'),(121,NULL,'Dobbeltrom','Tilgjengelig'),(122,NULL,'Dobbeltrom','Tilgjengelig'),(123,NULL,'Dobbeltrom','Tilgjengelig'),(124,NULL,'Dobbeltrom','Tilgjengelig'),(125,NULL,'Dobbeltrom','Tilgjengelig'),(126,NULL,'Dobbeltrom','Tilgjengelig'),(127,NULL,'Dobbeltrom','Tilgjengelig'),(128,NULL,'Dobbeltrom','Tilgjengelig'),(129,NULL,'Dobbeltrom','Tilgjengelig'),(130,NULL,'Dobbeltrom','Tilgjengelig'),(131,NULL,'Dobbeltrom','Tilgjengelig'),(132,NULL,'Dobbeltrom','Tilgjengelig'),(133,NULL,'Dobbeltrom','Tilgjengelig'),(134,NULL,'Dobbeltrom','Tilgjengelig'),(135,NULL,'Dobbeltrom','Tilgjengelig'),(136,NULL,'Dobbeltrom','Tilgjengelig'),(137,NULL,'Dobbeltrom','Tilgjengelig'),(138,NULL,'Dobbeltrom','Tilgjengelig'),(139,NULL,'Dobbeltrom','Tilgjengelig'),(140,NULL,'Dobbeltrom','Tilgjengelig'),(141,NULL,'Dobbeltrom','Tilgjengelig'),(142,NULL,'Dobbeltrom','Tilgjengelig'),(143,NULL,'Dobbeltrom','Tilgjengelig'),(144,NULL,'Dobbeltrom','Tilgjengelig'),(145,NULL,'Dobbeltrom','Tilgjengelig'),(146,NULL,'Dobbeltrom','Tilgjengelig'),(147,NULL,'Dobbeltrom','Tilgjengelig'),(148,NULL,'Dobbeltrom','Tilgjengelig'),(149,NULL,'Dobbeltrom','Tilgjengelig'),(150,NULL,'Dobbeltrom','Tilgjengelig'),(151,NULL,'Dobbeltrom','Tilgjengelig'),(152,NULL,'Dobbeltrom','Tilgjengelig'),(153,NULL,'Dobbeltrom','Tilgjengelig'),(154,NULL,'Dobbeltrom','Tilgjengelig'),(155,NULL,'Dobbeltrom','Tilgjengelig'),(156,NULL,'Dobbeltrom','Tilgjengelig'),(157,NULL,'Dobbeltrom','Tilgjengelig'),(158,NULL,'Dobbeltrom','Tilgjengelig'),(159,NULL,'Dobbeltrom','Tilgjengelig'),(160,NULL,'Dobbeltrom','Tilgjengelig'),(161,NULL,'Dobbeltrom','Tilgjengelig'),(162,NULL,'Dobbeltrom','Tilgjengelig'),(163,NULL,'Dobbeltrom','Tilgjengelig'),(164,NULL,'Dobbeltrom','Tilgjengelig'),(165,NULL,'Dobbeltrom','Tilgjengelig');
/*!40000 ALTER TABLE `rom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `romservice`
--

DROP TABLE IF EXISTS `romservice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `romservice` (
  `RomNr` int(3) NOT NULL,
  `TypeService` varchar(60) DEFAULT NULL,
  `Rengjøring` varchar(60) DEFAULT NULL,
  `Mat` varchar(45) DEFAULT NULL,
  `AntallMat` varchar(45) DEFAULT NULL,
  `Drikke` varchar(45) DEFAULT NULL,
  `AntallDrikke` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`RomNr`),
  CONSTRAINT `RomNrRomserviceFK` FOREIGN KEY (`RomNr`) REFERENCES `rom` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `romservice`
--

LOCK TABLES `romservice` WRITE;
/*!40000 ALTER TABLE `romservice` DISABLE KEYS */;
INSERT INTO `romservice` VALUES (1,'VIP','Under opphold','Diversmatvare','2','Vann','2'),(2,'Vanlig','Ved utsjekk','Diversmatvare','3','Vann','4');
/*!40000 ALTER TABLE `romservice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utsjekk`
--

DROP TABLE IF EXISTS `utsjekk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utsjekk` (
  `RomNr` int(3) NOT NULL,
  `TlfNr` int(8) DEFAULT NULL,
  PRIMARY KEY (`RomNr`),
  KEY `TlfNr_idx` (`TlfNr`),
  CONSTRAINT `RomNrUtsjekkFK` FOREIGN KEY (`RomNr`) REFERENCES `opphold` (`RomNr`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TlfNrUtsjekkFK` FOREIGN KEY (`TlfNr`) REFERENCES `personer` (`TlfNr`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utsjekk`
--

LOCK TABLES `utsjekk` WRITE;
/*!40000 ALTER TABLE `utsjekk` DISABLE KEYS */;
INSERT INTO `utsjekk` VALUES (1,90918019),(2,90918020),(3,90918021),(36,90918026),(37,90918027),(38,90918028);
/*!40000 ALTER TABLE `utsjekk` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-03 12:08:00
