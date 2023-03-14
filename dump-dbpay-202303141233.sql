-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: dbpay
-- ------------------------------------------------------
-- Server version	5.5.5-10.9.1-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accounts` (
  `id` binary(16) NOT NULL,
  `name` varchar(100) NOT NULL,
  `organization_id` binary(16) NOT NULL,
  `account_id` binary(16) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `modification_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `account_organization_FK` (`organization_id`),
  KEY `account_FK` (`account_id`),
  CONSTRAINT `accounts_FK` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`),
  CONSTRAINT `accounts_organization_FK` FOREIGN KEY (`organization_id`) REFERENCES `organizations` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `concepts`
--

DROP TABLE IF EXISTS `concepts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `concepts` (
  `id` binary(16) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `concepts`
--

LOCK TABLES `concepts` WRITE;
/*!40000 ALTER TABLE `concepts` DISABLE KEYS */;
/*!40000 ALTER TABLE `concepts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `incomes`
--

DROP TABLE IF EXISTS `incomes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `incomes` (
  `id` binary(16) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `movement_id` binary(16) DEFAULT NULL,
  `concept_id` binary(1) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `income_movement_FK` (`movement_id`),
  KEY `income_concept_FK` (`concept_id`),
  CONSTRAINT `incomes_FK` FOREIGN KEY (`movement_id`) REFERENCES `movements` (`id`),
  CONSTRAINT `incomes_concepts_FK` FOREIGN KEY (`concept_id`) REFERENCES `concepts` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incomes`
--

LOCK TABLES `incomes` WRITE;
/*!40000 ALTER TABLE `incomes` DISABLE KEYS */;
/*!40000 ALTER TABLE `incomes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movements`
--

DROP TABLE IF EXISTS `movements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movements` (
  `id` binary(16) NOT NULL,
  `account_id` binary(16) NOT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `movements_FK` (`account_id`),
  CONSTRAINT `movements_FK` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movements`
--

LOCK TABLES `movements` WRITE;
/*!40000 ALTER TABLE `movements` DISABLE KEYS */;
/*!40000 ALTER TABLE `movements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizations`
--

DROP TABLE IF EXISTS `organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizations` (
  `id` binary(16) NOT NULL,
  `organization_id` binary(16) DEFAULT NULL,
  `name` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `modification_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `organization_FK` (`organization_id`),
  CONSTRAINT `organizations_FK` FOREIGN KEY (`organization_id`) REFERENCES `organizations` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizations`
--

LOCK TABLES `organizations` WRITE;
/*!40000 ALTER TABLE `organizations` DISABLE KEYS */;
/*!40000 ALTER TABLE `organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizations_concepts`
--

DROP TABLE IF EXISTS `organizations_concepts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizations_concepts` (
  `id` binary(16) NOT NULL,
  `concept_id` binary(16) NOT NULL,
  `organization_id` binary(16) NOT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `modification_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `concept_organization_FK` (`concept_id`),
  KEY `organization_concept_FK_1` (`organization_id`),
  CONSTRAINT `organizations_concepts_FK` FOREIGN KEY (`organization_id`) REFERENCES `organizations` (`id`),
  CONSTRAINT `organizations_concepts_FK_1` FOREIGN KEY (`concept_id`) REFERENCES `concepts` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizations_concepts`
--

LOCK TABLES `organizations_concepts` WRITE;
/*!40000 ALTER TABLE `organizations_concepts` DISABLE KEYS */;
/*!40000 ALTER TABLE `organizations_concepts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `outcomes`
--

DROP TABLE IF EXISTS `outcomes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `outcomes` (
  `id` binary(16) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `creation_date` datetime NOT NULL,
  `concept_id` binary(16) DEFAULT NULL,
  `movement_id` binary(16) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `outcome_movement_FK` (`movement_id`),
  KEY `outcome_concept_FK_1` (`concept_id`),
  CONSTRAINT `outcomes_FK` FOREIGN KEY (`movement_id`) REFERENCES `movements` (`id`),
  CONSTRAINT `outcomes_FK_1` FOREIGN KEY (`concept_id`) REFERENCES `concepts` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `outcomes`
--

LOCK TABLES `outcomes` WRITE;
/*!40000 ALTER TABLE `outcomes` DISABLE KEYS */;
/*!40000 ALTER TABLE `outcomes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'dbpay'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-14 12:33:45
