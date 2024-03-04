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
  price DECIMAL(6,2),
  rating INT,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

