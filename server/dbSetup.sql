CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE stockParts(
  id INT AUTO_INCREMENT PRIMARY KEY,
  productImage VARCHAR(500) NOT NULL,
  type VARCHAR(10) NOT NULL,
  size VARCHAR(50),
  price DECIMAL(8,2) NOT NULL,
  name VARCHAR(70) NOT NULL,
  company VARCHAR(60) NOT NULL,
  speed VARCHAR(50),
  gigs VARCHAR(20),
  powerScore INT NOT NULL
) default charset utf8 COMMENT '';

CREATE TABLE pcBuilds(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  powerScore INT,
  rating DECIMAL(5,2),
  price DECIMAL(6,2),
  isPrivate BOOLEAN,
  pcCase VARCHAR(70),
  casePicture VARCHAR(500),
  pcCpu VARCHAR(70),
  gpu VARCHAR(70),
  motherBoard VARCHAR(70),
  ram VARCHAR(70),
  pcStorage VARCHAR(70),
  powerSupply VARCHAR(70),
  cooler VARCHAR(70),
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE buildParts(
  id INT AUTO_INCREMENT PRIMARY KEY,
  buildId int NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  partId int NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (partId) REFERENCES stockParts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE cartItems(
  id INT AUTO_INCREMENT PRIMARY KEY,
  buildId int NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (buildId) REFERENCES pcBuilds(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE saveBuild(
  id INT AUTO_INCREMENT PRIMARY KEY,
  buildId int NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (buildId) REFERENCES pcBuilds(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE supportTickets(
  id INT AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  customerName VARCHAR(80),
  customerEmail VARCHAR(80),
  issueSubject VARCHAR(100),
  issueDescription VARCHAR(500),
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

ALTER TABLE supportTickets
ADD COLUMN ticketStatus VARCHAR(50)
AFTER issueDescription;


