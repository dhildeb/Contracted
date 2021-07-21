CREATE Table IF NOT Exists contractors(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT "Primary Key",
  name VARCHAR(255),
  expertise VARCHAR(255),
  rating int
) DEFAULT charset utf8 COMMENT '';
CREATE Table IF NOT Exists jobs(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT "Primary Key",
  title VARCHAR(255) NOT NULL,
  Description VARCHAR(255),
  available TINYINT,
  jobSize int DEFAULT 1,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) DEFAULT charset utf8 COMMENT '';
CREATE Table contractor_jobs(
  id int AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'Primary Key',
  bid int NOT NULL,
  jobId int NOT NULL COMMENT 'FK: Job',
  contractorId VARCHAR(255) NOT NULL COMMENT 'FK: contractor',
  FOREIGN KEY (contractorId) REFERENCES contractors(id) on DELETE CASCADE,
  FOREIGN KEY (jobId) REFERENCES jobs(id) ON DELETE CASCADE
) DEFAULT charset utf8 COMMENT '';
-- ALTER TABLE
--   jobs
-- ADD
--   COLUMN creatorId VARCHAR(255) NOT NULL;