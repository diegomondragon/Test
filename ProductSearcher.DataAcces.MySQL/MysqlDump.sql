CREATE DATABASE  IF NOT EXISTS `ProductsDB` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ProductsDB`;
-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: localhost    Database: ProductsDB
-- ------------------------------------------------------
-- Server version	8.0.11

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
-- Table structure for table `Department`
--

DROP TABLE IF EXISTS `Department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Department` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Department`
--

LOCK TABLES `Department` WRITE;
/*!40000 ALTER TABLE `Department` DISABLE KEYS */;
INSERT INTO `Department` VALUES (1,'Produce'),(2,'Grocery'),(3,'Pharmacy');
/*!40000 ALTER TABLE `Department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Product`
--

DROP TABLE IF EXISTS `Product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` longtext,
  `LastSold` datetime(3) DEFAULT NULL,
  `ShelfLife` bigint(20) DEFAULT NULL,
  `DepartmentId` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `UnitId` int(11) DEFAULT NULL,
  `xFor` int(11) DEFAULT NULL,
  `Cost` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9000006 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Product`
--

LOCK TABLES `Product` WRITE;
/*!40000 ALTER TABLE `Product` DISABLE KEYS */;
INSERT INTO `Product` VALUES (113,'bread','2017-09-12 00:00:00.000',14,2,1.5,2,1,0.12),(1111,'cheese slices','2017-09-15 00:00:00.000',20,2,2.68,2,1,0.4),(1189,'hamburger buns','2017-09-13 00:00:00.000',14,2,1.75,2,1,0.14),(11122,'grapes','2017-09-10 00:00:00.000',7,1,4,1,1,1.2),(12221,'pasta sauce','2017-09-14 00:00:00.000',23,2,3.75,2,1,1),(18939,'sliced turkey','2017-09-16 00:00:00.000',20,2,3.29,2,1,0.67),(90879,'tortilla chips','2017-09-17 00:00:00.000',45,2,1.99,2,1,0.14),(95175,'Strawberry','2017-09-07 00:00:00.000',3,1,2.49,1,1,0.1),(119290,'cereal','2017-09-18 00:00:00.000',40,2,3.19,2,1,0.19),(124872,'Lettuce','2017-09-11 00:00:00.000',5,1,0.79,1,1,0.1),(321654,'apples','2017-09-06 00:00:00.000',7,1,1.49,1,1,0.2),(321753,'onion','2017-09-08 00:00:00.000',9,1,1,2,1,0.05),(753542,'banana','2017-09-05 00:00:00.000',4,1,2.99,1,1,0.44),(987654,'Tomato','2017-09-09 00:00:00.000',4,1,2.35,1,1,0.2),(4629464,'canned vegtables','2017-09-19 00:00:00.000',200,2,1.89,2,1,0.19),(9000001,'headache medicine','2017-09-20 00:00:00.000',365,3,4.89,2,1,1.9),(9000002,'Migraine Medicine','2017-09-21 00:00:00.000',365,3,5.89,2,1,1.9),(9000003,'Cold and Flu','2017-09-22 00:00:00.000',365,3,3.29,2,1,1.9),(9000004,'Allegry Medicine','2017-09-23 00:00:00.000',365,3,3,2,1,1.25),(9000005,'Pain','2017-09-24 00:00:00.000',365,3,2.89,2,1,1);
/*!40000 ALTER TABLE `Product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Unit`
--

DROP TABLE IF EXISTS `Unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Unit` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Unit`
--

LOCK TABLES `Unit` WRITE;
/*!40000 ALTER TABLE `Unit` DISABLE KEYS */;
INSERT INTO `Unit` VALUES (1,'Lb'),(2,'Each');
/*!40000 ALTER TABLE `Unit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-07 15:45:09
