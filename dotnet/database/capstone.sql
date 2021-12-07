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
	property_address nvarchar (100) NOT NULL,
	property_name nvarchar(25) NULL,
	property_isAvailable bit NOT NULL, 
	property_beds int NOT NULL,
	property_baths int NOT NULL,
	property_size int NOT NULL,
	property_owner int NOT NULL,
	CONSTRAINT PK_property PRIMARY KEY (property_id),
	CONSTRAINT FK_property_owner_users_user_id FOREIGN KEY (property_owner)REFERENCES users(user_id)
)
-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
GO



INSERT INTO properties (property_address, property_name, property_beds,  property_baths, property_isAvailable, property_size, property_owner) VALUES 
('2498 Hickory Pine Ln','House1',3, 1,1, 1598, 1);
INSERT INTO properties (property_address, property_name, property_beds,  property_baths, property_isAvailable, property_size, property_owner) VALUES 
('2907 N High St','House2', 4, 2, 1, 2000, 1);
INSERT INTO properties (property_address, property_name, property_beds,  property_baths, property_isAvailable, property_size, property_owner) VALUES 
('2312 Far Away Dr','House3', 1, 1, 1, 2500, 1);
INSERT INTO properties (property_address, property_name, property_beds,  property_baths, property_isAvailable, property_size, property_owner) VALUES 
('3746 Somewhere Close','House4',3,1,0, 1598, 1);


SELECT * FROM properties

