IF EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = 'inventory'
)
BEGIN
    ALTER DATABASE inventory SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE IF EXISTS inventory;
END;

CREATE DATABASE inventory;
USE inventory;

DROP TABLE IF EXISTS barcode;
DROP TABLE IF EXISTS item;
DROP TABLE IF EXISTS category;

CREATE TABLE category(
	c_id INT IDENTITY(1,1) PRIMARY KEY,
	c_name VARCHAR(20) unique NOT NULL
);

CREATE TABLE item(
	item_id INT identity(1,1) PRIMARY KEY,
	item_name VARCHAR(30) NOT NULL,
	desc_item VARCHAR(75),
	company_name VARCHAR(20),
	category_id INT FOREIGN KEY references category(c_id) NOT NULL ,
	price NUMERIC(18,2) NOT NULL
);

CREATE TABLE barcode (
    barcode_id INT PRIMARY KEY identity(1,1),
    item_id INT FOREIGN KEY REFERENCES item(item_id) NOT NULL,
    barcode VARBINARY(MAX),
    quantity INT NOT NULL DEFAULT 0 CHECK(quantity >= 0),
);