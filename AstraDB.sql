-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: astra
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alergias`
--

DROP TABLE IF EXISTS `alergias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alergias` (
  `IdAlergia` int NOT NULL AUTO_INCREMENT,
  `IdPaciente` int NOT NULL,
  `Alergia` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdAlergia`),
  KEY `idx_alergias_paciente` (`IdPaciente`),
  CONSTRAINT `FK_Alergias_Pacientes` FOREIGN KEY (`IdPaciente`) REFERENCES `pacientes` (`IdPaciente`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alergias`
--

LOCK TABLES `alergias` WRITE;
/*!40000 ALTER TABLE `alergias` DISABLE KEYS */;
/*!40000 ALTER TABLE `alergias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctores`
--

DROP TABLE IF EXISTS `doctores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(100) NOT NULL,
  `Contraseña` varchar(255) NOT NULL,
  `Doctor` varchar(50) DEFAULT NULL,
  `IdPaciente` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UK_Doctor_Usuario` (`Usuario`),
  KEY `FK_Doctores_Pacientes` (`IdPaciente`),
  CONSTRAINT `FK_Doctores_Pacientes` FOREIGN KEY (`IdPaciente`) REFERENCES `pacientes` (`IdPaciente`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctores`
--

LOCK TABLES `doctores` WRITE;
/*!40000 ALTER TABLE `doctores` DISABLE KEYS */;
INSERT INTO `doctores` VALUES (1,'Admin','admin','Angel Villa',NULL),(2,'Ricarte','1234','Ricarte',NULL),(3,'daniel','25200614','daniel',NULL);
/*!40000 ALTER TABLE `doctores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expediente`
--

DROP TABLE IF EXISTS `expediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expediente` (
  `IdExpediente` int NOT NULL AUTO_INCREMENT,
  `Expediente` varchar(100) DEFAULT NULL,
  `IdPaciente` int NOT NULL,
  PRIMARY KEY (`IdExpediente`),
  KEY `idx_expediente_paciente` (`IdPaciente`),
  CONSTRAINT `FK_Expediente_Pacientes` FOREIGN KEY (`IdPaciente`) REFERENCES `pacientes` (`IdPaciente`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expediente`
--

LOCK TABLES `expediente` WRITE;
/*!40000 ALTER TABLE `expediente` DISABLE KEYS */;
/*!40000 ALTER TABLE `expediente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pacientes`
--

DROP TABLE IF EXISTS `pacientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pacientes` (
  `IdPaciente` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Edad` int DEFAULT NULL,
  `Altura` float DEFAULT NULL,
  `Peso` float DEFAULT NULL,
  `Proxima_cita_Fecha` datetime DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  PRIMARY KEY (`IdPaciente`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pacientes`
--

LOCK TABLES `pacientes` WRITE;
/*!40000 ALTER TABLE `pacientes` DISABLE KEYS */;
INSERT INTO `pacientes` VALUES (3,'Ambar','Ronquillo',19,1.51,70,NULL,NULL),(5,'María','Gómez',27,1.62,60,NULL,NULL),(6,'Carlos','López',54,1.8,90,NULL,NULL),(7,'Sofía','Martínez',41,1.68,65,NULL,NULL);
/*!40000 ALTER TABLE `pacientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `padecimientos`
--

DROP TABLE IF EXISTS `padecimientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `padecimientos` (
  `IdPadecimiento` int NOT NULL AUTO_INCREMENT,
  `IdPaciente` int NOT NULL,
  `Padecimiento` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdPadecimiento`),
  KEY `idx_padecimientos_paciente` (`IdPaciente`),
  CONSTRAINT `FK_Padecimientos_Pacientes` FOREIGN KEY (`IdPaciente`) REFERENCES `pacientes` (`IdPaciente`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `padecimientos`
--

LOCK TABLES `padecimientos` WRITE;
/*!40000 ALTER TABLE `padecimientos` DISABLE KEYS */;
/*!40000 ALTER TABLE `padecimientos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-30 23:23:30
