Create Table Stores (
	LocationID INT NOT NULL Identity Primary Key,
	City NVARCHAR(60) NOT NULL,
	State NVARCHAR(60) NOT NULL,
	)

Create Table Customers (
	CustomerID INT NOT NULL Identity Primary Key,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
)

Create Table Inventory (
	InventoryID INT NOT NULL Identity Primary Key,
	Title NVARCHAR(80) NOT NULL,
	Rating NVARCHAR(6) NOT NULL,
	Details NVARCHAR(200) NOT NULL,
	Price Money NOT NULL,
	Stock INT NOT NULL,
	LocationID INT NOT NULL Foreign Key References Stores(LocationID)
)

Create Table Orders (
	OrderID INT NOT NULL Identity Primary Key,
	CustomerID INT NOT NULL Foreign Key References Customers(CustomerID),
	InventoryID INT NOT NULL Foreign Key References Inventory(InventoryID),
	LocationID INT NOT NULL Foreign Key References Stores(LocationID),
	Date Datetime2 NOT NULL
)
