SELECT * FROM dbo.Customers;
select FirstName, LastName from dbo.Customers
select * from dbo.Branches
select city from dbo.Branches
-- Distinct example: distinct cities for branches
SELECT DISTINCT City FROM dbo.Branches;
SELECT CustomerID, FirstName, LastName, DateOfBirth
FROM dbo.Customers
WHERE DateOfBirth > '1985-01-01'
ORDER BY LastName ASC;

SELECT TOP (1) AccountID, Balance
FROM dbo.Accounts
ORDER BY Balance DESC;
SELECT * FROM dbo.Accounts WHERE AccountType IN ('S','C');
-- BETWEEN
SELECT * FROM dbo.Accounts WHERE Balance BETWEEN 1000 AND 20000;
-- LIKE
SELECT * FROM dbo.Customers WHERE Email LIKE '%@example.com';

SELECT * FROM dbo.Customers
WHERE (FirstName = 'Amit' OR FirstName = 'Neha')
AND NOT Email IS NULL;
SELECT * FROM dbo.Customers
WHERE FirstName in( 'Amit','Neha')