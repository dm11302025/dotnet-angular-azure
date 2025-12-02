ALTER TABLE Customers ADD PhoneNumber NVARCHAR(15);
SELECT * from Customers
ALTER TABLE Customers DROP COLUMN PhoneNumber;
EXEC sp_rename 'Customers.FullName', 'CustomerName', 'COLUMN';