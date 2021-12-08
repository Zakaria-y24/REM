USE master
GO

-- Drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

-- Create Tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE properties(
	property_id int IDENTITY (1000,1) NOT NULL,
	property_street nvarchar (100) NOT NULL,
	property_city nvarchar (15) NOT NULL,
	property_state nvarchar (12) NOT NULL,
	property_zipcode int NOT NULL,
	property_name nvarchar(25) NULL,
	property_beds int NOT NULL,
	property_baths int NOT NULL,
	property_size int NOT NULL,
	property_owner int NOT NULL,
	property_isAvailable bit NOT NULL,
	CONSTRAINT PK_property PRIMARY KEY (property_id),
	CONSTRAINT FK_property_owner_users_user_id FOREIGN KEY (property_owner)REFERENCES users(user_id)
)
CREATE TABLE applicants(
applicant_id int IDENTITY (1,1) NOT NULL,
applicant_name nvarchar(25) NOT NULL,
applicant_social_hash nvarchar(20)  NOT NULL,
applicant_address nvarchar(50) NOT NULL,
applicant_hasPets bit NOT NULL,
applicant_salary decimal NOT NULL,
applicant_phone nvarchar(15),
applicant_property int NOT NULL,
CONSTRAINT PK_applicant PRIMARY KEY (applicant_id),
CONSTRAINT FK_applicant_property_properties_property_id FOREIGN KEY(applicant_property) REFERENCES properties(property_id)
)
-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
GO


SELECT property_id, property_street,property_city,property_state,property_zipcode, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable FROM properties 

INSERT INTO properties (property_street,property_city,property_state,property_zipcode, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable) VALUES 
('2498 Hickory Pine Ln','Columbus','Georgia',31801,'House1',3,2, 1598, 1, 1);
INSERT INTO properties (property_street,property_city,property_state,property_zipcode, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable) VALUES 
('2907 N High St','Columbus','Ohio',43225,'House2', 4, 2, 2000, 1, 1);
INSERT INTO properties (property_street,property_city,property_state,property_zipcode, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable) VALUES 
('2312 Far Away Dr','Honolulu','Hawaii',96795,'House3', 1, 1, 2500, 1, 1);
INSERT INTO properties (property_street,property_city,property_state,property_zipcode, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable) VALUES 
('3746 Somewhere Close','Westerville','Ohio',43081,'House4',3,2, 1598, 1, 1);
SELECT * from properties

