CREATE FUNCTION dbo.ufn_GetCustomerFullName(@CustomerID INT)
RETURNS NVARCHAR(101)
AS
BEGIN
DECLARE @name NVARCHAR(101);
SELECT @name = CONCAT(FirstName,' ',LastName) FROM dbo.Customers WHERE CustomerID = @CustomerID;
RETURN @name;
END;
GO
-- Usage
SELECT dbo.ufn_GetCustomerFullName(1) AS FullName;
SELECT dbo.ufn_GetCustomerFullName(CustomerID) as FllName from dbo.Customers

CREATE FUNCTION dbo.ufn_GetAccountsByBranch(@BranchID INT)
RETURNS TABLE
AS
RETURN
(
SELECT AccountID, CustomerID, Balance
FROM dbo.Accounts
WHERE BranchID = @BranchID
);
GO
-- Usage
SELECT * FROM dbo.ufn_GetAccountsByBranch(1);