SELECT a.AccountID, a.Balance
FROM dbo.Accounts a
WHERE a.BranchID = 
(SELECT TOP 1 BranchID FROM dbo.Accounts WHERE CustomerID = 1);

SELECT AccountID, CustomerID, Balance
FROM dbo.Accounts
WHERE CustomerID IN (SELECT CustomerID FROM dbo.Customers WHERE Email LIKE '%@example.com');