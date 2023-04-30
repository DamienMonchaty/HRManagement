--
-- Script SQL de la solution HRManagement
--
CREATE DATABASE IF NOT EXISTS hrmandb;
USE hrmandb;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` VALUES ('20230430060532_init','6.0.1');

--
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;

CREATE TABLE `addresses` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Street1` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Street2` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Street3` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ZipCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `City` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `addresses`
--

INSERT INTO `addresses` VALUES 
('B22699V4-42A2-4666-9631-1C2D1E2QE4F7','nrYvHAOpYT1icobLTkQ4XQ==','UhTX5ZpJ4y2iv3Vcblzqvw==','UhTX5ZpJ4y2iv3Vcblzqvw==','jT5NXNJs3hNAgncxRV5IJg==','qWxdptf99V53m3HvJKwiyg=='),
('bad0d22e-8d15-4049-bf49-3a9f3e060ce2','WSHHPNBN6j1pMj+6PrluNg==','1GZv+K7HFjq3LdD4eRPN9w==','wSNtyP0YoYr3v8wQPYZNnQ==','jT5NXNJs3hNAgncxRV5IJg==','WSHHPNBN6j1pMj+6PrluNg=='),
('C44698B8-89A2-4115-9631-1C2D1E2AC5F7','YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=','UhTX5ZpJ4y2iv3Vcblzqvw==','UhTX5ZpJ4y2iv3Vcblzqvw==','fqv0JX8PgBMMSKadKO8wUA==','qWxdptf99V53m3HvJKwiyg=='),
('D55699V4-42A2-4666-9631-1C2D1E2QE4F7','N8SZmdEorA16bD1D14eQgA==','UhTX5ZpJ4y2iv3Vcblzqvw==','UhTX5ZpJ4y2iv3Vcblzqvw==','jT5NXNJs3hNAgncxRV5IJg==','qWxdptf99V53m3HvJKwiyg=='),
('E66698B8-89A2-4115-9631-1C2D1E2AC5F7','4nL/FfFSsPNEECz4eSRT8ENay+dNU7kUoTZxBrlniPE=','UhTX5ZpJ4y2iv3Vcblzqvw==','UhTX5ZpJ4y2iv3Vcblzqvw==','fqv0JX8PgBMMSKadKO8wUA==','cC5WEXQrlF8DxQZ5INUEcQ==');

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` VALUES 
('2301D884-221A-4E7D-B509-0113DCC043E1','Administrator','ADMINISTRATOR','a006bf27-38be-4e17-b0bd-c91f2af6382f'),
('7D9B7113-A8F8-4035-99A7-A20DD400F6A3','Employe','EMPLOYE','9207c289-664f-4b88-abb6-4c0373ef2d68');
--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;

CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NatCardNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecCardNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BirthDate` date NOT NULL,
  `BirthPlace` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BirthCountry` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Nationality` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NetSalary` float NOT NULL,
  `BrutSalary` float NOT NULL,
  `PositionEnum` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `AddressId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_AspNetUsers_AddressId` (`AddressId`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  CONSTRAINT `FK_AspNetUsers_Addresses_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `addresses` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` VALUES 
('78948ead-1ab7-4098-a826-a954fb8f6efe','4yHITpa2iNUA2Xf60JCENw==','4yHITpa2iNUA2Xf60JCENw==','oR8GJdUHcsI84UB7UmRu+w==','Rl8MzdASQ52Y3pEsFh05eQ==','1986-08-06','WSHHPNBN6j1pMj+6PrluNg==','4+MztYqq5KqPz14rcrB5Kw==',NULL,2250,3000,'DEVELOPER','bad0d22e-8d15-4049-bf49-3a9f3e060ce2','damienmonchaty@hotmail.fr','DAMIENMONCHATY@HOTMAIL.FR','damienmonchaty@hotmail.fr','DAMIENMONCHATY@HOTMAIL.FR',1,'AQAAAAEAACcQAAAAEGNPRUMV+GrlnHHeh9QpBxm3pwKUQttCslwsJqlwaF9KkRai8e5ISwWMZZvXYNWBrw==','3RFTGMKGHIFFZ75RR6ZGJW5J2GRNO7AM','ef9a1afc-3aef-43d9-997b-b1f15311b180',NULL,0,0,NULL,1,0),
('B22698B8-42A2-4115-9631-1C2D1E2AC5F7','lPfqw/4To4cUqkFXmjr99A==','RKni2nEve0sgoL7KKwYx5A==','/Jd2bzeOttDTlAepi7Vj7Q==','HarYCrqDtXq0aGL4Euy0Zw==','1996-01-31','jLy3HqDCK0+/NECBgw3iQA==','JQA8CV5rxSF0/Hp6+X36Ww==','/JPYnJI6bQjl6aZqqg748Q==',0,0,'MANAGER','B22699V4-42A2-4666-9631-1C2D1E2QE4F7','Admin1','ADMIN1@ADMIN.FR','admin1@admin.fr','ADMIN1@ADMIN.FR',1,'AQAAAAEAACcQAAAAEJvgCy9V7F7mEs4LmNiA7nq/E45QPnegwMMmXxTJ4R04sIzq19PMKKYK1tnPgduWSA==','ae9838c6-005a-42c7-8065-bed127257fd1','f34b92b4-1737-4979-97d1-84c00ff54d39',NULL,1,0,NULL,0,0),
('C55678B8-4209-4115-9631-1CE51E2AC5F7','lPfqw/4To4cUqkFXmjr99A==','RKni2nEve0sgoL7KKwYx5A==','/D2ZmG3Ut4D7HZnQ4LIC3A==','9KxG3ftafKogzxBycgaaqw==','1975-05-21','g+PoCWm3amX+lswFWV8cAA==','JQA8CV5rxSF0/Hp6+X36Ww==','/JPYnJI6bQjl6aZqqg748Q==',0,0,'MANAGER','E66698B8-89A2-4115-9631-1C2D1E2AC5F7','Emp4','EMP4@EMP.FR','emp4@emp.fr','EMP4@EMP.FR',1,'AQAAAAEAACcQAAAAEAX8F3GUbwm5XPRfgWmSYpJtY6i6vVkJqUfcTzPYBCVPZjSwIPWAwY4hPTW9/HqxsA==','c5868439-f469-479f-a87c-b9208974e126','344a55c2-3dba-4864-9059-3a3e026a213b',NULL,1,0,NULL,0,0),
('E22678B8-42A2-4115-9631-1CE51E2AC5F7','lPfqw/4To4cUqkFXmjr99A==','RKni2nEve0sgoL7KKwYx5A==','X+XAHEIv6iQhza/ISyly4w==','RsGU0ra9qNyUFez5reZDig==','1986-10-11','jLy3HqDCK0+/NECBgw3iQA==','JQA8CV5rxSF0/Hp6+X36Ww==','/JPYnJI6bQjl6aZqqg748Q==',0,0,'MANAGER','C44698B8-89A2-4115-9631-1C2D1E2AC5F7','Emp2','EMP2@EMP.FR','emp2@emp.fr','EMP2@EMP.FR',1,'AQAAAAEAACcQAAAAEFGT4o9ked7UlTsmZabzXvGKjbTd85Aon+beAdlcYA7+toWNFhkW2VUjMQyJkXB9oA==','4cbba3a2-f165-48f0-9d34-b087cbcd3d2c','194d1b8c-1ef0-4e19-b316-6b91db829232',NULL,1,0,NULL,0,0),
('F33678B8-4G62-4115-9631-1CE51E2AC5F7','lPfqw/4To4cUqkFXmjr99A==','RKni2nEve0sgoL7KKwYx5A==','XPm7I7D6QN8s2mq8hyy/sg==','RsGU0ra9qNyUFez5reZDig==','1990-12-31','ScRQbVozn+lzAJOs41qD0g==','JQA8CV5rxSF0/Hp6+X36Ww==','/JPYnJI6bQjl6aZqqg748Q==',0,0,'MANAGER','D55699V4-42A2-4666-9631-1C2D1E2QE4F7','Emp3','EMP3@EMP.FR','emp3@emp.fr','EMP3@EMP.FR',1,'AQAAAAEAACcQAAAAEKlnC3ZA0d6CEV1i4FNNsa6iUL7WECIqWqZU2X7Xw6owUuGwrwN3Z2KAS0mg+bhRSg==','2a01b31a-55d2-4a4c-a556-4fafb63cbb95','e56da7e8-04e9-44a1-8e51-3e7bf32f6fe9',NULL,1,0,NULL,0,0);

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;

CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` VALUES 
('B22698B8-42A2-4115-9631-1C2D1E2AC5F7','2301D884-221A-4E7D-B509-0113DCC043E1'),
('78948ead-1ab7-4098-a826-a954fb8f6efe','7D9B7113-A8F8-4035-99A7-A20DD400F6A3'),
('E22678B8-42A2-4115-9631-1CE51E2AC5F7','7D9B7113-A8F8-4035-99A7-A20DD400F6A3');

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;

CREATE TABLE `clients` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` VALUES 
('B22699V4-42A2-4666-9631-1D9D1E2QE4F7','CLIENT1','DESC CLIENT1'),
('C4469D48-89A2-3615-9631-1C2D1E2AC/&7','CLIENT2','DESC CLIENT2');

--
-- Table structure for table `diplomas`
--

DROP TABLE IF EXISTS `diplomas`;

CREATE TABLE `diplomas` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Libelle` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Diplomas_UserId` (`UserId`),
  CONSTRAINT `FK_Diplomas_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `diplomas`
--

INSERT INTO `diplomas` VALUES 
('B123V455-42A2-3456-9631-1DHZSE2QE4F7','E7HAk0sSrG5MNlEhSSXbxg==','2017-01-12','2015-05-21','E22678B8-42A2-4115-9631-1CE51E2AC5F7'),
('C4469D48-89A2-3615-9631-1C2D1E2AC2&7','FE4M/Q+DQs2gVsq8mNFgZb2mENKClUVBSW1T8OM6MHw=','2011-05-04','2009-05-21','E22678B8-42A2-4115-9631-1CE51E2AC5F7'),
('C4H83D48-89A2-3615-9631-1C2DAL0AC9&7','ktJ4K+MXoJcFcwftaKi7Wg==','2016-05-31','2013-03-11','B22698B8-42A2-4115-9631-1C2D1E2AC5F7'),
('ea3457d0-c6ae-4830-99bf-be613af843ab','7HOy1gJMAzCecWkHYAFCsw==','2012-10-06','2010-10-06','78948ead-1ab7-4098-a826-a954fb8f6efe');

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;

CREATE TABLE `projects` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Libelle` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `ProjectEnum` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ClientId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Projects_ClientId` (`ClientId`),
  CONSTRAINT `FK_Projects_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `projects`
--

INSERT INTO `projects` VALUES 
('54d7fcb6-3212-4e2f-abeb-aad04b970b29','Projet Reseaux','Mise en place arcihtecture reseaux','2022-12-31','2023-12-31','EN_COURS','C4469D48-89A2-3615-9631-1C2D1E2AC/&7'),
('8a3b19bd-034d-402a-a585-075df0416577','Projet Gestion Reseaux Sociaux','Audience Linkedin, fb, instagram','2023-05-07','2023-10-08','EN_PREPARATION','C4469D48-89A2-3615-9631-1C2D1E2AC/&7'),
('912e1b44-ae47-4166-82c5-5384d4e8db73','Projet C#','Back-end','2023-04-29','2023-07-23','EN_COURS','C4469D48-89A2-3615-9631-1C2D1E2AC/&7'),
('ab4a41d0-130a-4189-85f5-6fee90a8c6ae','Projet web','Conception Site Web','2022-12-31','2023-12-31','EN_PREPARATION','B22699V4-42A2-4666-9631-1D9D1E2QE4F7'),
('dce51217-6642-4572-b006-1617946efe80','Projet Web 2','NodeJS','2023-09-10','2024-07-28','EN_PREPARATION','B22699V4-42A2-4666-9631-1D9D1E2QE4F7'),
('f144bfa5-4183-40da-a895-411071d25e00','Projet Angular','Front-End','2022-12-31','2023-12-31','EN_PREPARATION','B22699V4-42A2-4666-9631-1D9D1E2QE4F7');

--
-- Table structure for table `missions`
--

DROP TABLE IF EXISTS `missions`;

CREATE TABLE `missions` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MissionEnum` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ProjectId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Missions_ProjectId` (`ProjectId`),
  KEY `IX_Missions_UserId` (`UserId`),
  CONSTRAINT `FK_Missions_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `FK_Missions_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `missions`
--

INSERT INTO `missions` VALUES 
('f986f2db-34f8-46c5-807d-bf93ed4ad3cf','Sécurité','JWT','EN_PREPARATION','912e1b44-ae47-4166-82c5-5384d4e8db73','78948ead-1ab7-4098-a826-a954fb8f6efe');

--
-- Table structure for table `schools`
--

DROP TABLE IF EXISTS `schools`;

CREATE TABLE `schools` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Libelle` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Schools_UserId` (`UserId`),
  CONSTRAINT `FK_Schools_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `schools`
--

INSERT INTO `schools` VALUES 
('B123V455-42A2-3456-9631-1DHZSE2QE4F7','q8ieydXLnJMphy5L4wp76A==','2016-05-31','2013-03-11','E22678B8-42A2-4115-9631-1CE51E2AC5F7'),
('C4469D48-89A2-3615-9631-1C2D1E2AC2&7','Pet7i993BgS+uQZJeQYSVQ==','2016-05-31','2013-03-11','E22678B8-42A2-4115-9631-1CE51E2AC5F7'),
('C4H83D48-89A2-3615-9631-1C2DAL0AC9&7','b+8rJ0ACwlqFzv48DSeleVeJCjkXxP9RxmDOTM5cfLc=','2016-05-31','2013-03-11','B22698B8-42A2-4115-9631-1C2D1E2AC5F7'),
('c5ed7e44-ef11-4664-b29b-9fe3c2ce80b2','qpeGYaNnvi9XUzx0Pq+tLg==','2010-10-06','2012-10-06','78948ead-1ab7-4098-a826-a954fb8f6efe');

--
-- Table structure for table `userprojects`
--

DROP TABLE IF EXISTS `userprojects`;

CREATE TABLE `userprojects` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProjectId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`ProjectId`),
  KEY `IX_UserProjects_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_UserProjects_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserProjects_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `userprojects`
--

INSERT INTO `userprojects` VALUES 
('C55678B8-4209-4115-9631-1CE51E2AC5F7','54d7fcb6-3212-4e2f-abeb-aad04b970b29'),
('F33678B8-4G62-4115-9631-1CE51E2AC5F7','8a3b19bd-034d-402a-a585-075df0416577'),
('78948ead-1ab7-4098-a826-a954fb8f6efe','912e1b44-ae47-4166-82c5-5384d4e8db73'),
('C55678B8-4209-4115-9631-1CE51E2AC5F7','912e1b44-ae47-4166-82c5-5384d4e8db73'),
('78948ead-1ab7-4098-a826-a954fb8f6efe','ab4a41d0-130a-4189-85f5-6fee90a8c6ae'),
('C55678B8-4209-4115-9631-1CE51E2AC5F7','dce51217-6642-4572-b006-1617946efe80'),
('78948ead-1ab7-4098-a826-a954fb8f6efe','f144bfa5-4183-40da-a895-411071d25e00'),
('E22678B8-42A2-4115-9631-1CE51E2AC5F7','f144bfa5-4183-40da-a895-411071d25e00');

