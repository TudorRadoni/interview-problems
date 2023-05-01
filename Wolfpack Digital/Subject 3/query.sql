-- You're working on a project to build an e-commerce website. Design a
-- database schema that will support product inventory, orders, and customer
-- data.
-- Each product has a name, description, price, and quantity in stock. Customers
-- can create an account with a username, email, and password. Customers
-- can place orders for one or more products, and each order has a unique
-- order ID, customer ID, product ID, quantity, and total price. Take into
-- consideration that we want to store in the order the price of the product at the
-- time of the order (price of the products might change).
-- When creating an order, the user should be able to set the (one) billing & the
-- (one) shipping address (addresses should contain data about city, street &
-- postal code). A user can have multiple billing & multiple shipping addresses
-- to select from when creating the order.

USE master;
GO

IF DB_ID (N'ecommerce') IS NOT NULL
DROP DATABASE ecommerce;
GO
CREATE DATABASE ecommerce;
GO
USE ecommerce
GO

DROP TABLE IF EXISTS Product
CREATE TABLE Product (
    productID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(50) NOT NULL,
    description VARCHAR(500) NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    quantityInStock INT NOT NULL
)
GO

DROP TABLE IF EXISTS Customer
CREATE TABLE Customer (
    customerID INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
)
GO

DROP TABLE IF EXISTS Orders
CREATE TABLE Orders (
    orderID INT PRIMARY KEY IDENTITY(1,1),
    customerID INT NOT NULL,
    productID INT NOT NULL,
    quantity INT NOT NULL,
    totalPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID),
    FOREIGN KEY (productID) REFERENCES Product(productID)
)
GO

DROP TABLE IF EXISTS Addresses
CREATE TABLE Addresses (
    addressID INT PRIMARY KEY IDENTITY(1,1),
    customerID INT NOT NULL,
    city VARCHAR(50) NOT NULL,
    street VARCHAR(50) NOT NULL,
    postalCode VARCHAR(50) NOT NULL
    FOREIGN KEY (customerID) REFERENCES Customer(customerID)
)
GO
