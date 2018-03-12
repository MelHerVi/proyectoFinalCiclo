CREATE DATABASE  IF NOT EXISTS `proyecto_melchorherrera_gestiondocumental` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `proyecto_melchorherrera_gestiondocumental`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: proyecto_melchorherrera_gestiondocumental
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
-- Table structure for table `centroeducativo`
--

DROP TABLE IF EXISTS `centroeducativo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `centroeducativo` (
  `id_centroEducativo` int(12) NOT NULL AUTO_INCREMENT,
  `nombre_director` varchar(20) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `CIF` varchar(12) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `fax` int(12) DEFAULT NULL,
  `cp` int(7) DEFAULT NULL,
  `nombreCentro` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`id_centroEducativo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `centroeducativo`
--

LOCK TABLES `centroeducativo` WRITE;
/*!40000 ALTER TABLE `centroeducativo` DISABLE KEYS */;
INSERT INTO `centroeducativo` VALUES (1,'Mel','Carrer Enric Valor','48581287C','961206280',934152051,46960,'IES Henri Matisse'),(2,'Héctor','Av. Vicent Mortes','52631498P','961205940',934150088,46590,'IES Peset Aleixandre'),(3,'Reda','Carrer Sant LLuis Beltrán','84220365W','961365540',934152051,54630,'La Salle');
/*!40000 ALTER TABLE `centroeducativo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `centrotrabajo`
--

DROP TABLE IF EXISTS `centrotrabajo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `centrotrabajo` (
  `id_centroTrabajo` int(12) NOT NULL AUTO_INCREMENT,
  `id_empresa` int(12) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `nombreCentro` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_centroTrabajo`),
  KEY `id_empresa` (`id_empresa`),
  CONSTRAINT `centrotrabajo_ibfk_1` FOREIGN KEY (`id_empresa`) REFERENCES `empresa` (`id_empresa`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `centrotrabajo`
--

LOCK TABLES `centrotrabajo` WRITE;
/*!40000 ALTER TABLE `centrotrabajo` DISABLE KEYS */;
INSERT INTO `centrotrabajo` VALUES (1,1,'C/ Prueba','620398555','Software Lab'),(2,2,'C/ Test','623005154','Redes'),(3,3,'C/ Pruebesita','695366978','Sistemas'),(4,1,'C/ El buen testeo','663299547','Software Dev'),(5,2,'Avd. muy larga','636955878','Develop Lab'),(6,3,'Carretera vieja','654565456','I + D'),(7,1,'C/ El buen proyecto','632548153','Software Lab'),(8,1,'Avd. El buen juego de unity','696369636','Redes'),(9,1,'C/ Los buenos hilos','654123025','Sistemas');
/*!40000 ALTER TABLE `centrotrabajo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentos`
--

DROP TABLE IF EXISTS `documentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documentos` (
  `id_documento` int(12) NOT NULL AUTO_INCREMENT,
  `id_centroEducativo` int(12) DEFAULT NULL,
  `id_empresa` int(12) DEFAULT NULL,
  `num_concierto` int(12) NOT NULL,
  `fecha_firma` date NOT NULL,
  `rutaDocumento` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id_documento`),
  KEY `id_centroEducativo` (`id_centroEducativo`),
  KEY `id_empresa` (`id_empresa`),
  CONSTRAINT `documentos_ibfk_1` FOREIGN KEY (`id_centroEducativo`) REFERENCES `centroeducativo` (`id_centroEducativo`),
  CONSTRAINT `documentos_ibfk_2` FOREIGN KEY (`id_empresa`) REFERENCES `empresa` (`id_empresa`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentos`
--

LOCK TABLES `documentos` WRITE;
/*!40000 ALTER TABLE `documentos` DISABLE KEYS */;
INSERT INTO `documentos` VALUES (1,1,2,11111,'2018-01-20',NULL),(2,2,2,22222,'2016-03-10',NULL),(3,1,3,23232,'2015-05-20',NULL),(4,3,3,33333,'2018-01-01',NULL),(5,2,3,11223,'2017-05-06',NULL),(6,1,1,22331,'2017-11-11',NULL),(16,1,2,22333,'2017-11-11',NULL),(17,2,3,11122,'2017-12-12',NULL),(18,1,1,22112,'2017-02-03',NULL),(19,3,2,44444,'2017-05-04',NULL),(20,3,1,44433,'2017-07-09',NULL),(21,2,2,44221,'2017-01-10',NULL),(22,2,1,55555,'2017-02-01',NULL),(23,2,3,55551,'2017-03-01',NULL),(24,1,3,52521,'2017-04-01',NULL),(25,1,3,55441,'2018-01-05',NULL),(26,1,3,66611,'2017-06-04',NULL),(27,2,2,11134,'2017-07-04',NULL),(28,3,3,45678,'2017-08-04',NULL),(29,1,1,97654,'2017-09-04',NULL),(30,1,2,56738,'2017-10-04',NULL),(31,1,2,91823,'2017-05-04',NULL),(32,3,1,73681,'2017-12-04',NULL),(33,3,2,98745,'2017-11-04',NULL),(34,3,3,19831,'2017-12-04',NULL),(35,1,1,11134,'2017-02-04',NULL);
/*!40000 ALTER TABLE `documentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empresa` (
  `id_empresa` int(12) NOT NULL AUTO_INCREMENT,
  `razon_social` varchar(20) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `CIF` varchar(12) DEFAULT NULL,
  `localidad` varchar(40) DEFAULT NULL,
  `provincia` varchar(40) DEFAULT NULL,
  `fax` int(12) DEFAULT NULL,
  `cp` int(7) DEFAULT NULL,
  `id_responsable` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_empresa`),
  KEY `id_responsable_idx` (`id_responsable`),
  CONSTRAINT `id_responsable` FOREIGN KEY (`id_responsable`) REFERENCES `responsable` (`id_Responsable`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (1,'Indra SL','C/ Mora de Rubielos','620382868','A00000000','Aldaya','Valencia',960451853,46960,9),(2,'Walhalla SA','C/ Gustave Eiffel','612036999','A00003333','Alaquas','Valencia',960452114,46970,10),(3,'Ahora Freeware SL','C/ Los Ceramistas','615899456','A00001111','Paterna','Valencia',960452224,46980,11);
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisos`
--

DROP TABLE IF EXISTS `permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisos` (
  `id_permiso` int(12) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id_permiso`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisos`
--

LOCK TABLES `permisos` WRITE;
/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
INSERT INTO `permisos` VALUES (1,'Administrador'),(2,'Personal');
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `responsable` (
  `id_Responsable` int(12) NOT NULL AUTO_INCREMENT,
  `DNI` varchar(10) DEFAULT NULL,
  `nombre` varchar(20) DEFAULT NULL,
  `apellidos` varchar(30) DEFAULT NULL,
  `correo` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_Responsable`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `responsable`
--

LOCK TABLES `responsable` WRITE;
/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
INSERT INTO `responsable` VALUES (9,'48581287C','Mel','Herrera Vicente','pro_melos@hotmail.com'),(10,'56961236W','Reda','Bousba Botswana','eskiusmi_kedizes@gmail.com'),(11,'45200131C','Héctor','Noparo Destudiar','quebien_eh@hotmail.com');
/*!40000 ALTER TABLE `responsable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rol` (
  `id_rol` int(12) NOT NULL AUTO_INCREMENT,
  `tipoRol` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador'),(2,'Profesor');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolpermisos`
--

DROP TABLE IF EXISTS `rolpermisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolpermisos` (
  `id_permiso` int(11) NOT NULL,
  `id_rol` int(11) NOT NULL,
  PRIMARY KEY (`id_permiso`,`id_rol`),
  KEY `id_rol` (`id_rol`),
  CONSTRAINT `rolpermisos_ibfk_1` FOREIGN KEY (`id_permiso`) REFERENCES `permisos` (`id_permiso`),
  CONSTRAINT `rolpermisos_ibfk_2` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolpermisos`
--

LOCK TABLES `rolpermisos` WRITE;
/*!40000 ALTER TABLE `rolpermisos` DISABLE KEYS */;
INSERT INTO `rolpermisos` VALUES (1,1),(2,2);
/*!40000 ALTER TABLE `rolpermisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `id_usuario` int(12) NOT NULL AUTO_INCREMENT,
  `id_rol` int(12) DEFAULT NULL,
  `id_centroEducativo` int(12) DEFAULT NULL,
  `observaciones` varchar(100) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `apellido1` varchar(45) DEFAULT NULL,
  `apellido2` varchar(45) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `fecha_baja` date DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `id_rol` (`id_rol`),
  KEY `id_centroEducativo` (`id_centroEducativo`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`),
  CONSTRAINT `usuarios_ibfk_2` FOREIGN KEY (`id_centroEducativo`) REFERENCES `centroeducativo` (`id_centroEducativo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,1,1,'El CEO','admin','admin','Jefesito','Gonzalez','Gonzalez','2014-01-01',NULL),(2,2,1,'Profesora de AD','Esther','Esther','Esther','Aguado','Jajaja','2000-07-25',NULL),(3,1,2,'Profesor de SI','Paco','Paco','Paco','Herrera','Jojojo','2015-01-05','2016-05-09'),(4,1,1,'Profesor de PSP','David','David','David','Ramada','Jujuju','2000-04-30',NULL),(5,2,2,'Profesor de DI','Jeronimo','Jeronimo','Jerónimo','Valero','Jijiji','2005-11-12',NULL),(6,1,3,'Profesora de SGE','Monica','Monica','Mónica','Esteve','Jajaja','2014-05-08',NULL),(7,1,3,'Profesor de PDM','Jorge','Jorge','Jorge','López','Jejeje','2015-09-04',NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-08 12:56:59
