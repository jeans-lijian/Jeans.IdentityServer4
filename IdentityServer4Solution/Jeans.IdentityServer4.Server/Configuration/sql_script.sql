-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 10.227.201.150    Database: lijian_ids4
-- ------------------------------------------------------
-- Server version	5.6.37-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `apiresources`
--

DROP TABLE IF EXISTS `apiresources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `apiresources` (
  `Id` char(36) NOT NULL,
  `Enabled` bit(1) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `DisplayName` varchar(200) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `AllowedAccessTokenSigningAlgorithms` varchar(100) DEFAULT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) DEFAULT NULL,
  `LastAccessed` datetime(6) DEFAULT NULL,
  `NonEditable` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apiresources`
--

LOCK TABLES `apiresources` WRITE;
/*!40000 ALTER TABLE `apiresources` DISABLE KEYS */;
INSERT INTO `apiresources` VALUES ('51D4EE0C-4D33-4013-B337-FBF1E73DF2A9',_binary '','user_api','用户API','管理用户信息',NULL,'2020-03-24 15:31:09.000000',NULL,NULL,_binary '\0');
/*!40000 ALTER TABLE `apiresources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `apiscopes`
--

DROP TABLE IF EXISTS `apiscopes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `apiscopes` (
  `Id` char(36) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `DisplayName` varchar(200) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Required` bit(1) NOT NULL,
  `Emphasize` bit(1) NOT NULL,
  `ShowInDiscoveryDocument` bit(1) NOT NULL,
  `ApiResourceId` char(36) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_apiscopes_ApiResourceId` (`ApiResourceId`),
  CONSTRAINT `FK_apiscopes_apiresources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `apiresources` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apiscopes`
--

LOCK TABLES `apiscopes` WRITE;
/*!40000 ALTER TABLE `apiscopes` DISABLE KEYS */;
INSERT INTO `apiscopes` VALUES ('9FF1D6DF-4BD2-4F5A-BC69-289DA7BB5D9C','user_api.write',NULL,NULL,_binary '\0',_binary '\0',_binary '','51D4EE0C-4D33-4013-B337-FBF1E73DF2A9'),('BC71EE5A-0883-4AB9-93F0-6BA8CBFDAE76','user_api.full_sccess',NULL,NULL,_binary '\0',_binary '\0',_binary '','51D4EE0C-4D33-4013-B337-FBF1E73DF2A9'),('DEE0B704-701A-46CE-86F7-6C269C748BE5','user_api.read_only',NULL,NULL,_binary '\0',_binary '\0',_binary '','51D4EE0C-4D33-4013-B337-FBF1E73DF2A9');
/*!40000 ALTER TABLE `apiscopes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `apisecrets`
--

DROP TABLE IF EXISTS `apisecrets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `apisecrets` (
  `Id` char(36) NOT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Value` longtext NOT NULL,
  `Expiration` datetime(6) DEFAULT NULL,
  `Type` varchar(250) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `ApiResourceId` char(36) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_apisecrets_ApiResourceId` (`ApiResourceId`),
  CONSTRAINT `FK_apisecrets_apiresources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `apiresources` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apisecrets`
--

LOCK TABLES `apisecrets` WRITE;
/*!40000 ALTER TABLE `apisecrets` DISABLE KEYS */;
/*!40000 ALTER TABLE `apisecrets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientgranttypes`
--

DROP TABLE IF EXISTS `clientgranttypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `clientgranttypes` (
  `Id` char(36) NOT NULL,
  `GrantType` varchar(250) NOT NULL,
  `ClientId` char(36) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_clientgranttypes_ClientId` (`ClientId`),
  CONSTRAINT `FK_clientgranttypes_clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientgranttypes`
--

LOCK TABLES `clientgranttypes` WRITE;
/*!40000 ALTER TABLE `clientgranttypes` DISABLE KEYS */;
INSERT INTO `clientgranttypes` VALUES ('14B42D61-E96D-4155-B242-279F07E58094','client_credentials','F67A807D-6BBD-430E-AC7F-D3BE3B87DA2D'),('458750FE-03B6-4180-B0EB-6F0AB7FAF9EE','password','92E99339-BE1B-4DCB-946E-C81726E19C93');
/*!40000 ALTER TABLE `clientgranttypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `clients` (
  `Id` char(36) NOT NULL,
  `Enabled` bit(1) NOT NULL,
  `ClientId` varchar(200) NOT NULL,
  `ProtocolType` varchar(200) NOT NULL,
  `RequireClientSecret` bit(1) NOT NULL,
  `ClientName` varchar(200) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `ClientUri` varchar(2000) DEFAULT NULL,
  `LogoUri` varchar(2000) DEFAULT NULL,
  `RequireConsent` bit(1) NOT NULL,
  `AllowRememberConsent` bit(1) NOT NULL,
  `AlwaysIncludeUserClaimsInIdToken` bit(1) NOT NULL,
  `RequirePkce` bit(1) NOT NULL,
  `AllowPlainTextPkce` bit(1) NOT NULL,
  `AllowAccessTokensViaBrowser` bit(1) NOT NULL,
  `FrontChannelLogoutUri` varchar(2000) DEFAULT NULL,
  `FrontChannelLogoutSessionRequired` bit(1) NOT NULL,
  `BackChannelLogoutUri` varchar(2000) DEFAULT NULL,
  `BackChannelLogoutSessionRequired` bit(1) NOT NULL,
  `AllowOfflineAccess` bit(1) NOT NULL,
  `IdentityTokenLifetime` int(11) NOT NULL,
  `AllowedIdentityTokenSigningAlgorithms` varchar(100) DEFAULT NULL,
  `AccessTokenLifetime` int(11) NOT NULL,
  `AuthorizationCodeLifetime` int(11) NOT NULL,
  `ConsentLifetime` int(11) DEFAULT NULL,
  `AbsoluteRefreshTokenLifetime` int(11) NOT NULL,
  `SlidingRefreshTokenLifetime` int(11) NOT NULL,
  `RefreshTokenUsage` int(11) NOT NULL,
  `UpdateAccessTokenClaimsOnRefresh` bit(1) NOT NULL,
  `RefreshTokenExpiration` int(11) NOT NULL,
  `AccessTokenType` int(11) NOT NULL,
  `EnableLocalLogin` bit(1) NOT NULL,
  `IncludeJwtId` bit(1) NOT NULL,
  `AlwaysSendClientClaims` bit(1) NOT NULL,
  `ClientClaimsPrefix` varchar(200) DEFAULT NULL,
  `PairWiseSubjectSalt` varchar(200) DEFAULT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) DEFAULT NULL,
  `LastAccessed` datetime(6) DEFAULT NULL,
  `UserSsoLifetime` int(11) DEFAULT NULL,
  `UserCodeType` varchar(100) DEFAULT NULL,
  `DeviceCodeLifetime` int(11) NOT NULL,
  `NonEditable` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES ('92E99339-BE1B-4DCB-946E-C81726E19C93',_binary '','api.client','oidc',_binary '',NULL,NULL,NULL,NULL,_binary '',_binary '',_binary '\0',_binary '',_binary '\0',_binary '\0',NULL,_binary '',NULL,_binary '',_binary '\0',300,NULL,3600,300,NULL,2592000,1296000,1,_binary '\0',1,0,_binary '',_binary '\0',_binary '\0','client_',NULL,'2020-03-24 16:53:14.000000',NULL,NULL,NULL,NULL,300,_binary '\0'),('F67A807D-6BBD-430E-AC7F-D3BE3B87DA2D',_binary '','service.client','oidc',_binary '',NULL,NULL,NULL,NULL,_binary '',_binary '',_binary '\0',_binary '',_binary '\0',_binary '\0',NULL,_binary '',NULL,_binary '',_binary '\0',300,NULL,3600,300,NULL,2592000,1296000,1,_binary '\0',1,0,_binary '',_binary '\0',_binary '\0','client_',NULL,'2020-03-24 16:53:14.000000',NULL,NULL,NULL,NULL,300,_binary '\0');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientscopes`
--

DROP TABLE IF EXISTS `clientscopes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `clientscopes` (
  `Id` char(36) NOT NULL,
  `Scope` varchar(200) NOT NULL,
  `ClientId` char(36) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_clientscopes_ClientId` (`ClientId`),
  CONSTRAINT `FK_clientscopes_clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientscopes`
--

LOCK TABLES `clientscopes` WRITE;
/*!40000 ALTER TABLE `clientscopes` DISABLE KEYS */;
INSERT INTO `clientscopes` VALUES ('7DA3D584-1C92-41A4-BD63-75DC330559AD','user_api.write','92E99339-BE1B-4DCB-946E-C81726E19C93'),('81DA5D1F-A4A8-4001-9DFF-F3A82F091D21','user_api.read_only','92E99339-BE1B-4DCB-946E-C81726E19C93'),('D55A15E3-7BA6-49B0-A93B-E822CCFB8876','user_api.read_only','F67A807D-6BBD-430E-AC7F-D3BE3B87DA2D'),('EF75BA20-378B-43EB-9FFE-36C946BB05F7','user_api.full_sccess','92E99339-BE1B-4DCB-946E-C81726E19C93');
/*!40000 ALTER TABLE `clientscopes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientsecrets`
--

DROP TABLE IF EXISTS `clientsecrets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `clientsecrets` (
  `Id` char(36) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `Value` longtext NOT NULL,
  `Expiration` datetime(6) DEFAULT NULL,
  `Type` varchar(250) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `ClientId` char(36) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_clientsecrets_ClientId` (`ClientId`),
  CONSTRAINT `FK_clientsecrets_clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientsecrets`
--

LOCK TABLES `clientsecrets` WRITE;
/*!40000 ALTER TABLE `clientsecrets` DISABLE KEYS */;
INSERT INTO `clientsecrets` VALUES ('DFB71EDF-5154-4B4C-B27E-87C0DA8056F3',NULL,'secret',NULL,'SharedSecret','2020-03-24 16:55:30.000000','92E99339-BE1B-4DCB-946E-C81726E19C93');
/*!40000 ALTER TABLE `clientsecrets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identityresources`
--

DROP TABLE IF EXISTS `identityresources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `identityresources` (
  `Id` char(36) NOT NULL,
  `Enabled` bit(1) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `DisplayName` varchar(200) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Required` bit(1) NOT NULL,
  `Emphasize` bit(1) NOT NULL,
  `ShowInDiscoveryDocument` bit(1) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) DEFAULT NULL,
  `NonEditable` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identityresources`
--

LOCK TABLES `identityresources` WRITE;
/*!40000 ALTER TABLE `identityresources` DISABLE KEYS */;
/*!40000 ALTER TABLE `identityresources` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-24 17:33:03
