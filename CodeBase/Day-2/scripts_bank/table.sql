create database DarkMattersDb
use DarkMattersDb
CREATE TABLE dbo.Branches (
BranchID INT IDENTITY(1,1) PRIMARY KEY,
BranchName NVARCHAR(100) NOT NULL,
City VARCHAR(50) NOT NULL,
IFSC CHAR(11) NOT NULL UNIQUE -- Unique constraint
);
-- Customers
CREATE TABLE dbo.Customers (
CustomerID INT IDENTITY(1,1) PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Email NVARCHAR(255) NULL UNIQUE, -- Unique email, allow NULL
DateOfBirth DATE NULL,
CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

-- Accounts
CREATE TABLE dbo.Accounts (
AccountID BIGINT IDENTITY(1000000000,1) PRIMARY KEY,
CustomerID INT NOT NULL,
BranchID INT NOT NULL,
AccountType CHAR(1) NOT NULL CHECK (AccountType IN ('S','C')), -- S = Savings, C = Current
Balance MONEY NOT NULL DEFAULT (0),
IsActive BIT NOT NULL DEFAULT (1),
OpenedOn DATE NOT NULL DEFAULT CONVERT(date, GETDATE()),
CONSTRAINT FK_Accounts_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID),
CONSTRAINT FK_Accounts_Branches FOREIGN KEY (BranchID) REFERENCES dbo.Branches(BranchID)
);
-- Transactions
CREATE TABLE dbo.Transactions (
TransactionID BIGINT IDENTITY(1,1) PRIMARY KEY,
AccountID BIGINT NOT NULL,
TranDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
Amount MONEY NOT NULL CHECK (Amount <> 0),
TranType CHAR(1) NOT NULL CHECK (TranType IN ('D','W','T')), -- D=Deposit, W=Withdrawal, T=Transfer
Description NVARCHAR(250) NULL,
RelatedAccountID BIGINT NULL, -- used for transfers
CONSTRAINT FK_Trans_Account FOREIGN KEY (AccountID) REFERENCES dbo.Accounts(AccountID)
);