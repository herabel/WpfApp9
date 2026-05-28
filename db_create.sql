CREATE DATABASE [ShopDB];
GO
USE [ShopDB];
GO

CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Units (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(20) NOT NULL
);

CREATE TABLE Suppliers (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL
);

CREATE TABLE Manufacturers (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL
);

CREATE TABLE Categories (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE PickupPoints (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Address NVARCHAR(255) NOT NULL
);

CREATE TABLE Statuses (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Users (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Login NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role_ID INT NOT NULL,
    FOREIGN KEY (Role_ID) REFERENCES Roles(ID)
);

CREATE TABLE Products (
    Article NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Discount INT DEFAULT 0,
    StockQuantity INT NOT NULL,
    Description NVARCHAR(MAX),
    Photo NVARCHAR(255),
    Unit_ID INT NOT NULL,
    Supplier_ID INT NOT NULL,
    Manufacturer_ID INT NOT NULL,
    Category_ID INT NOT NULL,
    FOREIGN KEY (Unit_ID) REFERENCES Units(ID),
    FOREIGN KEY (Supplier_ID) REFERENCES Suppliers(ID),
    FOREIGN KEY (Manufacturer_ID) REFERENCES Manufacturers(ID),
    FOREIGN KEY (Category_ID) REFERENCES Categories(ID)
);

CREATE TABLE Orders (
    ID INT IDENTITY(1,1) PRIMARY KEY, 
    OrderDate DATE NOT NULL,
    DeliveryDate DATE NOT NULL,
    ReceiveCode INT NOT NULL,
    Point_ID INT NOT NULL,
    User_ID INT NOT NULL,
    Status_ID INT NOT NULL,
    FOREIGN KEY (Point_ID) REFERENCES PickupPoints(ID),
    FOREIGN KEY (User_ID) REFERENCES Users(ID),
    FOREIGN KEY (Status_ID) REFERENCES Statuses(ID)
);

CREATE TABLE OrderItems (
    Order_ID INT NOT NULL,
    Product_Article NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    PRIMARY KEY (Order_ID, Product_Article),
    FOREIGN KEY (Order_ID) REFERENCES Orders(ID),
    FOREIGN KEY (Product_Article) REFERENCES Products(Article) ON UPDATE CASCADE
);