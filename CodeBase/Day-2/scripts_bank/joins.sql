SELECT a.AccountID, a.Balance, a.AccountType, c.FirstName, c.LastName
FROM dbo.Accounts a
INNER JOIN dbo.Customers c ON a.CustomerID = c.CustomerID;
--Left OuterJoin
SELECT c.CustomerID, c.FirstName, c.LastName, a.AccountID, a.Balance
FROM dbo.Customers c
LEFT JOIN dbo.Accounts a ON c.CustomerID = a.CustomerID;
select * from dbo.Customers
select * from dbo.Accounts
--right join
SELECT a.AccountID, a.Balance, b.BranchName
FROM dbo.Accounts a
RIGHT JOIN dbo.Branches b ON a.BranchID = b.BranchID;

SELECT c1.CustomerID AS Cust1, c1.FirstName, c2.CustomerID AS Cust2, c2.FirstName
FROM dbo.Customers c1
INNER JOIN dbo.Customers c2 ON c1.LastName = c2.LastName AND c1.CustomerID <> c2.CustomerID;